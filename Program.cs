using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSVConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Modelo> datos = new List<Modelo>();
            using (StreamReader lector = new StreamReader("Archivo.csv"))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] columnas = linea.Split('|');
                    ModeloJson modeloJson = JsonConvert.DeserializeObject<ModeloJson>(columnas[1]);
                    datos.Add(new Modelo()
                    {
                        Id = columnas[0],
                        Campo1 = modeloJson.Campo1,
                        Campo2 = modeloJson.Campo2
                    });
                }
                foreach(var dato in datos)
                {
                    Console.WriteLine(dato.Id);
                    Console.WriteLine(dato.Campo1);
                    Console.WriteLine(dato.Campo2);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }       
    }

    public class Modelo
    {
        public string Id { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
    }

    public class ModeloJson
    {
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
    }
}
