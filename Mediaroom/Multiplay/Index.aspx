<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Index.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="TVControls" Namespace="Microsoft.TV.TVControls" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Actions" TagPrefix="mrml" %>
<%@ Register assembly="TVControls" namespace="Microsoft.TV.TVControls.Animations" TagPrefix="mrml" %>

<form id="form1" runat="server">
<mrml:TVPage ID="TVPage1" runat="server" Background="~/Images/version-2.jpg" 
    style="position: absolute; height: 720px; width: 1280px;" BackgroundContent="Default_Background.xml" 
    onenter="AudioAction0 ShowAction1" onkey="NavigateAction0:back">
   <mrml:TVPhysicsGrid ID="TVPhysicsGrid1" runat="server" AutoFlow="Horizontal" 
            Circular="True" DataBinder="XmlDataBinder,dsMenu,Data" 
            PushBounds="rect(0,0,713,0)" Style="position: absolute; left: 53px; top: 73;
        width: 764px; height: 62px" onblur="HideAction0" AlignCursors="Snap" 
            NextDown="phTblChannel" NextUp="TVPhysicsGrid1" 
        onfocus="ShowAction0 CompositeAction0" ElementWidth="235" 
        NextLeft="TVPhysicsGrid1" NextRight="TVPhysicsGrid1">
            <mrml:TVPhysicsTemplate ID="TVPhysicsTemplate17" runat="server" 
                             onhighlight="setId scriptSubmit" Style="position: absolute;
            top: -2px; width: 165px; height: 60px; left: 83;" TemplateName="Category" FontStyle="bold24" 
                             HorizontalAlign="Center" VerticalAlign="Center">
   
                <mrml:TVActions ID="actMenu" runat="server" Actions-Capacity="8" 
                    Style="position: absolute; top: 0; left: 0;" Version="36">
                    <mrml:ScriptAction Function="visibletrue" Name="ScriptAction0" X="0" Y="0" />
                    <mrml:ScriptAction Data="" Function="doSubmit" Name="scriptSubmit" X="0" 
                        Y="0" />
                    <mrml:SetAction Name="setId" PropertyName="value" PropertyValue="$(@id)" 
                        Target="lblIdMenu" X="0" Y="0" />
                </mrml:TVActions>
                <mrml:TVPhysicsTemplate ID="TVPhysicsTemplate27" runat="server" 
                    Style="position: absolute; top: 0px; left: 0px; width: 165px; height: 60px;" 
                    ClipChildren="True" FontStyle="reg24" 
                    VerticalAlign="Center" 
                    PhysicsFocusFade="" PhysicsFade="selected[1,0.3](position.horizontal)" 
                    PhysicsYPan="selected[-0.5,0](position.horizontal)" 
                    PhysicsZoom="selected[1.8,1](position.horizontal)" 
                    PhysicsXPan="selected[-0.2,0](position.horizontal)" >$(@name)</mrml:TVPhysicsTemplate>

                
            </mrml:TVPhysicsTemplate>
            <mrml:TVImage ID="imgLeftArrow" runat="server"
                style="position:absolute; height: 36px; width: 26px; left:4; top: 6;" 
                Url="~/Images/arrow_barra2.png" >
            </mrml:TVImage>
            <mrml:TVImage ID="imgRightArrow" runat="server" 
                style="position:absolute; height: 36px; width: 26px; left: 219; top: 6;" 
                Url="">
            </mrml:TVImage>
        </mrml:TVPhysicsGrid>
    <mrml:TVXmlDataSource ID="dsMenu" runat="server" style="position:absolute; top: 0px; left: 0px;" 
        Url="~/Data/XMLCategory.aspx">
    </mrml:TVXmlDataSource>


     <%--onclick="refreshLogo scriptButtons setDescription setShow setSchedule setDuration tuneChannel scriptCheck Scripthora" --%>

    <mrml:TVPhysicsTable ID="phTblChannel" runat="server" 
        DataBinder="XmlDataBinder,dsChannel,Data" 
        ElementWidth="304" 
        style="position: absolute; left: 30px; top: 164; height: 530px; width: 413px;" 
        AutoFlow="Horizontal" 
        onready="scriptPosition animationChannel HideAction1" Alpha="0" 
        NextDown="phTblChannel" NextUp="TVPhysicsGrid1" 
        onkey="scriptRight:right" onblur="ScriptMostrar" >
        <mrml:TVPhysicsRowTemplate ID="phRwChannel" runat="server" 
            ElementHeight="74" ElementWidth="413" 
            style="position:absolute; width: 413px; height: 444px; left: 0px; top: 46;" TemplateName="Row" 
            AutoFlow="Horizontal" HeaderTemplate="header">
            <mrml:TVPhysicsTemplate ID="phTmpChannel" runat="server" 
                Style="position: absolute; height: 64px; width: 413px;" TemplateName="Channel" 
                FocusBackground="~/Images/btn_barra_foco.png" 
                Background="~/Images/btn_barra.png" 
                onhighlight="setTotalCheck setIdChannel setCheck setIndex setName setPhoto ScriptOcultar SetInicio SetFinal SetImage refreshLogo setDescription setShow setSchedule setDuration tuneChannel Scripthora" 
                onkey="scriptRight:right" NextLeft="TVPhysicsGrid1" 
                NextRight="phTmpChannel" onclick="scriptCheck scriptButtons" 
               >
                <mrml:TVActions ID="actChannel" runat="server" Style="position: absolute; top: 0; left: 0;" 
                    Actions-Capacity="32" Version="44">
                    <mrml:RefreshAction Data="$(@image)" Force="True" Name="refreshLogo" 
                        Target="imgLogo" X="0" Y="0" />
                    <mrml:RefreshAction Force="True" Name="refreshLogoButton1" 
                        Target="imgChannel1" X="0" Y="0" />
                    <mrml:RefreshAction Force="True" Name="refreshLogoButton2" 
                        Target="imgChannel2" X="0" Y="0" />
                    <mrml:RefreshAction Force="True" Name="refreshLogoButton3" 
                        Target="imgChannel3" X="0" Y="0" />
                    <mrml:RefreshAction Force="True" Name="refreshLogoButton4" 
                        Target="imgChannel4" X="0" Y="0" />
               
                    <mrml:RefreshAction Force="True" Name="refreshLogoButtonAux" 
                        Target="imgChannelAux" X="0" Y="0" />
               
                    <mrml:ScriptAction Data="" Function="showButtons" Name="scriptButtons" X="0" 
                        Y="0" />
                    <mrml:ScriptAction Data="" Function="doCheck" Name="scriptCheck" X="0" Y="0" />
                    <mrml:SetAction Name="setCheck" PropertyName="value" 
                        PropertyValue="$(@check)" Target="lblCheck" X="0" Y="0" />
                    <mrml:SetAction Name="setDescription" PropertyName="value" PropertyValue="$(@description)" 
                        Target="lblDescription" X="0" Y="0" />
                    <mrml:SetAction Name="setDuration" PropertyName="value" PropertyValue="$(@duration)" 
                        Target="lblDuration" X="0" Y="0" />
                    <mrml:SetAction Name="SetFinal" PropertyName="value" 
                        PropertyValue="$(@final)" Target="LblFin" X="0" Y="0" />
                    <mrml:SetAction Name="setIdChannel" PropertyName="value" 
                        PropertyValue="$(@id)" Target="lblIdChannel" X="0" Y="0" />
                    <mrml:SetAction Name="setIndex" PropertyName="value" Target="lblIndex" 
                        X="0" Y="0" PropertyValue="$(@index)" />
                    <mrml:SetAction Name="SetInicio" PropertyName="value" Target="Lblinicio" 
                        X="0" Y="0" PropertyValue="$(@avance)" />
                    <mrml:SetAction Name="setLblButton1" PropertyName="value" Target="lblChannel1" 
                        X="0" Y="0" />
                    <mrml:SetAction Name="setLblButton2" PropertyName="value" 
                        PropertyValue="" Target="lblChannel2" X="0" Y="0" />
                    <mrml:SetAction Name="setLblButton3" PropertyName="value" PropertyValue="" 
                        Target="lblChannel3" X="0" Y="0" />
                    <mrml:SetAction Name="setLblButton4" PropertyName="value" 
                        PropertyValue="" Target="lblChannel4" X="0" Y="0" />
                    <mrml:SetAction Name="setLblButtonAux" PropertyName="value" 
                        Target="lblChannelAux" X="0" Y="0" />
                    <mrml:SetAction Name="setName" PropertyName="value" 
                        PropertyValue="$(@name)" Target="lblName" X="0" Y="0" />
                    <mrml:SetAction Name="setPhoto" PropertyName="value" 
                        PropertyValue="$(@image)" Target="lblPhoto" X="0" Y="0" />
                    <mrml:SetAction Name="setSchedule" PropertyName="value" 
                        PropertyValue="$(@schedule)" Target="lblSchedule" X="0" Y="0" />
                    <mrml:SetAction Name="setShow" PropertyName="value" 
                        PropertyValue="$(@show)" Target="lblTitle" X="0" Y="0" />
                    <mrml:SetAction Name="setTotalCheck" PropertyName="value" 
                        PropertyValue="$(@totalCheck)" Target="lblTotalCheck" X="0" Y="0" />
                    <mrml:TuneAction Data="tune:$(@number)" Name="tuneChannel" Target="TVVideo1" 
                        X="0" Y="0" />
                </mrml:TVActions>
                <mrml:TVPhysicsTemplate ID="phTmpNumber" runat="server" 
                    Style="position: absolute; height: 64px; width: 50px;" HorizontalAlign="Center" 
                    Text="$(@number)" VerticalAlign="Center" FontStyle="bold20">
                </mrml:TVPhysicsTemplate>
                <mrml:TVPhysicsImageTemplate ID="phImgLogo" runat="server" 
                    Style="position: absolute; height: 55px; width: 58px; left: 55; top: 3;" 
                    DataPath="@image" KeepAspectRatio="True" PhysicsFade="" PhysicsZoom="">
                </mrml:TVPhysicsImageTemplate>
                <mrml:TVPhysicsTemplate ID="phTmpTitle" runat="server" 
                    Style="position: absolute; height: 64px; width: 240px; left: 123;" 
                    Text="$(@show)" ClipChildren="True" FontStyle="reg20" VerticalAlign="Center">
                </mrml:TVPhysicsTemplate>
                <mrml:TVPhysicsTemplate ID="phTmpCheck" templatename="*[@check='true']" 
                Style="top:17; left:373; width:30; height:30" RenderDepth="Foreground" 
                Background="~/Images/circulo.png" ClipChildren="true" 
                runat="server" />
            </mrml:TVPhysicsTemplate>
            
        </mrml:TVPhysicsRowTemplate>
        <mrml:TVPhysicsTemplate ID="TVPhysicsTemplate4" runat="server" Style="position: absolute;
            top: 0px; left: 0px; width: 413px; height: 30px;" TemplateName="header" Foreground="ARGB(255,147,195,225)"
            RenderDepth="background" FontStyle="Bold39">
            <mrml:TVPhysicsTemplate ID="TVPhysicsTemplate5" runat="server" Style="position: absolute;
                top: 8px; left: 366; height: 28px; width: 44px;" Background="~/Images/arrow_menu2.png"
                PhysicsFade="and(lt(scrollposition.vertical),selected.horizontal)">
            </mrml:TVPhysicsTemplate>
            <mrml:TVPhysicsTemplate ID="TVPhysicsTemplate6" runat="server" Style="position: absolute;
                top: 496; left: 366; height: 28px; width: 44px;" Background="~/Images/arrow_menu1.png"
                PhysicsFade="and(gt(endscrollposition.vertical),selected.horizontal)">
            </mrml:TVPhysicsTemplate>
        </mrml:TVPhysicsTemplate>
    </mrml:TVPhysicsTable>
    <mrml:TVXmlDataSource ID="dsChannel" runat="server" Style="position: absolute; top: 0px; left: 0px;" 
        Url="~/Data/XMLChannel.aspx">
    </mrml:TVXmlDataSource>
    <mrml:TVLabel ID="lblIdMenu" runat="server" 
        style="position: absolute; top: 32px; left: 1056px;" Text="" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblTitle" runat="server" 
        style="position: absolute; top: 554px; left: 579px; width: 484px;" Text="" 
        FontStyle="bold18">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblDescription" runat="server" 
        style="position: absolute; top: 589px; left: 519px; height: 61px; width: 675px;" 
        Text="" FontStyle="reg16">
    </mrml:TVLabel>
    <mrml:TVImage ID="imgLogo" runat="server" 
        
        
        
        style="position: absolute; top: 547px; width: 50px; height: 38px; left: 519px;">
    </mrml:TVImage>
    <mrml:TVLabel ID="lblSchedule" runat="server" HorizontalAlign="Right" 
        style="position: absolute; top: 509px; left: 750px; width: 156px;" Text="">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblDurationTitle" runat="server" FontStyle="bold16" 
        style="position: absolute; top: 655px; left: 519px; width: 188px;" 
        Text="Duración del programa:" IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblDuration" runat="server" FontStyle="reg16" 
        style="position: absolute; top: 655px; left: 689px; width: 245px;" Text="">
    </mrml:TVLabel>
    <mrml:TVVideo ID="TVVideo1" runat="server" 
        
        style="position: absolute; top: 220px; left: 525px; width: 377px; height: 280px;" 
        ShowBusyIndicator="False">
    </mrml:TVVideo>
    <mrml:TVScript ID="TVScript1" runat="server" 
        style="position:absolute; top: 0; left: 0; height: 25px; width: 99px;">
        <Script>

            var position="0";

            function doCheck() 
            {
                var count = getProperty("lblTotalCheck", "text");
                
                setProperty("lblDurationTitle", "visible", "true");
                
                var item = getProperty("lblIdChannel", "text");
                var checked = getProperty("lblCheck", "text");
                
                position = getProperty("lblIndex", "text");

                if (checked == "true") 
                {
                    check = "uncheck";
                }
                else 
                {
                    check = "check";
                }

                if (count != 4 || check != "check") 
                {
                    setProperty("lblCheck", "text", check);
                    invokeAction("TVPage1", "refreshChannel");
                    setProperty("btnChannels", "visible", "false");
                }
                if (count == 3 && check != "uncheck") 
                {
                    setProperty("btnChannels", "visible", "true");
                    invokeAction("TVPage1", "TimeoutAction0");
                }
                          }


            function movePosition()
            {
                invokeAction("TVPage1", "setPosition", position);
            }


            function moveRight() 
            {
                var visible = getProperty("btnChannels", "visible");
                if (visible == "true") 
                {
                    invokeAction("TVPage1", "focusChannels");
                }
                else if (visible == "false") 
                {
                    invokeAction("TVPage1", "FocusAction0");
                }
            }


            function doSubmit() 
            {
                var state = getProperty("lblIdMenu", "text");
                var lastState = getProperty("lblIdMenuLast", "text");

                invokeAction("TVPage1", "HideAction0");

                if (state != lastState) 
                {
                    setProperty("lblIdMenuLast", "text", state);
                    invokeAction("TVPage1", "submitChannel");
                    position = "0";
                }

                if (state == "4")
                {
                 setProperty("imgRightArrow", "left", "275")
                }
                else if (state == "5") 
                {
                    setProperty("imgRightArrow", "left", "122")
                }
                else if (state == "3") 
                {
                    setProperty("imgRightArrow", "left", "175")
                }
                else if (state == "6") 
                {
                    setProperty("imgRightArrow", "left", "172")
                }
                else if (state == "9") 
                {
                    setProperty("imgRightArrow", "left", "285")
                }
                else if (state == "8") 
                {                   
                    setProperty("imgRightArrow", "left", "173")
                }
                else if (state == "7") 
                {
                    setProperty("imgRightArrow", "left", "171")
                }
                else if (state == "1") 
                {
                    setProperty("imgRightArrow", "left", "205")
                }
                else if (state == "2") 
                {
                    setProperty("imgRightArrow", "left", "207")
                }
                else 
                {
                    setProperty("imgRightArrow", "left", "233")
                }

                setProperty("imgLeftArrow", "left", "7")
                invokeAction("TVPage1", "ShowAction0");

            }


            function showButtons() 
            {

                   var button = new Array(4);
                  
                    for (i = 1; i < 5; i++) {
                        button[i] = getProperty("lblChannel" + i, "text");
                    }

                    var text = getProperty("lblName", "text");
                    var photo = getProperty("lblPhoto", "text");
                    var boto;

                    if (button[1] == text || button[2] == text || button[3] == text || button[4] == text)
                        {
                        for (i = 1; i < 5; i++) 
                            {
                            if (button[i] == text) 
                                {
                                invokeAction("phTmpChannel", "setLblButton" + [i], "");
                                invokeAction("phTmpChannel", "refreshLogoButton" + [i], " ");
                                setProperty("btnChannel" + [i], "background", "image(Images/btn_canal_opacity.png)");
                                break;
                                }
                            }

                    } 
                    else 
                    {
                    for (i = 1; i < 5; i++) 
                        {
                        if (button[i] == "") 
                           {
                            invokeAction("phTmpChannel", "setLblButton" + [i], text);
                            invokeAction("phTmpChannel", "refreshLogoButton" + [i], photo);
                            setProperty("btnChannel" + [i], "background", "image(Images/btn_canal.png)");
                            break;
                           }
                        }
                }

            
            }

            function visibletrue() 
            {
               setProperty("imgRightArrow", "visible", "true")            
               setProperty("imgLeftArrow", "visible", "true")
            }

            function visiblefalse() 
            {
                setProperty("imgRightArrow", "visible", "false")
                setProperty("imgLeftArrow", "visible", "false")
            }

            function hora()
            {
                var ruta = getProperty("Lblinicio", "text");
                setProperty("TVImage1", "url", ruta);
            }

        </Script>

    </mrml:TVScript>
    <mrml:TVActions ID="actMultiplay" runat="server" Actions-Capacity="32" 
        style="position:absolute; top: 13; left: 6;" Version="37">
        <mrml:AnimationAction AnimationID="fadeContainer" Name="animationChannel" 
            Target="phTblChannel" X="0" Y="0" />
        <mrml:AnimationAction AnimationID="fadeContainer" Name="animationFade1" 
            Target="btnChannel1" X="0" Y="0" />
        <mrml:AnimationAction AnimationID="fadeContainer" Name="animationFade2" 
            Target="btnChannel2" X="0" Y="0" />
        <mrml:AnimationAction AnimationID="fadeContainer" Name="animationFade3" 
            Target="btnChannel3" X="0" Y="0" />
        <mrml:AnimationAction AnimationID="fadeContainer" Name="animationFade4" 
            Target="btnChannel4" X="0" Y="0" />
        <mrml:FocusAction Name="FocusAction0" Target="TVPhysicsGrid1" X="0" 
            Y="0" />
        <mrml:FocusAction Name="focusChannels" Target="btnChannels" X="0" Y="0" />
        <mrml:FocusAction Name="focusTChannels" Target="phTblChannel" X="0" Y="0" />
        <mrml:HideAction Name="HideAction0" Targets="imgLeftArrow imgRightArrow" X="0" 
            Y="0" />
        <mrml:HideAction Name="HideAction1" Targets="TVBusyIndicator1" X="0" Y="0" />
        <mrml:NavigateAction Data="page:http://190.215.44.18/Dashboard/Pages/Init.aspx" 
            Name="NavigateAction0" X="0" Y="0" />
        <mrml:NavigateAction Data="Channels.aspx" Name="navigateChannels" X="0" Y="0" />
        <mrml:SubmitAction Gadgets="lblIdChannel lblCheck lblIdMenu" Name="refreshChannel" 
            Target="dsChannel" Url="Data/XMLChannel.aspx" X="0" Y="0" />
        <mrml:ScriptAction Function="hora" Name="Scripthora" X="0" Y="0" />
        <mrml:ScriptAction Function="visibletrue" Name="ScriptMostrar" X="0" Y="0" />
        <mrml:ScriptAction Data="" Function="visiblefalse" Name="ScriptOcultar" X="0" 
            Y="0" />
        <mrml:ScriptAction Function="ordena" Name="ScriptOrdenar" X="0" 
            Y="0" />
        <mrml:ScriptAction Data="" Function="movePosition" Name="scriptPosition" X="0" 
            Y="0" />
        <mrml:ScriptAction Data="" Function="moveRight" Name="scriptRight" X="0" 
            Y="0" />
        <mrml:SetAction Name="setPosition" PropertyName="verticalPosition" 
            Target="phTblChannel" X="0" Y="0" />
        <mrml:ShowAction Name="ShowAction0" Targets="imgLeftArrow imgRightArrow" X="0" 
            Y="0" />
        <mrml:ShowAction Name="ShowAction1" Targets="TVBusyIndicator1" X="0" Y="0" />
        <mrml:SubmitAction Gadgets="lblIdMenu" Method="Get" Name="submitChannel" 
            Target="dsChannel" Url="Data/XMLChannel.aspx" X="0" Y="0" />
        <mrml:TimeoutAction Action="focusChannels" Delay="1000" Name="TimeoutAction0" 
            X="0" Y="0" />
    </mrml:TVActions>
    <mrml:TVLabel ID="lblTotalCheck" runat="server" 
        style="position: absolute; top: 98px; left: 940px;" Text="" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblIdChannel" runat="server" 
        style="position: absolute; top: 142px; left: 937px;" Text="" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblCheck" runat="server" 
        
        style="position: absolute; top: 60px; left: 939px; height: 29px; width: 99px;" 
        Text="" IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblIndex" runat="server" 
        style="position: absolute; top: 31px; left: 939px;" Text="" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVButton ID="btnChannel1" runat="server" 
        Background="~/Images/btn_canal_opacity.png" FocusBackground="argb(0,0,0,0)" 
        FocusGlow="argb(0,0,0,0)" Pressed="argb(0,0,0,0)" 
        
        style="position: absolute; width: 288px; height: 40px; top: 250; left: 920;">
        <mrml:TVImage ID="imgChannel1" runat="server" 
            Style="position: absolute; height: 31px; width: 36px; left: 19; top: 4;">
        </mrml:TVImage>
        <mrml:TVLabel ID="lblChannel1" runat="server" 
            Style="position: absolute; left: 70; width: 178px; height: 40px; top: 0px;" 
            Text="" VerticalAlign="Center" Foreground="argb(255,0,0,0)" 
            ClipChildren="True">
        </mrml:TVLabel>
    </mrml:TVButton>
    <mrml:TVButton ID="btnChannel2" runat="server" 
        Background="~/Images/btn_canal_opacity.png" FocusBackground="argb(0,0,0,0)" 
        FocusGlow="argb(0,0,0,0)" Pressed="argb(0,0,0,0)" 
        
        style="position: absolute; width: 288px; height: 40px; top: 292; left: 920;">
        <mrml:TVImage ID="imgChannel2" runat="server" 
            Style="position: absolute; height: 31px; width: 36px; left: 19; top: 4;">
        </mrml:TVImage>
        <mrml:TVLabel ID="lblChannel2" runat="server" 
            Style="position: absolute; left: 70; width: 178px; height: 40px; top: 0px;" 
            Text="" VerticalAlign="Center" Foreground="argb(255,0,0,0)" 
            ClipChildren="True">
        </mrml:TVLabel>
    </mrml:TVButton>
    <mrml:TVButton ID="btnChannel3" runat="server" 
        Background="~/Images/btn_canal_opacity.png" FocusBackground="argb(0,0,0,0)" 
        FocusGlow="argb(0,0,0,0)" Pressed="argb(0,0,0,0)" 
        
        style="position: absolute; width: 288px; height: 40px; top: 334; left: 920;">
        <mrml:TVImage ID="imgChannel3" runat="server" 
            Style="position: absolute; height: 31px; width: 36px; left: 19; top: 4;">
        </mrml:TVImage>
        <mrml:TVLabel ID="lblChannel3" runat="server" 
            Style="position: absolute; left: 70; width: 178px; height: 40px; top: 0px;" 
            Text="" VerticalAlign="Center" Foreground="argb(255,0,0,0)" 
            ClipChildren="True">
        </mrml:TVLabel>
    </mrml:TVButton>
    <mrml:TVButton ID="btnChannel4" runat="server" 
        Background="~/Images/btn_canal_opacity.png" FocusBackground="argb(0,0,0,0)" 
        FocusGlow="argb(0,0,0,0)" Pressed="argb(0,0,0,0)" 
        
        style="position: absolute; width: 288px; height: 40px; top: 376; left: 920;">
        <mrml:TVImage ID="imgChannel4" runat="server" 
            Style="position: absolute; height: 31px; width: 36px; left: 19; top: 4;">
        </mrml:TVImage>
        <mrml:TVLabel ID="lblChannel4" runat="server" 
            Style="position: absolute; left: 70; width: 178px; height: 40px; top: 0px;" 
            Text="" VerticalAlign="Center" Foreground="argb(255,0,0,0)" 
            ClipChildren="True">
        </mrml:TVLabel>
    </mrml:TVButton>



    <mrml:TVAnimations ID="TVAnimations1" runat="server" Animations-Capacity="4" 
        style="position:absolute; top: 0; left: 0;" Version="9">
        <mrml:AnimationContainer Name="AnimationContainer0" X="0" Y="0">
            <mrml:FadeAnimation Duration="0.998" From="0" Index="1" Name="FadeAnimation" 
                To="1" />
        </mrml:AnimationContainer>
        <mrml:AnimationContainer Name="fadeContainer" X="0" Y="0">
            <mrml:FadeAnimation Duration="0.5" From="0" Index="1" Name="fadeButton" 
                To="1" />
        </mrml:AnimationContainer>
    </mrml:TVAnimations>
    <mrml:TVLabel ID="lblPhoto" runat="server" 
        style="position: absolute; top: 70px; left: 1163px;" Text="" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblName" runat="server" 
        style="position: absolute; top: 107px; left: 1161px;" Text="" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="lblIdMenuLast" runat="server" 
        style="position: absolute; top: 34px; left: 1165px;" Text="" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVButton ID="btnChannels" runat="server" 
        Background="~/Images/btn-channel.png" 
        FocusBackground="~/Images/btn-channel_focus.png" FocusGlow="argb(104,120,142,236)" 
        Pressed="argb(0,0,0,0)" 
        
        style="position: absolute; top: 440px; width: 285px; height: 55px; left: 921;" 
        IsVisible="False" NextDown="btnChannels" NextLeft="phTblChannel" 
        NextRight="btnChannels" NextUp="btnChannels" onclick="navigateChannels" 
        onfocus="ScriptOcultar" Glow="argb(104,120,142,236)">
    </mrml:TVButton>
    <mrml:TVImage ID="imgIconChannel" runat="server" 
        Background="~/Images/icon_canal.png" 
        style="position: absolute; top: 215px; left: 920; height: 24px; width: 234px;">
    </mrml:TVImage>
    <mrml:TVLabel ID="Lblinicio" runat="server" 
        style="position: absolute; top: 99px; left: 1046px;" Text="TVLabel" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVLabel ID="LblFin" runat="server" 
        style="position: absolute; top: 66px; left: 1052px;" Text="TVLabel" 
        IsVisible="False">
    </mrml:TVLabel>
    <mrml:TVImage ID="TVImage1" runat="server" 
        
        
        
        style="position: absolute; top: 502px; left: 530px; height: 40px; width: 236px;">
    </mrml:TVImage>
    <mrml:TVBusyIndicator ID="TVBusyIndicator1" runat="server" 
        
        style="position: absolute; height: 96px; width: 96px; left: 1155; top: 596;" 
        StyleClass="Image.Busy.Indicator">
    </mrml:TVBusyIndicator>
</mrml:TVPage>
</form>


