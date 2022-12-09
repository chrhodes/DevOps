using System;
using System.CommandLine;
using System.Xml;

namespace ConsoleApp2
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("Sample app for learning Docker");

            var loop = true;

            rootCommand.SetHandler(() =>
            {
                Console.WriteLine("Enter two numbers.  Any non-numeric value exits");

                while (loop)
                {
                    int number1;
                    int number2;

                    Console.Write("Enter First Number: ");
                    var input1 = Console.ReadLine();

                    if (!int.TryParse(input1, out number1) )
                    {
                        Console.Error.WriteLine($"Cannot parse {input1} as number");
                        loop = false;
                    }
                    else
                    {
                        Console.Write("Enter Second Number: ");
                        var input2 = Console.ReadLine();

                        if (!int.TryParse(input2, out number2))
                        {
                            Console.Error.WriteLine($"Cannot parse {input2} as number");
                            loop = false;
                        }
                        else
                        {
                            var result = number1 + number2;

                            Console.WriteLine($"{number1} + {number2} = {result}");
                        }

                        if (!loop)
                        {
                            Console.WriteLine("Exiting");
                        }
                    }
                }
            });

            return await rootCommand.InvokeAsync(args);
        }
    }
}