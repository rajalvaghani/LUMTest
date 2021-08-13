namespace LUMTest.Domain
{
    public class MaterialFunction
    {
        public MaterialFunction(double minTemperature, double maxTemperature)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
        }
        public double MinTemperature { get; protected set; }
        public double MaxTemperature { get; protected set; }
    }
}
