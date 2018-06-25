using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace ServiceConsoleTest
{
    abstract class SettingsLeaf : ICollection<SettingsLeaf>
    {
        private string name;
        private List<SettingsLeaf> settingsLeaves;

        public SettingsLeaf()
        {
            settingsLeaves = new List<SettingsLeaf>();
        }

        virtual public void Init(XmlNode node)
        {
            this.initName(node);
        }

        public bool hasChild => this.Count > 0;

        public int Count => settingsLeaves.Count;

        public bool IsReadOnly => false;

        public string Name { get => name;}

        public void Add(SettingsLeaf item)
        {
            settingsLeaves.Add(item);
        }

        public void Clear()
        {
            settingsLeaves.Clear();
        }

        public bool Contains(SettingsLeaf item)
        {
            return settingsLeaves.Contains(item);
        }

        public void CopyTo(SettingsLeaf[] array, int arrayIndex)
        {
            settingsLeaves.CopyTo(array, arrayIndex);
        }

        public bool Remove(SettingsLeaf item)
        {
            return settingsLeaves.Remove(item);
        }

        public IEnumerator<SettingsLeaf> GetEnumerator()
        {
            return settingsLeaves.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return settingsLeaves.GetEnumerator();
        }

        protected void initName(XmlNode node)
        {
            if(node.SelectSingleNode("@Name") != null)
            {
                this.name = node.SelectSingleNode("@Name").Value;
            }
            else
            {
                this.name = node.Name;
            }
        }
    }
}
