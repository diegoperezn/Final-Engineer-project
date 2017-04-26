<%@ Page Language="vb" MasterPageFile="~/Site.Master"  CodeBehind="AltaModificacionDiseño.aspx.vb" Inherits="WebApplication1.AltaDiseñoUI" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('nombre,altura,ancho,puntadas')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('clientes')) {
                if (errores = '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
            }

            if (!validarRegex('ancho', /^\d+(?:,\d{0,2})?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, alturaInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('altura', /^\d+(?:,\d{0,2})?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, anchoInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('puntadas', /^\d+$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, puntadasInvalido%>" />"  + "<br/>"
            }
             if (errores != '')  {
                var elemento = document.getElementById("errores");
                elemento.innerHTML = errores
                return false;
            } else {
                return true;
            }
        }

        function validarCamposInsumos() {
            var errores = '';

            if (!validarRequeridos('cantidadInsumo')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarRegex('cantidadInsumo', /^\d+(?:,\d{0,2})?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, cantidadInvalido%>" />"  + "<br/>"
            }

            if (errores != '')  {
                var elemento = document.getElementById("erroresInsumos");
                elemento.innerHTML = errores
                return false;
            } else {
                return true;
            }
        } 
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<div class="cargaDisenios">
		<h2> 
            <asp:Label ID="labelTituloCreacion" runat="server" Text="<%$ Resources:labelsDiseño, labelTituloCreacion %>" ></asp:Label>
            <asp:Label ID="labelTituloEdicion" runat="server" Text="<%$ Resources:labelsDiseño, labelTituloEdicion %>" ></asp:Label>
        </h2>
		<div class="formulario">
            <div id="errores" class="errores">
                <asp:HiddenField ID="idDiseño" runat="server" />
            </div>
                        
            <asp:Panel ID="clientePanel" class="campo" runat="server">
                
				<span>
					<asp:Label ID="Label5" class="label" runat="server" Text="<%$ Resources:labelsDiseño, cliente %>"></asp:Label>
				</span>
				<span>
                    <asp:DropDownList ID="clientes" runat="server" 
                    DataSourceID="clienteBusiness" DataTextField="nombre" 
                    DataValueField="idCliente"></asp:DropDownList>
				<asp:ObjectDataSource ID="clienteBusiness" runat="server" 
                    SelectMethod="CargarClientes" TypeName="Negocio.UsuarioBusiness">
                </asp:ObjectDataSource>
				</span>
			</asp:Panel>
			<div class="campo">
				<span>
					<asp:Label class="label" runat="server" Text="<%$ Resources:labelsDiseño, nombre %>"></asp:Label>
				</span>
				<span>
					 <asp:TextBox ID="nombre" class="input" runat="server"></asp:TextBox>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label class="label" runat="server" Text="<%$ Resources:labelsDiseño, alto %>"></asp:Label>
				</span>
				<span>
					 <asp:TextBox ID="altura" class="input" runat="server"></asp:TextBox>
				</span>
			</div>
           	<div class="campo">
				<span>
					<asp:Label class="label" runat="server" Text="<%$ Resources:labelsDiseño, ancho %>"></asp:Label>
				</span>
				<span>
					 <asp:TextBox ID="ancho" class="input" runat="server"></asp:TextBox>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labelsDiseño, puntadas %>"></asp:Label>
				</span>
				<span>
                    <asp:TextBox ID="puntadas" class="input" runat="server"></asp:TextBox>
				</span>
			</div>
            <div class="clear">
                <div><h3><asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labelsDiseño, archivos %>"></asp:Label></h3></div>
                <div class="campo">
				    <span>
					    <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsDiseño, imagen %>"></asp:Label>
                        <asp:Image ID="imagenCargada" runat="server"  
                        ImageUrl="~/images/tilde.png" Visible="False" />
				    </span>
				    <span>
					    <asp:FileUpload ID="imagen"  class="input" runat="server" />
				    </span>
			    </div>
			    <div class="campo">
				    <span>
					    <asp:Label class="label" runat="server" Text="<%$ Resources:labelsDiseño, matrizFinal %>" ></asp:Label>
                         <asp:Image ID="matrizCargada" runat="server"  
                        ImageUrl="~/images/tilde.png" Visible="False" />
				    </span>
				    <span>
					    <asp:FileUpload ID="matrizFinal"  class="input" runat="server" />
				    </span>
			    </div>
			    <div class="campo">
				    <span>
					    <asp:Label class="label" runat="server" Text="<%$ Resources:labelsDiseño, matrizEditable %>"></asp:Label>
                         <asp:Image ID="editableCargada" runat="server" 
                        ImageUrl="~/images/tilde.png" Visible="False"  />
				    </span>
				    <span>
					    <asp:FileUpload ID="matrizEditable"  class="input" runat="server" />
				    </span>
			    </div>
			    <div class="campo">
				    <span>
					    <asp:Label class="label" runat="server" Text="<%$ Resources:labelsDiseño, ficha %>"></asp:Label>
                         <asp:Image ID="fichaCargada" runat="server" ImageUrl="~/images/tilde.png" 
                        Visible="False"  />
				    </span>
				    <span>
                        <asp:FileUpload ID="ficha"  class="input" runat="server" />
				    </span>
			    </div>
            </div>
            </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                <div><h3><asp:Label ID="Labellista" class="label" runat="server" Text="<%$ Resources:labelsDiseño, listaInsumos %>"></asp:Label></h3></div>
                <div id="erroresInsumos" class="errores"></div>
                <div class="clear">
                    <div class="campo">
				        <span>
					        <asp:Label class="label" runat="server" Text="<%$ Resources:labelsDiseño, insumos %>"></asp:Label>
				        </span>
				        <span>
                            <asp:DropDownList ID="insumos" runat="server" DataSourceID="insumoBusiness" 
                            DataTextField="detalleTipoColor" DataValueField="codInsumo"></asp:DropDownList>
				        <asp:ObjectDataSource ID="insumoBusiness" runat="server" 
                            SelectMethod="listarInsumos" TypeName="Negocio.InsumoBusiness">
                        </asp:ObjectDataSource>
				        </span>
			        </div>
                    <div class="campo">
				        <span>
					        <asp:Label class="label" runat="server"  Text="<%$ Resources:labelsDiseño, cantidadInsumo %>"></asp:Label>
				        </span>
				        <span>
					         <asp:TextBox ID="cantidadInsumo" class="input" runat="server"></asp:TextBox>
				        </span>
			        </div>
                    <div class="submitContainer ">
                        <asp:Button ID="cargarInsumo" class="submit" OnClientClick ="return validarCamposInsumos()"
                                 runat="server" Text="Cargar insumo" />
                    </div>
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
            </ContentTemplate>
        </asp:UpdatePanel>
		<div class="submitContainer">
            <asp:Button class="submit" ID="grabar" OnClientClick="return validarCampos()" runat="server" Text="<%$ Resources:labels, grabar %>" />
            <asp:Button class="submit" ID="editar" OnClientClick="return validarCampos()" runat="server" Text="<%$ Resources:labels, editar %>" />
            <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
		</div>
    </div> 
</asp:Content>
