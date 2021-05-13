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
    public class Wood : IXmlSerializable
    {
        private string _breed;
        private int _humidity;
        private int _density;

        //public Wood(string breed, int humidity, int density)
        //{
        //    Breed = breed;
        //    Humidity = humidity;
        //    Density = density;
        //}
        public override string ToString()
        {
            return $"{Breed}, {Humidity} %, {Density}";
        }

        //public object Clone()
        //{
        //    return new Wood(Breed, Humidity, Density);
        //}


        public string Breed
        {
            get
            {
                return _breed;
            }
            set
            {
                _breed = value ?? throw new ArgumentNullException("Данное поле не может быть пустым");

            }
        }

        public int Humidity
        {
            get
            {
                return _humidity;
            }
            set
            {
                if (value < 100 || value > 0)
                {
                    _humidity = value;
                }
                else throw new ArgumentException("Влажность должна быть в пределе от 0 до 100");
            }
        }

        public int Density
        {
            get
            {
                return _density;
            }
            set
            {
                if (value > 1)
                {
                    _density = value;
                }
                else throw new ArgumentException("Плотность не может быть меньше 1");
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "Breed":
                            reader.Read();
                            _breed = reader.Value;
                            break;
                        case "Humidity":
                            reader.Read();
                            _humidity = Int32.Parse(reader.Value);
                            break;
                        case "Density":
                            reader.Read();
                            _density = Int32.Parse(reader.Value);
                            break;
                    }
                }

                if (reader.Name.Equals("Wood"))
                {
                    break;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Wood");
            writer.WriteElementString("Breed", _breed);
            writer.WriteElementString("Humidity", _humidity.ToString());
            writer.WriteElementString("Density", _density.ToString());
            writer.WriteEndElement();
        }
        public static List<Wood> ReadWoodsList(string fileName)
        {
            List<Wood> woods = new List<Wood>();
            if (File.Exists(fileName))
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    reader.MoveToContent();
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && !reader.Name.Equals("Woods"))
                        {
                            Wood wood = new Wood();
                            wood.ReadXml(reader);
                            woods.Add(wood);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return woods;
        }
        public static void WriteWoodsToFile(string fileName, List<Wood> woods)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = true;
            settings.ConformanceLevel = ConformanceLevel.Auto;

            XmlWriter xmlWriter = XmlWriter.Create(fileName, settings);
            xmlWriter.WriteStartElement("Woods");
            woods.ForEach(wood =>
            {
                wood.WriteXml(xmlWriter);
            });
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
        


    }
}
