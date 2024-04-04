using System;

public class Shape
{
    public string Name { get; set; }

    public Shape(string name)
    {
        Name = name;
    }

    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }


    public Rectangle(string name, double width, double height) : base(name)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }


    public Circle(string name, double radius) : base(name)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
public class Triangle : Shape
{
    public double BAse { get; set; }
    public double HEight { get; set; }
    public Triangle(string name, double Base, double Height) : base(name)
    {
        BAse = Base;
        HEight = Height;

    }
    public override double CalculateArea()
    {

        return 0.5 * HEight * BAse;

    }
}

class Programm
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle("Rectangle", 5, 10);
        PrintShapeArea(rectangle);

        Circle circle = new Circle("Circle", 7);
        PrintShapeArea(circle);

        Triangle triangle = new Triangle("triangle", 4, 6);
        PrintShapeArea(triangle);
    }


    static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine(shape.Name + " - Area: " + shape.CalculateArea());
    }
}
