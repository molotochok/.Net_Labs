using System;

namespace Lab2
{
    class Parabola : Function
    {
        private double P { get; set; }
        

        public Parabola(double p)
        {
            P = p;
        }

        public override double[] Calculate(double x)
        {
            double ySquared = 2 * P * x;

            if (ySquared < 0)
            {
                return null;
            }

            double y = Math.Sqrt(ySquared);

            return new double[] { y, -y };
        }

        public override void Print(double[] y, double x)
        {
            Console.WriteLine(String.Format("Parabola:\nWith parameter p = {0:0.###}:", P));
            if (y == null)
                Console.WriteLine(String.Format("If x = {0:0.###} then y - doesn't exist", x));
            else
                Console.WriteLine(String.Format("If x = {0:0.###} then y1 = {1:0.###}, y2 = {2:0.###}", x, y[0], y[1]));
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Parabola ellipse = (Parabola)obj;
            return P == ellipse.P;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return (int)(P) % 300 + 100;
        }

        // Override ToString
        public override string ToString()
        {
            return String.Format("Parabola: y^2=2*{0}*x", P);
        }

        // Method returns copy of an object
        public override object DeepCopy()
        {
            return new Parabola(P);
        }
    }
}
