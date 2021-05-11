using Microsoft.VisualStudio.TestTools.UnitTesting;
using LucyAndLily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Symbolics;

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
            var piece = new Piece(5, 1);

            piece.Flip(1);

            Assert.AreEqual(piece, new Piece(1, 2));
        }


        [TestMethod()]
        public void SquareDistanceTest()
        {
            var location = new TrigPair("2^(1/2)", "14^(1/2)");
            var piece = new Piece(location, 5, 2, (0, 0));

            Assert.AreEqual(piece.SquareDistance, 16.0);
        }

        [TestMethod]
        public void FlipFactorTest()
        {
            var piece = Piece.FlipFactorExpression(1, 2, 3);
            var pi = SymbolicExpression.Pi;
            Assert.AreEqual(piece, new TrigPair(-4 * (pi / 3).Cos(), SymbolicExpression.Zero));
        }

        [TestMethod]
        [TestCategory("Inverse function test.")]
        public void UnitInversionTest()
        {
            // Test all for 5;
            Assert.AreEqual(Piece.InverseRoot(5, 1), 1, "In Z5 1 has an inverse of 1.");
            Assert.AreEqual(Piece.InverseRoot(5, 2), 3, "In Z5 2 has an inverse of 3.");
            Assert.AreEqual(Piece.InverseRoot(5, 3), 2, "In Z5 3 has an inverse of 2.");
            Assert.AreEqual(Piece.InverseRoot(5, 4), 4, "In Z5 4 has an inverse of 4.");
            Assert.AreEqual(Piece.InverseRoot(6, 1), 1, "In Z6 1 has an inverse of 1.");
            Assert.AreEqual(Piece.InverseRoot(6, 5), 5, "In Z6 1 has an inverse of 1.");
            Assert.AreEqual(Piece.InverseRoot(100,99), 99, "In Z6 1 has an inverse of 1.");
        }

        [TestMethod]
        [TestCategory("Inverse function test.")]
        public void NonUnitInversionTest()
        {
            Assert.AreEqual(Piece.InverseRoot(5, 0), null, "In Z5 0 has no inverse.");
            Assert.AreEqual(Piece.InverseRoot(6, 2), null, "In Z6 2 is not a unit.");
            Assert.AreEqual(Piece.InverseRoot(6, 3), null, "In Z6 2 is not a unit.");
            Assert.AreEqual(Piece.InverseRoot(15, 5), null, "In Z15 5 is not a unit.");
            Assert.AreEqual(Piece.InverseRoot(15, 3), null, "In Z15 3 is not a unit.");

            Assert.ThrowsException<Exception>(() => Piece.InverseRoot(1,99));
            Assert.ThrowsException<Exception>(() => Piece.InverseRoot(-1,99));
            Assert.ThrowsException<Exception>(() => Piece.InverseRoot(0,99));
        }
    }
}