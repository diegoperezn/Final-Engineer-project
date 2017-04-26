<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleEstadistica.aspx.vb" Inherits="WebApplication1.EstadisticasUI" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label ID="labelTituloEstadisticas" runat="server" Text="<%$ Resources:labels, tituloEstadisticas %>" ></asp:Label>
    </h2>
    <div><h3><asp:Label ID="Label5" class="label" runat="server" Text="<%$ Resources:labels, ventasPorMes %>"></asp:Label></h3></div>
    <div class="campo">
    <asp:Chart ID="Chart1" runat="server" DataSourceID="baseTest" Height="279px" 
            Width="279px">
        <series>
            <asp:Series Name="Series1" XValueMember="Column1" YValueMembers="Column2">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </chartareas>
    </asp:Chart>
    </div>
    <div class="campo">
    <asp:Chart ID="Chart2" runat="server" DataSourceID="baseTest" Height="281px" 
        Width="282px" >
        <series>
            <asp:Series ChartType="Pie" Name="Series1" XValueMember="Column1" 
                YValueMembers="Column2" ChartArea="ChartArea1">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </chartareas>
    </asp:Chart>
    </div> 
    <asp:SqlDataSource ID="baseTest" runat="server" 
        ConnectionString="<%$ ConnectionStrings:uniprofConnectionString %>" 
        SelectCommand="select  CAST(Month(fecha) AS varchar(5)) + '/' + CAST(Year(fecha) AS varchar(5)),
		     Sum(lf.precio * lf.cantidad) , sum(iva)
    from LineaFactura as lf, Factura as f 
    where lf.nro_factura = f.nro_factura 
	    and lf.nro_factura = f.nro_factura 
	    and lf.tipo_factura = f.tipo_factura 
    group by CAST(Month(fecha) AS varchar(5)) + '/' + CAST(Year(fecha) AS varchar(5))">
    </asp:SqlDataSource>
    <div><h3><asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labels, produccionPorMaquina %>"></asp:Label></h3></div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="campo"  style ="width:100%">
             <div class="campo">
        <asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labels, maquina %>"></asp:Label>
        <asp:DropDownList ID="maquina" AutoPostBack=true runat="server" DataSourceID="maquias" 
            DataTextField="nombre" DataValueField="codMaquina"> </asp:DropDownList>
        <asp:ObjectDataSource ID="maquias" runat="server" SelectMethod="listarMaquinas" 
            TypeName="Negocio.MaterialesBusiness"></asp:ObjectDataSource>
            </div>
            <div class="campo">
        <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labels, año %>"></asp:Label>
        <asp:DropDownList ID="año" AutoPostBack=true runat="server" > 
            <asp:ListItem Selected =true Text ="2012" Value ="2012"></asp:ListItem>
            </asp:DropDownList>
            </div>
        <asp:Chart ID="Chart3" runat="server" DataSourceID="produccionPorMaquina" 
            Width="653px">
            <Series>
                <asp:Series Name="Series1" XValueMember="fecha" YValueMembers="Column1" 
                    YValuesPerPoint="6">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="produccionPorMaquina" runat="server" 
            ConnectionString="<%$ ConnectionStrings:uniprofConnectionString %>" SelectCommand="select CAST(Month(fechaFinal) AS varchar(5)) + '/' 
		        + CAST(Year(fechaFinal) AS varchar(5)) as fecha, sum(p.cantidad * a.precioActual)
		        
             from produccion as p, articulos as a
		        where p.cod_articulo = a.cod_articulo 
                    AND p.cod_maquina = @codMaquina
                    AND Year(fechaFinal) = @year
	            group by CAST(Month(fechaFinal) AS varchar(5)) + '/' 
		        + CAST(Year(fechaFinal) AS varchar(5))
            order by fecha ">
            <SelectParameters>
                <asp:ControlParameter ControlID="maquina" DefaultValue="1" Name="codMaquina" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="año" DefaultValue="2012" Name="year" 
                    PropertyName="SelectedValue" Type =String  />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

    </ContentTemplate> 
    </asp:UpdatePanel>




    
    <div><h3><asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labels, costoInsumos %>"></asp:Label></h3></div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
             <div class="campo"  style ="width:100%">
             <div class="campo">
                <asp:Label ID="Label7" class="label" runat="server" Text="<%$ Resources:labels, año %>"></asp:Label>
                <asp:DropDownList ID="añoInsumos" AutoPostBack=true runat="server" > 
                    <asp:ListItem Selected =true Text ="2012" Value ="2012"></asp:ListItem>
                    </asp:DropDownList>
            </div> 

        <asp:Chart ID="Chart4" runat="server" DataSourceID="gastosPorInsumo" 
            Width="653px">
            <Series>
                <asp:Series Name="Series1" 
                    YValuesPerPoint="6" XValueMember="fecha" YValueMembers="Column1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                 <asp:SqlDataSource ID="gastosPorInsumo" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:uniprofConnectionString %>" SelectCommand="select CAST(Month(fecha) AS varchar(5)) + '/' 
		        + CAST(Year(fecha) AS varchar(5)) as fecha, (sum(m.cantidad * i.costo) * -1)
		        
             from movimientosStock as m, insumo as i
		        where m.cod_insumo = i.cod_insumo 
                    AND Year(fecha) = @year
                    AND m.tipo = 1
	            group by CAST(Month(fecha) AS varchar(5)) + '/' 
		        + CAST(Year(fecha) AS varchar(5))
            order by fecha">
                     <SelectParameters>
                         <asp:ControlParameter ControlID="añoInsumos" DefaultValue="2012" Name="year" 
                             PropertyName="SelectedValue" Type =String  />
                     </SelectParameters>
                 </asp:SqlDataSource>
    </div>

    </ContentTemplate> 
    </asp:UpdatePanel>
</asp:Content>
