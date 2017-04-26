<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionPedido.aspx.vb" Inherits="WebApplication1.AltaModificacionPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarSelectRequeridos('clientes')) {
                if (errores == '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
            }

            if (document.getElementById('MainContent_listaProduccion') == null) {
                 errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, faltaTrabajo %>" />"  + "<br/>"
            }
            

             if (errores != '')  {
                var elemento = document.getElementById("errores");
                elemento.innerHTML = errores
                return false;
            } else {
                return true;
            }
        }

        function validarCamposTrabajo() {
            var errores = '';

            if (!validarRequeridos('cantidad')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('articulos')) {
                if (errores == '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
            }

            if (!validarRegex('cantidad', /^\d+$/)) {
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cargaDisenios">
		<h2> 
            <asp:Label ID="labelTituloEdicion" runat="server" Text="<%$ Resources:labelsPedido, labelTituloCreacion %>" ></asp:Label>
        </h2>
		<div class="formulario">
            <div id="errores" class="errores">
                <asp:HiddenField ID="idDiseño" runat="server" />
            </div>
             <div class="clear">           
             <div><h3><asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labelsPedido, datosPedido %>"></asp:Label></h3></div>
                <asp:Panel ID="clientePanel" class="campo" runat="server">
                    
                    <span>
					    <asp:Label ID="Label55" class="label" runat="server" Text="<%$ Resources:labelsPedido, cliente %>"></asp:Label>
				    </span>
				    <span>
                        <asp:DropDownList ID="clientes" runat="server" ToolTip="<%$ Resources:labelsPedido, ayudaCliente %>"
                        DataSourceID="clienteBusiness" DataTextField="nombre" AutoPostBack =true  
                        DataValueField="idCliente"></asp:DropDownList>
				    <asp:ObjectDataSource ID="clienteBusiness" runat="server" 
                        SelectMethod="CargarClientes" TypeName="Negocio.UsuarioBusiness">
                    </asp:ObjectDataSource>
				    </span>
			    </asp:Panel>
			    <div class="campo" style="width: 93%;">
				    <span>
					    <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsPedido, comentario %>"></asp:Label>
				    </span>
				    <span>
					     <asp:TextBox ID="comentario" class="input" runat="server" Rows="3" ToolTip="<%$ Resources:labelsPedido, ayudaComentario %>"
                        TextMode="MultiLine"></asp:TextBox>
				    </span>
			    </div>
			    <div class="campo" style="width: 111%;">
				    <span>
					    <asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsPedido, fecha %>"></asp:Label>
				    <asp:Calendar ID="Calendar1" runat="server" ToolTip="<%$ Resources:labelsPedido, ayudaFecha %>" BackColor="White" 
                        BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" 
                        Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" 
                        TitleFormat="Month" Width="400px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" 
                            ForeColor="#333333" Height="10pt" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" 
                            Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" 
                            ForeColor="White" Height="14pt" />
                        <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar>
				    </span>
			    </div>
            </div> 
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="clear">
                    <div><h3><asp:Label ID="Label5" class="label" runat="server" Text="<%$ Resources:labelsPedido, listaProduccion %>"></asp:Label></h3></div>
                    <asp:GridView ID="listaProduccion" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablaResultado" ForeColor="Black" GridLines="Vertical" 
                        AllowPaging="True" AutoGenerateColumns="False" ToolTip="<%$ Resources:labelsPedido, ayudaListaProduccion %>">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/eliminar.png" 
                                ShowDeleteButton="True" />
                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                                SortExpression="cantidad" />
                            <asp:BoundField DataField="fechaInicio" DataFormatString="{0:g}" 
                                HeaderText="fechaInicio" SortExpression="fechaInicio" />
                            <asp:BoundField DataField="fechaFinal" DataFormatString="{0:g}" 
                                HeaderText="fechaFinal" SortExpression="fechaFinal" />
                            <asp:TemplateField HeaderText="maquina" ConvertEmptyStringToNull="False" 
                                SortExpression="maquina">
                                <ItemTemplate>
                                    <asp:Label ID="Label56" runat="server" Text='<%# Eval("maquina").nombre %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="articulo" 
                                SortExpression="articulo">
                                <ItemTemplate>
                                    <asp:Label ID="Label57" runat="server" 
                                        Text='<%# Eval("articulo").diseño.nombre %>'></asp:Label>
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
                <div><h3><asp:Label ID="Labellista" class="label" runat="server" Text="<%$ Resources:labelsPedido, crearTrabajo %>"></asp:Label></h3></div>
                <div id="erroresInsumos" class="errores"></div>
                <div class="clear">
                    <div class="campo">
	                        <span>
		                        <asp:Label ID="Labelcliente" class="label" runat="server" Text="<%$ Resources:labelsArticulo, articulo %>"> </asp:Label>
	                        </span>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate >
	                            <span>
                                    <asp:DropDownList class="input" ID="articulos" 
                                    ToolTip="<%$ Resources:labelsPedido, ayudaDiseño %>" runat="server"></asp:DropDownList>
	                            </span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
             
                    <div class="campo">
				        <span>
					        <asp:Label ID="LabelcantidadInsumo" class="label" runat="server"  Text="<%$ Resources:labelsPedido, cantidad %>"></asp:Label>
				        </span>
				        <span>
					         <asp:TextBox ID="cantidad" class="input" ToolTip="<%$ Resources:labelsPedido, ayudaCantidad %>" runat="server"></asp:TextBox>
				        </span>
			        </div>
                    <div class="submitContainer ">
                        <asp:Button ID="cargarInsumo" class="submit" ToolTip="<%$ Resources:labelsPedido, ayudaBuscarFechas %>" OnClientClick ="return validarCamposTrabajo()"
                                 runat="server" Text="<%$ Resources:labelsPedido, buscarFechas %>" />
                    </div>
                    <div class="clear">
                     <div><h3><asp:Label ID="Label6" class="label" runat="server" Text="<%$ Resources:labelsPedido, posiblesFechas %>"></asp:Label></h3></div>
                    <asp:GridView ID="listaPosiblesFechas" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablaResultado" ForeColor="Black" GridLines="Vertical" 
                        AllowPaging="True" AutoGenerateColumns="False" ToolTip="<%$ Resources:labelsPedido, ayudaSeleccionarFecha %>">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/tilde.png" 
                                SelectImageUrl="~/images/tilde.png" ShowSelectButton="True" />
                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                                SortExpression="cantidad" />
                            <asp:BoundField DataField="fechaInicio" DataFormatString="{0:g}" 
                                HeaderText="fechaInicio" SortExpression="fechaInicio" />
                            <asp:BoundField DataField="fechaFinal" DataFormatString="{0:g}" 
                                HeaderText="fechaFinal" SortExpression="fechaFinal" />
                            <asp:TemplateField HeaderText="maquina" ConvertEmptyStringToNull="False" 
                                SortExpression="maquina">
                                <ItemTemplate>
                                    <asp:Label ID="Label56" runat="server" Text='<%# Eval("maquina").nombre %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="articulo" 
                                SortExpression="articulo">
                                <ItemTemplate>
                                    <asp:Label ID="Label57" runat="server" 
                                        Text='<%# Eval("articulo").diseño.nombre %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label58" runat="server" Text="<%$ Resources:labelsPedido, sinArticulo %>"></asp:Label>
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
                    </div>
                </div>

               </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="submitContainer">
            <asp:Button class="submit" ID="grabar" OnClientClick ="return validarCampos()" runat="server" ToolTip="<%$ Resources:labelsPedido, ayudaGrabar %>" Text="<%$ Resources:labels, grabar %>" />
            <asp:Button class="submit" ID="cancelar" runat="server" OnClientClick="history.back()" Text="<%$ Resources:labels, cancelar %>" />
		</div>
    </div> 

</asp:Content>
