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
            //Piece piece = new Piece(5,2);

            //Assert.AreEqual(piece.Order, 5);
            //Assert.AreEqual(piece.Root, 2);
            //Assert.AreEqual(piece.Orientation, (0, 0));
            //Assert.IsTrue(piece.Location.IsZero());
        }

        [TestMethod("Full Constructor")]
        public void PieceTest1()
        {
            //var location = new TrigPair("cos(10)", "sin(10)");
            //Piece piece = new Piece(location,5,2,(2,5));

            //Assert.AreEqual(piece.Order, 5);
            //Assert.AreEqual(piece.Root, 2);
            //Assert.AreEqual(piece.Orientation, (2, 5));
            //Assert.IsTrue(piece.Location == new TrigPair("cos(10)", "sin(10)"));
        }

        [TestMethod()]
        public void FlipTest()
        {
            //var piece = new Piece(5, 1);
            //Piece expected;

            //piece.Flip(1);
            //// <Piece - Location: (cos(2/5*π) + cos(4/5*π), sin(2/5*π) + sin(4/5*π)), Order: 5, Root: 1, Orientation: (1, 2)>.
            //expected = new Piece(new TrigPair("cos(2/5*π) + cos(4/5*π)", "sin(2/5*π) + sin(4/5*π)"), 5, 1, (1, 2));

            //Assert.AreEqual(expected, piece);

            //piece = new Piece(5, 1);
            //piece.Flip(1);
            //piece.Flip(1);
            //Assert.AreEqual(new Piece(5,1), piece);
        }

        [TestMethod()]
        public void SquareDistanceTest()
        {
            //var location = new TrigPair("2^(1/2)", "14^(1/2)");
            //var piece = new Piece(location, 5, 2, (0, 0));

            //Assert.AreEqual(piece.SquareDistance, 16.0);
        }

        [TestMethod]
        [TestCategory("Inverse function test.")]
        public void UnitInversionTest()
        {
            // Test all for 5;
            Assert.AreEqual(1, Piece.InverseRoot(5, 1), "In Z5 1 has an inverse of 1.");
            Assert.AreEqual(3, Piece.InverseRoot(5, 2), "In Z5 2 has an inverse of 3.");
            Assert.AreEqual(2, Piece.InverseRoot(5, 3), "In Z5 3 has an inverse of 2.");
            Assert.AreEqual(4, Piece.InverseRoot(5, 4), "In Z5 4 has an inverse of 4.");
            Assert.AreEqual(1, Piece.InverseRoot(6, 1), "In Z6 1 has an inverse of 1.");
            Assert.AreEqual(5, Piece.InverseRoot(6, 5), "In Z6 1 has an inverse of 1.");
            Assert.AreEqual(99, Piece.InverseRoot(100, 99), "In Z6 1 has an inverse of 1.");
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