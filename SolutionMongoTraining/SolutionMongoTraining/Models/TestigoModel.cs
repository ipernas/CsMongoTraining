using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMongoTraining.Models
{
    class TestigoModel
    {
        public TestigoModel()
        {
            stack = new List<int>();
        }

        public MongoDB.Bson.BsonObjectId id { get; set; }

        public int testigoId { get; set; }

        public string source { get; set; }

        public DateTime? lastUpdateTim { get; set; }

        public List<int> stack { get; set; }
    }
}
