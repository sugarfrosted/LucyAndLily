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
            var kmaginary = Expr.I;
            Expr complexExpProd = Expr.Parse("-exp(sqrt(-1)*2*pi)*exp(4)");
            Console.WriteLine(complexExpProd.ExponentialSimplify().ToString());
            Console.WriteLine(complexExpProd.ExponentialContract().ToString());
            Console.WriteLine(complexExpProd.ExponentialExpand().ToString());
            Console.WriteLine(new TrigPair("pi","1/2").SquareNorm());
            Console.ReadKey();
        }
    }
}
