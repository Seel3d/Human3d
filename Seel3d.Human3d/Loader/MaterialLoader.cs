using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Seel3d.Human3d.Object;

namespace Seel3d.Human3d.Loader
{
    public class MaterialLoader : ILoader
    {
        public static List<string> MtlHeader
        {
            get
            {
                return new List<string>
			    {
			        "#",
			        "# Exported material ",
			        "#",
			        "# Made by Seel3d (c)",
			        "# For more informations visit www.seel3d.com",
			        "# Or contact aurelien.souchet@epitech.eu ",
			        "#"
			    };
            }
        }

        #region ILoader implementation

        public ILoadable Load(StreamReader sr)
        {
            var newMaterial = new Material();
	        string line = null;

            while (line = sr.ReadLine() != null)
	        {
		        if (line.StartsWith("#") || String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
		        {
			        continue;
		        }

                if (line.StartsWith("newmtl"))
                {
                    newMaterial.Name = line.Remove(0, 7);
                }
                else if (line.StartsWith("Kd"))
                {
                    newMaterial.Kd = line.Remove(0, 3);
                }
                else if (line.StartsWith("Ks"))
                {
                    newMaterial.Ks = line.Remove(0, 3);
                }
                else if (line.StartsWith("d"))
                {
                    newMaterial.D = Convert.ToInt32(line.Remove(0, 2));
                }
                else if (line.StartsWith("map_Kd"))
                {
                    newMaterial.MapKd = line.Remove(0, 7);
                }
                else if (line.StartsWith("map_D"))
                {
                    newMaterial.MapD = line.Remove(0, 6);
                }
                else
                {
                    throw new Exception("Got a problem when parsing file, line is: " + line);
                }
	        }

            return newMaterial;
        }

        public void Save(ILoadable toSave, Stream stream)
        {
            var material = toSave as Material;
            if (material != null)
            {
                using (StreamWriter file = new StreamWriter(stream))
                {
                    foreach (var line in MtlHeader)
                    {
                        file.WriteLine(line);
                    }

                    file.WriteLine("newmtl {0}", material.Name);
                    file.WriteLine("Kd {0}", material.Kd);
                    file.WriteLine("Ks {0}", material.Ks);
                    file.WriteLine("d {0}", material.D);
                    file.WriteLine("map_Kd {0}", material.MapKd);
                    file.WriteLine("map_D {0}", material.MapD);
                }
            }
        }

        #endregion
    }
}
