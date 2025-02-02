using CustomsRiskEngineRPNToInfixNotation.Model;
using CustomsRiskEngineRPNToInfixNotation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomsRiskEngineRPNToInfixNotationTests
{
    [TestClass]
    public class RpnToInfixConverterTest
    {
        private readonly RPNConverterService _converter;

        public RpnToInfixConverterTest()
        {
            _converter = new RPNConverterService();
        }

        [TestMethod]
        [DataRow("3 4 × 5 6 × +", "(3 × 4) + (5 × 6)")]
        [DataRow("12 34 + 1 2 + 3 4 + × ×", "((12 + 34) × ((1 + 2) × (3 + 4)))")]
        [DataRow("3 4 +", "(3 + 4)")]
        [DataRow("8 2 -", "(8 - 2)")]
        [DataRow("5 6 ×", "(5 × 6)")]
        [DataRow("10 2 /", "(10 / 2)")]
        [DataRow("2 3 ^", "(2 ^ 3)")]
        [DataRow("1 2 + 3 4 + ×", "(1 + 2) × (3 + 4)")]
        public void ConvertToInfix_ValidInput_ReturnsCorrectInfix(string rpn, string expectedInfix)
        {
            // Arrange
            var expression = new RPNExpression(rpn);

            // Act
            var result = _converter.ConvertToInfix(expression);

            // Assert
            Assert.AreEqual(expectedInfix, result);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("+")]
        [DataRow("4 +")]
        [DataRow("5 6 7 +")]
        public void ConvertToInfix_InvalidInput_ThrowsException(string rpn)
        {
            // Arrange
            var expression = new RPNExpression(rpn);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => _converter.ConvertToInfix(expression));
        }

        [TestMethod]
        public void ConvertToInfix_SimpleExpression_ReturnsCorrectResult()
        {
            // Arrange
            string input = "3 4 +";
            string expected = "(3 + 4)";
            var expression = new RPNExpression(input);

            // Act
            var result = _converter.ConvertToInfix(expression);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
