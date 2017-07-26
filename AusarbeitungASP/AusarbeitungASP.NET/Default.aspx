<%@ Page Title="Newton-Polynom Rechner" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AusarbeitungASP.NET._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<asp:SqlDataSource ID="SqlDataSource" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    SelectCommand="SELECT DISTINCT [xValue], [yValue] FROM [Point] ORDER BY [xValue]"
    InsertCommand="INSERT INTO [Point] ([xValue], [yValue]) VALUES (CAST(@xValue AS Decimal(18, 0)), CAST(@yValue AS Decimal(18, 0)))"
    DeleteCommand="TRUNCATE TABLE [Point]">
    <InsertParameters>
        <asp:ControlParameter name="xValue" ControlID="TextBoxX" PropertyName="Text" />
        <asp:ControlParameter name="yValue" ControlID="TextBoxY" PropertyName="Text" />
    </InsertParameters>
</asp:SqlDataSource>
    <div class="jumbotron">
        <h1>Graphen</h1>
        <p class="lead">
            <asp:Chart ID="Chart" runat="server" DataSourceID="SqlDataSource">
            <Series>
                <asp:Series Name="Dots" XValueMember="xValue" YValueMembers="yValue" ChartType="Point"></asp:Series>
                <asp:Series Name="LineGraph" XValueMember="xValue" YValueMembers="yValue" ChartType="Line"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea"></asp:ChartArea>
            </ChartAreas>
            </asp:Chart>
            <p>
                Funktion: p(x) = <asp:Label ID="Label" runat="server"></asp:Label>
            </p>
       </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Koordinaten einfügen</h2>
            <p>
                Die eingebenen Koordinaten werden in den Graphen eingezeichnet und mit Geraden verbunden. Zusätzlich wird ein Interpolationspolynom nach Newton errechnet und unterhalb des Graphen angezeigt.
            </p>
            <p>
                x-Wert: <asp:TextBox ID="TextBoxX" runat="server"></asp:TextBox><br />
                y-Wert: <asp:TextBox ID="TextBoxY" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="ButtonSubmit" runat="server" Text="Einfügen" />
            <asp:Button ID="ButtonClear" runat="server" Text="Clear" />
        </div>
    </div>
</asp:Content>
