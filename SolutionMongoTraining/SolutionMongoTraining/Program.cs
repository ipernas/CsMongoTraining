using SolutionMongoTraining.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMongoTraining
{
    class Program
    {
        static int Main(string[] args)
        {
            TestigosController pCont = new TestigosController();

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        pCont.InitColection();
                        Console.WriteLine("***** Se ha rellenado la colección...");
                        break;
                    case 2:
                        var pList = pCont.List();
                        foreach (var it in pList)
                        {
                            Console.WriteLine(it.testigoId.ToString() + " " + it.source);
                        }
                        break;
                    case 3:
                        pCont.DeleteLast();
                        Console.WriteLine("***** Se ha eliminado de la colección...");
                        break;
                    case 4:
                        var sRes = pCont.findZipFromLatLon();
                        Console.WriteLine("***** El Cp es:" + sRes);
                        break;
                    default:
                        break;
                }
            } while (userInput != 9);


            return 0;
        }

        static private int DisplayMenu()
        {
            Console.WriteLine("Mongo Training - Qare");
            Console.WriteLine();
            Console.WriteLine("1. Rellenar la colección");
            Console.WriteLine("2. Listar elementos");
            Console.WriteLine("3. Borrar el último elemento ");
            Console.WriteLine("4. Localizar el CP de las coordenadas [-3.8886827, 40.4896445]");

            Console.WriteLine("9. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
