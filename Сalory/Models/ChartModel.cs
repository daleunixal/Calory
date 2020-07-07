namespace Сalory.Models
{
    public class ChartModel
    {
        public string Name;
        public double Quantity;

        public ChartModel(string name, double q)
        {
            Name = name;
            Quantity = q;
        }
    }
}