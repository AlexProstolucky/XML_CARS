using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace xml
{
    internal class Program
    {
        public static void print_xml(string filename)
        {
            XmlTextReader reader = null;

            try
            {


                reader = new XmlTextReader(filename);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                string counter = "";
                while (reader.Read())
                {

                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.Write(counter);
                            Console.WriteLine("<{0}>", reader.Name);
                            counter += "  ";
                            break;
                        case XmlNodeType.Text:
                            Console.Write(counter);
                            Console.WriteLine(reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            Console.Write(counter);
                            Console.WriteLine("<![CDATA[{0}]]>", reader.Value);
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            Console.Write(counter);
                            Console.WriteLine("<?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.Write(counter);
                            Console.WriteLine("<!--{0}-->", reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                            Console.Write(counter);
                            Console.WriteLine("<?xml version='1.0'?>");
                            break;
                        case XmlNodeType.Document:
                            Console.Write(counter);
                            break;
                        case XmlNodeType.DocumentType:
                            Console.Write(counter);
                            Console.WriteLine("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.EntityReference:
                            Console.Write(counter);
                            Console.WriteLine(reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            counter = counter.Remove(0, 2);
                            Console.Write(counter);
                            Console.WriteLine("</{0}>", reader.Name);
                            break;
                    }
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        static void Main(string[] args)
        {
            XmlTextWriter Wr = null;
            Wr = new XmlTextWriter("auto.xml", System.Text.Encoding.UTF8);
            Wr.Formatting = Formatting.Indented;
            Wr.WriteStartDocument();
            Wr.WriteStartElement("Запити");

            Wr.WriteStartElement("Запит1");

            Wr.WriteStartElement("Авто1");
            Wr.WriteAttributeString("Вигляд", "500px-2016_Toyota_Prius.jpg");
            Wr.WriteElementString("Виробник", "Тойота");
            Wr.WriteElementString("Модель", "Пріус");
            Wr.WriteElementString("Рік", "2016");
            Wr.WriteElementString("Колір", "Червоний");
            Wr.WriteElementString("Витрати", "3,1л/100км");
            Wr.WriteEndElement();

            Wr.WriteStartElement("Авто2");
            Wr.WriteAttributeString("Вигляд", "500px-2016_Daewoo_Lanos.jpg");
            Wr.WriteElementString("Виробник", "Ланос");
            Wr.WriteElementString("Модель", "Део");
            Wr.WriteElementString("Рік", "2014");
            Wr.WriteElementString("Колір", "Сірий");
            Wr.WriteElementString("Витрати", "4,2л/100км");
            Wr.WriteEndElement();

            Wr.WriteStartElement("Авто3");
            Wr.WriteAttributeString("Вигляд", "");
            Wr.WriteElementString("Виробник", "Тесла");
            Wr.WriteElementString("Модель", "model S");
            Wr.WriteElementString("Рік", "2019");
            Wr.WriteElementString("Колір", "Чорний");
            Wr.WriteElementString("Витрати", "6л/100км");
            Wr.WriteEndElement();

            Wr.WriteEndElement();


            Wr.WriteStartElement("Запит2");

            Wr.WriteStartElement("Авто1");
            Wr.WriteAttributeString("Вигляд", "");
            Wr.WriteElementString("Виробник", "Тесла");
            Wr.WriteElementString("Модель", "model X");
            Wr.WriteElementString("Рік", "2019");
            Wr.WriteElementString("Колір", "білий");
            Wr.WriteElementString("Витрати", "7,1л/100км");
            Wr.WriteEndElement();

            Wr.WriteStartElement("Авто2");
            Wr.WriteAttributeString("Вигляд", "");
            Wr.WriteElementString("Виробник", "Тесла");
            Wr.WriteElementString("Модель", "model S");
            Wr.WriteElementString("Рік", "2011");
            Wr.WriteElementString("Колір", "чорний");
            Wr.WriteElementString("Витрати", "5,1л/100км");
            Wr.WriteEndElement();

            Wr.WriteStartElement("Авто3");
            Wr.WriteAttributeString("Вигляд", "");
            Wr.WriteElementString("Виробник", "Тесла");
            Wr.WriteElementString("Модель", "model X");
            Wr.WriteElementString("Рік", "2017");
            Wr.WriteElementString("Колір", "Чорний");
            Wr.WriteElementString("Витрати", "5л/100км");
            Wr.WriteEndElement();

            Wr.WriteEndElement();



            Wr.WriteEndElement();
            Wr.Close();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("XML файл згенеровано");
            Console.WriteLine("");
            Console.WriteLine("вивід:");

            print_xml("auto.xml");
            Console.ReadKey();
        }
    }
}