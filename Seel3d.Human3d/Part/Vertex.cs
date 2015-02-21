namespace Seel3d.Human3d.Part
{
    public class Vertex
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Vertex(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vertex()
        {
        }

        public Vertex Add(Vertex toAdd)
        {
            return new Vertex
            {
                X = X + toAdd.X,
                Y = Y + toAdd.Y,
                Z = Z + toAdd.Z
            };
        }

        public Vertex AddFactor(double factor)
        {
            return new Vertex
            {
                X = X * factor,
                Y = Y * factor,
                Z = Z * factor
            };
        }
    }
}

