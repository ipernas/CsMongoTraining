using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
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
        public bool Delete(int testigoId)
        {
            var delres = dbMongoCollection.DeleteOne(x => x.testigoId == testigoId);
            return delres.IsAcknowledged;
        }

        /* *********************************************** */
        public string findZipFromLatLon(double Lon /*-3*/, double Lat /*40*/)
        {
            try
            {
                var dbMongoClientGeo = new MongoClient(/* Aquí va la cadena de conexión*/);
                var dbMongoDbGeo = dbMongoClientGeo.GetDatabase("GEO");
                var dbMongoCollectionGeo = dbMongoDbGeo.GetCollection<GeoZipModel>("GeoZipMadrid");

                /* Se pasa el punto de longitud y latitud a un objeto punto */
                var point = GeoJson.Point(GeoJson.Geographic(Lon, Lat));

                /* Se crea una query (linq no vale para geo en mongo) y se buscan los polígonos que intersecan con el punto */
                var qBuilderZip = Builders<GeoZipModel>.Filter.GeoIntersects("geometry", point);
                var pZip = dbMongoCollectionGeo.Find(qBuilderZip).FirstOrDefault();
                if (pZip != null)
                    return pZip.zipCode;
                else
                    return "???";
            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}
