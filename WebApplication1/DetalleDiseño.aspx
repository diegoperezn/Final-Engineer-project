<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleDiseño.aspx.vb" Inherits="WebApplication1.DetalleDiseño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<h2> 
            <asp:Label ID="labelTituloCreacion" runat="server" Text="<%$ Resources:labelsDiseño, labelTituloCreacion %>" ></asp:Label>
        </h2>
		<div class="formulario">
             <asp:HiddenField ID="idDiseño" runat="server" />
                        
            <div class="campo">
                
				<span>
					<asp:Label ID="Label123" class="label" runat="server" Text="<%$ Resources:labelsDiseño, cliente %>"></asp:Label>
				</span>
				<span>
                    <asp:Label ID="clientes" runat="server"></asp:Label>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsDiseño, nombre %>"></asp:Label>
				</span>
				<span>
					 <asp:Label ID="nombre" class="detalle" runat="server"></asp:Label>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsDiseño, alto %>"></asp:Label>
				</span>
				<span>
					 <asp:Label ID="altura" class="detalle" runat="server"></asp:Label>
				</span>
			</div>
           	<div class="campo">
				<span>
					<asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labelsDiseño, ancho %>"></asp:Label>
				</span>
				<span>
					 <asp:Label ID="ancho" class="detalle" runat="server"></asp:Label>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labelsDiseño, puntadas %>"></asp:Label>
				</span>
				<span>
                    <asp:Label ID="puntadas" class="detalle" runat="server"></asp:Label>
				</span>
			</div>
            <div class="clear">
                <div><h3><asp:Label ID="Label5" class="label" runat="server" Text="<%$ Resources:labelsDiseño, archivos %>"></asp:Label></h3></div>
                <div class="campo clear" style="width: 90%;" >
				    <span>
					    <asp:Label ID="Label6" class="label" runat="server" Text="<%$ Resources:labelsDiseño, imagen %>"> </asp:Label>
                        
                    </span>
				    <span>
                        <div style="width: 108%;">
					    <asp:Label ID="imagen"  class="detalle" runat="server"></asp:Label>
                        <asp:ImageButton ID="descargarImagen" runat="server" ImageUrl="~/images/descargar.png" />
                        </div>
                   </span>
			    </div>
                <div class="clear" >
                    <asp:Image ID="imagenDiseño" class="imagenDiseño" runat="server" />
                </div>
			    <div class="campo clear" style="width: 90%;">
				    <span>
					    <asp:Label ID="Label9" class="label" runat="server" Text="<%$ Resources:labelsDiseño, ficha %>"></asp:Label>
                        
				    </span>
				    <span>
                    <div style="width: 108%;">
                        <asp:Label ID="ficha"  class="detalle" runat="server"></asp:Label>
                        <asp:ImageButton ID="descargarFicha" runat="server"  ImageUrl="~/images/descargar.png" />
                    </div>
				    </span>
			    </div>
                <div class="clear">
                    <asp:Image ID="imagenFicha" class="imagenDiseño"  runat="server" />
                </div>
			    <div class="campo" style="width: 90%;">
				    <span>
					    <asp:Label ID="Label7" class="label" runat="server" Text="<%$ Resources:labelsDiseño, matrizFinal %>" ></asp:Label>
				    </span>
				    <span>
                    <div style="width: 108%;">
					    <asp:Label ID="matrizFinal"  class="detalle" runat="server" ></asp:Label>
                        <asp:ImageButton ID="descargarMatriz" runat="server" 
                        ImageUrl="~/images/descargar.png" />
</div>
				    </span>
			    </div>
			    <div class="campo" style="width: 90%;">
				    <span>
					    <asp:Label ID="Label8" class="label" runat="server" Text="<%$ Resources:labelsDiseño, matrizEditable %>"></asp:Label>
				    </span>
				    <span>
                    <div style="width: 108%;">
					    <asp:Label ID="matrizEditable"  class="detalle" runat="server"></asp:Label>
                        <asp:ImageButton ID="descargarEditable" runat="server" 
                        ImageUrl="~/images/descargar.png" />
                        </div>
				    </span>
			    </div>
            </div>
            
            <div><h3><asp:Label ID="Labellista" class="label" runat="server" Text="<%$ Resources:labelsDiseño, listaInsumos %>"></asp:Label></h3></div>
            <div class="clear">
                <div class="clear">
                    <asp:GridView ID="listaInsumo" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablaResultado" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/eliminar.png" 
                                ShowDeleteButton="True" />
                            <asp:TemplateField HeaderText="<%$ Resources:labelsDiseño, insumo %>">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("insumo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>
            </div>

		<div class="submitContainer">
            <asp:Button class="submit" ID="editar" runat="server" Text="<%$ Resources:labels, editar %>" />
            <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
		</div>
    </div> 
</asp:Content>
