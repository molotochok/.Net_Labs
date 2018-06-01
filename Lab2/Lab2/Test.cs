using System;
using System.Collections.Generic;

namespace Lab2
{
    class Test
    {
        // Variant tasks
        // How Function and it subclasses work
        private void TestFunctionClasses()
        {
            Console.WriteLine("---------------- Test Function --------------------");
            try
            {
                Function ellipse = new Ellipse(5, 4);
                Function hiperbola = new Hiperbola(4.3, 5.9);
                Function parabola = new Parabola(0);

                ellipse.Print(ellipse.Calculate(4.1), 4.1);
                hiperbola.Print(hiperbola.Calculate(1.2f), 1.2f);
                parabola.Print(parabola.Calculate(0.5f), 0.5f);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }
        // How Series class works
        private void TestSeriesClass()
        {
            Console.WriteLine("---------------- Test Series --------------------");
            Random random = new Random();
            Series series = new Series();
            for (int i = 1; i <= 3; i++)
            {
                Function ellipse = new Ellipse(random.Next(1, 10), random.Next(10, 20));
                Function hiperbola = new Hiperbola(random.Next(1, 100), random.Next(5, 50));
                Function parabola = new Parabola(random.Next(100, 200));
                series.Add(parabola);
                series.Add(hiperbola);
                series.Add(ellipse);
            }

            Console.WriteLine(series);
        }

        // Basic tasks 1
        // How Equals works
        private void TestEquals()
        {
            Console.WriteLine("---------------- Test Equals --------------------");
            void CheckIfEquals<T>(T t1, T t2)
            {
                string equalsMessage = "";
                if (t1.Equals(t2))
                    equalsMessage = "equals";
                else
                    equalsMessage = "not equals";
                Console.WriteLine(String.Format("{0} {1} to {2}", t1.ToString(), equalsMessage, t2.ToString()));
            }
            Function hiperbola1 = new Hiperbola(2, 3);
            Function hiperbola2 = new Hiperbola(3, 4);
            CheckIfEquals(hiperbola1, hiperbola2);

            Function parabola1 = new Parabola(2);
            Function parabola2 = new Parabola(2);
            CheckIfEquals(parabola1, parabola2);

            Function ellipse1 = new Ellipse(13.3, 9);
            Function ellipse2 = new Ellipse(13.3, 9);
            CheckIfEquals(ellipse1, ellipse2);

            Series series1 = new Series();
            series1.Add(parabola1);
            series1.Add(ellipse1);
            Series series2 = new Series();
            series2.Add(parabola2);
            series2.Add(ellipse2);

            CheckIfEquals(series1, series2);
        }
        // How operators != and == work
        private void TestOperations()
        {
            Console.WriteLine("---------------- Test operators != and == --------------------");
            Function hiperbola1 = new Hiperbola(1, 2);
            Function hiperbola2 = new Hiperbola(1, 2);

            if(hiperbola1 == hiperbola2)
                Console.WriteLine(String.Format("{0} == {1}", hiperbola1, hiperbola2));
            else
                Console.WriteLine(String.Format("{0} != {1}", hiperbola1, hiperbola2));

            Series series1 = new Series();
            series1.Add(new Parabola(2));
            Series series2 = new Series();
            series2.Add(new Ellipse(2.3, 4.5));

            if(series1 != series2)
            {
                Console.WriteLine(String.Format("{0} !=\n{1}", series1, series2));
            }
        }
        // How GetHashCode work
        private void TestGetHashCode()
        {
            Console.WriteLine("---------------- Test GetHashCode --------------------");
            void ShowHashCode<T>(T t)
            {
                Console.WriteLine("Hash Code of {0} is {1}", t, t.GetHashCode());
            }
            Function ellipse1 = new Ellipse(2, 3);
            Function ellipse2 = new Ellipse(3, 4);
            Function ellipse3 = new Ellipse(2, 3);

            ShowHashCode(ellipse1);
            ShowHashCode(ellipse2);
            ShowHashCode(ellipse3);

            Series series1 = new Series();
            Series series2 = new Series();
            series1.Add(ellipse1);
            series1.Add(ellipse2);

            series2.Add(ellipse1);
            series2.Add(ellipse2);

            ShowHashCode(series1);
            ShowHashCode(series2);
        }
        // How DeepCopy works
        private void TestDeepCopy()
        {
            Console.WriteLine("---------------- Test DeepCopy --------------------");

            Function parabola1 = new Parabola(9.5f);
            Function parabola2 = new Parabola(2);

            Console.WriteLine(String.Format("Parabola1: {0}", parabola1));
            Console.WriteLine(String.Format("Before DeepCopy Parabola2: {0}", parabola2));

            parabola2 = (Parabola)parabola1.DeepCopy();
            Console.WriteLine(String.Format("After DeepCopy Parabola2: {0}", parabola2));


            Series series1 = new Series();
            series1.Add(parabola1);
            Series series2 = (Series)series1.DeepCopy();

            Console.Write(String.Format("Series1:\n{0}", series1));
            Console.Write(String.Format("Series2:\n{0}", series2));

        }
        //  How ToString workds
        private void TestToString()
        {
            Console.WriteLine("---------------- Test ToString --------------------");
            Function hiperbola = new Hiperbola(2, 5);
            Function parabola  = new Parabola(22);
            Function ellipse   = new Ellipse(23, 13);

            Console.WriteLine(hiperbola);
            Console.WriteLine(parabola);
            Console.WriteLine(ellipse);

            Series series = new Series(hiperbola, parabola, ellipse);
            Console.WriteLine(series);
        }

        // Basic tasks 2
        private void TestSeries()
        {
            Console.WriteLine("---------------- TestSeries --------------------");
            Series series = new Series();
            series.Add(new Parabola(2));
            series.Add(new Hiperbola(3, 5));
            series.Add(new Ellipse(9.4, 4.5));

            series.RemoveAt(0);

            series.FunctionList = new List<Function> { new Parabola(3), new Parabola(2.2) };
        }
        private void TestException()
        {
            Console.WriteLine("---------------- TestException --------------------");
            try
            {
                Function hiperbola = new Hiperbola(2, 0);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Main method which shows all tests
        public void ShowTests()
        {
            TestFunctionClasses();
            TestSeriesClass();

            TestEquals();
            TestOperations();
            TestGetHashCode();
            TestDeepCopy();
            TestToString();

            TestSeries();
            TestException();
        }
    }
}
