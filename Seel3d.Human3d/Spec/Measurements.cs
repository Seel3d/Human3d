using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seel3d.Human3d
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
