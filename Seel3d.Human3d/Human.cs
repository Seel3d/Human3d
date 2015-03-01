using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seel3d.Human3d.Loader;
using Seel3d.Human3d.Object;
using Seel3d.Human3d.Spec;

namespace Seel3d.Human3d
{
    public class Human : ISpecies
    {
        #region Parametres 3d

        protected Object3D Object3D;

        #endregion

        #region Body

        public int Age { get; set; }

        public float Weight { get; set; }

        public float Height { get; set; }

        public IBody Body { get; set; }

        public Sex Sexe { get; set; }

        #endregion

        #region Measurements

        public Dictionary<string, double> Transformations { get; set; }

        #endregion

        #region Constructors

        public Human()
        {
            //Human("Assets/default.obj", Export3DType.WaveFront);

            Age = 25;
            Weight = 50;
            Height = 150;
            Sexe = Sex.Man;
            
            Object3D = new Object3D();
            Body = new HumanBody();
            Import("Assets/default.obj", Export3DType.WaveFront);
            Transformations = new Dictionary<string, double>();
        }

        public Human(string path, Export3DType type = Export3DType.WaveFront)
        {
            Import(path, type);
            Transformations = new Dictionary<string, double>();
        }

        #endregion

        public void Import(string path, Export3DType importType = Export3DType.WaveFront)
        {
            using (var loader = new WavefrontLoader())
            {
                Object3D = loader.Load(path) as Object3D;
            }
        }

        public void Export(string path, Export3DType exportType = Export3DType.WaveFront)
        {

            using (var loader = new WavefrontLoader())
            {
                loader.Save(Object3D, path);
            }
        }

        public void ApplyTransformation(Transformation transform, double coef)
        {
            Object3D.ApplyTransformation(transform, coef);
        }

        public void LaunchTransform(int height, int age, Sex sexe)
        {
            PrepareTransformations(height, age, sexe);
            ApplyTransformations();
        }

        private void PrepareTransformations(int height, int age, Sex sexe)
        {
            Transformations = new Dictionary<string, double>
            {
                {"age_body", (age - 25d)/(90d - 25d)},
                {"height_body", (height - 155d)/(194d - 155d)}
            };

            if (sexe == Sex.Woman)
            {
                Transformations.Add("sex_body", 1.0d);
            }

            //foreach (var measurement in Measurements.GetMeasurements())
            //{
            //    foreach (var measurementDetail in measurement)
            //    {
            //        double coeff = CalculateCoeff(measurementDetail.Key, measurementDetail.Value);
            //        string target = GetTarget(measurementDetail.Key, measurementDetail.Value);
            //        Transformations.Add(measurementDetail.Key, coeff);
            //    }
            //}
        }

        private int CalculateCoeff(string name, double value)
        {
            var basicBodyMeasurements = new Dictionary<string, double>
            {
                {"TopHead", 2.456},
                {"TopRightHead", 3.456},
                {"TopLeftHead", 3.456},
                {"RightEar", 839.116},
                {"RightJaw", 827.146},
                {"LeftJaw", 755.148},
                {"LeftEar", 740.116},
                {"test2", 3.456},
                {"test2", 3.456},
                {"test2", 3.456},
                {"test2", 3.456}


                //<string>RightNeck,826,174</string>
                //<string>LeftNeck,759,174</string>
                //<string>PectoralRight,887,315</string>
                //<string>PectoralLeft,692,315</string>
                //<string>BellyRight,870,394</string>
                //<string>BellyLeft,712,394</string>
                //<string>HipRight,891,494</string>
                //<string>HipLeft,692,494</string>
                //<string>L_TopArm,692,204</string>
                //<string>L_TopInteriorArm,687,301</string>
                //<string>L_BicepsInterior,661,322</string>
                //<string>L_BicepsExterior,640,250</string>
                //<string>L_ElbowExterior,598,315</string>
                //<string>L_ElbowInterior,638,350</string>
                //<string>L_ForearmExterior,547,365</string>
                //<string>L_ForearmInterior,585,394</string>
                //<string>L_WristExterior,518,404</string>
                //<string>L_WristInterior,550,418</string>
                //string>L_HandBottom,478,498</string>
                //<string>R_TopArm,891,204</string>
                //<string>R_TopInteriorArm,898,297</string>
                //<string>R_BicepsInterior,915,322</string>
                //<string>R_BicepsExterior,940,250</string>
                //<string>R_ElbowExterior,990,318</string>
                //<string>R_ElbowInterior,955,350</string>
                //<string>R_ForearmExterior,1041,365</string>
                //<string>R_ForearmInterior,998,394</string>
                //<string>R_WristExterior,1071,404</string>
                //<string>R_WristInterior,1037,418</string>
                //<string>R_HandBottom,1098,494</string>
                //<string>L_ButtExterior,680,573</string>
                //<string>L_ButtInterior,784,573</string>
                //<string>L_KneesExterior,671,742</string>
                //<string>L_KneesInterior,732,757</string>
                //<string>L_CalfExterior,665,890</string>
                //<string>L_CalfInterior,718,878</string>
                //<string>L_FeetBottom,677,1021</string>
                //<string>R_ButtExterior,902,573</string>
                //<string>R_ButtInterior,801,573</string>
                //<string>R_KneesExterior,907,730</string>
                //<string>R_KneesInterior,850,767</string>
                //<string>R_CalfExterior,921,875</string>
                //<string>R_CalfInterior,862,875</string>
                //<string>R_FeetBottom,904,1018</string>
            };

            return 1;
        }

        private string GetTarget(string name, double value)
        {
            return "test";
        }

        private void ApplyTransformations()
        {
            foreach (var tranformation in Transformations)
            {
                ApplyTransformation(TransformationLoader.Load(tranformation.Key) as Transformation, tranformation.Value);
            }
        }
    }
}
