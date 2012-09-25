<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Channels.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="TVControls" Namespace="Microsoft.TV.TVControls" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Actions" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Animations" TagPrefix="mrml" %>

<form id="form1" runat="server">

<mrml:TVPage ID="TVPage1" runat="server" 
    Style="position: absolute; height: 720px; width: 1280px;" 
    Background="~/Images/bg-multichannel.jpg" 
    BackgroundContent="Default_Background.xml" onenter="BindAction0">
    <mrml:TVMediaProfiles ID="TVMediaProfiles1" runat="server" 
        style="position:absolute; top: 14; left: 172;" MediaProfiles-Capacity="4" 
        Version="1">
        <mrml:MediaProfile Name="mdPrChannel" PIP="Three" />
    </mrml:TVMediaProfiles>
    <mrml:TVButton ID="btnChannel1" runat="server" 
        style="position: absolute; top: 19px; left: 977px; width: 255px; height: 245px;" 
        FocusBackground="~/Images/foco-channel.png" FocusGlow="argb(0,0,0,0)" 
        Background="argb(0,0,0,0)" NextDown="btnChannel2" NextLeft="btnChannel1" 
        NextRight="btnChannel1" NextUp="btnChannel1" onclick="scriptChannel1" 
        Pressed="argb(0,0,0,0)">
        <mrml:TVImage ID="imgChannel1" runat="server" 
            Style="position: absolute; height: 180px; width: 232px; left: 11; top: 11;" 
            Url="~/Images/box-channel-small.png">
        </mrml:TVImage>
        <mrml:TVLabel ID="lblChannel1" runat="server" 
            Style="position: absolute; top: 195; left: 60; width: 180px; height: 0px;" 
            Text="Nat Geo Wild" ClipChildren="True" Wrap="False">
        </mrml:TVLabel>
        <mrml:TVImage ID="imgLogo1" runat="server" 
            Style="position: absolute; top: 191; height: 36px; width: 45px; left: 11;" 
            Url="~/Images/version-2.png">
        </mrml:TVImage>
        <mrml:TVVideo ID="vdChannel1" runat="server" 
            Style="position: absolute; height: 160px; width: 213px; left: 21; top: 21;" 
            IsPip="True" ShowBusyIndicator="False">
        </mrml:TVVideo>
    </mrml:TVButton>

    <mrml:TVButton ID="btnChannel2" runat="server" 
        style="position: absolute; top: 238px; left: 977px; width: 255px; height: 245px;" 
        FocusBackground="~/Images/foco-channel.png" FocusGlow="argb(0,0,0,0)" 
        Background="argb(0,0,0,0)" NextDown="btnChannel3" NextLeft="btnChannel2" 
        NextRight="btnChannel2" NextUp="btnChannel1" onclick="scriptChannel2" 
        Pressed="argb(0,0,0,0)">
        <mrml:TVImage ID="imgChannel2" runat="server" 
            Style="position: absolute; height: 180px; width: 232px; left: 11; top: 11;" 
            Url="~/Images/box-channel-small.png">
        </mrml:TVImage>
        <mrml:TVLabel ID="lblChannel2" runat="server" 
            Style="position: absolute; top: 195; left: 60; width: 180px; height: 0px;" 
            Text="CNN en español" ClipChildren="True" Wrap="False">
        </mrml:TVLabel>
        <mrml:TVImage ID="imgLogo2" runat="server" 
            Style="position: absolute; top: 191; height: 36px; width: 45px; left: 11;" 
            Url="~/Images/version-2.png">
        </mrml:TVImage>
        <mrml:TVVideo ID="vdChannel2" runat="server" 
            Style="position: absolute; height: 160px; width: 213px; left: 21; top: 21;" 
            IsPip="True" ShowBusyIndicator="False">
        </mrml:TVVideo>
    </mrml:TVButton>

    <mrml:TVButton ID="btnChannel3" runat="server" 
        style="position: absolute; top: 459px; left: 977px; width: 255px; height: 245px;" 
        FocusBackground="~/Images/foco-channel.png" FocusGlow="argb(0,0,0,0)" 
        Background="argb(0,0,0,0)" NextDown="btnChannel3" NextLeft="btnChannel3" 
        NextRight="btnChannel3" NextUp="btnChannel2" onclick="scriptChannel3" 
        Pressed="argb(0,0,0,0)">
        <mrml:TVImage ID="imgChannel3" runat="server" 
            Style="position: absolute; height: 180px; width: 232px; left: 11; top: 11;" 
            Url="~/Images/box-channel-small.png">
        </mrml:TVImage>
        <mrml:TVLabel ID="lblChannel3" runat="server" 
            Style="position: absolute; top: 195; left: 60; width: 180px; height: 0px;" 
            Text="MTV HD" ClipChildren="True" Wrap="False">
        </mrml:TVLabel>
        <mrml:TVImage ID="imgLogo3" runat="server" 
            Style="position: absolute; top: 191; height: 36px; width: 45px; left: 11;" 
            Url="~/Images/version-2.png">
        </mrml:TVImage>
        <mrml:TVVideo ID="vdChannel3" runat="server" 
            Style="position: absolute; height: 160px; width: 213px; left: 21; top: 21;" 
            IsPip="True" ShowBusyIndicator="False">
        </mrml:TVVideo>
    </mrml:TVButton>
    <mrml:TVActions ID="actChannel" runat="server" Actions-Capacity="16" 
        style="position:absolute; top: 15; left: 65;" Version="9">
        <mrml:BindAction Data="True" Name="BindAction0" Target="vdPrincipal" X="0" 
            Y="0" />
        <mrml:RefreshAction Force="True" Name="refreshChannel1" Target="imgLogo1" 
            X="0" Y="0" />
        <mrml:RefreshAction Force="True" Name="refreshChannel2" Target="imgLogo2" 
            X="0" Y="0" />
        <mrml:RefreshAction Force="True" Name="refreshChannel3" Target="imgLogo3" 
            X="0" Y="0" />
        <mrml:RefreshAction Force="True" Name="refreshPrincipal" Target="imgPrincipal" 
            X="0" Y="0" />
        <mrml:ScriptAction Data="btnChannel1" Function="setTune" Name="scriptChannel1" 
            X="0" Y="0" />
        <mrml:ScriptAction Data="btnChannel2" Function="setTune" Name="scriptChannel2" 
            X="0" Y="0" />
        <mrml:ScriptAction Data="btnChannel3" Function="setTune" Name="scriptChannel3" 
            X="0" Y="0" />
        <mrml:TuneAction Name="tuneChannel1" Target="vdChannel1" X="0" Y="0" />
        <mrml:TuneAction Name="tuneChannel2" Target="vdChannel2" X="0" Y="0" />
        <mrml:TuneAction Name="tuneChannel3" Target="vdChannel3" X="0" Y="0" />
        <mrml:TuneAction Name="tunePrincipal" Target="vdPrincipal" X="0" Y="0" />
    </mrml:TVActions>
    <mrml:TVVideo ID="vdPrincipal" runat="server" 
        
        style="position: absolute; top: 86px; left: 116px; width: 710px; height: 533px;" 
        ShowBusyIndicator="False">
    </mrml:TVVideo>
    <mrml:TVImage ID="imgPrincipal" runat="server" 
        Style="position: absolute; top: 632; height: 58px; width: 73px; left: 106;" 
        Background="argb(0,0,0,0)">
    </mrml:TVImage>
    <mrml:TVLabel ID="lblPrincipal" runat="server" 
        
        
        Style="position: absolute; top: 647px; left: 189px; width: 500px; height: 0px;" Text="Disney Channel" 
        FontStyle="bold22">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblTunePrincipal" runat="server" Style="position: absolute; top: 63px; left: 0px;" 
        Text="tune:122" IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblTune1" runat="server" Style="position: absolute; top: 94; left: 0px;" 
        Text="tune:121" IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblTune2" runat="server" Style="position: absolute; top: 124; left: 0px;" 
        Text="tune:120" IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblTune3" runat="server" Style="position: absolute; top: 154; left: 0px;" 
        Text="tune:117" IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVScript ID="TVScript1" runat="server" 
        style="position: absolute; top: 14; left: 292;">
        <Script>
            function setTune() {
                var id = window.readContext("data");
                var principal;
                var tune;
                if (id == "btnChannel1") {
                    principal = getProperty("lblTunePrincipal", "text");
                    principalLogo = getProperty("imgPrincipal", "url");
                    principalName = getProperty("lblPrincipal", "text");
                    tune = getProperty("lblTune1", "text");
                    tuneLogo = getProperty("imgLogo1", "url");
                    tuneName = getProperty("lblChannel1", "text");
                    if (principal != tune) {
                        invokeAction("TVPage1", "tunePrincipal", tune)
                        invokeAction("TVPage1", "tuneChannel1", principal)
                        setProperty("lblTunePrincipal", "text", tune);
                        invokeAction("TVPage1", "refreshPrincipal", tuneLogo);
                        setProperty("lblPrincipal", "text", tuneName);
                        setProperty("lblTune1", "text", principal);
                        invokeAction("TVPage1", "refreshChannel1", principalLogo);
                        setProperty("lblChannel1", "text", principalName);
                    }
                }
                else if (id == "btnChannel2") {
                    principal = getProperty("lblTunePrincipal", "text");
                    principalLogo = getProperty("imgPrincipal", "url");
                    principalName = getProperty("lblPrincipal", "text");
                    tune = getProperty("lblTune2", "text");
                    tuneLogo = getProperty("imgLogo2", "url");
                    tuneName = getProperty("lblChannel2", "text");
                    if (principal != tune) {
                        invokeAction("TVPage1", "tunePrincipal", tune)
                        invokeAction("TVPage1", "tuneChannel2", principal)
                        setProperty("lblTunePrincipal", "text", tune);
                        invokeAction("TVPage1", "refreshPrincipal", tuneLogo);
                        setProperty("lblPrincipal", "text", tuneName);
                        setProperty("lblTune2", "text", principal);
                        invokeAction("TVPage1", "refreshChannel2", principalLogo);
                        setProperty("lblChannel2", "text", principalName);
                    }
                }
                else if (id == "btnChannel3") {
                    principal = getProperty("lblTunePrincipal", "text");
                    principalLogo = getProperty("imgPrincipal", "url");
                    principalName = getProperty("lblPrincipal", "text");
                    tune = getProperty("lblTune3", "text");
                    tuneLogo = getProperty("imgLogo3", "url");
                    tuneName = getProperty("lblChannel3", "text");
                    if (principal != tune) {
                        invokeAction("TVPage1", "tunePrincipal", tune)
                        invokeAction("TVPage1", "tuneChannel3", principal)
                        setProperty("lblTunePrincipal", "text", tune);
                        invokeAction("TVPage1", "refreshPrincipal", tuneLogo);
                        setProperty("lblPrincipal", "text", tuneName);
                        setProperty("lblTune3", "text", principal);
                        invokeAction("TVPage1", "refreshChannel3", principalLogo);
                        setProperty("lblChannel3", "text", principalName);
                    }
                }
            }
        </Script>
    </mrml:TVScript>
</mrml:TVPage>
</form>

