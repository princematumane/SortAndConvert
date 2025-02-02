using CustomsRiskEngineRPNToInfixNotation.Core;
using CustomsRiskEngineRPNToInfixNotation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsRiskEngineRPNToInfixNotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rpnConverter = new RPNConverterService();
            var _converter = new RpnToInfixConverter(rpnConverter);

            do
            {
                Console.WriteLine("Enter Reverse Polish Notation (RPN) expression:");
                var rpnExpression = Console.ReadLine();

                try
                {
                    var infixExpression = _converter.Execute(rpnExpression);
                    Console.WriteLine($"Infix Notation: {infixExpression}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }


                Console.WriteLine("Do you want to continue? Press any key to continue, or 'q' to quit.");
                var userChoice = Console.ReadKey().KeyChar.ToString().ToLower();

                if (userChoice == "q")
                    break;

                Console.WriteLine();

            } while (true);
        }
    }
}
