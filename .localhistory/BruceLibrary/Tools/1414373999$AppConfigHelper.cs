using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

namespace BruceLibrary.Tools
{
    public class AppConfigHelper : AppSettingsReader
    {
        private string docName = string.Empty;

        public static AppConfigHelper Current = new AppConfigHelper();

        private AppConfigHelper()
            : base()
        {
            docName = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Assembly.GetEntryAssembly().GetName().Name + ".exe.config");
        }

        public object GetValue(string key, Type type, object defaultValue)
        {
            object temp = defaultValue;

            try
            {
                temp = this.GetValue(key, type);
            }
            catch (InvalidOperationException) { }

            return temp;
        }

        public bool SetValue(string key, string value)
        {
            XmlDocument cfgDoc = new XmlDocument();
            loadConfigDoc(cfgDoc);

            XmlNode node = cfgDoc.SelectSingleNode("//appSettings");
            if (node == null)
            {
                throw new System.InvalidOperationException("appSettings section not found");
            }

            try
            {
                XmlElement addElem = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");

                if (addElem != null)
                {
                    addElem.SetAttribute("value", value);
                }
                else
                {
                    XmlElement entry = cfgDoc.CreateElement("add");
                    entry.SetAttribute("key", key);
                    entry.SetAttribute("value", value);
                    node.AppendChild(entry);
                }
                saveConfigDoc(cfgDoc, docName);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoveElement(string key)
        {
            try
            {
                XmlDocument cfgDoc = new XmlDocument();
                loadConfigDoc(cfgDoc);
                XmlNode node = cfgDoc.SelectSingleNode("//appSettings");
                if (node == null)
                {
                    throw new System.InvalidOperationException("appSettings section not found");
                }
                node.RemoveChild(node.SelectSingleNode("//add[@key='" + key + "']"));
                saveConfigDoc(cfgDoc, docName);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private XmlDocument loadConfigDoc(XmlDocument cfgDoc)
        {
            cfgDoc.Load(docName);
            return cfgDoc;
        }

        private void saveConfigDoc(XmlDocument cfgDoc, string cfgDocPath)
        {
            XmlTextWriter writer = new XmlTextWriter(cfgDocPath, null);
            writer.Formatting = Formatting.Indented;
            cfgDoc.WriteTo(writer);
            writer.Flush();
            writer.Close();
        }
    }
}
