<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleProduccion.aspx.vb" Inherits="WebApplication1.DetalleProduccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2> 
        <asp:Label ID="labelTituloDetalle" runat="server" Text="<%$ Resources:labelsProduccion, labelTituloDetalle %>" ></asp:Label>
    </h2>
	<div class="formulario">
        <div class="clear">           
        <div class="campo" >
                
            <span>
				<asp:Label ID="Label55" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, codPedido %>"></asp:Label>
			</span>
			<span>
                <asp:Label ID="codPedido" class="detalle"  runat="server"></asp:Label>
			</span>
			</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label1" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, diseño %>"></asp:Label>
			</span>
			<span>
					<asp:Label ID="diseño" class="detalle" runat="server" ></asp:Label>
			</span>
		</div>
        </div> 
        <div class="campo" >
            <span>
				<asp:Label ID="Label2" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, prenda %>"></asp:Label>
			</span>
			<span>
                <asp:Label ID="prenda" class="detalle"  runat="server"></asp:Label>
			</span>
		</div>
        <div class="campo" >
            <span>
				<asp:Label ID="Label5" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, cantidad %>"></asp:Label>
			</span>
			<span>
                <asp:Label ID="cantidad" class="detalle"  runat="server"></asp:Label>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label8" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, comentario %>"></asp:Label>
			</span>
			<span>
					<asp:Label ID="comentario" class="detalle" runat="server" ></asp:Label>
			</span>
		</div>
                <div class="campo" >
                    
            <span>
				<asp:Label ID="Label4" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, estadoActual %>"></asp:Label>
			</span>
			<span>
                <asp:Label ID="estado" class="detalle"  runat="server"></asp:Label>
			</span>
			</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label6" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, fechaInicio %>"></asp:Label>
			</span>
			<span>
					<asp:Label ID="fechaInicio" class="detalle" runat="server" ></asp:Label>
			</span>
		</div>
        <div class="campo" >
            <span>
				<asp:Label ID="Label9" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, fechaFinal %>"></asp:Label>
			</span>
			<span>
                <asp:Label ID="fechaFinal" class="detalle"  runat="server"></asp:Label>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label11" class="label"  runat="server" Text="<%$ Resources:labelsProduccion, utilizacion %>"></asp:Label>
			</span>
			<span>
					<asp:Label ID="utilizacion" class="detalle" runat="server" ></asp:Label>
			</span>
		</div>
    </div> 
    <div class="submitContainer">
        <asp:HiddenField ID="idProduccion" runat="server" />
        <asp:Button class="submit" ID="cancelar" runat="server" OnClientClick="history.back()" Text="<%$ Resources:labels, cancelar %>" />
        <asp:Button class="submit" ID="cambiarEstado" runat="server"  />
	</div>
</asp:Content>
