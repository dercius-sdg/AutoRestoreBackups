using System.Xml;

namespace ServiceConsoleTest
{
    class DirectoryLeaf : SettingsLeaf
    {
        private string directory;
        public override void Init(XmlNode node)
        {
            base.Init(node);
            directory = node.SelectSingleNode("@Path").Value;
        }
    }
}
