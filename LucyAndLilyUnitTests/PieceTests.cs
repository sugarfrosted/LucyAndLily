using Microsoft.VisualStudio.TestTools.UnitTesting;
using LucyAndLily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyAndLily.Tests
{
    [TestClass()]
    public class PieceTests
    {
        [TestMethod("Partial Constructor")]
        public void PieceTest()
        {
            Piece piece = new Piece(5,2);

            Assert.AreEqual(piece.Order, 5);
            Assert.AreEqual(piece.Root, 2);
            Assert.AreEqual(piece.Orientation, (0, 0));
            Assert.IsTrue(piece.Location.IsZero());
        }

        [TestMethod("Full Constructor")]
        public void PieceTest1()
        {
            var location = new TrigPair("cos(10)", "sin(10)");
            Piece piece = new Piece(location,5,2,(2,5));

            Assert.AreEqual(piece.Order, 5);
            Assert.AreEqual(piece.Root, 2);
            Assert.AreEqual(piece.Orientation, (2, 5));
            Assert.IsTrue(piece.Location == new TrigPair("cos(10)", "sin(10)"));
        }

        [TestMethod()]
        public void FlipTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SquareDistanceTest()
        {
            var location = new TrigPair("2^(1/2)", "14^(1/2)");
            Piece piece = new Piece(location, 5, 2, (0, 0));

            Assert.AreEqual(piece.SquareDistance, 16.0);
        }

        [TestMethod]
        public void FlipFactorTest()
        {

        }
    }
}