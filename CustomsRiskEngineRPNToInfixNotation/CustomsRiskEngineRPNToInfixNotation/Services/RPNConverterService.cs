using CustomsRiskEngineRPNToInfixNotation.Interfaces;
using CustomsRiskEngineRPNToInfixNotation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsRiskEngineRPNToInfixNotation.Services
{
    public class RPNConverterService : IRPNConverterService
    {
        private readonly HashSet<string> _operators = new HashSet<string> { "+", "-", "*", "/", "^" };

        public string ConvertToInfix(RPNExpression rpnExpression)
        {
            var stack = new Stack<string>();
            var tokens = rpnExpression.Expression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (_operators.Contains(token))
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Invalid RPN expression: insufficient operands for operator.");
                    }

                    var operand2 = stack.Pop();
                    var operand1 = stack.Pop();
                    var infixExpression = $"({operand1} {token} {operand2})";
                    stack.Push(infixExpression);
                }
                else
                {
                    stack.Push(token);
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Invalid RPN expression: too many operands or insufficient operators.");
            }

            return stack.Pop();
        }
    }
}
