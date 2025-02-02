using CustomsRiskEngineRPNToInfixNotation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsRiskEngineRPNToInfixNotation.Interfaces
{
    public interface IRPNConverterService
    {
        string ConvertToInfix(RPNExpression rpnExpression);
    }
}
