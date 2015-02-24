using System.Collections.Generic;
using Seel3d.Human3d.Object;

namespace Seel3d.Human3d.Part
{
    public class Group
    {
        public List<Face> Faces { get; set; }

        public Material Material { get; set; }

        public string Name { get; set; }

        public Group(string name = "default")
        {
            Name = name;
            Faces = new List<Face>();
        }
    }
}
