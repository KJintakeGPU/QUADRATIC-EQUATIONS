using System;

namespace QuadraticEquationSolver
{
    // Lớp cơ sở giải phương trình bậc 1
    public class PhuongTrinhBac1
    {
        protected double a;
        protected double b;

        public PhuongTrinhBac1(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        // Phương thức giải phương trình bậc 1
        public virtual void Giai()
        {
            Console.WriteLine($"Phương trình: {a}x + {b} = 0");

            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("Phương trình có vô số nghiệm");
                }
                else
                {
                    Console.WriteLine("Phương trình vô nghiệm");
                }
            }
            else
            {
                double x = -b / a;
                Console.WriteLine($"Phương trình có nghiệm duy nhất: x = {x:F2}");
            }
        }
    }

    // Lớp kế thừa giải phương trình bậc 2
    public class PhuongTrinhBac2 : PhuongTrinhBac1
    {
        private double c;

        public PhuongTrinhBac2(double a, double b, double c) : base(a, b)
        {
            this.c = c;
        }

        // Ghi đè phương thức Giai từ lớp cơ sở
        public override void Giai()
        {
            Console.WriteLine($"Phương trình: {a}x² + {b}x + {c} = 0");

            if (a == 0)
            {
                // Nếu a = 0, trở thành phương trình bậc 1
                Console.WriteLine("Vì a = 0, phương trình trở thành phương trình bậc 1:");
                base.Giai();
                return;
            }

            double delta = CalculateDelta();
            Console.WriteLine($"Delta = b² - 4ac = {b}² - 4*{a}*{c} = {delta:F2}");

            if (delta < 0)
            {
                Console.WriteLine("Delta < 0: Phương trình vô nghiệm");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Delta = 0: Phương trình có nghiệm kép");
                Console.WriteLine($"x1 = x2 = {x:F2}");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Delta > 0: Phương trình có 2 nghiệm phân biệt");
                Console.WriteLine($"x1 = {x1:F2}");
                Console.WriteLine($"x2 = {x2:F2}");
            }
        }

        private double CalculateDelta()
        {
            return b * b - 4 * a * c;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("CHƯƠNG TRÌNH GIẢI PHƯƠNG TRÌNH BẬC 2");
            Console.WriteLine("=====================================");

            Console.Write("Nhập a: ");
            double a = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhập b: ");
            double b = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhập c: ");
            double c = double.Parse(Console.ReadLine() ?? "0");

            PhuongTrinhBac2 pt = new PhuongTrinhBac2(a, b, c);

            Console.WriteLine("\nKẾT QUẢ:");
            Console.WriteLine("=========");
            pt.Giai();

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}