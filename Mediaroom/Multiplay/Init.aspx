<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Init.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="TVControls" Namespace="Microsoft.TV.TVControls" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Actions" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Animations" TagPrefix="mrml" %>

<mrml:TVPage ID="Init_page" runat="server" Alpha="0" 
        style="position:absolute; height: 768px; width: 1360px;"  
        onenter="SubmitActionEnviarUsuario" BackgroundContent="Background_Video.xml">
        
        <mrml:TVSystemDataSource ID="TVSystemDataSource1" runat="server" 
            Style="position: absolute; top: 439px; left: 592px;" >
        </mrml:TVSystemDataSource>

        <mrml:TVLabel ID="TVLabelDeviceId" runat="server" 
            Style="position: absolute; top: 256px; left: 232px;" Text=""          
            IsVisible="False" 
            DataBinder="SystemDataBinder,TVSystemDataSource1,DeviceId"  >
        </mrml:TVLabel>
        
        <mrml:TVLabel ID="TVLabelIPAddress" runat="server" 
            Style="position: absolute; top: 54px; left: 232px;" Text=""          
            IsVisible="False" 
            DataBinder="SystemDataBinder,TVSystemDataSource1,IPAddress" >
        </mrml:TVLabel>

         <mrml:TVLabel ID="TVLabelMacAddress" runat="server" 
            Style="position: absolute; top: 94px; left: 232px;" Text=""          
            IsVisible="False" 
            DataBinder="SystemDataBinder,TVSystemDataSource1,MacAddress" >
        </mrml:TVLabel>
        
         <mrml:TVLabel ID="TVLabelClientId" runat="server" Style="position: absolute; top: 215px; left: 235px;" 
            Text=""            
            IsVisible="False" 
            DataBinder="SystemDataBinder,TVSystemDataSource1,ClientId" >
        </mrml:TVLabel>


        <mrml:TVLabel ID="TVLabelAccountId" runat="server" Style="position: absolute; top: 328px; left: 235px;" 
            Text=""          
            IsVisible="False" 
            DataBinder="SystemDataBinder,TVSystemDataSource1,AccountId" >
        </mrml:TVLabel>

        <mrml:TVLabel ID="TVLabelSerialNumber" runat="server" Style="position: absolute; top: 133px; left: 232px;" 
            Text=""           
            IsVisible="False" 
            DataBinder="SystemDataBinder,TVSystemDataSource1,SerialNumber" >
        </mrml:TVLabel>

        <mrml:TVLabel ID="TVLabelHostname" runat="server" 
            Style="position: absolute; top: 368px; left: 235px; height: 26px;" Text="" 
            DataBinder="SystemDataBinder,TVSystemDataSource1,HostName">
        
        </mrml:TVLabel>
         <mrml:TVActions ID="TVActions" runat="server" 
             style="position:absolute; top: 288; left: 736;" Version="6" 
            Actions-Capacity="4">
             <mrml:SubmitAction Gadgets="TVLabelDeviceId TVLabelIPAddress TVLabelClientId TVLabelAccountId TVLabelSerialNumber TVLabelHostname" 
                 Method="Get" Name="SubmitActionEnviarUsuario" Url="Init_GA.aspx" X="0" Y="0" />
         </mrml:TVActions>
    </mrml:TVPage>