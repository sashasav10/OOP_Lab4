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
    public class Lumber : IXmlSerializable
    {
        //public Lumber(Wood wood, SawingOption sawingoption, DateTime dateOfDelivery, int marking, int quantity, int price)
        //{
        //    Wood = wood;
        //    SawingOption = sawingoption;
        //    DateOfDelivery = dateOfDelivery;
        //    Marking = marking;
        //    Quantity = quantity;
        //    Price = price;
        //}
        private SawingOption _sawingoption;
        private Wood _wood;
        private DateTime _dateOfDelivery;
        private int _marking;
        private int _quantity;
        private int _price;

        public SawingOption SawingOption
        {
            get
            {
                return _sawingoption;
            }
            set
            {
                _sawingoption = value;
            }
        }

        public Wood Wood
        {
            get
            {
                return _wood;
            }
            set
            {
                _wood = value ?? throw new ArgumentNullException("Данное поле не может быть пустым");

            }
        }

        public DateTime DateOfDelivery
        {
            get
            {
                return _dateOfDelivery;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    _dateOfDelivery = value;

                }
                else throw new ArgumentException("Неправильная дата поставки");
            }
        }

        public int Marking
        {
            get
            {
                return _marking;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Маркировка не может быть отрицательной или равняться нулю");
                }
                else
                {
                    _marking = value;
                }
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количство не может быть меньше 0");
                }
                else
                {
                    _quantity = value;
                }
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Цена не может быть меньше 0");
                }
                else
                {
                    _price = value;
                }
            }
        }
        public override string ToString()
        {
            return $"Порода {Wood.Breed}, влажность {Wood.Humidity}, плотность {Wood.Density}, вид {SawingOption}, маркировка {Marking}, {Quantity} шт., {Price} грн/шт";
        }

        //public object Clone()
        //{
        //    var woodClone = Wood.Clone() as Wood;
        //    return new Lumber(woodClone, SawingOption, DateOfDelivery, Marking, Quantity, Price);
        //}
        public static List<Lumber> ReadWoodsList(XmlReader reader)
        {
            List<Lumber> lumbers = new List<Lumber>();
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.IsStartElement() && !reader.Name.Equals("Lumbers"))
                {
                    Lumber lumber = new Lumber();
                    lumber.ReadXml(reader);
                    lumbers.Add(lumber);
                }
                else
                {
                    break;
                }

            }
            return lumbers;
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
                        case "Wood":
                            _wood = new Wood();
                            _wood.ReadXml(reader);
                            break;

                        case "SawingOption":
                            reader.Read();
                            _sawingoption = (SawingOption)Enum.Parse(typeof(SawingOption), reader.Value);
                            break;

                        case "DateOfDelivery":
                            reader.Read();
                            _dateOfDelivery = DateTime.Parse(reader.Value);
                            break;

                        case "Marking":
                            reader.Read();
                            _marking = Int32.Parse(reader.Value);
                            break;
                        case "Quantity":
                            reader.Read();
                            _quantity = Int32.Parse(reader.Value);
                            break;
                        case "Price":
                            reader.Read();
                            _price = Int32.Parse(reader.Value);
                            break;
                    }
                }

                if (reader.Name.Equals("Lumber"))
                {
                    break;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Lumber");
            _wood.WriteXml(writer);
            writer.WriteElementString("SawingOption", _sawingoption.ToString());
            writer.WriteElementString("DateOfDelivery", _dateOfDelivery.ToString());
            writer.WriteElementString("Marking", _marking.ToString());
            writer.WriteElementString("Quantity", _quantity.ToString());
            writer.WriteElementString("Price", _price.ToString());
            writer.WriteEndElement();
        }
        public static void WriteLumbersToFile(string fileName, List<Lumber> woods)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = true;
            settings.ConformanceLevel = ConformanceLevel.Auto;

            XmlWriter xmlWriter = XmlWriter.Create(fileName, settings);
            xmlWriter.WriteStartElement("Lumbers");
            woods.ForEach(lumber =>
            {
                lumber.WriteXml(xmlWriter);
            });
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
        
    }
}
