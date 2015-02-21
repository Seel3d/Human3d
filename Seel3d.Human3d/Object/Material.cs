using System.Collections.Generic;
using Seel3d.Human3d.Loader;
using Seel3d.Human3d.Part;

namespace Seel3d.Human3d.Object
{
    public class Material : ILoadable
    {
        public string Name { get; set; }

        public string MapKd { get; set; }

        public string MapD { get; set; }

        public int D { get; set; }

        public string Kd { get; set; }

        public string Ks { get; set; }

        public Material()
        {
        }
    }
}
