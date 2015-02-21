using System.Collections.Generic;

namespace Seel3d.Human3d.Part
{
    public class Face
    {
        public List<FaceVertex> Vertices { get; set; }

        public Face()
        {
            Vertices = new List<FaceVertex>();
        }
    }
}
