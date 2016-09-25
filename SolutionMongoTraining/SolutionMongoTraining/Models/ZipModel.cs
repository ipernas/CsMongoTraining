using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMongoTraining.Models
{
    public class GeoZipModel
    {
        public MongoDB.Bson.ObjectId id { get; set; }

        public string zipId { get; set; }
        public string zipCode { get; set; }
        public string WKT { get; set; }

        public GeoPolygonMongoModel geometry { get; set; }

    }

    public class GeoPolygonMongoModel
    {
        public string type { get; set; }
        public List<List<double[]>> coordinates { get; set; }
    }

}
