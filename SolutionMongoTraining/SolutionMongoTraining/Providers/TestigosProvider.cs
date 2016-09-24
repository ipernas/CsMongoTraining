using MongoDB.Driver;
using SolutionMongoTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMongoTraining.Providers
{
    class TestigosProvider
    {
        private const string DATABASE_NAME = "DBTraining";
        private const string COLLECTION_NAME = "ColTraining";

        private MongoClient dbMongoClient;
        private IMongoDatabase dbMongoDb;
        private IMongoCollection<TestigoModel> dbMongoCollection;

        public TestigosProvider()
        {
            /* Configuración para la conexión */
            dbMongoClient = new MongoClient(/* Aquí va la cadena de conexión*/);
            /* Apuntar a la base de datos */
            dbMongoDb = dbMongoClient.GetDatabase(DATABASE_NAME);
            /* Apuntar a la colección o crearla si no existe */
            dbMongoCollection = dbMongoDb.GetCollection<TestigoModel>(COLLECTION_NAME);
        }

        public bool Add(TestigoModel pNew)
        {
            try
            {
                /* Inserción en la colección*/
                dbMongoCollection.InsertOne(pNew);
            }
            catch (Exception err) {
                throw err;
            }
            return true;
        }
        public List<TestigoModel> List()
        {
            /* Inserción en la colección*/
            var lstRet = dbMongoCollection
                                .AsQueryable<TestigoModel>()
                                .Where(x => true)
                                .Select(x => x).ToList();
            return lstRet;
        }
        public async Task<TestigoModel> Update(string source)
        {
            throw new NotImplementedException();
        }
        public async Task<TestigoModel> Delete(string source)
        {
            throw new NotImplementedException();
        }
    }
}
