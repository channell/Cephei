using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDna.Integration;
using ExcelDna.Integration.Rtd;
using ExcelDna.Integration.CustomUI;
using Cephei.XL;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.Formatters;
using Cephei.Cell;
using System.IO;
using QLNet;

namespace Cephei.XL
{
    [ComVisible(true)]
    public class Addin : ExcelDna.Integration.IExcelAddIn, IObserver<ICell>
    {
        private TelemetryClient _telemetry;
        private IDisposable _modelListener;
        private string _email;
        public void AutoClose()
        {
            Log.Information("CLOSE {0}", _email);
            Log.CloseAndFlush();
            _telemetry.Flush();
        }

        public void AutoOpen()
        {
            var logfile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CepheiXL\\logs.json");
#if DEBUG
            var cfg = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.RollingFile((new Serilog.Formatting.Json.JsonFormatter()), logfile)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProcessId()
                .Enrich.FromLogContext();

            Log.Logger = cfg.CreateLogger();
#else
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "d5a8ffc9-329b-4341-bfff-0069e30bcfa0";
            configuration.ConnectionString = "InstrumentationKey=d5a8ffc9-329b-4341-bfff-0069e30bcfa0;IngestionEndpoint=https://uksouth-0.in.applicationinsights.azure.com/";
            _telemetry = new TelemetryClient(configuration);

            var cfg = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.ApplicationInsights(configuration, TelemetryConverter.Events)
                .WriteTo.RollingFile((new Serilog.Formatting.Json.JsonFormatter()), logfile)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProcessId()
                .Enrich.FromLogContext();

            Log.Logger = cfg.CreateLogger();
#endif
            _modelListener = Model.getState().Model.Subscribe(this);
            Cell.Cell.Parellel = false;
            
            _email = UserPrincipal.Current.EmailAddress;
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            LoadModels();

            Log.Information("OPEN {1} {0}", _email, version);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            Log.Error("ERROR {0} {1}", _email, error.Message);
        }

        public void OnNext(ICell value)
        {
            if (value.Mnemonic != "Clock")
            {
                var t = value.GetType();
                if (t.IsGenericType)
                {
                    var p = t.GenericTypeArguments[0];
                    if (p.IsClass)
                    {
                        var m = String.Format("CALC {0}", p.Name);
                        Log.Information(m);
                    }
                }
                else
                {
                    if (t.IsClass)
                    {
                        var m = String.Format("CALC {0}", t.Name);
                        Log.Information(m);
                    }
                }
            }
        }

        /// <summary>
        /// Load user models
        /// </summary>
        private void LoadModels ()
        {
            var dir = ExcelDnaUtil.XllPath;
            dir = dir.Substring(0, dir.LastIndexOf('\\'));
            foreach (var f in Directory.EnumerateFiles(dir))
            {
                if (f.ToLower().EndsWith("model.dll"))
                {
                    var methods = new System.Collections.Generic.List<MethodInfo>();
                    var ass = Assembly.LoadFile(f);
                    foreach (var ty in ass.GetTypes())
                    {
                        foreach (var me in ty.GetMethods())
                        {
                            foreach (var att in me.GetCustomAttributes())
                            {
                                if (att.GetType().Name == "ExcelFunction")
                                {
                                    methods.Add(me);
                                    break;
                                }
                            }
                        }
                    }
                    ExcelIntegration.RegisterMethods(methods);
                }
            }
        }
    }
}

