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
        public bool InitColection()
        {
            TestigosProvider pInjector = new TestigosProvider();

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
            TestigosProvider pInjector = new TestigosProvider();
            return pInjector.List();
        }
    }
    ///************************/
    //public async Task<TestigoModel> SearchCPByCoord(string lat, string lon)
    //{
    //    throw new NotImplementedException();
    //}

}
