<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Init_GA.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="TVControls" Namespace="Microsoft.TV.TVControls" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Actions" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Animations" TagPrefix="mrml" %>

<mrml:TVPage ID="TVPage1" runat="server" Style="position: absolute;" 
    BackgroundContent="Background_Video.xml" onenter="gotoIndex">
    <mrml:TVActions ID="TVActions1" runat="server" Style="position: absolute;" 
        Actions-Capacity="4" Version="2">
        <mrml:NavigateAction Data="Index.aspx" Name="gotoIndex" X="0" Y="0" />
    </mrml:TVActions>
</mrml:TVPage>