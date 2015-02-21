using System;
using System.IO;
using System.Linq;
using Seel3d.Human3d.Object;
using Seel3d.Human3d.Part;

namespace Seel3d.Human3d.Loader
{
    public class TransformationLoader : ILoader
    {
        #region ILoader implementation

        public static ILoadable Load(StreamReader sr)
        {
            //todo change
	        string name = "test";
            var newTransformation = new Transformation(name);

            // var _strAppDir = AppDomain.CurrentDomain.RelativeSearchPath;
	        var _strAppDir = ".";  

            string path = String.Format(@"{0}\Targets\{1}.target", _strAppDir, name);

            string line = 





            foreach (var values in sr.ReadLine(path)
                .Where(line => !line.StartsWith("#") && !String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(values => values.Length >= 4))
            {
                newTransformation.Translations.Add(Convert.ToInt32(values[0]), new Vertex
                {
                    X = Convert.ToDouble(values[1].Replace(".", ",")),
                    Y = Convert.ToDouble(values[2].Replace(".", ",")),
                    Z = Convert.ToDouble(values[3].Replace(".", ","))
                });
            }
            return newTransformation;
        }

        ILoadable ILoader.Load(StreamReader sr)
        {
            return Load(sr);
        }

        public void Save(ILoadable toSave, Stream stream)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}