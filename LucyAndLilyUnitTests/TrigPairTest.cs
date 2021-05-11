using Microsoft.VisualStudio.TestTools.UnitTesting;
using LucyAndLily;
using MathNet.Symbolics;
using System.Collections.Generic;

namespace LucyAndLilyUnitTests
{
    [TestClass]
    public class TrigPairTest
    {
        TrigPair value;

        [TestMethod]
        public void IsZeroTrigPairs()
        {
            value = new TrigPair("0","0");
            Assert.IsTrue(value.IsZero(),value.Real.ToString() + "," + value.Imag.ToString());

            value = new TrigPair();
            Assert.IsTrue(value.IsZero(),value.Real.ToString() + "," + value.Imag.ToString());

            value = new TrigPair("0","1");
            Assert.AreNotEqual(true, value.IsZero(),value.Real.ToString() + "," + value.Imag.ToString());
        }
        [TestMethod]
        public void SubtractionTrigPairs()
        {
        }
        [TestMethod]
        
        public void EqualityTrigPairs()
        {

            SymbolicExpression real = SymbolicExpression.Parse("2*cos(2*pi*d/N+pi/N)*cos(pi/N)"); 
            SymbolicExpression imag = SymbolicExpression.Parse("2*cos(2*pi*d/N+pi/N)*cos(pi/N)");

            TrigPair left;
            TrigPair right;

            left = new TrigPair(real.TrigonometricExpand(), imag.TrigonometricExpand());
            right = new TrigPair(real.TrigonometricContract(), imag.TrigonometricContract());

            Assert.IsTrue(left == right);
            Assert.IsFalse(left != right);

            left = new TrigPair(-real.TrigonometricExpand(), -imag.TrigonometricExpand());
            right = new TrigPair(real.TrigonometricContract(), imag.TrigonometricContract());
            Assert.IsFalse(left == right);
            Assert.IsTrue(left != right);

            left = new TrigPair(SymbolicExpression.Parse("1"), SymbolicExpression.Parse("1"));
            right = new TrigPair(SymbolicExpression.Parse("1"), SymbolicExpression.Parse("1"));
            Assert.IsTrue(left == right);
            Assert.IsFalse(left != right);
        }

        [TestMethod]
        public void AddTrigPairs()
        {
            TrigPair left;
            TrigPair right;

            var cosSq = SymbolicExpression.Parse("cos^2(x)");
            var sinSq = SymbolicExpression.Parse("sin^2(x)");

            left = new TrigPair(sinSq, cosSq);
            right = new TrigPair(cosSq, sinSq);
            Assert.IsTrue(left + right == new TrigPair("1","1"));
        }

        [TestMethod]
        public void NegateTrigPairs()
        {
            var negative = new TrigPair("-1", "-1");
            var positive = new TrigPair("1", "1");

            Assert.IsTrue(positive == - negative);
            Assert.IsTrue(- positive == negative);
            Assert.IsTrue(- positive != - negative);
        }

        [TestMethod]
        public void SubTrigPairs()
        {
            TrigPair left;
            TrigPair right;

            var cosSq = SymbolicExpression.Parse("cos^2(x)");
            var sinSq = SymbolicExpression.Parse("sin^2(x)");

            left = new TrigPair(sinSq, cosSq);
            right = new TrigPair(-cosSq, -sinSq);
            Assert.IsTrue(left - right == new TrigPair("1","1"));
        }

        [TestMethod]
        public void MulTrigPairs()
        {
            TrigPair left;
            TrigPair right;

            var cos = SymbolicExpression.Parse("cos(x)");
            var sin = SymbolicExpression.Parse("sin(x)");

            left = new TrigPair(sin, cos);
            right = new TrigPair(1/sin, 1/cos);
            Assert.IsTrue(left * right == new TrigPair("1","1"));
        }

        [TestMethod]
        public void CalculateNormTrigPairs()
        {
            var test = new TrigPair("cos(1)", "sin(1)");

            Assert.AreEqual(1.0, test.SquareNorm());
        }

        [TestMethod]
        public void SubstituteTrigPairs()
        {
            var p = SymbolicExpression.Variable("p");
            var test = new TrigPair(p.Cos(), p.Sin()) ;

            test.Substitute(p, SymbolicExpression.Parse("10"));
        }

        [TestMethod]
        public void NumericPair()
        {
            var test = new TrigPair("1", "2");

            Assert.AreEqual(test.GetNumeric(), (1.0, 2.0));

        }

    }
}
