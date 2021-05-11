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
            Console.WriteLine((Expr.Parse("sin(2/3*pi)") * Expr.Parse("sin(2/3*pi)")).TrigonometricSimplify()); // trigsimplify
            var x = SymbolicExpression.Variable("x");
            Console.WriteLine((x + 1).Substitute(x, Expr.Parse("10")));
            Console.ReadKey();
        }
    }
}
