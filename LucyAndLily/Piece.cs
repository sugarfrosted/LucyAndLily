using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;

namespace LucyAndLily
{
    public class Piece
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

        public double SquareDistance
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
        public void Flip(int direction) //switch to use vars, then unit test generation!
        {
            // If the direction isn't valid do nothing (might make this an exception)
            if (direction < 0 || direction > this.Order)
            {
                return;
            }

            int d = direction + Orientation.Item2;

            this.Location += FlipFactorExpression(d,
                (Orientation.Item1 != 1) ? 1 : -1,
                this.Order);

            this.Orientation = (1 - this.Orientation.Item1,
                (-2 * d - 1 + this.Orientation.Item2+3*this.Order) % this.Order);
        } 

        /// <summary>
        /// The factor we use to change a shape's coordinates.
        /// </summary>
        /// <param name="d">Usually based on the direction of rotation.</param>
        /// <param name="s">Usually the sign in the cosine.</param>
        /// <param name="N">Usually represents to order of the peice.</param>
        /// <returns></returns>
        internal static TrigPair FlipFactorExpression(Expr d, Expr s, Expr N) // The factor we need to flip the shape.
        {
            Expr pi = Expr.Pi;
            Expr real = 2 * (2 * pi * d / N + pi / N).Cos() * (pi / N).Cos() * s; // Expr.Parse("2*cos(2*pi*d/N+pi/N)*cos(pi/N)*s");
            Expr imag = 2 * (2 * pi * d / N + pi / N).Sin() * (pi / N).Cos(); // Expr.Parse("2*sin(2*pi*d/N+pi/N)*cos(pi/N)");

            return new TrigPair(real, imag);
        }

        /// <summary>
        /// Calculated the inverse of the element given the base.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int? InverseRoot(int order, int root)
        {
            if (order <= 1)
            {
                throw new Exception("Invalid size.");
            }
            if (root == 1)
            {
                return 1;
            }
            if (root == 0 || order % root == 0)
            {
                return null;
            }

            for (var i = 1; i < order; i ++)
            {
                if(i * root % order == 1)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
