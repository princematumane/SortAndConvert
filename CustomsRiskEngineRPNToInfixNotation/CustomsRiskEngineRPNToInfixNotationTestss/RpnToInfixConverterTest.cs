using CustomsRiskEngineRPNToInfixNotation.Model;
using CustomsRiskEngineRPNToInfixNotation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomsRiskEngineRPNToInfixNotationTestss
{
    [TestClass]
    public class RpnToInfixConverterTest
    {
        private readonly RPNConverterService _RPNConverterService;

        public RpnToInfixConverterTest()
        {
            _RPNConverterService = new RPNConverterService();
        }

        [TestMethod]
        [DataRow("3 4 +", "(3 + 4)")]
        [DataRow("3 4 * 5 6 * +", "((3 * 4) + (5 * 6))")]
        [DataRow("12 34 +", "(12 + 34)")]
        [DataRow("1 2 + 3 4 + *", "((1 + 2) * (3 + 4))")]
        [DataRow("3 4 + 5 *", "((3 + 4) * 5)")]
        [DataRow("2 3 4 * + 5 6 * - 7 +", "(((2 + (3 * 4)) - (5 * 6)) + 7)")]
        [DataRow("15 7 1 1 + - / 3 * 2 1 1 + + -", "(((15 / (7 - (1 + 1))) * 3) - (2 + (1 + 1)))")]
        [DataRow("22", "22")]
        public void ConvertToInfix_ValidInput_ReturnsCorrectInfix(string rpn, string expectedInfix)
        {
            // Arrange
            var expression = new RPNExpression(rpn);

            // Act
            var result = _RPNConverterService.ConvertToInfix(expression);

            // Assert
            Assert.AreEqual(expectedInfix, result);
        }

        [TestMethod]
        [DataRow("+")]
        [DataRow("5 6")]
        [DataRow("+ 5 6")]
        [DataRow("4 +")]
        [DataRow("5 6 7 +")]
        public void ConvertToInfix_InvalidInput_ThrowsException(string rpn)
        {
            // Arrange
            var expression = new RPNExpression(rpn);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => _RPNConverterService.ConvertToInfix(expression));
        }


        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void ConvertToInfix_EmptyOrNullExpression_ReturnsArgumentException(string rpn)
        {
            Assert.ThrowsException<ArgumentException>(() => new RPNExpression(rpn));
        }
    }
}
