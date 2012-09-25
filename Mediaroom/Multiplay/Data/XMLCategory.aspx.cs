using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using MultiplayLibrary;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void Render(HtmlTextWriter writer)
    {
        MultiplayConnection conn = new MultiplayConnection();

        DataSet _dsCategory = conn.searchCategory();

        XmlDocument doc = new XmlDocument();
        try
        {
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode dataNode = doc.CreateElement("Data");
            doc.AppendChild(dataNode);

            foreach (DataRow dr in _dsCategory.Tables[0].Rows)
            {
                XmlNode categoryNode = doc.CreateElement("Category");
                dataNode.AppendChild(categoryNode);

                XmlAttribute idAttribute = doc.CreateAttribute("id");
                idAttribute.Value = dr["idChannelCategory"].ToString();

                XmlAttribute nameAttribute = doc.CreateAttribute("name");
                nameAttribute.Value = dr["channelCategoryName"].ToString();

                categoryNode.Attributes.Append(idAttribute);
                categoryNode.Attributes.Append(nameAttribute);
            }
        }
        catch (Exception ex)
        {
            String message = ex.Message;
        }




        writer.Write(doc.OuterXml);
    }
}
