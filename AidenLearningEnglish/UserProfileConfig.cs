using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace AidenLearningEnglish
{
    class UserProfileConfig
    {
        // Fields
        private static string SKIN_SET = "SKIN";

        private static XmlDocument document;
        public static void Initialize()
        {
            document = new XmlDocument();
            string file = Application.ExecutablePath + ".config";
            if (File.Exists(file))
            {
                document.Load(file);
            }
        }
        public static XmlDocument GetDocument()
        {
            if (document == null) Initialize();
            return document;
        }
        // Methods
        public static string GetConfig(string AppKey)
        {
            XmlDocument document = GetDocument();
            XmlElement element = (XmlElement)document.SelectSingleNode("//appSettings").SelectSingleNode("//add[@key=\"" + AppKey + "\"]");
            if (element != null)
            {
                return element.GetAttribute("value");
            }
            return "";
        }
        public static string GetURL()
        {
            return GetConfig("url");
        }

        public static bool IsRemember()
        {
            string config = GetConfig("remember");
            if (!string.IsNullOrEmpty(config))
            {
                bool result = true;
                bool.TryParse(config, out result);
                return result;
            }
            return false;
        }

        public static bool isWSMode()
        {
            string config = GetConfig("wsmode");
            if (!string.IsNullOrEmpty(config))
            {
                bool result = true;
                bool.TryParse(config, out result);
                return result;
            }
            return false;
        }

        public static void SetValue(string AppKey, string AppValue)
        {
            XmlDocument document = GetDocument();
            XmlNode node = document.SelectSingleNode("//appSettings");
            XmlElement element = (XmlElement)node.SelectSingleNode("//add[@key=\"" + AppKey + "\"]");
            if (element != null)
            {
                element.SetAttribute("value", AppValue);
            }
            else
            {
                XmlElement newChild = document.CreateElement("add");
                newChild.SetAttribute("key", AppKey);
                newChild.SetAttribute("value", AppValue);
                node.AppendChild(newChild);
            }
            //document.Save(Application.ExecutablePath + ".config");
        }

        public static void Flush()
        {
            XmlDocument document = GetDocument();
            document.Save(Application.ExecutablePath + ".config");
        }

        public static void UpdateConfig(string Xkey, string Xvalue)
        {
            XmlDocument document = GetDocument();
            ((XmlElement)document.SelectSingleNode("//add[@key=\"" + Xkey + "\"]")).SetAttribute("value", Xvalue);
            document.Save(Application.ExecutablePath + ".config");
        }

    }
}

