using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seel3d.Human3d.Object;

namespace Seel3d.Human3d.Loader
{
    public interface ILoader : IDisposable
    {
        ILoadable Load(string name);

        void Save(ILoadable toSave, string path);
    }
}
