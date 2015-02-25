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

        public static ILoadable Load(string name)
        {
            var newTransformation = new Transformation(name);

            var strAppDir = AppDomain.CurrentDomain.RelativeSearchPath;

            string path = String.Format(@"{0}\Targets\{1}.target", strAppDir, name);

            foreach (var values in File.ReadLines(path)
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

        ILoadable ILoader.Load(string name)
        {
            return Load(name);
        }

        public void Save(ILoadable toSave, string path)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            
        }
    }
}