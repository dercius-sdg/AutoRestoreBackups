using System;
using System.Xml;

namespace ServiceConsoleTest
{
    class OptionLeaf : SettingsLeaf
    {
        string nameOption;
        object value;

        public string NameOption { get => nameOption; set => nameOption = value; }
        public Object Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public override void Init(XmlNode node)
        {
            base.Init(node);
            this.NameOption = node.SelectSingleNode("@Name").Value;
            try
            {
                value = Convert.ToInt32(node.SelectSingleNode("@Value").Value);
                return;
            }
            catch
            {
                value = null;
            }
            try
            {
                value = Convert.ToDouble(node.SelectSingleNode("@Value").Value);
                return;
            }
            catch
            {
                value = null;
            }
            try
            {
                value = Convert.ToBoolean(node.SelectSingleNode("@Value").Value);
                return;
            }
            catch
            {
                value = null;
            }
            try
            {
                value = Convert.ToString(node.SelectSingleNode("@Value").Value);
                return;
            }
            catch
            {
                value = null;
            }
        }
    }
}
