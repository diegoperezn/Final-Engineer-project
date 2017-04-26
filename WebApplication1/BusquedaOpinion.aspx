<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaOpinion.aspx.vb" Inherits="WebApplication1.BusquedaOpinion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="labelTitulo" runat="server" 
            Text="<%$ Resources:labelsOpinion, labelTituloListaOpiniones %>" ></asp:Label>
    </h2>
    <div class="formulario">
			<div class="campo">
				<span>
                    <asp:Label ID="labelmail" runat="server" Text="<%$ Resources:labelsUsuarios, mail %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="mail" runat="server"></asp:TextBox>
				</span>
			</div>
    </div> 
    <div class="submitContainer">
        <asp:LinkButton class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:LinkButton>
        <asp:LinkButton ID="buscar" runat="server" Text="<%$ Resources:labels, buscar %>" ></asp:LinkButton>
    </div>
    <div class="clear ">
        <asp:GridView ID="listadoOpiniones" runat="server" AutoGenerateColumns="False" 
            DataSourceID="opinionBusiness" AllowPaging="True" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            CssClass="tablaResultado" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" 
                    SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="<%$ Resources:labelsUsuarios, nombre %>" 
                    SortExpression="nombre" />
                <asp:BoundField DataField="mail" HeaderText="<%$ Resources:labelsUsuarios, mail %>" SortExpression="mail" />
            </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:labels, listaVacia %>"></asp:Label>
        </EmptyDataTemplate>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="opinionBusiness" runat="server" 
            SelectMethod="listarOpinionesPorMail" TypeName="Negocio.OpinionBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="mail" Name="mail" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
