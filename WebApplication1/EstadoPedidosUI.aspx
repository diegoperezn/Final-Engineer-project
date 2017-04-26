<%@ Page Language="vb" MasterPageFile="~/Site.Master"  CodeBehind="EstadoPedidosUI.aspx.vb" Inherits="WebApplication1.EstadoPedidosUI" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<h3> Estados Pedidos </h3>
	<div class="formularioBusqueda">
		<div class="campo">
			<span>
				<label class="label">Cliente:</label>
			</span>
			<span>
				<select class="input">
					<option value="volvo">Apellido1, nombre1</option>
					<option value="volvo">Apellido2, nombre2</option>
					<option value="volvo">Apellido3, nombre3</option>
					<option value="volvo">Apellido4, nombre4</option>
					<option value="volvo">Apellido5, nombre5</option>
				</select>
			</span>
		</div>
		<div class="campo" >
			<span>
				<label class="label">Estado:</label>
			</span>
			<span>
				<select class="input">
					<option value="volvo">Pendiente entrega</option>
					<option value="saab">Entregado</option>
					<option value="mercedes">produccion</option>
					<option value="audi">Pendiente diseño</option>
				</select> 
			</span>
		</div>
		<div class="campo" style="clear:left;">
			<span>
				<label class="label">Diseño:</label>
			</span>
			<span>
				<select class="input">
					<option value="volvo">Volvo - 16x5</option>
					<option value="saab">Saab - 5x5</option>
					<option value="mercedes">Mercedes - 8x3</option>
					<option value="audi">Audi - 12x8</option>
				</select>
			</span>
		</div>
		<div class="campo">
			<span>
				<label class="label">Tipo De Prenda:</label>
			</span>
			<span>
				<select class="input">
					<option value="volvo">Campera armada</option>
					<option value="saab">Frente campera</option>
					<option value="mercedes">Bolsillo</option>
					<option value="audi">Gorro</option>								
				</select> 
			</span>
		</div>
	</div>
	<div class="botones">
		<input type="button" class="submit" value="Buscar"/>
	</div>
	<div class="tabla">
	<table border="2">
		<tbody>
		<tr>
		<td>Id</td>
		<td>Fecha Inicio</td>
		<td>Fecha esperada finalizacion</td>
		<td>Dise?o</td>
		<td>Prenda</td>
		<td>Cantidad</td>
		<td>Cliente</td>		
		<td>Estado</td>
		<td>Porcentaje Realizacion</td>
		</tr>
		<tr>
		<td>123</td>
		<td>21/06/2012 09:00</td>	
		<td>22/06/2012 15:00</td>
		<td>AU LaPlata</td>
		<td>Bolsillo</td>
		<td>100</td>
		<td>Boris</td>
		<td>En Produccion</td>
		<td>73%</td>
		</tr>
		<tr>
		<td>123</td>
		<td>21/06/2012 09:00</td>	
		<td>22/06/2012 15:00</td>
		<td>AU LaPlata</td>
		<td>Bolsillo</td>
		<td>100</td>
		<td>Boris</td>
		<td>En Produccion</td>
		<td>73%</td>
		</tr>
		<tr>
		<td>123</td>
		<td>21/06/2012 09:00</td>	
		<td>22/06/2012 15:00</td>
		<td>AU LaPlata</td>
		<td>Bolsillo</td>
		<td>100</td>
		<td>Boris</td>
		<td>En Produccion</td>
		<td>73%</td>
		</tr>
		<tr>
		<td>123</td>
		<td>21/06/2012 09:00</td>	
		<td>22/06/2012 15:00</td>
		<td>AU LaPlata</td>
		<td>Bolsillo</td>
		<td>100</td>
		<td>Boris</td>
		<td>En Produccion</td>
		<td>73%</td>
		</tr>
		<tr>
		<td>123</td>
		<td>21/06/2012 09:00</td>	
		<td>22/06/2012 15:00</td>
		<td>AU LaPlata</td>
		<td>Bolsillo</td>
		<td>100</td>
		<td>Boris</td>
		<td>En Produccion</td>
		<td>73%</td>
		</tr>
		</tbody>
		</table>
	</div>
    <div class="botones" >
		<asp:Button class="submit" ID="editarFamilia" runat="server" Text="Cargar pedido" />
	</div>
</asp:Content>

