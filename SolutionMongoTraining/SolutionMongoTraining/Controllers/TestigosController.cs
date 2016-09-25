using SolutionMongoTraining.Models;
using SolutionMongoTraining.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMongoTraining.Controllers
{
    class TestigosController
    {
        private TestigosProvider pInjector;

        public TestigosController()
        {
            pInjector = new TestigosProvider();
        }

        public bool InitColection()
        {
            TestigoModel pBuffer;
            for (int lCnt = 0; lCnt < 100; lCnt++)
            {
                pBuffer = new TestigoModel()
                {
                    lastUpdateTim = DateTime.Now,
                    source = "src " + lCnt.ToString(),
                    stack = Enumerable.Range(0, lCnt).ToList(),
                    testigoId = lCnt
                };
                pInjector.Add(pBuffer);
            }
            return true;
        }

        public List<TestigoModel> List()
        {
            return pInjector.List();
        }

        public bool DeleteLast()
        {
            return pInjector
                .Delete(pInjector
                    .List()
                    .Last()
                        .testigoId); 
        }
        public string findZipFromLatLon()
        {
            return pInjector.findZipFromLatLon(-3.8886827, 40.4896445);
        }
    }
    ///************************/
    //public async Task<TestigoModel> SearchCPByCoord(string lat, string lon)
    //{
    //    throw new NotImplementedException();
    //}

}
