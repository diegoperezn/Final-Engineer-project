<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaUsuario.aspx.vb" Inherits="WebApplication1.BusquedaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="cargaDisenios">
		<h2> 
            <asp:Label ID="labelTitulo" runat="server" Text="<%$ Resources:labelsUsuarios, labelTituloListaUsuarios %>" ></asp:Label>
        </h2>
		<div class="formulario">
			<div class="campo">
				<span>
                    <asp:Label ID="labelNombre" runat="server" Text="<%$ Resources:labelsUsuarios, nombre %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="nombre" runat="server"></asp:TextBox>
				</span>
			</div>
			<div class="campo">
				<span>
                    <asp:Label ID="labelApellido" runat="server" Text="<%$ Resources:labelsUsuarios, apellido %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="apellido" runat="server"></asp:TextBox>
				</span>
			</div>
            <div class="campo">
				<span>
                    <asp:Label ID="labelMail" runat="server" Text="<%$ Resources:labelsUsuarios, mail %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="mail" runat="server"></asp:TextBox>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label ID="labelTelFijo" runat="server" Text="<%$ Resources:labelsUsuarios, telFijo %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="telFijo" runat="server"></asp:TextBox>
				</span>
			</div>
            <div class="campo">
				<span>
					<asp:Label ID="labelTelMovil" runat="server" Text="<%$ Resources:labelsUsuarios, telMovil %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="telMovil" runat="server"></asp:TextBox>
				</span>
			</div>
        </div>
        <div class="submitContainer">
            <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
            <asp:LinkButton ID="buscar" runat="server" Text="<%$ Resources:labels, buscar %>" ></asp:LinkButton>
		</div>
        <div class="clear ">
            <asp:GridView ID="listadoUsuarios" runat="server" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                CssClass="tablaResultado" ForeColor="Black" GridLines="Vertical" 
                AutoGenerateColumns="False" DataSourceID="usuarioBusiness" 
                AllowPaging="True">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField EditImageUrl="~/images/editar.png" 
                        SelectImageUrl="~/images/masDetalle.png" ShowEditButton="True" 
                        ShowSelectButton="True" ButtonType="Image" />
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                    <asp:BoundField DataField="nombre" HeaderText="<%$ Resources:labelsUsuarios, nombre %>" 
                        SortExpression="nombre" />
                    <asp:BoundField DataField="apellido" HeaderText="<%$ Resources:labelsUsuarios, apellido %>" 
                        SortExpression="apellido" />
                    <asp:BoundField DataField="telefonoMovil" HeaderText="<%$ Resources:labelsUsuarios, telMovil %>" 
                        SortExpression="telefonoMovil" />
                    <asp:BoundField DataField="telefonoFijo" HeaderText="<%$ Resources:labelsUsuarios, telFijo %>" 
                        SortExpression="telefonoFijo" />
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
            <asp:ObjectDataSource ID="usuarioBusiness" runat="server" 
                SelectMethod="listarUsuariosConRestricciones" 
                TypeName="Negocio.UsuarioBusiness">
                <SelectParameters>
                    <asp:ControlParameter ControlID="nombre" Name="nombre" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="apellido" Name="apellido" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="mail" Name="mail" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="telMovil" Name="telMovil" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="telFijo" Name="telfijo" PropertyName="Text" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div> 
</asp:Content>
