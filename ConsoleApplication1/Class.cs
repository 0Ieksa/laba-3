using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторна_робота__3_2_
{
    public class Triangle
    {
        public double x1, y1, x2, y2, x3, y3;
        private double a, b, c;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;

            a = SideLength(x1, y1, x2, y2);
            b = SideLength(x2, y2, x3, y3);
            c = SideLength(x3, y3, x1, y1);
        }

        private double SideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double Perimeter()
        {
            return a + b + c;
        }

        public double Square()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public bool AreEqual(Triangle other)
        {
            bool sidesEqual = (this.a == other.a && this.b == other.b && this.c == other.c) 
                              (this.a == other.b && this.b == other.c && this.c == other.a) 
                              (this.a == other.c && this.b == other.a && this.c == other.b);

            return sidesEqual;
        }

        public double Height(int sideIndex)
        {
            double s = Square();
            double a = this.a;
            switch (sideIndex)
            {
                case 1:
                    a = this.a;
                    break;
                case 2:
                    a = this.b;
                    break;
                case 3:
                    a = this.c;
                    break;
                default:
                    throw new ArgumentException("sideIndex must be 1, 2, or 3.");
            }
            return 2 * s / a;
        }

        public double Median(int sideIndex)
        {
            double medianLength;

            switch (sideIndex)
            {
                case 1:
                    medianLength = Math.Sqrt(2 * b * b + 2 * c * c - a * a) / 2;
                    break;
                case 2:
                    medianLength = Math.Sqrt(2 * c * c + 2 * a * a - b * b) / 2;
                    break;
                case 3:
                    medianLength = Math.Sqrt(2 * a * a + 2 * b * b - c * c) / 2;
                    break;
                default:
                    throw new ArgumentException("sideIndex must be 1, 2, or 3.");
            }
            return medianLength;
        }

        public double Bisector(int sideIndex)
        {
            double p = Perimeter();
            double bisectorLength;

            switch (sideIndex)
            {
                case 1:
                    bisectorLength = Math.Sqrt(b * c * p * (b + c - a)) / (b + c);
                    break;
                case 2:
                    bisectorLength = Math.Sqrt(a * c * p * (a + c - b)) / (a + c);
                    break;
                case 3:
                    bisectorLength = Math.Sqrt(a * b * p * (a + b - c)) / (a + b);
                    break;
                default:
                    throw new ArgumentException("sideIndex must be 1, 2, or 3.");
            }
            return bisectorLength;
        }

        public double InscribedCircleRadius()
        {
            double s = Square();
            double p = Perimeter();
            return 2 * s / p;
        }

        public double CircumscribedCircleRadius()
        {
            double s = Square();
            return (a * b * c) / (4 * s);
        }
        
public string TriangleType()
        {
            if (a == b && b == c)
            {
                return "Рівносторонній";
            }
            else if (a == b  b == c  a == c)
            {
                return "Рівнобедрений";
            }
            else
            {
                if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) 
                    Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2) 
                    Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2))
                {
                    return "Прямокутний";
                }
                else if (Math.Pow(a, 2) + Math.Pow(b, 2) > Math.Pow(c, 2) &&
                         Math.Pow(b, 2) + Math.Pow(c, 2) > Math.Pow(a, 2) &&
                         Math.Pow(a, 2) + Math.Pow(c, 2) > Math.Pow(b, 2))
                {
                    return "Гострокутний";
                }
                else
                {
                    return "Тупокутний";
                }
            }
        }

        public void RotationAroundApex(double angleInDegrees, int vertexIndex)
        {
            double angleInRadians = angleInDegrees * Math.PI / 180.0;
            double xFixed, yFixed;

            switch (vertexIndex)
            {
                case 1:
                    xFixed = x1;
                    yFixed = y1;
                    break;
                case 2:
                    xFixed = x2;
                    yFixed = y2;
                    break;
                case 3:
                    xFixed = x3;
                    yFixed = y3;
                    break;
                default:
                    throw new ArgumentException("vertexIndex must be 1, 2, or 3.");
            }

            double newX2 = (x2 - xFixed) * Math.Cos(angleInRadians) - (y2 - yFixed) * Math.Sin(angleInRadians) + xFixed;
            double newY2 = (x2 - xFixed) * Math.Sin(angleInRadians) + (y2 - yFixed) * Math.Cos(angleInRadians) + yFixed;
            double newX3 = (x3 - xFixed) * Math.Cos(angleInRadians) - (y3 - yFixed) * Math.Sin(angleInRadians) + xFixed;
            double newY3 = (x3 - xFixed) * Math.Sin(angleInRadians) + (y3 - yFixed) * Math.Cos(angleInRadians) + yFixed;

            x2 = Math.Round(newX2, 2);
            y2 = Math.Round(newY2, 2);
            x3 = Math.Round(newX3, 2);
            y3 = Math.Round(newY3, 2);
            Console.WriteLine($"Новi координати вершин пiсля обертання:{xFixed}, {yFixed}, {x2}, {y2}, {x3}, {y3}");
        }

        public static void SaveTriangleToJson(Triangle triangle, string filePath)
        {
            string json = JsonConvert.SerializeObject(triangle);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Створений об'єкт збережено до {filePath}.");
        }
        public static Triangle LoadTriangleFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }
            string json = File.ReadAllText(filePath);
            Triangle triangle = JsonConvert.DeserializeObject<Triangle>(json);
            Console.WriteLine($"Об'єкт створено з {filePath}.");
            return triangle;
        }
    }
}