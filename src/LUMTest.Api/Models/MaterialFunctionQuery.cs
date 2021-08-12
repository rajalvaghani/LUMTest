using LUMTest.Domain;

namespace LUMTest.Api.Models
{
    public class MaterialFunctionQuery
    {
        public MaterialFunctionQuery(MaterialFunction materialFunction)
        {
            MinTemperature = materialFunction.MinTemperature;
            MaxTemperature = materialFunction.MaxTemperature;
        }

        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
    }
}