using System;
using System.Collections.Generic;
using System.Xml;

namespace Parsers
{
    public class XmlParser
    {
        public static Dictionary<string, object> Parse(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            Dictionary<string, object> data = new Dictionary<string, object>();
            ParseElement(xmlDoc.DocumentElement, data);

            return data;
        }

        private static void ParseElement(XmlElement element, Dictionary<string, object> data)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                if (node is XmlElement childElement)
                {
                    if (childElement.HasChildNodes && childElement.FirstChild is XmlElement)
                    {
                        Dictionary<string, object> childData = new Dictionary<string, object>();
                        ParseElement(childElement, childData);
                        data[childElement.Name] = childData;
                    }
                    else
                    {
                        data[childElement.Name] = childElement.InnerText;
                    }
                }
            }
        }

        public static void Write(string filePath, Dictionary<string, object> data)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Root");
            xmlDoc.AppendChild(root);

            WriteElement(xmlDoc, root, data);

            xmlDoc.Save(filePath);
        }

        private static void WriteElement(XmlDocument xmlDoc, XmlElement parentElement, Dictionary<string, object> data)
        {
            foreach (var kvp in data)
            {
                XmlElement element = xmlDoc.CreateElement(kvp.Key);

                if (kvp.Value is Dictionary<string, object> childData)
                {
                    WriteElement(xmlDoc, element, childData);
                }
                else
                {
                    element.InnerText = kvp.Value.ToString();
                }

                parentElement.AppendChild(element);
            }
        }
    }
}
