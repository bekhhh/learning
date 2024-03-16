﻿namespace Task5
{
    public class Rectangle : Shape
    {
        public override double Area { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }

        public override double GetArea()
        {
            Area = Math.Round(SideA * SideB, 2);
            return Area;
        }
        public override void PrintArea()
        {
            Console.WriteLine($"Площадь прямоугольника: {Area}");
        }
    }
}