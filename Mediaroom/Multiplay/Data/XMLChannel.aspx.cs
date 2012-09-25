using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MultiplayLibrary;
using System.Xml;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void Render(HtmlTextWriter writer)
    {
        MultiplayConnection conn = new MultiplayConnection();

        DataSet _dsChannel = conn.searchChannel(Request.QueryString["lblIdMenu"]);

        XmlDocument doc = new XmlDocument();

        String date = DateTime.Now.ToString();

        DataSet _dsShow = new DataSet();

        ArrayList channels = new ArrayList();

        if (Session["channels"] != null)
            channels = (ArrayList)Session["channels"];

        if (Request.QueryString["lblCheck"] != null && Request.QueryString["lblCheck"] != "" && Request.QueryString["lblIdChannel"] != null && Request.QueryString["lblIdChannel"] != "")
        {
            if (Request.QueryString["lblCheck"] == "check")
                channels.Add(Request.QueryString["lblIdChannel"]);
            else if (Request.QueryString["lblCheck"] == "uncheck")
                channels.Remove(Request.QueryString["lblIdChannel"]);

            Session["channels"] = channels;
        }

        try
        {
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode dataNode = doc.CreateElement("Data");
            doc.AppendChild(dataNode);

            XmlNode rowNode = doc.CreateElement("Row");
            dataNode.AppendChild(rowNode);
            int i = 0;
            foreach (DataRow dr in _dsChannel.Tables[0].Rows)
            {
                XmlNode channelNode = doc.CreateElement("Channel");
                rowNode.AppendChild(channelNode);

                XmlAttribute indexAttribute = doc.CreateAttribute("index");
                indexAttribute.Value = i.ToString();

                XmlAttribute idAttribute = doc.CreateAttribute("id");
                idAttribute.Value = dr["idChannel"].ToString();

                XmlAttribute nameAttribute = doc.CreateAttribute("name");
                nameAttribute.Value = dr["channelName"].ToString();

                XmlAttribute numberAttribute = doc.CreateAttribute("number");
                numberAttribute.Value = dr["channelNumber"].ToString();

                XmlAttribute imageAttribute = doc.CreateAttribute("image");
                imageAttribute.Value = dr["channelImage"].ToString();

                _dsShow = conn.searchActualShow(dr["idChannel"].ToString(), date);

                XmlAttribute idShowAttribute = doc.CreateAttribute("idShow");
                idShowAttribute.Value = _dsShow.Tables[0].Rows[0]["idProgram"].ToString();

                XmlAttribute showAttribute = doc.CreateAttribute("show");
                showAttribute.Value = _dsShow.Tables[0].Rows[0]["title"].ToString();

                XmlAttribute descriptionAttribute = doc.CreateAttribute("description");
                descriptionAttribute.Value = _dsShow.Tables[0].Rows[0]["description"].ToString();

                TimeSpan ts = DateTime.Parse(_dsShow.Tables[0].Rows[0]["endDate"].ToString()) - DateTime.Parse(_dsShow.Tables[0].Rows[0]["startDate"].ToString());
                XmlAttribute durationAttribute = doc.CreateAttribute("duration");
                if (ts.Hours != 0)
                {
                    if (ts.Minutes != 0)
                        durationAttribute.Value = ts.Hours.ToString() + ":" + ts.Minutes.ToString() + " min.";
                    else
                    {
                        if (ts.Hours>1)
                            durationAttribute.Value = ts.Hours.ToString() + " Hrs.";
                        else
                            durationAttribute.Value = ts.Hours.ToString() + " Hr.";
                    }
                }
                else
                    durationAttribute.Value = ts.Minutes.ToString() + " min.";

                XmlAttribute scheduleAttribute = doc.CreateAttribute("schedule");

                

                DateTime startDate = DateTime.Parse(_dsShow.Tables[0].Rows[0]["startDate"].ToString());
                DateTime endDate = DateTime.Parse(_dsShow.Tables[0].Rows[0]["endDate"].ToString());
                DateTime Actual = DateTime.Now;
              
                TimeSpan dato1 = endDate - startDate;
                TimeSpan dato2 = Actual - startDate;

                Double minutos = dato1.TotalMinutes;
                Double minutos2 = dato2.TotalMinutes;

                int totalavance = Convert.ToInt32((minutos2 * 100 / minutos));
                string avance;

                int total = totalavance;
                avance = "0";


                if (total < 10)
                {
                    avance = "Images/load/load2.png";
                }
                else if (total >= 10 && total < 15)
                {
                    avance = "Images/load/load3.png";
                }
                else if (total >= 15 && total < 20)
                {
                    avance = "Images/load/load4.png";
                }
                else if (total >= 20 && total < 25)
                {
                    avance = "Images/load/load5.png";
                }
                else if (total >= 25 && total < 30)
                {
                    avance = "Images/load/load6.png";
                }
                else if (total >= 30 && total < 35)
                {
                    avance = "Images/load/load7.png";
                }
                else if (total >= 35 && total < 40)
                {
                    avance = "Images/load/load8.png";
                }
                else if (total >= 40 && total < 45)
                {
                    avance = "Images/load/load9.png";
                }
                else if (total >= 45 && total < 50)
                {
                    avance = "Images/load/load10.png";
                }
                else if (total >= 50 && total < 55)
                {
                    avance = "Images/load/load11.png";
                }
                else if (total >= 55 && total < 60)
                {
                    avance = "Images/load/load12.png";
                }
                else if (total >= 60 && total < 65)
                {
                    avance = "Images/load/load13.png";
                }
                else if (total >= 65 && total < 70)
                {
                    avance = "Images/load/load14.png";
                }
                else if (total >= 70 && total < 75)
                {
                    avance = "Images/load/load15.png";
                }
                else if (total >= 75 && total < 80)
                {
                    avance = "Images/load/load16.png";
                }
                else if (total >= 80 && total < 85)
                {
                    avance = "Images/load/load17.png";
                }
                else if (total >= 85 && total < 90)
                {
                    avance = "Images/load/load18.png";
                }
                else if (total >= 90 && total < 100)
                {
                    avance = "Images/load/load19.png";
                }



                XmlAttribute InicioAttribute = doc.CreateAttribute("avance");
                InicioAttribute.Value = avance;

               

                scheduleAttribute.Value = startDate.ToShortTimeString() + " - " + endDate.ToShortTimeString() + " Hrs.";

                XmlAttribute checkAttribute = doc.CreateAttribute("check");
                if(channels.Contains(dr["idChannel"].ToString()))
                    checkAttribute.Value = "true";
                else
                    checkAttribute.Value = "false";

                XmlAttribute totalCheckAttribute = doc.CreateAttribute("totalCheck");
                totalCheckAttribute.Value = channels.Count.ToString();

                channelNode.Attributes.Append(indexAttribute);
                channelNode.Attributes.Append(idAttribute);
                channelNode.Attributes.Append(nameAttribute);
                channelNode.Attributes.Append(numberAttribute);
                channelNode.Attributes.Append(imageAttribute);
                channelNode.Attributes.Append(idShowAttribute);
                channelNode.Attributes.Append(showAttribute);
                channelNode.Attributes.Append(descriptionAttribute);
                channelNode.Attributes.Append(durationAttribute);
                channelNode.Attributes.Append(InicioAttribute);
                channelNode.Attributes.Append(scheduleAttribute);
                channelNode.Attributes.Append(checkAttribute);
                channelNode.Attributes.Append(totalCheckAttribute);
                i++;
            }
        }
        catch (Exception ex)
        {
            String message = ex.Message;
        }




        writer.Write(doc.OuterXml);
    }
}
