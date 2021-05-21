using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;
// using Float = MathNet.Symbolics.FloatingPoint;

namespace LucyAndLily
{
    public class TrigPair // lazy implemenation just to make notion easy
    {
        #region Properties
        private Expr _real;
        public Expr Real
        { 
            get { return _real; }
            set
            {
                _real = value.TrigonometricContract().TrigonometricExpand().TrigonometricSimplify();
            }
        }

        private Expr _imag;
        public Expr Imag
        { 
            get { return _imag; }
            set
            {
                _imag = value.TrigonometricContract().TrigonometricExpand().TrigonometricSimplify();
            }
        }
        #endregion



        public TrigPair(string real, string imag):
                    this(Expr.Parse(real), Expr.Parse(imag)) { }
        public TrigPair(Expr real, Expr imag)
        {
            this.Real = real;
            this.Imag = imag;
        }
        public TrigPair()
        {
            this.Real = Expr.Zero;
            this.Imag = Expr.Zero;
        }


        public void Substitute(Expr x, Expr replacement)
        {
            this.Real.Substitute(x, replacement);
            this.Imag.Substitute(x, replacement);
        }

        // We assume that the variables match between each side
        public double SquareNorm()
        {
            Expr symbolicSquareNorm = Real.Pow(2) + Imag.Pow(2);
            return symbolicSquareNorm.Evaluate(new Dictionary<string, FloatingPoint>()).RealValue;
        }

        /// <summary>
        /// Gets the numeric representation of the point. 
        /// </summary>
        /// <returns></returns>
        public (double, double) GetNumeric()
        {
            var dict = new Dictionary<string, FloatingPoint>();
            return (this.Real.Evaluate(dict).RealValue,
                this.Imag.Evaluate(dict).RealValue);
        }
        public bool IsZero()
        {
            return this.Real.ToString() == "0" && this.Imag.ToString() == "0";
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            //throw new NotImplementedException();
            if (obj.GetType() == typeof(TrigPair))
            {
                return (this - (obj as TrigPair)).IsZero();
            }

            // Unused
            return base.Equals(obj);
        }

        // override object.GetHashCode
        /// <summary>
        /// Do not trust this. Lol.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (this.Real.ToString(), this.Imag.ToString()).GetHashCode();
        }

        public static TrigPair operator +(TrigPair a, TrigPair b) => new TrigPair(a.Real + b.Real, a.Imag + b.Imag);
        public static TrigPair operator *(TrigPair a, TrigPair b) => new TrigPair(a.Real * b.Real, a.Imag * b.Imag);
        public static TrigPair operator -(TrigPair a, TrigPair b) => new TrigPair(a.Real - b.Real, a.Imag - b.Imag);
        public static TrigPair operator -(TrigPair a) => new TrigPair(-a.Real, -a.Imag);
        public static bool operator ==(TrigPair a, TrigPair b) => a.Equals(b);
        public static bool operator !=(TrigPair a, TrigPair b) => !a.Equals(b);

        public override string ToString()
        {
            return (this.Real, this.Imag).ToString();
        }
    }
}
