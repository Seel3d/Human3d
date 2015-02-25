using System.Collections.Generic;

namespace Seel3d.Human3d.Spec
{
    public class Measurements
    {
        protected List<Dictionary<string, double>> MeasurementList { get; set; }

        public Measurements()
        {
            MeasurementList = new List<Dictionary<string, double>>();
        }

        public void AddMeasurement(Dictionary<string, double> measurement)
        {
            MeasurementList.Add(measurement);
        }

        public List<Dictionary<string, double>> GetMeasurements()
        {
            return MeasurementList;
        }
    }
}
