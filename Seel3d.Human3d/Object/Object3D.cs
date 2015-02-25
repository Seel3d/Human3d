using System.Collections.Generic;
using Seel3d.Human3d.Part;

namespace Seel3d.Human3d.Object
{
    public class Object3D : ILoadable
    {
        public List<Vertex> Vertices { get; set; }

        public List<Coord> Coords { get; set; }

        public Dictionary<string, Material> Materials { get; set; }

        public List<string> MaterialLibNames { get; set; }

        public List<Group> Groups { get; set; }

        public Object3D()
        {
            Vertices = new List<Vertex>();
            Coords = new List<Coord>();
            MaterialLibNames = new List<string>();
            Groups = new List<Group>();
			Materials = new Dictionary<string, Material>();
        }

		public void ApplyTransformation(Transformation toApply, double factor = 0.5)
		{
			foreach (var translation in toApply.Translations)
			{
			    var index = translation.Key;
			    var toAddVertex = translation.Value.AddFactor(factor);
			    if (index < Vertices.Count)
			    {
			        var originalVertex = Vertices[index];
			        Vertices[translation.Key] = Vertices[index].Add(toAddVertex);
			    }
			}
		}
    }
}
