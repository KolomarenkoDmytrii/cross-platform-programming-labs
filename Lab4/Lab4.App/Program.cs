using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using Lab4.Labs;

namespace Lab4.App {
    [Command(Name = "run-labs", Description = "Run lab works"),
     Subcommand(typeof(Run))]
    class RunLabs {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<RunLabs>(args);

        // [Option(Description = "Lab work to run")]
        // public string Lab { get; }

        [Option(ShortName = "I", Description = "Input file")]
        public string Input { get; } = "INPUT.TXT";

        [Option(ShortName = "o", Description = "Output file")]
        public string Output { get; } = "OUTPUT.TXT";

        private int OnExecute(CommandLineApplication app, IConsole console) {
            console.WriteLine("You must specify at a subcommand.");
            app.ShowHelp();
            return 1;
        }

        // private void OnExecute() {
        //     // const string labToRun = "lab3";
        //     // const string inputFilePath = "lab3_input.txt";
        //     // const string outputFilePath = "lab3_output.txt";
        //     string labToRun = Lab;
        //     string inputFilePath = Input;
        //     string outputFilePath = Output;
        //
        //     if (labToRun == "lab1") {
        //         Lab1.WriteAnswer(inputFilePath, outputFilePath);
        //     }
        //     else if (labToRun == "lab2") {
        //         Lab2.WriteAnswer(inputFilePath, outputFilePath);
        //     }
        //     else if (labToRun == "lab3") {
        //         Lab3.WriteAnswer(inputFilePath, outputFilePath);
        //     }
        //
        //     Console.WriteLine("Hello");
        //     Console.WriteLine(Lab1.IsDnaSequence("AGCT"));
        // }

        [Command("run", Description = "Run a specified lab work"),
         Subcommand(typeof(RunLab1)),
         Subcommand(typeof(RunLab2)),
         Subcommand(typeof(RunLab3))]
        private class Run {
            private int OnExecute(IConsole console)
            {
                console.Error.WriteLine("You must specify a lab work to run. See --help for more details.");
                return 1;
            }



            [Command("lab3", Description = "Run the lab work 3"),
             HelpOption,
             Subcommand(typeof(SetPath))]
            private class RunLab3 {
                [Option(ShortName = "I", Description = "Input file")]
                public string Input { get; } = "INPUT.TXT";

                [Option(ShortName = "o", Description = "Output file")]
                public string Output { get; } = "OUTPUT.TXT";

                private void OnExecute()
                {
                    try
                    {
                        Lab3.WriteAnswer(Input, Output);
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine($"An error occured: {exception}");
                    }
                }

                [Command("set-path", Description = "Run the lab work 3"), HelpOption]
                private class SetPath {
                    [Option("-p|--path", Description = "Input and output files directory")]
                    public string ResultPath { get; set; }

                    private void OnExecute()
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(ResultPath)) {
                                ResultPath = Environment.GetFolderPath(
                                    Environment.SpecialFolder.UserProfile
                                );
                            }
                            Lab3.WriteAnswer(
                                Path.Join(ResultPath, "INPUT.TXT"), Path.Join(ResultPath, "OUTPUT.TXT")
                            );
                        }
                        catch (Exception exception)
                        {
                            Console.Error.WriteLine($"An error occured: {exception}");
                        }
                    }
                }
            }
        }
    }
}
