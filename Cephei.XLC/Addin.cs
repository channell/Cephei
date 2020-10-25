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
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "d5a8ffc9-329b-4341-bfff-0069e30bcfa0";
            configuration.ConnectionString = "InstrumentationKey=d5a8ffc9-329b-4341-bfff-0069e30bcfa0;IngestionEndpoint=https://uksouth-0.in.applicationinsights.azure.com/";
            _telemetry = new TelemetryClient(configuration);

            var cfg = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.ApplicationInsights(configuration, TelemetryConverter.Events)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProcessId()
                .Enrich.FromLogContext();

            Log.Logger = cfg.CreateLogger();

            _modelListener = Model.getState().Model.Subscribe(this);
            
            _email = UserPrincipal.Current.EmailAddress;
            var version = Assembly.GetExecutingAssembly().GetName().Version;

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
                    var m = String.Format("CALC {0}", p.Name);
                    Log.Information(m);
                }
                else
                {
                    var m = String.Format("CALC {0}", t.Name);
                    Log.Information(m);
                }
            }
        }
    }
}

