using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServiceConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var se = Settings.GetSettings(@"E:\Документы\Visual Studio 2017\Projects\AutoRestoreBackups\AutoRestoreBackups\Config.xml").GetEnumerator();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }

    class Settings : SettingsLeaf
    {
        private static Settings instance;
        private Settings(string path)
        {
            var document = new XmlDocument();
            document.Load(path);
            var node = document.DocumentElement;
            this.initName(node);
            this.BuildTree(node,this);
        }

        private void BuildTree(XmlNode node,SettingsLeaf parentLeaf)
        {
            var childElementEnum = node.ChildNodes.GetEnumerator();
            while (childElementEnum.MoveNext())
            {
                var childNode = (XmlNode)childElementEnum.Current;
                var leaf = this.constructLeaf(childNode);
                if (leaf != null)
                {
                    leaf.Init(childNode);
                    parentLeaf.Add(leaf);
                    BuildTree(childNode, leaf);
                }
                else
                {
                    BuildTree(childNode, parentLeaf);
                }
            }
        }

        private SettingsLeaf constructLeaf(XmlNode node)
        {
            var name = node.Name;
            if (name == Properties.Settings.Default.DirectoryTag) return new DirectoryLeaf();
            if (name == Properties.Settings.Default.ConnectionTag) return new ConnectionLeaf();
            if (name == Properties.Settings.Default.OptionTag) return new OptionLeaf();
            return null;
        } 
        public static Settings GetSettings(string path = "")
        {
            if (instance == null && path == "") throw new Exception("Для начального значения путь конфигурации не может быть пустым");
            if (instance == null)
            {
                instance = new Settings(path);
            }
            return instance;
        }

        public override void Init(XmlNode node)
        {

        }
    }
}
