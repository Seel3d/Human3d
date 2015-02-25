using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seel3d.Human3d.Object;

namespace Seel3d.Human3d.Loader
{
    public static class LoaderFactory
    {
        public static ILoader GetLoader(Export3DType type)
        {
            if (type == Export3DType.WaveFront)
            {
                return new WavefrontLoader();
            }
            return new Seel3dLoader();
        }

    }
}
