using System;

class Circle
{
    private double radius;
    private double xCenter;
    private double yCenter;

    public Circle(double r, double x, double y)
    {
        radius = r;
        xCenter = x;
        yCenter = y;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public bool IsPointInside(double x, double y)
    {
        double distance = Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y - yCenter, 2));
        return distance <= radius;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Circle with radius {radius}:");
        Console.WriteLine($"Area: {CalculateArea():0.##}");
        Console.WriteLine($"Perimeter: {CalculatePerimeter():0.##}");
    }
}

class Program
{
    static Circle[] CreateCircles(int numCircles)
    {
        Circle[] circles = new Circle[numCircles];
        for (int i = 0; i < numCircles; i++)
        {
            Console.WriteLine($"Enter details for Circle {i + 1}:");
            Console.Write("Radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.Write("X coordinate of center: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y coordinate of center: ");
            double y = Convert.ToDouble(Console.ReadLine());
            circles[i] = new Circle(radius, x, y);
        }
        return circles;
    }

    static void PrintCircleInfo(Circle[] circles)
    {
        foreach (Circle circle in circles)
        {
            circle.PrintInfo();
            Console.WriteLine();
        }
    }

    static void CheckPointInCircles(Circle[] circles, double x, double y)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            Console.WriteLine($"Point ({x}, {y}) is {(circles[i].IsPointInside(x, y) ? "inside" : "outside")} Circle {i + 1}");
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the number of circles to create: ");
        int numCircles = Convert.ToInt32(Console.ReadLine());
        Circle[] circles = CreateCircles(numCircles);
        Console.WriteLine("\nCircle Information:");
        PrintCircleInfo(circles);

        Console.WriteLine("\nEnter a point to check its position relative to the circles:");
        Console.Write("X coordinate: ");
        double xPoint = Convert.ToDouble(Console.ReadLine());
        Console.Write("Y coordinate: ");
        double yPoint = Convert.ToDouble(Console.ReadLine());

        CheckPointInCircles(circles, xPoint, yPoint);
    }
}
