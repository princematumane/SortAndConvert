using CustomsRiskEngineRPNToInfixNotation.Interfaces;
using CustomsRiskEngineRPNToInfixNotation.Model;
using CustomsRiskEngineRPNToInfixNotation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsRiskEngineRPNToInfixNotation.Core
{
    public class RpnToInfixConverter
    {
        private readonly IRPNConverterService _rpnConverterService;

        public RpnToInfixConverter(IRPNConverterService rpnConverterService)
        {
            _rpnConverterService = rpnConverterService;
        }

        public string Execute(string rpnExpression)
        {
            var expression = new RPNExpression(rpnExpression);
            return _rpnConverterService.ConvertToInfix(expression);
        }
    }
}
