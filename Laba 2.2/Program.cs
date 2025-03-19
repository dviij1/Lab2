using System;
using System.IO;
using System.Text.Json;

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

    // Публічний конструктор без параметрів для десеріалізації
    public Vector() { }

    // Виведення координат
    public void Print()
    {
        Console.WriteLine($"Вектор: ({x}, {y}, {z})");
    }

    // Метод 1: Серіалізація об'єкта у JSON файл
    public static void SaveToJson(Vector vector, string filename)
    {
        string json = JsonSerializer.Serialize(vector);
        File.WriteAllText(filename, json);
        Console.WriteLine("Об'єкт збережено у JSON файл.");
    }

    // Метод 2: Десеріалізація з JSON файлу
    public static Vector LoadFromJson(string filename)
    {
        string json = File.ReadAllText(filename);
        Vector vector = JsonSerializer.Deserialize<Vector>(json);
        Console.WriteLine("Об'єкт завантажено з JSON файлу.");
        return vector;
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
        // Введення координат для першого вектора
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Введіть координати першого вектора (x, y, z):");
        Console.ResetColor();
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double z1 = double.Parse(Console.ReadLine());
        Vector v1 = new Vector(x1, y1, z1);

        // Введення координат для другого вектора
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Введіть координати другого вектора (x, y, z):");
        Console.ResetColor();
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double z2 = double.Parse(Console.ReadLine());
        Vector v2 = new Vector(x2, y2, z2);

        // Виведення векторів
        v1.Print();
        v2.Print();

        // Збереження вектора у файл
        Vector.SaveToJson(v1, "vector.json");

        // Завантаження вектора з JSON файлу
        Vector loadedVector = Vector.LoadFromJson("vector.json");

        // Виведення завантаженого вектора
        loadedVector.Print();

        // Додавання векторів
        Vector sum = Vector.Add(v1, v2);
        Console.WriteLine("Сума векторів:");
        sum.Print();

        // Віднімання векторів
        Vector diff = Vector.Subtract(v1, v2);
        Console.WriteLine("Різниця векторів:");
        diff.Print();

        // Скалярний добуток
        double dotProd = Vector.DotProduct(v1, v2);
        Console.WriteLine($"Скалярний добуток: {dotProd}");

        // Довжина першого вектора
        double length = v1.Length();
        Console.WriteLine($"Довжина першого вектора: {length}");
    }
}
