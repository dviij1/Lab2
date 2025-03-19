using System;

public class Vector
{
    // Координати
    public double x, y, z;

    // Ініціалізація координат
    public Vector(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Виведення координат
    public void Print()
    {
        Console.WriteLine($"Вектор: ({x}, {y}, {z})");
    }

    // Додавання
    public static Vector Add(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }

    // Віднімання
    public static Vector Subtract(Vector v1, Vector v2)
    {
        return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }

    // Скалярний добуток
    public static double DotProduct(Vector v1, Vector v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    // Довжина
    public double Length()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Введіть координати першого вектора (x, y, z):");
        Console.ResetColor();
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double z1 = double.Parse(Console.ReadLine());
        Vector v1 = new Vector(x1, y1, z1);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Введіть координати другого вектора (x, y, z):");
        Console.ResetColor();
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double z2 = double.Parse(Console.ReadLine());
        Vector v2 = new Vector(x2, y2, z2);

        v1.Print();
        v2.Print();

        Vector sum = Vector.Add(v1, v2);
        Console.WriteLine("Сума векторів:");
        sum.Print();

        Vector diff = Vector.Subtract(v1, v2);
        Console.WriteLine("Різниця векторів:");
        diff.Print();

        double dotProd = Vector.DotProduct(v1, v2);
        Console.WriteLine($"Скалярний добуток: {dotProd}");

        double length = v1.Length();
        Console.WriteLine($"Довжина першого вектора: {length}");
    }
}
