using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelGry;

namespace UnitTestProjectModelGry
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(1, 10)]
        [DataRow(1,1)]
        [DataRow(10, 1)]
        public void Losuj_Zakres_OK(int a, int b)
        {
            // Arrange-Act-Assert
            int x = a;
            int y = b;

            int los = Gra.Losuj(x, y);

            Assert.IsTrue(los >= Math.Min(x,y) && los <= Math.Max(x,y) );
        }
    }
}
