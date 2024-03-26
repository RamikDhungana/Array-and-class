using System;

class Point
{
    private double x;
    private double y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }
}

class Circle
{
    private Point center;
    private double radius;

    public Circle(Point center, double radius)
    {
        this.center = center;
        this.radius = radius;
    }

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public double Perimeter()
    {
        return 2 * Math.PI * radius;
    }

    public double Surface()
    {
        return Math.PI * radius * radius;
    }

    public bool IsPointInside(Point testPoint)
    {
        double distance = Math.Sqrt(Math.Pow(testPoint.X - center.X, 2) + Math.Pow(testPoint.Y - center.Y, 2));
        return distance <= radius;
    }
}

class CircleManager
{
    public Circle[] CreateCircles(int numberOfCircles)
    {
        Circle[] circles = new Circle[numberOfCircles];
        for (int i = 0; i < numberOfCircles; i++)
        {
            Console.WriteLine($"Enter details for Circle {i + 1}:");
            Point center = GetPointFromUser();
            Console.Write("Enter radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            circles[i] = new Circle(center, radius);
            Console.WriteLine();
        }
        return circles;
    }

    public void PrintCircleInfo(Circle circle)
    {
        Console.WriteLine($"Perimeter: {circle.Perimeter()}, Surface: {circle.Surface()}");
    }

    public Point GetPointFromUser()
    {
        Console.Write("Enter X coordinate of point: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter Y coordinate of point: ");
        double y = Convert.ToDouble(Console.ReadLine());
        return new Point(x, y);
    }

    public void CheckPointInCircles(Point testPoint, Circle[] circles)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            bool isInside = circles[i].IsPointInside(testPoint);
            Console.WriteLine($"Test point is {(isInside ? "inside" : "outside")} Circle {i + 1}");
        }
    }
}

class Program
{
    static void Main()
    {
        CircleManager manager = new CircleManager();

        Console.Write("Enter number of circles to create: ");
        int numberOfCircles = Convert.ToInt32(Console.ReadLine());

        Circle[] circles = manager.CreateCircles(numberOfCircles);

        Console.WriteLine("Details of Circles:");
        for (int i = 0; i < numberOfCircles; i++)
        {
            Console.WriteLine($"Circle {i + 1} - ");
            manager.PrintCircleInfo(circles[i]);
        }

        Point testPoint = manager.GetPointFromUser();
        manager.CheckPointInCircles(testPoint, circles);
    }
}
