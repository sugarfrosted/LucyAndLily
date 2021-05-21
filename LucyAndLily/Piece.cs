using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MathNet.Symbolics;
//using Expr = MathNet.Symbolics.SymbolicExpression;

namespace LucyAndLily
{
    public class Piece
    {
        public string Location
        {
            get; private set;
        }

        public int Order
        {
            get; private set;
        }

        public int Root
        {
            get; private set;
        }

        public (int, int) Orientation
        {
            get; private set;
        }

        public (double, double) DecimalCoordinates
        {
            get; private set;
        }

        public double DecimalNorm
        {
            get; private set;
        }


        //public Piece(string location, int order, int root, (int, int) orientation) // are r1 and r2 scalars
        //{
        //    this.Location = location;
        //    this.Order = order;
        //    this.Root = root;
        //    this.Orientation = orientation;
        //}

        public Piece(int order, int root)
        {
            this.Location = "0";
            this.Order = order;
            this.Root = root;
            this.Orientation = (0, 0);
            this.DecimalCoordinates = (0.0, 0.0);
            this.DecimalNorm = 0.0;
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

            // call out to the GAP server. Might add a cache. 
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

        public override string ToString()
        {

            return String.Format("Piece - Location: {0}, Order: {1}, Root: {2}, Orientation: {3}", this.Location.ToString(), this.Order, this.Root, this.Orientation);

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
            if (obj.GetType() == typeof(Piece))
            {
                var other = obj as Piece;

                return other.Order == this.Order &&
                    other.Root == this.Root &&
                    other.Orientation == this.Orientation &&
                    other.Location == this.Location;
            }
            return base.Equals(obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
    }
}
