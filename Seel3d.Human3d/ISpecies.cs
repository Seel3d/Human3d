using Seel3d.Human3d.Object;
using Seel3d.Human3d.Spec;

namespace Seel3d.Human3d
{
    public interface ISpecies
    {
        int Age { get; set; }
        float Weight { get; set; }
        float Height { get; set; }
        IBody Body { get; set; }
        Sex Sexe { get; set; }
        void Import(string path, Export3DType importType = Export3DType.WaveFront);
        void Export(string path, Export3DType exportType = Export3DType.WaveFront);
        void ApplyTransformation(Transformation transform, double coef);
        void LaunchTransform(int height, int age, Sex sexe);
    }
}