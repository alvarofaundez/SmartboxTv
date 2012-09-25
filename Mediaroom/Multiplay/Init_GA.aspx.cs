using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Datos;
using GaDotNet.Common.Data;
using GaDotNet.Common.Helpers;
using GaDotNet.Common;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string TVLabelClientId = Request.QueryString["TVLabelClientId"];

            string TVLabelAccountId = Request.QueryString["TVLabelAccountId"];

            string TVLabelDeviceId = Request.QueryString["TVLabelDeviceId"];

            string TVLabelIPAddress = Request.QueryString["TVLabelIPAddress"];

            string TVLabelMacAddress = Request.QueryString["TVLabelMacAddress"];

            string TVLabelHostname = Request.QueryString["TVLabelHostname"];

            string TVLabelSerialNumber = Request.QueryString["TVLabelSerialNumber"];





            PostgreNpgsqlConnection postv = new PostgreNpgsqlConnection();

            Stb usuario = (Stb)Session["stb"];


            //sino esta cargado usuario en sesion, recargamos

            if (usuario == null && TVLabelClientId != null && TVLabelAccountId != null && TVLabelDeviceId != null && TVLabelIPAddress != null)
            {

                if ((usuario = postv.GetStb(TVLabelAccountId)) == null)
                {

                    usuario = new Stb(TVLabelClientId, TVLabelAccountId, TVLabelDeviceId, TVLabelHostname,

                                            TVLabelIPAddress, TVLabelMacAddress, TVLabelSerialNumber);

                    usuario.Save();

                    // sqlcon.addUsuario(myUsuario);

                }

                // 

                Session["stb"] = usuario;


                Comando comandoInicio = new Comando(usuario, DateTime.Now, TipoEnum.TIPOCOMANDO.START, TipoEnum.TIPOAPLICACION.MULTIPLAY);

                comandoInicio.Save();

                GooglePageView pageView = new GooglePageView("MULTIPLAY.START", usuario.AccountID, "/MULTIPLAY.START.aspx");
                TrackingRequest request = new RequestFactory().BuildRequest(pageView);
                GoogleTracking.FireTrackingEvent(request);


            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Error.aspx?message=" + ex.Message);
        }

        //Stb stb = (Stb)Session["stb"];

        //// comprobemos que este email no ha sido registrado en este STB !!
        //DataUser du = new DataUser();
        //du.IdUser = stb.AccountID;

        //PizzaSQLConnection sql = new PizzaSQLConnection();
        //DataUser esregistrado = sql.searchUser(du);

        //if (esregistrado == null)
        //{
        //    this.TVPage1.OnEnter = new Microsoft.TV.TVControls.Events.EnterEvent("NavigateAction0");
        //}
        //else
        //{
        //    this.TVPage1.OnEnter = new Microsoft.TV.TVControls.Events.EnterEvent("gotoIndex");
        //}
    }
}
