using Лабораторна_робота__3_2_;
class Program
{
    static void Main(string[] args)
    {
        // Створення екземплярів трикутника
        Triangle triangle1 = new Triangle(0, 0, 5, 0, 0, 2);
        Triangle triangle2 = new Triangle(0, 0, 5, 0, 0, 2);

        // Виведення інформації про трикутники
        Console.WriteLine("Трикутник 1:");
        PrintTriangleInfo(triangle1);
        Console.WriteLine();

        Console.WriteLine("Tрикутник 2:");
        PrintTriangleInfo(triangle2);
        Console.WriteLine();

        // Порівняння двох трикутників за рівністю
        Console.WriteLine("Чи рiвнi цi два трикутники?");
        if (triangle1.AreEqual(triangle2))
        {
            Console.WriteLine("Так, цi два трикутники рiвнi");
        }
        else
        {
            Console.WriteLine("Нi, цi два трикутники не рiвнi");
        }
            Console.WriteLine();

        // Поворот трикутника 1 навколо одної з вершин
        Console.WriteLine("Поворот трикутника 1 навколо вершини 1 на 90 градусiв:");
        triangle1.RotationAroundApex(90, 1);
        Console.WriteLine();

        // Поворот трикутника 2 навколо одної з вершин
        Console.WriteLine("Поворот трикутника 2 навколо вершини 1 на 90 градусiв:");
        triangle2.RotationAroundApex(90, 1);
        Console.WriteLine();

        Triangle.SaveTriangleToJson(triangle1, "triangle1.json");
        Triangle triangle = Triangle.LoadTriangleFromJson("triangle1.json");
        
        Console.ReadKey();
    }

    static void PrintTriangleInfo(Triangle triangle)
    {
        Console.WriteLine("Периметр: " + triangle.Perimeter());
        Console.WriteLine("Площа: " + triangle.Square());
        Console.WriteLine("Висота проведена до сторони a: " + triangle.Height(1));
        Console.WriteLine("Висота проведена до сторони b: " + triangle.Height(2));
        Console.WriteLine("Висота проведена до сторони c: " + triangle.Height(3));
        Console.WriteLine("Медiана проведена до сторони a: " + triangle.Median(1));
        Console.WriteLine("Медiана проведена до сторони b: " + triangle.Median(2));
        Console.WriteLine("Медiана проведена до сторони c: " + triangle.Median(3));
        Console.WriteLine("Бiсектриса проведена до сторони a: " + triangle.Bisector(1));
        Console.WriteLine("Бiсектриса проведена до сторони b: " + triangle.Bisector(2));
        Console.WriteLine("Бiсектриса проведена до сторони c: " + triangle.Bisector(3));
        Console.WriteLine("Радiус вписаного кола: " + triangle.InscribedCircleRadius());
        Console.WriteLine("Радiус описаного кола: " + triangle.CircumscribedCircleRadius());
        Console.WriteLine("Тип: " + triangle.TriangleType());
    }
}