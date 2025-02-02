using CustomsRiskEngineRPNToInfixNotation.Interfaces;
using CustomsRiskEngineRPNToInfixNotation.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
            var stack = new Stack<string>(rpnExpression.Expression.Length / 2);
            var reader = new StringReader(rpnExpression.Expression);
            var tokenBuilder = new StringBuilder();
            int ch;

            while ((ch = reader.Read()) != -1)
            {
                if (char.IsWhiteSpace((char)ch))
                {
                    if (tokenBuilder.Length > 0)
                    {
                        ProcessToken(stack, tokenBuilder.ToString());
                        tokenBuilder.Clear();
                    }
                }
                else
                {
                    tokenBuilder.Append((char)ch);
                }
            }

            if (tokenBuilder.Length > 0)
            {
                ProcessToken(stack, tokenBuilder.ToString());
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Invalid RPN expression: too many operands or insufficient operators.");
            }

            return stack.Pop();
        }

        private void ProcessToken(Stack<string> stack, string token)
        {
            if (_operators.Contains(token))
            {
                if (stack.Count < 2)
                {
                    throw new InvalidOperationException("Invalid RPN expression: insufficient operands for operator.");
                }

                var operand2 = stack.Pop();
                var operand1 = stack.Pop();
                var infixExpression = new StringBuilder()
                    .Append('(')
                    .Append(operand1)
                    .Append(' ')
                    .Append(token)
                    .Append(' ')
                    .Append(operand2)
                    .Append(')')
                    .ToString();
                stack.Push(infixExpression);
            }
            else
            {
                stack.Push(token);
            }
        }
    }
}
