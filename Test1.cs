using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLogicLibrary;

namespace MyTests
{
    [TestClass]
    public class GraphicEngineTests
    {
        [TestMethod]
        public void CalculateFrequencies_ValidString_ReturnsCorrectCounts()
        {
            // Arrange (Подготовка)
            var engine = new GraphicEngine();
            string input = "112223";

            // Act (Действие)
            engine.CalculateFrequencies(input);

            // Assert (Проверка)
            Assert.AreEqual(2, engine._frequencies[1]); // Две единицы
            Assert.AreEqual(3, engine._frequencies[2]); // Три двойки
            Assert.AreEqual(1, engine._frequencies[3]); // Одна тройка
            Assert.AreEqual(0, engine._frequencies[0]); // Нулей нет
        }

        [TestMethod]
        public void CalculateFrequencies_EmptyString_ReturnsAllZeros()
        {
            var engine = new GraphicEngine();

            engine.CalculateFrequencies("");

            foreach (int count in engine._frequencies)
            {
                Assert.AreEqual(0, count);
            }
        }

        [TestMethod]
        public void CalculateFrequencies_MixedChars_IgnoresNonDigits()
        {
            var engine = new GraphicEngine();
            string input = "1a2!3 ";

            engine.CalculateFrequencies(input);

            Assert.AreEqual(1, engine._frequencies[1]);
            Assert.AreEqual(1, engine._frequencies[2]);
            Assert.AreEqual(1, engine._frequencies[3]);
        }
    }
}