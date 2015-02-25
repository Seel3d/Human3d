using System.Collections.Generic;
using Seel3d.Human3d.Part;

namespace Seel3d.Human3d.Object
{
    public class Transformation : ILoadable
    {
        public string Name { get; set; }

        public Dictionary<int, Vertex> Translations { get; set; }

        public Transformation(string name)
        {
            Name = name;
            Translations = new Dictionary<int, Vertex>();
        }
    }
}
