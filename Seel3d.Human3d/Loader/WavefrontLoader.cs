using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Seel3d.Human3d.Object;
using Seel3d.Human3d.Part;

namespace Seel3d.Human3d.Loader
{
    public class WavefrontLoader : ILoader
    {
        private static IEnumerable<string> ObjHeader
        {
            get
            {
                return new List<string>
				{
					"#",
					"# Exported 3d model ",
					"#",
					"# Made by Seel3d (c)",
					"# For more informations visit www.seel3d.com",
					"# Or contact aurelien.souchet@epitech.eu ",
					"#"
				};
            }
        }

        #region ILoader implementation

        public void Save(ILoadable toLoad, Stream stream)
        {
            var obj = toLoad as Object3D;
            using (var file = new StreamWriter(stream))
            {
                foreach (var line in ObjHeader)
                {
                    file.WriteLine(line);
                }
                file.WriteLine();
                file.WriteLine("# Material lib");
                foreach (var material in obj.MaterialLibNames)
                {
                    file.WriteLine(GetMaterialLine(material));
                }
                file.WriteLine();
                file.WriteLine("# Vertices");
                foreach (var vertex in obj.Vertices)
                {
                    file.WriteLine(GetVertexLine(vertex));
                }
                file.WriteLine();
                file.WriteLine("# Coords");
                foreach (var coord in obj.Coords)
                {
                    file.WriteLine(GetCoordLine(coord));
                }
                file.WriteLine();
                file.WriteLine("# Faces");
                file.WriteLine();
                foreach (var group in obj.Groups)
                {
                    file.WriteLine("g " + group.Name);
                    file.WriteLine();
                    if (group.Material != null)
                    {
                        file.WriteLine("usemtl " + group.Material.Name);
                    }
                    foreach (var face in group.Faces)
                    {
                        var faceBuilder = new StringBuilder();
                        faceBuilder.Append("f");
                        foreach (var faceVertex in face.Vertices)
                        {
                            faceBuilder.Append(" ");
                            faceBuilder.Append(faceVertex.VertexIndex);
                            faceBuilder.Append("/");
                            if (faceVertex.TextureIndex != 0)
                            {
                                faceBuilder.Append(faceVertex.TextureIndex);
                            }
                            if (faceVertex.NormalIndex != 0)
                            {
                                faceBuilder.Append("/");
                                faceBuilder.Append(faceVertex.NormalIndex);
                            }
                        }
                        file.WriteLine(faceBuilder.ToString());
                    }
                    file.WriteLine();
                }
            }
        }

        public ILoadable Load(StreamReader sr)
        {
            var loadedObj = new Object3D();
	        string line = null;

	        while ((line = sr.ReadLine()) != null)
	        {
		        if (line.StartsWith("#") || String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
		        {
			        continue;
		        }

                if (line.StartsWith("mtllib "))
                {
                    loadedObj.MaterialLibNames.Add(ParseMaterial(line.Remove(0, 7)));
                }
                else if (line.StartsWith("vt "))
                {
                    loadedObj.Coords.Add(ParseCoord(line.Remove(0, 3)));
                }
                else if (line.StartsWith("v "))
                {
                    loadedObj.Vertices.Add(ParseVertex(line.Remove(0, 2)));
                }
                else if (line.StartsWith("g "))
                {
                    loadedObj.Groups.Add(ParseGroup(line.Remove(0, 2)));
                }
                else if (line.StartsWith("usemtl "))
                {
                    // todo 
                    // parser .mtl file
                    //obj.Groups.Last().Material = new Material(ParseMaterial(line.Remove(0, 6)));
                    //loadedObj.MaterialLibNames.Add(line.Remove(0, 7));
                    loadedObj.Groups.Last().Material = new Material
                    {
                        Name = line.Remove(0, 7)
                    };
                }
                else if (line.StartsWith("f "))
                {
                    loadedObj.Groups.Last().Faces.Add(ParseFace(line.Remove(0, 2)));
                }
                else if (line.StartsWith("s ") || line.StartsWith("o "))
                {
                    // Tolerating s and o param to make it blender compliant
                }
                else
                {
                    throw new Exception("Got a problem when parsing file, line is: " + line);
                }  
	        }

            return loadedObj;
        }

        #endregion

        private string GetMaterialLine(string mat)
        {
            var materialBuilder = new StringBuilder();
            materialBuilder.Append("mtllib ");
            materialBuilder.Append(mat);
            return materialBuilder.ToString();
        }

        private string GetVertexLine(Vertex vtx)
        {
            var vertexBuilder = new StringBuilder();
            vertexBuilder.Append("v ");
            vertexBuilder.AppendFormat("{0:0.0000}", vtx.X, CultureInfo.InvariantCulture);
            vertexBuilder.Append(" ");
            vertexBuilder.AppendFormat("{0:0.0000}", vtx.Y, CultureInfo.InvariantCulture);
            vertexBuilder.Append(" ");
            vertexBuilder.AppendFormat("{0:0.0000}", vtx.Z, CultureInfo.InvariantCulture);
            return vertexBuilder.ToString().Replace(",", ".");
        }

        private string GetCoordLine(Coord coord)
        {
            var coordBuilder = new StringBuilder();
            coordBuilder.Append("vt ");
            coordBuilder.Append(coord.U.ToString("0.0000", CultureInfo.InvariantCulture));
            coordBuilder.Append(" ");
            coordBuilder.Append(coord.V.ToString("0.0000", CultureInfo.InvariantCulture));
            coordBuilder.Append(" ");
            coordBuilder.Append(coord.W.ToString("0.0000", CultureInfo.InvariantCulture));
            return coordBuilder.ToString();
        }

        private Coord ParseCoord(string line)
        {
            var coords = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var coordRes = new Coord
            {
                U = Convert.ToDouble(coords[0], CultureInfo.InvariantCulture),
                V = Convert.ToDouble(coords[1], CultureInfo.InvariantCulture),
            };
            if (coords.Length > 2)
            {
                coordRes.W = Convert.ToDouble(coords[2]);
            }
            return coordRes;
        }

        private Vertex ParseVertex(string line)
        {
            var vertices = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return (new Vertex
            {
                X = Convert.ToDouble(vertices[0], CultureInfo.InvariantCulture),
                Y = Convert.ToDouble(vertices[1], CultureInfo.InvariantCulture),
                Z = Convert.ToDouble(vertices[2], CultureInfo.InvariantCulture)
            });
        }

        private string ParseMaterial(string line)
        {
            return (line.Trim().Replace(".mtl", ""));
        }

        private Group ParseGroup(string line)
        {
            return new Group(line.Trim());
        }

        private Face ParseFace(string line)
        {
            var faces = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var face = new Face();
            foreach (var faceVertex in faces)
            {
                var facevertexPart = faceVertex.Split(new[] { '/' }, StringSplitOptions.None);
                var faceVtex = new FaceVertex(Convert.ToInt32(facevertexPart[0]), 0, 0);
                if (facevertexPart.Length > 1)
                {
                    if (facevertexPart[1].Length != 0)
                    {
                        faceVtex.TextureIndex = Convert.ToInt32(facevertexPart[1]);
                    }
                }
                if (facevertexPart.Length > 2)
                {
                    if (facevertexPart[2].Length != 0)
                    {
                        faceVtex.TextureIndex = Convert.ToInt32(facevertexPart[2]);
                    }
                }
                face.Vertices.Add(faceVtex);
            }
            return face;
        }
    }
}
