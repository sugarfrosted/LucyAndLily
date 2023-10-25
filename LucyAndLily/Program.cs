using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;

namespace LucyAndLily
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Expr.Parse("cos(2 / 5 * pi) + cos(4 / 5 * pi) - cos(6 / 5 * pi) - cos(8 / 5 * pi)");
            Console.WriteLine(expression.TrigonometricContract());
            Console.WriteLine(expression.TrigonometricExpand());
            Console.WriteLine(expression.TrigonometricSimplify());
            Console.WriteLine(expression.Evaluate(new Dictionary<string, FloatingPoint>()));
            Console.WriteLine(expression.RationalReduce());
        }
    }
}
