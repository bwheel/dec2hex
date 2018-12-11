using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace dec2hex
{
    class Program
    {
        private static string PROGRAM_NAME = Assembly.GetExecutingAssembly().GetName().Name;
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].Equals("help") || 
                    args[0].Equals("--help") ||
                    args[0].Equals("-h"))
                    {
                        PrintUsage();
                    }
                else
                {
                    dec2hex(args, " ");
                }
            }
            else
            {
                if (Console.In.Peek() > 0)
                {
                    string input = Console.In.ReadToEnd();
                    dec2hex(input.Split(' '), " ");
                }
                else
                {
                    PrintUsage();
                }
            }
        }

        private static void PrintUsage()
        {
            Console.Out.WriteLine(
$@"{PROGRAM_NAME} [numbers] 
or
echo '[numbers]' | {PROGRAM_NAME}");
        }

        private static void dec2hex(IEnumerable<string> elements, string separator)
        {
                foreach (var element in elements)
                {
                    if(int.TryParse(element.Trim(), out int num ))
                    {
                        Console.Out.Write("0x{0:x2}", num);
                    }
                    Console.Out.Write(separator);
                    
                }
        }
    }
}
