using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Gen
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("syntax error");
                return;
            }

            var pam = new Queue<string>(args);

            string rootpackage = pam.Dequeue();
            string outputDirectory = pam.Dequeue();

            while (pam.Count > 0)
            {
                string cmd = pam.Dequeue();

                switch (cmd)
                {
                    case "-ql":
                        var version = pam.Dequeue();
                        var qlcmd = new QL.Control(rootpackage, "Cephei.QL" + version, outputDirectory + "\\Cephei.QL" + version);
                        Status("Generating QL interfaces");
                        Console.WriteLine(qlcmd.TransformText());
                        break;

                    case "-impl":
                        version = pam.Dequeue();
                        var impcmd = new QL.Impl.Control(rootpackage, "Cephei.QL" + version + ".impl", outputDirectory + "\\Cephei.QL" + version + ".impl");
                        Status("Generating QL implementation");
                        Console.WriteLine(impcmd.TransformText());
                        break;

                    case "-data":
                        version = pam.Dequeue();
                        var datacmd = new Data.Control(rootpackage, "Cephei.Data" + version, outputDirectory + "\\Cephei.Data" + version);
                        Status("Generating Data layer");
                        Console.WriteLine(datacmd.TransformText());
                        break;

                    case "-xl":
                        version = pam.Dequeue();
                        var xlcmd = new XL.Control(rootpackage, "Cephei.XL" + version, outputDirectory + "\\Cephei.XL" + version);
                        Status("Generating XL interface");
                        Console.WriteLine(xlcmd.TransformText());
                        break;

                    case "-fun":
                        var ver = pam.Dequeue();
                        var funcmd = new Fun.FunFactory(rootpackage, ver);
                        Status("Generating Fun interface");
                        var code = funcmd.TransformText();
                        System.IO.File.WriteAllText(outputDirectory + "\\Cephei.Fun" + ver + "\\Cephei.fs", code);
                        Console.WriteLine("Rendered Functional interfaces");
                        break;

                    case "-qlnet":
                        var netQL = new NetQL.Control(rootpackage, "Cephei.QL", outputDirectory);
                        Status("Generating QLNet interface");
                        Console.WriteLine(netQL.TransformText());
                        break;

                    case "-xlnet":
                        var netXL = new NetXL.Control(rootpackage, "Cephei.XL", outputDirectory);
                        Status("Generating QLNet interface");
                        Console.WriteLine(netXL.TransformText());
                        break;

                    case "-all":
                        version = pam.Dequeue();
                        qlcmd = new QL.Control(rootpackage, "Cephei.QL" + version, outputDirectory + "\\Gen\\Cephei.QL" + version);
                        impcmd = new QL.Impl.Control(rootpackage, "Cephei.QL" + version + ".impl" , outputDirectory + "\\Gen\\Cephei.QL" + version + ".impl");
                        datacmd = new Data.Control(rootpackage, "Cephei.Data" + version, outputDirectory + "\\Gen\\Cephei.Data" + version);
                        xlcmd = new XL.Control(rootpackage, "Cephei.XL" + version, outputDirectory + "\\gen\\Cephei.XL" + version );
                        Status("Generating QL interface");
                        Console.WriteLine(qlcmd.TransformText());
                        Status("Generating QL impl classes");
                        Console.WriteLine(impcmd.TransformText());
                        Status("Generating data classes");
                        Console.WriteLine(datacmd.TransformText());
                        Status("Generating XL classes");
                        Console.WriteLine(xlcmd.TransformText());
                        funcmd = new Fun.FunFactory(rootpackage, version);
                        code = funcmd.TransformText();
                        System.IO.File.WriteAllText(outputDirectory + "\\Cephei.Fun" + version + "\\Cephei.fs", code);
                        Console.WriteLine("Rendered Functional interfaces");
                        break;
                }
            }
            Status("Finished");
        }
        private static void Status(string msg)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("{0} {1}", DateTime.Now.ToShortTimeString(), msg);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");
        }
    }
}