using Task5.Shapes;

namespace Task5.Figures
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 2);           
        }       
    }
}