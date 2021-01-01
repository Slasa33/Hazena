using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DataLayer.Abstract;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DataLayer.XML
{
    public class HraciXML : IHraci
    {

        private static void SerializeToXml<T>(T obj, string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {

                var ser = new XmlSerializer(typeof(T));
                ser.Serialize(fileStream, obj);
            }
        }

        public static string GetContentOfXML(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            string content;
            content = File.ReadAllText(path);
            return content;
        }

        public static T DeserializeFromXml<T>(string xml) where T : class
        {
            if (xml == null) return null;
            T result;
            var ser = new XmlSerializer(typeof(T));
            using (var tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }

        public Hraci SelectHeslo(string rodne_cislo, string heslo)
        {
            List<Hraci> hraci = DeserializeFromXml<List<Hraci>>(GetContentOfXML("hraci.xml"));
            foreach(var hrac in hraci)
            {
                if (hrac.rodne_cislo == rodne_cislo && hrac.heslo == heslo) return hrac;
            }
            return null;
        }

        public Hraci SelectId(int id)
        {
            List<Hraci> hraci = DeserializeFromXml<List<Hraci>>(GetContentOfXML("hraci.xml"));
            foreach (var hrac in hraci)
            {
                if (hrac.hID == id) return hrac;
            }
            return null;
        }

        public IEnumerable<Hraci> SelectHraci(int id)
        {
            List<Hraci> hraci = DeserializeFromXml<List<Hraci>>(GetContentOfXML("hraci.xml"));
            hraci = hraci.Where(x => x.klub_kID == id).ToList();
            return hraci;
        }

        public int Insert(ITableItem item)
        {
            Hraci hrac = (Hraci)item;
            List<Hraci> hraci;
            List<Hraci> temp = DeserializeFromXml<List<Hraci>>(GetContentOfXML("hraci.xml"));
            hraci = temp ?? new List<Hraci>();
            int id;
            if (hraci.Count > 0)
            {
                id = hraci.Last().hID + 1;
            }
            else id = 1;
            hrac.hID = id;
            hraci.Add(hrac);
            SerializeToXml(hraci, "hraci.xml");
            return 0;
        }

        public int Update(ITableItem item)
        {
            Hraci hrac = (Hraci)item;
            List<Hraci> hraci;
            List<Hraci> temp = DeserializeFromXml<List<Hraci>>(GetContentOfXML("hraci.xml"));
            hraci = temp ?? new List<Hraci>();
            for (int i = 0; i < hraci.Count; i++)
            {
                if (hraci[i].hID == hrac.hID) hraci.RemoveAt(i);
            }
            hraci.Add(hrac);
            hraci = hraci.OrderBy(x => x.hID).ToList();
            SerializeToXml(hraci, "hraci.xml");
            return 0;
        }

        public int Delete(ITableItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}
