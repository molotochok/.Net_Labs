using System;

namespace Lab2
{
    class Ellipse : Function
    {
        private double A { get; set; }
        private double _b;
        public double B {
            get {
                return _b;
            }
            set {
                if (value == 0)
                    throw new DivideByZeroException("B can't be equal 0");
                else
                    _b = value;
            }
        }

        public Ellipse(double a, double b)
        {
            A = a;
            B = b;
        }

        public override double[] Calculate(double x)
        {
            double ySquared = Math.Pow(A, 2) * (1 - Math.Pow(x, 2) / Math.Pow(B, 2));
            
            if(ySquared < 0)
            {
                return null;
            }

            double y = Math.Sqrt(ySquared);

            return new double[] { y, -y };
        }

        public override void Print(double[] y, double x)
        {
            Console.WriteLine(String.Format("Ellipse:\nWith parameters a = {0:0.###} and b = {1:0.###}:", A, B));
            if(y == null)
                Console.WriteLine(String.Format("If x = {0:0.###} then y - doesn't exist", x));
            else
                Console.WriteLine(String.Format("If x = {0:0.###} then y1 = {1:0.###}, y2 = {2:0.###}", x, y[0], y[1]));
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Ellipse ellipse = (Ellipse)obj;
            return A == ellipse.A && B == ellipse.B;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return (int)(A + B) % 300 + 100;
        }

        // Override ToString
        public override string ToString()
        {
            return String.Format("Ellipse: y^2/{0}+x^2/{1}=1", Math.Pow(A, 2), Math.Pow(B, 2));
        }

        // Method returns copy of an object
        public override object DeepCopy()
        {
            return new Ellipse(A, B);
        }
    }
}
