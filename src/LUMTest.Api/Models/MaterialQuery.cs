using LUMTest.Domain;

namespace LUMTest.Api.Models
{
    public class MaterialQuery
    {
        public MaterialQuery(Material material)
        {
            MaterialId = material.Id;
            Name = material.Name;
            IsVisible = material.IsVisible;
            TypeOfPhase = material.TypeOfPhase.ToString();
            MaterialFunction = new MaterialFunctionQuery(material.MaterialFunction);
        }

        public string MaterialId { get; set; }
        public string Name { get; set; }
        public bool IsVisible { get; set; }
        public string TypeOfPhase { get; set; }
        public MaterialFunctionQuery MaterialFunction { get; set; }
    }
}
