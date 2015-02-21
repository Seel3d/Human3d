using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seel3d.Human3d.Object;

namespace Seel3d.Human3d.Loader
{
    public interface ILoader
    {
        ILoadable Load(StreamReader sr);

        void Save(ILoadable toSave, Stream stream);
    }
}
