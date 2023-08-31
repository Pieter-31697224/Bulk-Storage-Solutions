<%@ Page Title="Reports" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Bulk_Storage_Solutions.Views.Reports" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.<asp:Chart ID="Chart1" runat="server" Height="219px" Width="1305px">
        <series>
            <asp:Series Name="Series1">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </chartareas>
        </asp:Chart>
    </h2>
</asp:Content>
