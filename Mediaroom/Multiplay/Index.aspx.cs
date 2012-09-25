using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.TV.TVControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int final = 10;
        string time = DateTime.Now.ToString();
        for (int i = 0; i <= final; i++)
        {
            TVVideoListItem video = new TVVideoListItem();
            video.VideoHeight = 190;
            video.VideoWidth = 190;
            video.Width = 200;
            video.Height = 200;
            video.VideoLeft = 5;
            video.VideoTop = 5;
            video.FocusBackground.Color = System.Drawing.Color.Beige;
            switch (i)
            {
                case 0:
                case 6:
                    video.VideoTuneURL = "tune:117";
                    break;
                case 1:
                case 7:
                    video.VideoTuneURL = "tune:120";
                    break;
                case 2:
                case 8:
                    video.VideoTuneURL = "tune:121";
                    break;
                case 3:
                case 9:
                    video.VideoTuneURL = "tune:122";
                    break;
                case 4:
                case 10:
                    video.VideoTuneURL = "tune:501";
                    break;
                case 5:
                    video.VideoTuneURL = "tune:681";
                    break;
            }
            
            //this.TVList1.Controls.Add(video);
        }
    }
}
