using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;


namespace TratandoString
{

    //public class Teste
    //{
    //    public int Idteste { get; set; }
    //    public string NomeTeste { get; set; }
    //    public double ValorTeste { get; set; }
    //}


    public class Conversoes
    {

        ///// <summary>
        ///// Apenas para teste
        ///// </summary>
        //static void Main()
        //{
        //    var teste = new Teste();

        //    teste.Idteste = 0;
        //    teste.NomeTeste = "Teste";
        //    teste.ValorTeste = 100.0;

        //    Conversoes c = new Conversoes();

        //    var testeXml = c.ObjectToXml<Teste>(teste);
        //    var testeJson = c.ObjectToJson<Teste>(teste);

        //    teste = c.XmlToObject<Teste>(testeXml);
        //    teste = c.JsonToObject<Teste>(testeJson);
        //}


        /// <summary>
        /// Este método recebe um Objecto e retorna o mesmo objeto em Formato Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public string ObjectToXml<T>(T objeto)
        {
            MemoryStream oStream = new MemoryStream();
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            serializador.Serialize(oStream, objeto);
            string retorno = Encoding.UTF8.GetString(oStream.ToArray());
            return retorno;
        }


        /// <summary>
        /// Este método recebe um Xml e transforma o mesmo em um Object correspondente
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Xml"></param>
        /// <returns></returns>
        public T XmlToObject<T>(string Xml)
        {

            MemoryStream oStream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));
            XmlSerializer deserializador = new XmlSerializer(typeof(T));
            T retorno = (T)deserializador.Deserialize(oStream);
            return retorno;
        }

        /// <summary>
        /// Este método recebe um Objeto e retorna o mesmo objeto em formato Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public string ObjectToJson<T>(T objeto)
        {
            MemoryStream oStream = new MemoryStream();
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(T));
            serializador.WriteObject(oStream, objeto);
            string retorno = Encoding.UTF8.GetString(oStream.ToArray());
            return retorno;
        }


        /// <summary>
        /// Este método recebe um string Json e retorna o objeto deste Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T JsonToObject<T> (string json)
        {

            MemoryStream oStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer deserializador = new DataContractJsonSerializer(typeof(T));
            T retorno = (T)deserializador.ReadObject(oStream);
            return retorno;

        }

    }
}




