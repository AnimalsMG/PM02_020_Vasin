using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM02_4ISIP_Vasin;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class TransportProblemTests
    {
        [TestMethod]
        public void TestCorrectSolution()
        {
            // Arrange
            int[] demand = { 20, 30 };
            int[] supply = { 10, 40 };
            int[][] costMatrix = new int[][]
            {
                new int[] { 2, 3 },
                new int[] { 4, 1 }
            };

            MainWindow mainWindow = new MainWindow();

            // Act
            var result = mainWindow.SolveTransportProblem(demand, supply, costMatrix);

            // Assert
            string expectedPlan = "Опорный план: \n0\t20\t\n10\t10\t\n";
            int expectedTotalCost = 100;

            Assert.AreEqual(expectedPlan, result.Item1);
            Assert.AreEqual(expectedTotalCost, result.Item2);
        }

        [TestMethod]
        public void TestUnequalSupplyDemand()
        {
            // Arrange
            int[] demand = { 20, 30 };
            int[] supply = { 10, 20 }; // Total supply is less than total demand
            int[][] costMatrix = new int[][]
            {
                new int[] { 2, 3 },
                new int[] { 4, 1 }
            };

            MainWindow mainWindow = new MainWindow();

            // Act
            var result = mainWindow.SolveTransportProblem(demand, supply, costMatrix);

            // Assert
            string expectedError = "Ошибка: сумма потребностей не равна сумме предложений!";
            int expectedTotalCost = 0;

            Assert.AreEqual(expectedError, result.Item1);
            Assert.AreEqual(expectedTotalCost, result.Item2);
        }

        [TestMethod]
        public void TestEmptyInput()
        {
            // Arrange
            int[] demand = { };
            int[] supply = { };
            int[][] costMatrix = new int[][]
            {
                new int[] {},
                new int[] {}
            };

            MainWindow mainWindow = new MainWindow();

            // Act
            var result = mainWindow.SolveTransportProblem(demand, supply, costMatrix);

            // Assert
            string expectedPlan = "Опорный план: \n\n";
            int expectedTotalCost = 0;

            Assert.AreEqual(expectedPlan, result.Item1);
            Assert.AreEqual(expectedTotalCost, result.Item2);
        }
    }
}