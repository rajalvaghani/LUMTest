using System;
using System.Text.Json.Serialization;

namespace LUMTest.Domain
{
    public class Material
    {        
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public bool IsVisible { get; protected set; }
        public PhaseType TypeOfPhase { get; protected set; }
        public MaterialFunction MaterialFunction { get; protected set; }
    }

    public enum PhaseType
    {
        Solid,
        Liquid
    }
}
