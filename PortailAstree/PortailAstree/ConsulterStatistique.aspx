<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsulterStatistique.aspx.cs" Inherits="Astree.ConsulterStatistique" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <style type="text/css">
        legend
        {
            color: White;
            font-family: Segoe UI, Verdana, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            background-color: rgb(79, 79, 79);
            padding: 5px;
            margin: 5px;
        }
        fieldset
        {
            border-color: #bbb;
            border-width: 1px;
            border-style: solid;
            width: 100%;
            height: 292px;
        }
    </style>
    <div style="width: 700px; margin: 0px auto;">
        <div style="float: left;">
            
         <%-- <asp:DropDownList ID="ddlCountries" runat="server" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged"
    AutoPostBack = "true">
</asp:DropDownList><hr />--%>

            <asp:Chart ID="Chart2" runat="server" >
                 <Titles>
        <asp:Title ShadowOffset="3" Name="Items" />
    </Titles>
    <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
    </Legends>
                <Series>
                    <asp:Series Name="Series1" ></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>
      
    </div>
</asp:Content>
