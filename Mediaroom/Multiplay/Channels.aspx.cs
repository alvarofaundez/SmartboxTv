using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using MultiplayLibrary;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["channels"] != null)
        {
            MultiplayConnection conn = new MultiplayConnection();
            String date = DateTime.Now.ToString();
            DataSet _dsShow = new DataSet();
            
       

            ArrayList channels = (ArrayList)Session["channels"];

            DataSet _ds = conn.searchChannelInfo(channels[0].ToString());
            _dsShow = conn.searchActualShow(_ds.Tables[0].Rows[0]["idChannel"].ToString(), date);

            this.imgPrincipal.Url = _ds.Tables[0].Rows[0]["channelImage"].ToString();
           // this.lblPrincipal.Text = _ds.Tables[0].Rows[0]["channelName"].ToString() + " - " + _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.lblPrincipal.Text =  _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.vdPrincipal.TuneURL = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();
            this.lblTunePrincipal.Text = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();

            _ds = conn.searchChannelInfo(channels[1].ToString());
            _dsShow = conn.searchActualShow(_ds.Tables[0].Rows[0]["idChannel"].ToString(), date);
            this.imgLogo1.Url = _ds.Tables[0].Rows[0]["channelImage"].ToString();
           // this.lblChannel1.Text = _ds.Tables[0].Rows[0]["channelName"].ToString() + " - " + _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.lblChannel1.Text =  _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.vdChannel1.TuneURL = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();
            this.lblTune1.Text = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();

            _ds = conn.searchChannelInfo(channels[2].ToString());
            _dsShow = conn.searchActualShow(_ds.Tables[0].Rows[0]["idChannel"].ToString(), date);
            this.imgLogo2.Url = _ds.Tables[0].Rows[0]["channelImage"].ToString();
            //this.lblChannel2.Text = _ds.Tables[0].Rows[0]["channelName"].ToString() + " - " + _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.lblChannel2.Text = _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.vdChannel2.TuneURL = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();
            this.lblTune2.Text = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();

            _ds = conn.searchChannelInfo(channels[3].ToString());
            _dsShow = conn.searchActualShow(_ds.Tables[0].Rows[0]["idChannel"].ToString(), date);
            this.imgLogo3.Url = _ds.Tables[0].Rows[0]["channelImage"].ToString();
           // this.lblChannel3.Text = _ds.Tables[0].Rows[0]["channelName"].ToString() + " - " + _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.lblChannel3.Text =  _dsShow.Tables[0].Rows[0]["title"].ToString();
            this.vdChannel3.TuneURL = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();
            this.lblTune3.Text = "tune:" + _ds.Tables[0].Rows[0]["channelNumber"].ToString();

        }
    }
}
