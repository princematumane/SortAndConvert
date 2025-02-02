using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsRiskEngineRPNToInfixNotation.Model
{
    public class RPNExpression
    {
        public string Expression { get; }

        public RPNExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Expression cannot be null or empty.", nameof(expression));
            }

            Expression = expression;
        }
    }
}
