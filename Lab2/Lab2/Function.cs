using System;

namespace Lab2
{
    abstract class Function
    {
        public abstract double[] Calculate(double x);

        public abstract void Print(double[] y, double x);

        public static bool operator ==(Function function1, Function function2)
        {
            return function1.Equals(function2);
        }
        public static bool operator !=(Function function1, Function function2)
        {
            return !function1.Equals(function2);
        }

        public abstract object DeepCopy();
    }
}
