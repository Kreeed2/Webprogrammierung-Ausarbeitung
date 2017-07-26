<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ausarbeitung._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <asp:Chart ID="Chart" runat="server" DataSourceID="SqlDataSource">
            <series>
                <asp:Series ChartType="Point" Name="Series" XValueMember="xValue" YValueMembers="yValue">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        
        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [xValue], [yValue] FROM [Point] ORDER BY [xValue]"></asp:SqlDataSource>
        
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Koordianten eintragen</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
                x-Koordinate: <asp:TextBox ID="TextBoxX" runat="server"></asp:TextBox><br/>
                y-Koordinate: <asp:TextBox ID="TextBoxY" runat="server"></asp:TextBox>
            <p>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Einfügen" />
            </p>
        </div>
    </div>

</asp:Content>
