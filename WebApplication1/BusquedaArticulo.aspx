<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaArticulo.aspx.vb" Inherits="WebApplication1.BusquedaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2> 
        <asp:Label ID="labelTitulo" runat="server" Text="<%$ Resources:labelsArticulo, labelTituloLista %>" ></asp:Label>
    </h2>
    <div class="campo">
	    <span>
		    <asp:Label ID="Labelcliente" class="label" runat="server" Text="<%$ Resources:labelsArticulo, diseño %>"> </asp:Label>
	    </span>
	    <span>
            <asp:DropDownList class="input" ID="diseño" runat="server" 
            DataSourceID="ObjectDataSource1" DataTextField="nombre" 
            DataValueField="idDiseño"></asp:DropDownList>
	    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="listarDiseños" TypeName="Negocio.DiseñoBusiness">
        </asp:ObjectDataSource>
	    </span>
    </div>
        <div class="campo">
	    <span>
		    <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsArticulo, tipoPrenda %>"> </asp:Label>
	    </span>
	    <span>
            <asp:DropDownList class="input" ID="tipoPrenda" runat="server" 
            DataSourceID="ObjectDataSource3" DataTextField="descripcion" 
            DataValueField="tipoPrenda"></asp:DropDownList>
	        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                SelectMethod="ListarPrendas" TypeName="Negocio.TipoPrendaBusiness">
            </asp:ObjectDataSource>
	    </span>
    </div>
    <div class="submitContainer">
        <asp:LinkButton class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="cancelar" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:LinkButton>
        <asp:LinkButton ID="buscar" runat="server" Text="<%$ Resources:labels, buscar %>" ></asp:LinkButton>
    </div>
    <div class ="clear">
        <asp:GridView ID="listaArticulos" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            CssClass="tablaResultado" DataSourceID="ObjectDataSource2" ForeColor="Black" 
            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" EditImageUrl="~/images/editar.png" 
                    SelectImageUrl="~/images/masDetalle.png" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="codArticulo" HeaderText="<%$ Resources:labelsArticulo, codArticulo %>" 
                    SortExpression="codArticulo" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsArticulo, diseño %>" 
                    SortExpression="diseño">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("diseño").nombre %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsArticulo, tipoPrenda %>" 
                    SortExpression="tipoPrenda">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("tipoPrenda").descripcion %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="precioActual" DataFormatString="{0:c}" 
                    HeaderText="<%$ Resources:labelsArticulo, precioActual %>" SortExpression="precioActual" />
                <asp:BoundField DataField="produccion" HeaderText="<%$ Resources:labelsArticulo, produccion %>" 
                    SortExpression="produccion" />
            </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:labels, listaVacia %>"></asp:Label>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="listarArticulos" TypeName="Negocio.ArticuloBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="tipoPrenda" Name="prenda" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="diseño" Name="diseño" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
