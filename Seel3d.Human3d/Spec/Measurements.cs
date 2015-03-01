using System.Collections.Generic;

namespace Seel3d.Human3d.Spec
{
    public class Measurements
    {
        protected Dictionary<string, double> MeasurementList { get; set; }

        public Measurements()
        {
            MeasurementList = new Dictionary<string, double>();
        }

        public void AddMeasurement(string name, double value)
        {
            MeasurementList.Add(name, value);
        }

        public Dictionary<string, double> GetMeasurements()
        {
            return MeasurementList;
        }

        public double GetMeasurement(string key)
        {
            return MeasurementList[key];
        }
    }
}
