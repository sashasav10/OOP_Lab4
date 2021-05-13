using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lab4_OOP
{
    public class Workshop : IXmlSerializable
    {
        private int _count;
        private List<Lumber> _lumbers = new List<Lumber>();
        public static int countObjects = 0;
        private int totalLumberPrice = 0;

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;

            }
        }
        public List<Lumber> Lumbers
        {
            get
            {
                return _lumbers;
            }
            set
            {
                _lumbers = value;

            }
        }
        public int TotalLumberPrice
        {
            get
            {
                return totalLumberPrice;
            }
            set
            {
                totalLumberPrice = value;

            }
        }
        public int CountObjects
        {
            get
            {
                return countObjects;
            }
            set
            {
                countObjects = value;

            }
        }

        public void AddLumber(Lumber lumber)
        {
            _lumbers.Add(lumber);
        }
        public void RemoveLumber(Lumber lumber)
        {
            _lumbers.Remove(lumber);
        }
        public void ClearLumbers()
        {
            _lumbers.Clear();
        }
        public void CalculateTotalPrice()
        {
            totalLumberPrice = 0;
            if (_lumbers != null)
            {
                _lumbers.ForEach(lumber =>
                {
                    totalLumberPrice += (lumber.Quantity * lumber.Price);
                });
                countObjects = _lumbers.Count;
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "Count":
                            reader.Read();
                            _count = Int32.Parse(reader.Value);
                            break;
                        case "Lumbers":
                            _lumbers = Lumber.ReadWoodsList(reader);
                            CalculateTotalPrice();
                            break;
                    }
                }
                if (reader.Name.Equals("Workshop"))
                {
                    break;
                }
            }
        }
        public static List<Workshop> ReadWorkshopList(string fileName)
        {
            List<Workshop> workshops = new List<Workshop>();
            if (File.Exists(fileName))
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    reader.MoveToContent();
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && !reader.Name.Equals("Workshops"))
                        {
                            Workshop workshop = new Workshop();
                            workshop.ReadXml(reader);
                            workshops.Add(workshop);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return workshops;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Workshop");
            writer.WriteElementString("Count", _count.ToString());
            writer.WriteStartElement("Lumbers");
            if (Lumbers != null)
            {
                Lumbers.ForEach(lumber =>
                {
                    lumber.WriteXml(writer);
                });
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public static void WriteWorkshopsToFile(string fileName, List<Workshop> workshops)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = true;
            settings.ConformanceLevel = ConformanceLevel.Auto;

            XmlWriter xmlWriter = XmlWriter.Create(fileName, settings);
            xmlWriter.WriteStartElement("Workshops");
            workshops.ForEach(journal =>
            {
                journal.WriteXml(xmlWriter);
            });
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        public override string ToString()
        {
            return $"Номер: {_count}\n Общая стоимость товаров: {totalLumberPrice} \nКоличество объектов: {countObjects}";
        }

        public string ToShortString()
        {
            return $"Номер: {_count} Общая стоимость товаров: {totalLumberPrice}";
        }
        
    }
}
