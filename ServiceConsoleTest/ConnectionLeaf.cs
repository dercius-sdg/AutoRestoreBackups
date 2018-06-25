using System;
using System.Data.SqlClient;
using System.Xml;

namespace ServiceConsoleTest
{
    class ConnectionLeaf : SettingsLeaf
    {
        private  SqlConnection connection;

        public SqlConnection Connection { get => connection;}

        public override void Init(XmlNode node)
        {
            base.Init(node);
            var stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.ConnectRetryInterval = Convert.ToInt32(node.SelectSingleNode("@ConnectionTimeOut").Value);
            stringBuilder.DataSource = node.SelectSingleNode("@ServerName").Value;
            connection = new SqlConnection(stringBuilder.ToString());
        }
    }
}
