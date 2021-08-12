using LUMTest.Domain;
using System.ComponentModel.DataAnnotations;
namespace LUMTest.Api.Models
{
    public class MaterialCommand
    {
       
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        [Required]
        public PhaseType TypeOfPhase { get; set; }

        public MaterialFunctionCommand MaterialFunction { get; set; }
    }
}
