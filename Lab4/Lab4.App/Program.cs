using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

using McMaster.Extensions.CommandLineUtils;
using DotNetEnv;

using Lab4.Labs;

namespace Lab4.App
{
    [Command(Name = "run-labs", Description = "Run lab works"),
     Subcommand(typeof(Run)),
     Subcommand(typeof(SetPath)),
     Subcommand(typeof(Version))]
    class RunLabs
    {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<RunLabs>(args);

        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("You must specify a subcommand.");
            app.ShowHelp();
            return 1;
        }

        [Command("run", Description = "Run a specified lab work"),
         Subcommand(typeof(RunLab1)),
         Subcommand(typeof(RunLab2)),
         Subcommand(typeof(RunLab3))]
        private class Run
        {
            private int OnExecute(IConsole console)
            {
                console.Error.WriteLine("You must specify a lab work to run. See --help for more details.");
                return 1;
            }

            [Command("lab1", Description = "Run the lab work 1"),
             HelpOption,
             Subcommand(typeof(SetPath))]
            private class RunLab1
            {
                [Option(ShortName = "I", Description = "Input file")]
                public string Input { get; }

                [Option(ShortName = "o", Description = "Output file")]
                public string Output { get; }

                private void OnExecute()
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(Input) && !string.IsNullOrEmpty(Output))
                        {
                            Lab1.WriteAnswer(Input, Output);
                        }
                        else
                        {
                            const string inputFile = "INPUT.TXT";
                            const string outputFile = "OUTPUT.TXT";

                            string dataDirectory = Environment.GetEnvironmentVariable("LAB_PATH");
                            if (string.IsNullOrEmpty(dataDirectory))
                            {
                                Env.Load(".env");
                                dataDirectory = Environment.GetEnvironmentVariable("LAB_PATH");

                                if (string.IsNullOrEmpty(dataDirectory))
                                    dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                            }

                            string inputPath = Path.Join(dataDirectory, inputFile);
                            string outputPath = Path.Join(dataDirectory, outputFile);
                            Lab1.WriteAnswer(inputPath, outputPath);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine($"An error occured: {exception}");
                    }
                }
            }

            [Command("lab2", Description = "Run the lab work 2"),
             HelpOption,
             Subcommand(typeof(SetPath))]
            private class RunLab2
            {
                [Option(ShortName = "I", Description = "Input file")]
                public string Input { get; }

                [Option(ShortName = "o", Description = "Output file")]
                public string Output { get; }

                private void OnExecute()
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(Input) && !string.IsNullOrEmpty(Output))
                        {
                            Lab2.WriteAnswer(Input, Output);
                        }
                        else
                        {
                            const string inputFile = "INPUT.TXT";
                            const string outputFile = "OUTPUT.TXT";

                            string dataDirectory = Environment.GetEnvironmentVariable("LAB_PATH");
                            if (string.IsNullOrEmpty(dataDirectory))
                            {
                                Env.Load(".env");
                                dataDirectory = Environment.GetEnvironmentVariable("LAB_PATH");

                                if (string.IsNullOrEmpty(dataDirectory))
                                    dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                            }

                            string inputPath = Path.Join(dataDirectory, inputFile);
                            string outputPath = Path.Join(dataDirectory, outputFile);
                            Lab2.WriteAnswer(inputPath, outputPath);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine($"An error occured: {exception}");
                    }
                }
            }

            [Command("lab3", Description = "Run the lab work 3"),
             HelpOption,
             Subcommand(typeof(SetPath))]
            private class RunLab3
            {
                [Option(ShortName = "I", Description = "Input file")]
                public string Input { get; }

                [Option(ShortName = "o", Description = "Output file")]
                public string Output { get; }

                private void OnExecute()
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(Input) && !string.IsNullOrEmpty(Output))
                        {
                            Lab3.WriteAnswer(Input, Output);
                        }
                        else
                        {
                            const string inputFile = "INPUT.TXT";
                            const string outputFile = "OUTPUT.TXT";

                            string dataDirectory = Environment.GetEnvironmentVariable("LAB_PATH");
                            if (string.IsNullOrEmpty(dataDirectory))
                            {
                                Env.Load(".env");
                                dataDirectory = Environment.GetEnvironmentVariable("LAB_PATH");

                                if (string.IsNullOrEmpty(dataDirectory))
                                    dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                            }

                            string inputPath = Path.Join(dataDirectory, inputFile);
                            string outputPath = Path.Join(dataDirectory, outputFile);
                            Lab3.WriteAnswer(inputPath, outputPath);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine(
                            $"An error occured: {exception}"
                        );
                    }
                }
            }
        }

        [Command("set-path",
         Description = "Set LAB_PATH environment value in .env file")]
        private class SetPath
        {
            [Option("-p|--path",
             Description = "Input and output files directory")]
            public string ResultPath { get; }

            private void OnExecute(IConsole console)
            {
                if (string.IsNullOrEmpty(ResultPath))
                    console.Error.WriteLine("Please specify path for input and output files directory.");
                else
                    File.AppendAllText(".env", $"LAB_PATH={ResultPath}");
            }
        }

        [Command("version",
         Description = "Output the command version and author")]
        private class Version
        {
            private void OnExecute(IConsole console)
            {
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

                console.WriteLine($"Version: {fileVersionInfo.FileVersion}");
                console.WriteLine($"Author: {fileVersionInfo.LegalCopyright}");
            }
        }
    }
}
