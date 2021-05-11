using Microsoft.VisualStudio.TestTools.UnitTesting;
using LucyAndLily;
using MathNet.Symbolics;
using System.Collections.Generic;

namespace LucyAndLily.Tests
{
    [TestClass]
    public class TrigPairTests
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
        [TestMethod("Same type non-null equals")]
        
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
            Assert.IsTrue(left.Equals(right));
            Assert.IsTrue(right.Equals(left));

            left = new TrigPair(-real.TrigonometricExpand(), -imag.TrigonometricExpand());
            right = new TrigPair(real.TrigonometricContract(), imag.TrigonometricContract());
            Assert.IsFalse(left == right);
            Assert.IsTrue(left != right);
            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(right.Equals(left));

            left = new TrigPair(SymbolicExpression.Parse("1"), SymbolicExpression.Parse("1"));
            right = new TrigPair(SymbolicExpression.Parse("1"), SymbolicExpression.Parse("1"));
            Assert.IsTrue(left == right);
            Assert.IsFalse(left != right);
            Assert.IsTrue(left.Equals(right));
            Assert.IsTrue(right.Equals(left));
        }

        [TestMethod]
        public void EqualityTrigPairAndOther()
        {
            TrigPair a = null;
            TrigPair b = new TrigPair();

            Assert.AreNotEqual(a, b, "Fails when left is null");
            Assert.AreNotEqual(b, a, "Fails when right is null");
            Assert.AreEqual(a, a, "Not reflexive on null");
            Assert.AreEqual(b, b, "Not reflexive on value");

            Assert.AreNotEqual(b, "breakfast");
            Assert.AreNotEqual(a, "breakfast");
            Assert.AreNotEqual("breakfast", a);
            Assert.AreNotEqual("breakfast", b);
        }

        [TestMethod]
        public void HashTrigPair()
        {
            var x = SymbolicExpression.Variable("x");
            var a = new TrigPair((2 * x).Cos(), (2 * x).Sin());
            var b = new TrigPair(2 * (x).Cos().Pow(2) - 1, 2 * x.Sin() * x.Cos());

            Assert.AreEqual(a.GetHashCode(), a.GetHashCode());
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
            Assert.AreEqual(b.GetHashCode(), a.GetHashCode());
            Assert.AreEqual(b.GetHashCode(), b.GetHashCode());
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
            Assert.AreEqual(left + right, new TrigPair("1","1"));
        }

        [TestMethod]
        public void NegateTrigPairs()
        {
            var negative = new TrigPair("-1", "-1");
            var positive = new TrigPair("1", "1");

            Assert.AreEqual(positive, - negative);
            Assert.AreEqual(- positive, negative);
            Assert.AreNotEqual(- positive, - negative);
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
            Assert.AreEqual(left - right, new TrigPair("1","1"));
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
            Assert.AreEqual(left * right, new TrigPair("1","1"));
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
