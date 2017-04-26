<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleEncuestas.aspx.vb" Inherits="WebApplication1.DetalleEncuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div><h3><asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labels, encuestaCalidad %>"></asp:Label></h3></div>
    <div class="campo">
        <div><asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labels, calidad %>"></asp:Label></div>
        <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource1">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" XValueMember="puntaje" 
                    YValueMembers="resultado">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:uniprofConnectionString %>" SelectCommand="select COUNT(1) as resultado, 'voto:' +  CAST(calidad AS varchar(1)) as puntaje from encuesta
	group by calidad"></asp:SqlDataSource>
    </div>
    <div class="campo">
    <div><asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labels, eficiencia %>"></asp:Label></div>
        <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource2">
            <Series>
                <asp:Series ChartType="Pie" Name="Series1" XValueMember="puntaje" 
                    YValueMembers="Column1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:uniprofConnectionString %>" SelectCommand="select COUNT(1), 'voto:' +  CAST(eficiencia AS varchar(1)) as puntaje from encuesta
	group by eficiencia"></asp:SqlDataSource>
    </div>
    <div class="campo">
    <div><asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labels, atencion %>"></asp:Label></div>
        <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource3">
            <Series>
                <asp:Series ChartType="Pie" Name="Series1" XValueMember="puntaje" 
                    YValueMembers="Column1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:uniprofConnectionString %>" SelectCommand="select COUNT(1), 'voto:' +  CAST(atencion AS varchar(1)) as puntaje from encuesta
	group by atencion"></asp:SqlDataSource>
    </div>
</asp:Content>
