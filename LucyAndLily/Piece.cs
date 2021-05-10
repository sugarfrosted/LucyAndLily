using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;

namespace LucyAndLily
{
    class Piece
    {
        private TrigPair _location;
        public TrigPair Location
        {
            get { return _location; }
            set
            {
                _location = value;
            } 
        }

        private int _order;
        public int Order
        {
            get
            {
                return _order;
            }
            private set
            {
                _order = value;
            }
        }

        private int _root;
        public int Root
        {
            get
            {
                return _root;
            }
            private set
            {
                _root = value;
            }
        }

        public (int, int) Orientation
        {
            get; set;
        }

        public FloatingPoint Distance
        {
            get
            {
                return Location.SquareNorm();
            }
        }


        public Piece(TrigPair location, int order, int root, (int,int) orientation) // are r1 and r2 scalars
        {
            this.Location = location;
            this.Order = order;
            this.Root = root;
            this.Orientation = orientation;
        }

        public Piece(int order, int root)
        {
            this.Location = new TrigPair(Expr.Zero, Expr.Zero);
            this.Order = order;
            this.Root = root;
            this.Orientation = (0, 0);
        }

        /// <summary>
        /// Performs the action of flipping in the plane.
        /// </summary>
        /// <param name="direction"></param>
        public void Flip(int direction) //state
        {
            // If the direction isn't valid do nothing (might make this an exception)
            if (direction < 0 || direction > this.Order)
            {
                return;
            }

            var flipFactor = FlipFactor();

            Expr nSubOrder = Expr.Parse(this.Order.ToString());
            flipFactor.Substitute(Expr.Parse("N"), nSubOrder);

            int d = direction + Orientation.Item2;
            Expr dSubDirection = Expr.Parse(d.ToString());
            flipFactor.Substitute(Expr.Parse("d"), dSubDirection);

            var sSubSign = Orientation.Item1 != 1 ? Expr.Parse("1") : Expr.Parse("-1");
            flipFactor.Substitute(Expr.Parse("s"), sSubSign);

            this.Location += flipFactor;

            this.Orientation = (1 - this.Orientation.Item1,
                (-2 * d - 1 + this.Orientation.Item2+3*this.Order) % this.Order);
        } 

        /// <summary>
        /// The factor we need to flip the shape. 
        /// </summary>
        /// <returns>A trig pair with the following variables:
        ///     "s": the sign
        ///     "d": the direction flipped
        ///     "N": the order of the shape
        /// </returns>
        private static TrigPair FlipFactor()
        {
            Expr real = Expr.Parse("2*cos(2*pi*d/N+pi/N)*cos(pi/N)*s");
            Expr imag = Expr.Parse("2*sin(2*pi*d/N+pi/N)*cos(pi/N)");
            return new TrigPair(real, imag);
        }
    }
}
