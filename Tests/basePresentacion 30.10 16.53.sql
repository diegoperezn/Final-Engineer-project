USE [uniprof]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[familiaID] [bigint] NOT NULL,
	[descripcion] [nvarchar](100) NULL,
	[nombre] [nvarchar](100) NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[familiaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Familia] ([familiaID], [descripcion], [nombre]) VALUES (1, N'Clientes', N'Permisos Clientes')
INSERT [dbo].[Familia] ([familiaID], [descripcion], [nombre]) VALUES (2, N'Operador maquinas de produccion', N'Operador de maquinas')
INSERT [dbo].[Familia] ([familiaID], [descripcion], [nombre]) VALUES (3, N'Cliente sin el permiso de realizacion de turnos', N'Cliente sin turnos')
INSERT [dbo].[Familia] ([familiaID], [descripcion], [nombre]) VALUES (4, N'Cliente con el permiso para realizar turnos', N'Cliente con turnos')
INSERT [dbo].[Familia] ([familiaID], [descripcion], [nombre]) VALUES (5, N'Administracion de finanzas', N'Administracion de finanzas')
INSERT [dbo].[Familia] ([familiaID], [descripcion], [nombre]) VALUES (6, N'Todos Los permisos', N'Administrador Total')
/****** Object:  Table [dbo].[Factura]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factura](
	[nro_factura] [bigint] NOT NULL,
	[nro_sucursal] [bigint] NOT NULL,
	[tipo_factura] [varchar](1) NOT NULL,
	[monto] [float] NOT NULL,
	[iva] [float] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_cliente] [bigint] NOT NULL,
	[nro_doc] [bigint] NOT NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[nro_sucursal] ASC,
	[nro_factura] ASC,
	[tipo_factura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Factura] ([nro_factura], [nro_sucursal], [tipo_factura], [monto], [iva], [fecha], [id_cliente], [nro_doc], [borrado]) VALUES (1, 1, N'A', 11, 11, CAST(0x00009F9800000000 AS DateTime), 1, 1, N'0')
INSERT [dbo].[Factura] ([nro_factura], [nro_sucursal], [tipo_factura], [monto], [iva], [fecha], [id_cliente], [nro_doc], [borrado]) VALUES (1, 2, N'B', 22, 22, CAST(0x000091BB00000000 AS DateTime), 1, 2, N'0')
/****** Object:  Table [dbo].[EstadoTrabajos]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoTrabajos](
	[cod_estado] [bigint] NOT NULL,
	[estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoTrabajos] PRIMARY KEY CLUSTERED 
(
	[cod_estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[EstadoTrabajos] ([cod_estado], [estado]) VALUES (1, N'en espera')
INSERT [dbo].[EstadoTrabajos] ([cod_estado], [estado]) VALUES (2, N'en proceso')
INSERT [dbo].[EstadoTrabajos] ([cod_estado], [estado]) VALUES (3, N'finalizado')
/****** Object:  Table [dbo].[EstadoPedido]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoPedido](
	[estado_pedido] [bigint] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoPedido] PRIMARY KEY CLUSTERED 
(
	[estado_pedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[EstadoPedido] ([estado_pedido], [descripcion]) VALUES (1, N'pendiente recepcion')
INSERT [dbo].[EstadoPedido] ([estado_pedido], [descripcion]) VALUES (2, N'en taller')
INSERT [dbo].[EstadoPedido] ([estado_pedido], [descripcion]) VALUES (3, N'en produccion')
INSERT [dbo].[EstadoPedido] ([estado_pedido], [descripcion]) VALUES (4, N'terminado')
/****** Object:  Table [dbo].[EstadoDiseños]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoDiseños](
	[estado] [bigint] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoDiseños] PRIMARY KEY CLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[EstadoDiseños] ([estado], [descripcion]) VALUES (1, N'Pendiente Realizacion')
INSERT [dbo].[EstadoDiseños] ([estado], [descripcion]) VALUES (2, N'Realizado')
/****** Object:  Table [dbo].[Encuesta]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encuesta](
	[id] [bigint] NOT NULL,
	[calidad] [int] NOT NULL,
	[eficiencia] [int] NOT NULL,
	[atencion] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Encuesta] ([id], [calidad], [eficiencia], [atencion]) VALUES (1, 3, 3, 3)
INSERT [dbo].[Encuesta] ([id], [calidad], [eficiencia], [atencion]) VALUES (2, 1, 1, 1)
INSERT [dbo].[Encuesta] ([id], [calidad], [eficiencia], [atencion]) VALUES (3, 4, 4, 4)
/****** Object:  Table [dbo].[Diseño]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Diseño](
	[cod_diseño] [bigint] NOT NULL,
	[alto] [float] NOT NULL,
	[ancho] [float] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[puntadas] [int] NOT NULL,
	[id_cliente] [bigint] NOT NULL,
	[pathImagen] [varchar](100) NULL,
	[pathDetalle] [varchar](100) NULL,
	[pathArchivoEditable] [varchar](100) NULL,
	[pathArchivoFinal] [varchar](100) NULL,
	[fechaRealizacion] [datetime] NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Diseño] PRIMARY KEY CLUSTERED 
(
	[cod_diseño] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Diseño] ([cod_diseño], [alto], [ancho], [nombre], [puntadas], [id_cliente], [pathImagen], [pathDetalle], [pathArchivoEditable], [pathArchivoFinal], [fechaRealizacion], [borrado]) VALUES (1, 11, 11, N'diseño1', 1111, 1, N'/cliente1/imagen/diseño1.jpg', N'/cliente1/detalle/diseño1.jpg', N'/cliente1/diseñoEditable/diseño1.jpg', N'/cliente1/diseño/diseño1.jpg', NULL, N'0')
INSERT [dbo].[Diseño] ([cod_diseño], [alto], [ancho], [nombre], [puntadas], [id_cliente], [pathImagen], [pathDetalle], [pathArchivoEditable], [pathArchivoFinal], [fechaRealizacion], [borrado]) VALUES (2, 22, 22, N'diseño2', 2222, 1, N'/cliente1/imagen/diseño2.jpg', N'/cliente1/detalle/diseño2.jpg', N'/cliente1/diseñoEditable/diseño2.jpg', N'/cliente1/diseño/diseño2.jpg', NULL, N'0')
/****** Object:  Table [dbo].[Cuenta]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[cuentaID] [bigint] NOT NULL,
	[estadoActual] [float] NULL,
	[tipo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[cuentaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cuenta] ([cuentaID], [estadoActual], [tipo]) VALUES (1, 0, N'doc a cobrar')
INSERT [dbo].[Cuenta] ([cuentaID], [estadoActual], [tipo]) VALUES (2, 0, N'Caja')
INSERT [dbo].[Cuenta] ([cuentaID], [estadoActual], [tipo]) VALUES (3, 0, N'Cheque')
/****** Object:  Table [dbo].[conversacion]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conversacion](
	[id_conversacion] [bigint] NOT NULL,
	[remitente] [bigint] NOT NULL,
	[destinatario] [bigint] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[conversacion] ([id_conversacion], [remitente], [destinatario]) VALUES (1, 1, 2)
INSERT [dbo].[conversacion] ([id_conversacion], [remitente], [destinatario]) VALUES (2, 4, 5)
/****** Object:  Table [dbo].[Color]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[codigo_color] [bigint] NOT NULL,
	[color] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Color] ([codigo_color], [color]) VALUES (1, N'Rojo')
INSERT [dbo].[Color] ([codigo_color], [color]) VALUES (2, N'Blanco')
INSERT [dbo].[Color] ([codigo_color], [color]) VALUES (3, N'Azul')
INSERT [dbo].[Color] ([codigo_color], [color]) VALUES (4, N'Gris')
/****** Object:  Table [dbo].[Documento]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[nro_doc] [bigint] NOT NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[nro_doc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Documento] ([nro_doc]) VALUES (1)
INSERT [dbo].[Documento] ([nro_doc]) VALUES (2)
INSERT [dbo].[Documento] ([nro_doc]) VALUES (3)
INSERT [dbo].[Documento] ([nro_doc]) VALUES (4)
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuarioID] [bigint] NOT NULL,
	[apellido] [nvarchar](50) NULL,
	[mail] [nvarchar](50) NULL,
	[nombre] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[telefonoFijo] [nvarchar](50) NOT NULL,
	[telefonoMovil] [nvarchar](50) NULL,
	[bloqueado] [char](1) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Usuario] ([usuarioID], [apellido], [mail], [nombre], [password], [telefonoFijo], [telefonoMovil], [bloqueado]) VALUES (1, N'apellido1', N'mail1@test.com', N'nombre1', N'44', N'1111-1111', N'1111-1111', N'0')
INSERT [dbo].[Usuario] ([usuarioID], [apellido], [mail], [nombre], [password], [telefonoFijo], [telefonoMovil], [bloqueado]) VALUES (2, N'apellido2', N'mail2@test.com', N'nombre2', N'44', N'2222-2222', N'2222-2222', N'0')
INSERT [dbo].[Usuario] ([usuarioID], [apellido], [mail], [nombre], [password], [telefonoFijo], [telefonoMovil], [bloqueado]) VALUES (3, N'apellido3', N'mail3@test.com', N'nombre3', N'44', N'3333-3333', N'3333-3333', N'0')
INSERT [dbo].[Usuario] ([usuarioID], [apellido], [mail], [nombre], [password], [telefonoFijo], [telefonoMovil], [bloqueado]) VALUES (4, N'apellido4', N'mail4@test.com', N'nombre4', N'44', N'4444-4444', N'4444-4444', N'0')
INSERT [dbo].[Usuario] ([usuarioID], [apellido], [mail], [nombre], [password], [telefonoFijo], [telefonoMovil], [bloqueado]) VALUES (5, N'apellido5', N'mail5@test.com', N'nombre5', N'pas5', N'5555-5555', N'5555-5555', N'0')
INSERT [dbo].[Usuario] ([usuarioID], [apellido], [mail], [nombre], [password], [telefonoFijo], [telefonoMovil], [bloqueado]) VALUES (6, N'perez', N'diego.perez.nadler@gmail.com', N'Diego', N'44', N'1234-1341', N'14-1234-1341', N'0')
/****** Object:  Table [dbo].[TipoPrenda]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPrenda](
	[tipo_prenda] [bigint] NOT NULL,
	[descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoPrenda] PRIMARY KEY CLUSTERED 
(
	[tipo_prenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TipoPrenda] ([tipo_prenda], [descripcion]) VALUES (1, N'Campera Armada')
INSERT [dbo].[TipoPrenda] ([tipo_prenda], [descripcion]) VALUES (2, N'Bolsillo')
INSERT [dbo].[TipoPrenda] ([tipo_prenda], [descripcion]) VALUES (3, N'manga')
INSERT [dbo].[TipoPrenda] ([tipo_prenda], [descripcion]) VALUES (4, N'frente campera')
/****** Object:  Table [dbo].[TipoPedido]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPedido](
	[tipo_pedido] [bigint] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoPedido] PRIMARY KEY CLUSTERED 
(
	[tipo_pedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TipoPedido] ([tipo_pedido], [descripcion]) VALUES (1, N'con turno')
INSERT [dbo].[TipoPedido] ([tipo_pedido], [descripcion]) VALUES (2, N'sin turno')
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[tipoMovimientoID] [bigint] NOT NULL,
	[movimiento] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[tipoMovimientoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TipoMovimiento] ([tipoMovimientoID], [movimiento]) VALUES (1, N'debito')
INSERT [dbo].[TipoMovimiento] ([tipoMovimientoID], [movimiento]) VALUES (2, N'credito')
/****** Object:  Table [dbo].[tipoInsumo]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoInsumo](
	[tipo_insumo] [bigint] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tipoStock] PRIMARY KEY CLUSTERED 
(
	[tipo_insumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tipoInsumo] ([tipo_insumo], [descripcion]) VALUES (1, N'hilo')
INSERT [dbo].[tipoInsumo] ([tipo_insumo], [descripcion]) VALUES (2, N'friselina fina')
INSERT [dbo].[tipoInsumo] ([tipo_insumo], [descripcion]) VALUES (3, N'friselina gruesa')
INSERT [dbo].[tipoInsumo] ([tipo_insumo], [descripcion]) VALUES (4, N'tela aplique')
INSERT [dbo].[tipoInsumo] ([tipo_insumo], [descripcion]) VALUES (5, N'reparacion')
/****** Object:  Table [dbo].[Mensaje]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mensaje](
	[id] [bigint] NOT NULL,
	[tipoMensaje] [int] NOT NULL,
	[leido] [varchar](1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_conversacion] [bigint] NOT NULL,
	[mensaje] [varchar](50) NOT NULL,
	[borrado] [varchar](1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Mensaje] ([id], [tipoMensaje], [leido], [fecha], [id_conversacion], [mensaje], [borrado]) VALUES (1, 1, N'1', CAST(0x0000A0B9011148F0 AS DateTime), 1, N'msj de 2 a 1', N'0')
INSERT [dbo].[Mensaje] ([id], [tipoMensaje], [leido], [fecha], [id_conversacion], [mensaje], [borrado]) VALUES (2, 0, N'0', CAST(0x0000A0B9011148F0 AS DateTime), 1, N'msj de 1 a 2', N'0')
INSERT [dbo].[Mensaje] ([id], [tipoMensaje], [leido], [fecha], [id_conversacion], [mensaje], [borrado]) VALUES (3, 0, N'1', CAST(0x0000A0B9011148F0 AS DateTime), 2, N'msj de 4 a 5', N'0')
INSERT [dbo].[Mensaje] ([id], [tipoMensaje], [leido], [fecha], [id_conversacion], [mensaje], [borrado]) VALUES (4, 1, N'1', CAST(0x0000A0B9011148F0 AS DateTime), 2, N'msj de 5 a 4', N'0')
/****** Object:  Table [dbo].[Maquina]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquina](
	[cod_maquina] [bigint] NOT NULL,
	[altoMargen] [int] NOT NULL,
	[anchoMargen] [int] NOT NULL,
	[cantidadColores] [int] NULL,
	[cabezales] [int] NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[velocidadPromedio] [int] NULL,
 CONSTRAINT [PK_Maquina] PRIMARY KEY CLUSTERED 
(
	[cod_maquina] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Maquina] ([cod_maquina], [altoMargen], [anchoMargen], [cantidadColores], [cabezales], [nombre], [velocidadPromedio]) VALUES (1, 15, 15, 3, 1, N'nombre1', 111)
INSERT [dbo].[Maquina] ([cod_maquina], [altoMargen], [anchoMargen], [cantidadColores], [cabezales], [nombre], [velocidadPromedio]) VALUES (2, 25, 25, 6, 6, N'nombre2', 222)
INSERT [dbo].[Maquina] ([cod_maquina], [altoMargen], [anchoMargen], [cantidadColores], [cabezales], [nombre], [velocidadPromedio]) VALUES (3, 35, 35, 12, 12, N'nombre3', 333)
/****** Object:  Table [dbo].[newsletter]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[newsletter](
	[id] [bigint] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[newsletter] [varchar](8000) NOT NULL,
	[enviado] [varchar](1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[newsletter] ([id], [nombre], [newsletter], [enviado]) VALUES (4, N'news1', N'<body background="#8A94AA"><style type="text/css"><!--body {	background-color: #8A94AA;}.txt-geral {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 13px;}.style3 {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 13px;	color:#003366;}.txt-geralp {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 11px;}.style-grd {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 18px;}--> </style><table width="600" border="0" align="center" cellpadding="0" cellspacing="0">  <tr>    <td class="titulo3"><img src="http://www.salvadorefilhos.pt/images/news/bg-topo.gif" alt="" width="600" height="21" /></td>  </tr>  <tr>    <td align="center" bgcolor="#EEEBE0"><div align="center"><img src="http://www.salvadorefilhos.pt/images/news/img-topo.jpg" alt="Salvador &amp; Filhos" width="600" height="206" border="0" /></div></td>  </tr>  <tr>    <td bgcolor="#EEEBE0"><table width="97%" border="0" align="center" cellpadding="0" cellspacing="16">      <tr>        <td width="50%" height="34" valign="top" class="txt-geral"><div class="style3">          <p><b>UNIPROF</b></p>          <p><b>NEWSLETTER N&ordm;9</b></p>        </div></td>        <td width="50%" align="right" valign="top" class="txt-geral"><img src="http://www.salvadorefilhos.pt/images/news/logo.gif" alt="Cristo Rei" width="99" height="66" /></td>      </tr>      <tr>        <td colspan="2" valign="top" class="txt-geral"><p align="center"><img src="http://www.es.salvadorefilhos.pt/newsletter/images/tit-newsl9.gif" alt="Servicios Adicionales" width="550" height="100" /></p>          	<table width="100%" border="0" cellspacing="0" cellpadding="0">				<tr>					<td width="60%" valign="top"><h2><span lang="ES-TRAD" xml:lang="ES-TRAD"><strong>Env&iacute;o, recepci&oacute;n</strong></span>:</h2>							<ul>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Log&iacute;stica de entrega y recogida de pedidos por nuestro   transportista especializado. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Entregas r&aacute;pidas. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Trabajamos internacionalmente. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Entrega directa a nuestros clientes.</span></li>								</ul></td>					<td width="40%" align="right"><img src="http://www.es.salvadorefilhos.pt/fotos/empresa/carrinho.gif" alt="Env&iacute;o, recepci&oacute;n" width="200" height="190" hspace="0" border="0" /></td>				</tr>				<tr>					<td valign="top"><h2><br />						<strong>Embalaje</strong>:</h2>							<ul>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Tenemos un servicio m&aacute;s a la disponibilidad de nuestros clientes. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Doblar y prensar las piezas personalizadas. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Embalaje individual en una bolsa de pl&aacute;stico. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Embalaje m&uacute;ltiple en una bolsa de pl&aacute;stico. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Embalaje en cajas de cart&oacute;n</span></li>								</ul></td>					<td align="right"><br />							<img src="http://www.es.salvadorefilhos.pt/fotos/empresa/embalagem.gif" alt="Embalaje" width="200" height="168" hspace="0" border="0" /></td>				</tr>				<tr>					<td valign="top"><h2><br />						<strong>Control de calidad</strong>:</h2>							<ul>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">N</span>uestros bordados son la prueba de la calidad y durabilidad,   colores s&oacute;lidos y garantidos, calidad garantizada. </li>								<li>Nuestros textiles son de un acabado de alta calidad, controlado y   probado. </li>								<li>Control de calidad para todos nuestros art&iacute;culos. </li>								<li>La experiencia y conocimiento a su servicio. </li>								<li>P&oacute;nganos a prueba.</li>								</ul></td>					<td align="right"><br />							<img height="200" alt="Control de calidad" src="http://www.es.salvadorefilhos.pt/fotos/empresa/maos.gif" width="200" border="0" /></td>				</tr>			</table>          	<p><strong>&iexcl;<a href="">Env&iacute;enos su solicitud</a>!<img src="http://www.salvadorefilhos.pt/newsletter/images/download-es.gif" alt="Descargas, Diapositivos gratis" width="173" height="148" border="0" align="right" /></strong></b></p>          <p>Descargue en su ordenador nuestro cat&aacute;logo de hilos y lista de clis&eacute;s en <a href="">descargas</a>. </p>          <p> Calidad siempre em nuestros art&iacute;culos garantizados y acabamiento especial.</p></td>      </tr>      <tr>        <td colspan="2" valign="top" class="txt-geral"></td>      </tr>    </table>    </td>  </tr>  <tr>   <td><img src="http://www.salvadorefilhos.pt/images/news/bg-bot.gif" alt="" width="600" height="50" /></td>  </tr></table></body></html>', N'1')
INSERT [dbo].[newsletter] ([id], [nombre], [newsletter], [enviado]) VALUES (3, N'news2', N'<body background="#8A94AA"><style type="text/css"><!--body {	background-color: #8A94AA;}.txt-geral {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 13px;}.style3 {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 13px;	color:#003366;}.txt-geralp {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 11px;}.style-grd {	font-family: Georgia, Times New Roman, Times, serif;	font-size: 18px;}--> </style><table width="600" border="0" align="center" cellpadding="0" cellspacing="0">  <tr>    <td class="titulo3"><img src="http://www.salvadorefilhos.pt/images/news/bg-topo.gif" alt="" width="600" height="21" /></td>  </tr>  <tr>    <td align="center" bgcolor="#EEEBE0"><div align="center"><img src="http://www.salvadorefilhos.pt/images/news/img-topo.jpg" alt="Salvador &amp; Filhos" width="600" height="206" border="0" /></div></td>  </tr>  <tr>    <td bgcolor="#EEEBE0"><table width="97%" border="0" align="center" cellpadding="0" cellspacing="16">      <tr>        <td width="50%" height="34" valign="top" class="txt-geral"><div class="style3">          <p><b>UNIPROF</b></p>          <p><b>NEWSLETTER N&ordm;9</b></p>        </div></td>        <td width="50%" align="right" valign="top" class="txt-geral"><img src="http://www.salvadorefilhos.pt/images/news/logo.gif" alt="Cristo Rei" width="99" height="66" /></td>      </tr>      <tr>        <td colspan="2" valign="top" class="txt-geral"><p align="center"><img src="http://www.es.salvadorefilhos.pt/newsletter/images/tit-newsl9.gif" alt="Servicios Adicionales" width="550" height="100" /></p>          	<table width="100%" border="0" cellspacing="0" cellpadding="0">				<tr>					<td width="60%" valign="top"><h2><span lang="ES-TRAD" xml:lang="ES-TRAD"><strong>Env&iacute;o, recepci&oacute;n</strong></span>:</h2>							<ul>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Log&iacute;stica de entrega y recogida de pedidos por nuestro   transportista especializado. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Entregas r&aacute;pidas. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Trabajamos internacionalmente. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Entrega directa a nuestros clientes.</span></li>								</ul></td>					<td width="40%" align="right"><img src="http://www.es.salvadorefilhos.pt/fotos/empresa/carrinho.gif" alt="Env&iacute;o, recepci&oacute;n" width="200" height="190" hspace="0" border="0" /></td>				</tr>				<tr>					<td valign="top"><h2><br />						<strong>Embalaje</strong>:</h2>							<ul>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Tenemos un servicio m&aacute;s a la disponibilidad de nuestros clientes. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Doblar y prensar las piezas personalizadas. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Embalaje individual en una bolsa de pl&aacute;stico. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Embalaje m&uacute;ltiple en una bolsa de pl&aacute;stico. </span> </li>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">Embalaje en cajas de cart&oacute;n</span></li>								</ul></td>					<td align="right"><br />							<img src="http://www.es.salvadorefilhos.pt/fotos/empresa/embalagem.gif" alt="Embalaje" width="200" height="168" hspace="0" border="0" /></td>				</tr>				<tr>					<td valign="top"><h2><br />						<strong>Control de calidad</strong>:</h2>							<ul>								<li><span lang="ES-TRAD" xml:lang="ES-TRAD">N</span>uestros bordados son la prueba de la calidad y durabilidad,   colores s&oacute;lidos y garantidos, calidad garantizada. </li>								<li>Nuestros textiles son de un acabado de alta calidad, controlado y   probado. </li>								<li>Control de calidad para todos nuestros art&iacute;culos. </li>								<li>La experiencia y conocimiento a su servicio. </li>								<li>P&oacute;nganos a prueba.</li>								</ul></td>					<td align="right"><br />							<img height="200" alt="Control de calidad" src="http://www.es.salvadorefilhos.pt/fotos/empresa/maos.gif" width="200" border="0" /></td>				</tr>			</table>          	<p><strong>&iexcl;<a href="">Env&iacute;enos su solicitud</a>!<img src="http://www.salvadorefilhos.pt/newsletter/images/download-es.gif" alt="Descargas, Diapositivos gratis" width="173" height="148" border="0" align="right" /></strong></b></p>          <p>Descargue en su ordenador nuestro cat&aacute;logo de hilos y lista de clis&eacute;s en <a href="">descargas</a>. </p>          <p> Calidad siempre em nuestros art&iacute;culos garantizados y acabamiento especial.</p></td>      </tr>      <tr>        <td colspan="2" valign="top" class="txt-geral"></td>      </tr>    </table>    </td>  </tr>  <tr>   <td><img src="http://www.salvadorefilhos.pt/images/news/bg-bot.gif" alt="" width="600" height="50" /></td>  </tr></table></body></html>', N'0')
INSERT [dbo].[newsletter] ([id], [nombre], [newsletter], [enviado]) VALUES (1, N'cabeceraTrabajo', N'<div onclick="return Control.invoke(''MessagePartBody'',''_onBodyClick'',event,event);" class="ReadMsgBody" id="mpf0_readMsgBodyContainer"><div id="mpf0_MsgContainer" class="SandboxScopeClass ExternalClass"><title>Detalle de solicitud de trabajo</title><div style="text-align:center"><div style=""><img hspace="0" height="175" width="300" vspace="0" border="0" align="none" title="logo-as-bordados" style="width:300px;height:175px" src="https://snt002.mail.live.com/Handlers/ImageProxy.mvc?bicild=&amp;canary=%2fQchkCzWvirc6X%2bUQgdmNcmam2AtlIcs6%2fbpO1JWeMc%3d0&amp;url=http%3a%2f%2fimg-ak.verticalresponse.com%2fmedia%2f4%2f5%2fc%2f45c8314463%2f1dae111de1%2flogo-as-bordados.jpg%3f__nocache__%3d1" alt="logo-as-bordados"></div><br><table cellspacing="0" cellpadding="0" border="0" align="center" style="color:rgb(34, 34, 34);font-family:arial, sans-serif;font-size:13px;background-color:rgb(255, 255, 255)"><tbody><tr><td style="" colspan="3"><span style="color:#000000"><font face="Arial, Helvetica, sans-serif"><strong><font size="5">&nbsp;Detalle pedido de trabajo</font></strong></font></span><br>&nbsp;</td></tr><tr><td width="23" style="">&nbsp;</td><td width="164" style="">&nbsp;</td><td width="343" style="">&nbsp;</td></tr><tr><td width="23" style=""><span style="color:#696969"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td width="164" style=""><span style="color:#696969"><font face="Arial, Helvetica, sans-serif"><strong>Apellido/s y Nombre/s:</strong></font></span></td><td width="343" style=""><span style="color:#696969"><font face="Arial, Helvetica, sans-serif">{cliente.apellido}, </font><span style="font-family:Arial, Helvetica, sans-serif">{cliente.Nombre}</span></span></td></tr><tr><td width="23" style="">&nbsp;</td><td width="164" style="">&nbsp;</td><td width="343" style="">&nbsp;</td></tr></tbody></table>{listaProduccion}</div><table cellspacing="0" cellpadding="0" border="0" align="center" style="text-align:center;color:rgb(34, 34, 34);font-family:arial, sans-serif;font-size:13px;background-color:rgb(255, 255, 255)"><tbody><tr><td width="23" style="">&nbsp;</td><td width="164" style="">&nbsp;</td><td width="343" style="">&nbsp;</td></tr><tr><td width="23" style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td width="164" style="text-align:left"><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Pedido</strong></font><strong style="color:rgb(102, 102, 102);font-family:Arial, Helvetica, sans-serif">:</strong></span></td><td width="343" style="">&nbsp;</td></tr><tr><td width="23" style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td width="164" style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Fecha Comienzo:</strong></font></span></td><td width="343" style=""><span style="color:rgb(105, 105, 105)"><span style="font-family:arial, helvetica, sans-serif"><strong>Fecha:&nbsp;</strong>{fechaComienzo}&nbsp;<strong>Hora:&nbsp;</strong>{horaComienzo}</span></span></td></tr><tr><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td style=""><span style="color:rgb(105, 105, 105)"><strong style="font-family:Arial, Helvetica, sans-serif">Fecha Estimada final</strong><font face="Arial, Helvetica, sans-serif"><strong>:</strong></font></span></td><td style=""><span style="color:rgb(105, 105, 105)"><strong style="font-family:arial, helvetica, sans-serif">Fecha:&nbsp;</strong><span style="font-family:arial, helvetica, sans-serif">{fechaFinal}&nbsp;</span><strong style="font-family:arial, helvetica, sans-serif">Hora:&nbsp;</strong><span style="font-family:arial, helvetica, sans-serif">{horaFinal}</span></span></td></tr><tr><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Precio pedido:</strong></font></span></td><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">{Trabajo.precio}</font></span></td></tr></tbody></table></div></div>', N'1')
INSERT [dbo].[newsletter] ([id], [nombre], [newsletter], [enviado]) VALUES (2, N'trabajo', N'<table cellspacing="0" cellpadding="0" border="0" align="center" style="text-align:center;color:rgb(34, 34, 34);font-family:arial, sans-serif;font-size:13px;background-color:rgb(255, 255, 255)"><tbody><tr><td width="23" style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td width="164" style="text-align:left"><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Trabajo&nbsp;Nro</strong></font><strong style="color:rgb(102, 102, 102);font-family:Arial, Helvetica, sans-serif">:&nbsp;</strong></span><span style="color:rgb(105, 105, 105);font-family:Arial, Helvetica, sans-serif;text-align:center">{XX}</span></td><td width="343" style="">&nbsp;</td></tr><tr><td width="23" style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td width="164" style="text-align: left;"><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Diseño</strong></font><strong style="color:rgb(102, 102, 102);font-family:Arial, Helvetica, sans-serif">:</strong></span></td><td width="343" style=""><font face="Arial, Helvetica, sans-serif"><a style="color:rgb(17, 85, 204)" href="mailto:diego.perez.nadler@gmail.com"><span style="color:rgb(105, 105, 105)"></span></a><span style="color:rgb(105, 105, 105)">{Diseño.nombre} - {Diseño.alto}x{Diseño.ancho}</span></font></td></tr><tr><td width="23" style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td width="164" style="text-align: left;"><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Fecha Comienzo:</strong></font></span></td><td width="343" style=""><span style="color:rgb(105, 105, 105)"><span style="font-family:arial, helvetica, sans-serif"><strong>Fecha:&nbsp;</strong>{fechaComienzo}&nbsp;<strong>Hora:&nbsp;</strong>{horaComienzo}</span></span></td></tr><tr><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td style="text-align: left;"><span style="color:rgb(105, 105, 105)"><strong style="font-family:Arial, Helvetica, sans-serif">Fecha Estimada final</strong><font face="Arial, Helvetica, sans-serif"><strong>:</strong></font></span></td><td style=""><span style="color:rgb(105, 105, 105)"><strong style="font-family:arial, helvetica, sans-serif">Fecha:&nbsp;</strong><span style="font-family:arial, helvetica, sans-serif">{fechaFinal}&nbsp;</span><strong style="font-family:arial, helvetica, sans-serif">Hora:&nbsp;</strong><span style="font-family:arial, helvetica, sans-serif">{horaFinal}</span></span></td></tr><tr><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td style="text-align: left;"><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Prenda:</strong></font></span></td><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">{TipoPrenda.Nombre}</font></span></td></tr><tr><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td style="text-align: left;"><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Cantidad:</strong></font></span></td><td style=""><span style="color:rgb(105, 105, 105)">{Trabajo.cantidad}</span></td></tr><tr><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">&nbsp;</font></span></td><td style="text-align: left;"><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif"><strong>Precio trabajo:</strong></font></span></td><td style=""><span style="color:rgb(105, 105, 105)"><font face="Arial, Helvetica, sans-serif">{Trabajo.precio}</font></span></td></tr></tbody></table>', N'1')
/****** Object:  Table [dbo].[MovimientosStock]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovimientosStock](
	[nro_movimiento] [bigint] NOT NULL,
	[cod_insumo] [bigint] NOT NULL,
	[cantidad] [float] NOT NULL,
	[fecha] [datetime] NULL,
	[tipo] [char](1) NULL,
 CONSTRAINT [PK_MovimientosStock] PRIMARY KEY CLUSTERED 
(
	[nro_movimiento] ASC,
	[cod_insumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[MovimientosStock] ([nro_movimiento], [cod_insumo], [cantidad], [fecha], [tipo]) VALUES (1, 1, 10, CAST(0x0000A0E600000000 AS DateTime), N'1')
INSERT [dbo].[MovimientosStock] ([nro_movimiento], [cod_insumo], [cantidad], [fecha], [tipo]) VALUES (1, 2, 14, CAST(0x0000A0E600000000 AS DateTime), N'2')
INSERT [dbo].[MovimientosStock] ([nro_movimiento], [cod_insumo], [cantidad], [fecha], [tipo]) VALUES (2, 1, -9, CAST(0x0000A0E600000000 AS DateTime), N'1')
/****** Object:  Table [dbo].[historico_estados_produccion]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[historico_estados_produccion](
	[nro_estado] [bigint] NOT NULL,
	[cod_produccion] [bigint] NOT NULL,
	[comentario] [nvarchar](100) NOT NULL,
	[fechaDesde] [datetime] NOT NULL,
	[fechaHasta] [datetime] NULL,
	[estado] [bigint] NOT NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_RelEstadoTrabajo] PRIMARY KEY CLUSTERED 
(
	[nro_estado] ASC,
	[cod_produccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[historico_estados_produccion] ([nro_estado], [cod_produccion], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (1, 1, N'comentario11', CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900E6B680 AS DateTime), 1, N'0')
INSERT [dbo].[historico_estados_produccion] ([nro_estado], [cod_produccion], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (1, 2, N'comentario12', CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900F73140 AS DateTime), 1, N'0')
INSERT [dbo].[historico_estados_produccion] ([nro_estado], [cod_produccion], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (2, 1, N'comentario21', CAST(0x0000A0C900E6B680 AS DateTime), CAST(0x0000A0C900F73140 AS DateTime), 2, N'0')
INSERT [dbo].[historico_estados_produccion] ([nro_estado], [cod_produccion], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (2, 2, N'comentario22', CAST(0x0000A0C900F73140 AS DateTime), NULL, 2, N'0')
INSERT [dbo].[historico_estados_produccion] ([nro_estado], [cod_produccion], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (3, 1, N'comentario31', CAST(0x0000A0C900F73140 AS DateTime), NULL, 3, N'0')
/****** Object:  Table [dbo].[Opiniones]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Opiniones](
	[id] [bigint] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[mail] [varchar](100) NOT NULL,
	[opinion] [varchar](500) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Opiniones] ([id], [nombre], [mail], [opinion]) VALUES (1, N'nombre1', N'mail1@test.com', N'opinion1')
INSERT [dbo].[Opiniones] ([id], [nombre], [mail], [opinion]) VALUES (2, N'nombre2', N'mail2@test.com', N'opinion2')
INSERT [dbo].[Opiniones] ([id], [nombre], [mail], [opinion]) VALUES (3, N'nombre3', N'mail3@test.com', N'opinion3')
/****** Object:  Table [dbo].[Patente]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[patenteID] [bigint] NOT NULL,
	[descripcion] [nvarchar](100) NULL,
	[permiso] [nvarchar](100) NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[patenteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (1, N'creacion de usuario', N'Creacion de usuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (2, N'Edicion de usuarios', N'Edicion de usuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (3, N'Eliminacion de usuarios', N'Eliminacion de usuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (4, N'Listado de usuario', N'Listado de usuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (5, N'Creacion de familias', N'Creacion de familias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (6, N'Edicion de familias', N'Edicion de familias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (7, N'Eliminacion de familias', N'Eliminacion de familias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (8, N'Listado de familias', N'Listado de familias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (9, N'Listado de patentes', N'Listado de patentes')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (10, N'Creacion de diseño', N'Creacion de diseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (11, N'Edicion de diseños', N'Edicion de diseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (12, N'Eliminacion de diseños', N'Eliminacion de diseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (13, N'Listado de diseños', N'Listado de diseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (14, N'creacionUsuarios', N'creacionUsuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (15, N'edicionUsuarios', N'edicionUsuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (16, N'eliminacionUsuarios', N'eliminacionUsuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (17, N'listadoUsuarios', N'listadoUsuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (18, N'detalleUsuarios', N'detalleUsuarios')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (19, N'listadoOpinion', N'listadoOpinion')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (20, N'detalleOpinion', N'detalleOpinion')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (21, N'detalleEstadisticas', N'detalleEstadisticas')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (22, N'creacionNewletter', N'creacionNewletter')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (23, N'edicionNewletter', N'edicionNewletter')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (24, N'eliminacionNewletter', N'eliminacionNewletter')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (25, N'listadoNewletter', N'listadoNewletter')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (26, N'detalleNewletter', N'detalleNewletter')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (27, N'creacionProveedor', N'creacionProveedor')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (28, N'edicionProveedor', N'edicionProveedor')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (29, N'listadoProveedor', N'listadoProveedor')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (30, N'detalleProveedor', N'detalleProveedor')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (31, N'creacionInsumo', N'creacionInsumo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (32, N'edicionInsumo', N'edicionInsumo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (33, N'listadoInsumo', N'listadoInsumo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (34, N'mensajes', N'mensajes')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (35, N'creacionMovimientoCliente', N'creacionMovimientoCliente')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (36, N'listadoMovimientoCliente', N'listadoMovimientoCliente')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (37, N'detalleMovimientoCliente', N'detalleMovimientoCliente')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (38, N'listadoFactura', N'listadoFactura')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (39, N'detalleFactura', N'detalleFactura')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (40, N'creacionMovimientoProveedor', N'creacionMovimientoProveedor')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (41, N'listadoMovimientoProveedor', N'listadoMovimientoProveedor')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (42, N'detalleMovimientoProveedor', N'detalleMovimientoProveedor')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (43, N'listadoOrdenCompra', N'listadoOrdenCompra')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (44, N'detalleOrdenCompra', N'detalleOrdenCompra')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (45, N'creacionDiseños', N'creacionDiseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (46, N'edicionDiseños', N'edicionDiseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (47, N'detalleDiseños', N'detalleDiseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (48, N'eliminacionDiseños', N'eliminacionDiseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (49, N'listadoDiseños', N'listadoDiseños')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (50, N'creacionPedido', N'creacionPedido')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (51, N'edicionPedido', N'edicionPedido')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (52, N'detallePedido', N'detallePedido')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (53, N'eliminacionPedido', N'eliminacionPedido')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (54, N'listadoPedido', N'listadoPedido')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (55, N'creacionProduccion', N'creacionProduccion')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (56, N'edicionProduccion', N'edicionProduccion')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (57, N'detalleProduccion', N'detalleProduccion')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (58, N'eliminacionProduccion', N'eliminacionProduccion')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (59, N'listadoProduccion', N'listadoProduccion')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (60, N'creacionArticulo', N'creacionArticulo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (61, N'edicionArticulo', N'edicionArticulo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (62, N'detalleArticulo', N'detalleArticulo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (63, N'eliminacionArticulo', N'eliminacionArticulo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (64, N'listadoArticulo', N'listadoArticulo')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (65, N'creacionFamilias', N'creacionFamilias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (66, N'edicionFamilias', N'edicionFamilias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (67, N'eliminacionFamilias', N'eliminacionFamilias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (68, N'listadoFamilias', N'listadoFamilias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (69, N'detalleFamilias', N'detalleFamilias')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (70, N'creacionMaquinas', N'creacionMaquinas')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (71, N'listadoMaquinas', N'listadoMaquinas')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (72, N'detalleMaquinas', N'detalleMaquinas')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (73, N'edicionMaquinas', N'edicionMaquinas')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (74, N'eliminacionMaquinas', N'eliminacionMaquinas')
INSERT [dbo].[Patente] ([patenteID], [descripcion], [permiso]) VALUES (75, N'detalleInsumo', N'detalleInsumo')
/****** Object:  Table [dbo].[Proveedor]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[id_proveedor] [bigint] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](50) NULL,
	[direccion] [nvarchar](100) NULL,
 CONSTRAINT [PK_ProveedorGeneral] PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Proveedor] ([id_proveedor], [nombre], [telefono], [direccion]) VALUES (1, N'nombre1', N'1111-1111', N'direccion 1')
INSERT [dbo].[Proveedor] ([id_proveedor], [nombre], [telefono], [direccion]) VALUES (2, N'nombre2', N'2222-2222', N'direccion 2')
INSERT [dbo].[Proveedor] ([id_proveedor], [nombre], [telefono], [direccion]) VALUES (3, N'nombre3', N'3333-3333', N'direccion 3')
/****** Object:  Table [dbo].[historico_estados_diseño]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[historico_estados_diseño](
	[nro_estado] [bigint] NOT NULL,
	[cod_diseño] [bigint] NOT NULL,
	[comentario] [nvarchar](100) NULL,
	[fechaDesde] [datetime] NOT NULL,
	[fechaHasta] [datetime] NULL,
	[estado] [bigint] NOT NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_RelEstadosDiseño] PRIMARY KEY CLUSTERED 
(
	[nro_estado] ASC,
	[cod_diseño] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenDeCompra]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenDeCompra](
	[nro_sucursal] [bigint] NOT NULL,
	[nro_orden_compra] [bigint] NOT NULL,
	[tipo_orden_compra] [varchar](1) NOT NULL,
	[monto] [float] NOT NULL,
	[iva] [float] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_proveedor] [bigint] NOT NULL,
	[nro_doc] [bigint] NOT NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_OrdenDeCompra] PRIMARY KEY CLUSTERED 
(
	[nro_sucursal] ASC,
	[nro_orden_compra] ASC,
	[tipo_orden_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[OrdenDeCompra] ([nro_sucursal], [nro_orden_compra], [tipo_orden_compra], [monto], [iva], [fecha], [id_proveedor], [nro_doc], [borrado]) VALUES (1, 1, N'A', 11, 11, CAST(0x00009F9800000000 AS DateTime), 1, 3, N'0')
INSERT [dbo].[OrdenDeCompra] ([nro_sucursal], [nro_orden_compra], [tipo_orden_compra], [monto], [iva], [fecha], [id_proveedor], [nro_doc], [borrado]) VALUES (1, 2, N'B', 22, 22, CAST(0x000091BB00000000 AS DateTime), 1, 4, N'0')
/****** Object:  Table [dbo].[operador]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[operador](
	[id_operador] [bigint] NOT NULL,
	[id_usuario] [bigint] NOT NULL,
 CONSTRAINT [PK_operador] PRIMARY KEY CLUSTERED 
(
	[id_operador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[operador] ([id_operador], [id_usuario]) VALUES (1, 4)
INSERT [dbo].[operador] ([id_operador], [id_usuario]) VALUES (2, 5)
/****** Object:  Table [dbo].[MovimientosCuenta]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientosCuenta](
	[nro_movimiento] [bigint] NOT NULL,
	[comentario] [nvarchar](500) NULL,
	[fecha] [datetime] NULL,
	[monto] [float] NULL,
	[cuentaID] [bigint] NULL,
	[tipoMovimientoID] [bigint] NULL,
 CONSTRAINT [PK_MovimientosCuenta] PRIMARY KEY CLUSTERED 
(
	[nro_movimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MovimientosCuenta] ([nro_movimiento], [comentario], [fecha], [monto], [cuentaID], [tipoMovimientoID]) VALUES (1, N'com1', CAST(0x00009F9800000000 AS DateTime), 11, 1, 1)
INSERT [dbo].[MovimientosCuenta] ([nro_movimiento], [comentario], [fecha], [monto], [cuentaID], [tipoMovimientoID]) VALUES (2, N'com2', CAST(0x00009E9200000000 AS DateTime), 22, 1, 1)
INSERT [dbo].[MovimientosCuenta] ([nro_movimiento], [comentario], [fecha], [monto], [cuentaID], [tipoMovimientoID]) VALUES (3, N'com3', CAST(0x0000933100000000 AS DateTime), 33, 1, 1)
/****** Object:  Table [dbo].[Reparacion]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reparacion](
	[cod_reparacion] [bigint] NOT NULL,
	[cod_maquina] [bigint] NOT NULL,
	[costo_mano_Obra] [float] NULL,
	[costo_materiales] [float] NULL,
 CONSTRAINT [PK_Reparacion] PRIMARY KEY CLUSTERED 
(
	[cod_reparacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [bigint] NOT NULL,
	[habitadoTurnos] [int] NOT NULL,
	[usuarioID] [bigint] NOT NULL,
	[newsletter] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Cliente] ([id_cliente], [habitadoTurnos], [usuarioID], [newsletter]) VALUES (1, 1, 1, N'0')
INSERT [dbo].[Cliente] ([id_cliente], [habitadoTurnos], [usuarioID], [newsletter]) VALUES (2, 0, 2, N'0')
INSERT [dbo].[Cliente] ([id_cliente], [habitadoTurnos], [usuarioID], [newsletter]) VALUES (3, 0, 6, N'0')
/****** Object:  Table [dbo].[Articulos]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulos](
	[cod_articulo] [bigint] NOT NULL,
	[tipoPrendaID] [bigint] NOT NULL,
	[diseñoID] [bigint] NOT NULL,
	[comentario] [nvarchar](500) NULL,
	[produccion] [int] NOT NULL,
	[precioActual] [float] NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_DiseñoPrenda] PRIMARY KEY CLUSTERED 
(
	[cod_articulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Articulos] ([cod_articulo], [tipoPrendaID], [diseñoID], [comentario], [produccion], [precioActual], [borrado]) VALUES (1, 1, 1, N'com1', 10, 2.1, N'0')
INSERT [dbo].[Articulos] ([cod_articulo], [tipoPrendaID], [diseñoID], [comentario], [produccion], [precioActual], [borrado]) VALUES (2, 2, 2, N'com2', 20, 20, N'0')
INSERT [dbo].[Articulos] ([cod_articulo], [tipoPrendaID], [diseñoID], [comentario], [produccion], [precioActual], [borrado]) VALUES (3, 2, 1, N'com3', 5, 30, N'0')
/****** Object:  Table [dbo].[JoinUsuarioToFamilia]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinUsuarioToFamilia](
	[familiaID] [bigint] NOT NULL,
	[usuarioID] [bigint] NOT NULL,
 CONSTRAINT [PK_JoinUsuarioToFamilia] PRIMARY KEY CLUSTERED 
(
	[familiaID] ASC,
	[usuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[JoinUsuarioToFamilia] ([familiaID], [usuarioID]) VALUES (1, 6)
INSERT [dbo].[JoinUsuarioToFamilia] ([familiaID], [usuarioID]) VALUES (2, 2)
INSERT [dbo].[JoinUsuarioToFamilia] ([familiaID], [usuarioID]) VALUES (6, 3)
/****** Object:  Table [dbo].[JoinPatenteToUsuario]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinPatenteToUsuario](
	[usuarioID] [bigint] NOT NULL,
	[patenteID] [bigint] NOT NULL,
 CONSTRAINT [PK_JoinPatenteToUsuario] PRIMARY KEY CLUSTERED 
(
	[usuarioID] ASC,
	[patenteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[JoinPatenteToUsuario] ([usuarioID], [patenteID]) VALUES (1, 1)
INSERT [dbo].[JoinPatenteToUsuario] ([usuarioID], [patenteID]) VALUES (3, 13)
/****** Object:  Table [dbo].[JoinMaquinaToTipoPrenda]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinMaquinaToTipoPrenda](
	[tipo_prenda] [bigint] NOT NULL,
	[cod_maquina] [bigint] NOT NULL,
 CONSTRAINT [PK_JoinMaquinaToTipoPrenda] PRIMARY KEY CLUSTERED 
(
	[tipo_prenda] ASC,
	[cod_maquina] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (1, 1)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (1, 2)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (1, 3)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (2, 1)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (2, 2)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (2, 3)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (3, 1)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (3, 2)
INSERT [dbo].[JoinMaquinaToTipoPrenda] ([tipo_prenda], [cod_maquina]) VALUES (3, 3)
/****** Object:  Table [dbo].[JoinFamiliaToPatente]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinFamiliaToPatente](
	[patenteID] [bigint] NOT NULL,
	[familiaID] [bigint] NOT NULL,
 CONSTRAINT [PK_JoinFamiliaToPatente] PRIMARY KEY CLUSTERED 
(
	[patenteID] ASC,
	[familiaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (1, 2)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (1, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (2, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (3, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (4, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (5, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (6, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (7, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (8, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (9, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (10, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (11, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (12, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (13, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (14, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (15, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (16, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (17, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (18, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (19, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (20, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (21, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (22, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (23, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (24, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (25, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (26, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (27, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (28, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (29, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (30, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (31, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (32, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (33, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (34, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (34, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (35, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (36, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (37, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (38, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (38, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (39, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (39, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (40, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (41, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (42, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (43, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (44, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (45, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (45, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (46, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (46, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (47, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (47, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (48, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (48, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (49, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (49, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (50, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (50, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (51, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (51, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (52, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (52, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (53, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (53, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (54, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (54, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (55, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (55, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (56, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (56, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (57, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (57, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (58, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (58, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (59, 1)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (59, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (60, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (61, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (62, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (63, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (64, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (65, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (66, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (67, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (68, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (69, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (70, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (71, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (72, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (73, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (74, 6)
INSERT [dbo].[JoinFamiliaToPatente] ([patenteID], [familiaID]) VALUES (75, 6)
/****** Object:  Table [dbo].[insumo]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[insumo](
	[cod_insumo] [bigint] NOT NULL,
	[nombre] [varchar](50) NULL,
	[detalle] [nvarchar](500) NOT NULL,
	[id_tipo_insumo] [bigint] NOT NULL,
	[color] [bigint] NOT NULL,
	[cantidadActual] [float] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[cod_insumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[insumo] ([cod_insumo], [nombre], [detalle], [id_tipo_insumo], [color], [cantidadActual]) VALUES (1, N'nombre1', N'detalle1', 1, 1, 100000)
INSERT [dbo].[insumo] ([cod_insumo], [nombre], [detalle], [id_tipo_insumo], [color], [cantidadActual]) VALUES (2, N'nombre2', N'detalle2', 1, 2, 200000)
INSERT [dbo].[insumo] ([cod_insumo], [nombre], [detalle], [id_tipo_insumo], [color], [cantidadActual]) VALUES (3, N'nombre3', N'detalle3', 1, 3, 300000)
INSERT [dbo].[insumo] ([cod_insumo], [nombre], [detalle], [id_tipo_insumo], [color], [cantidadActual]) VALUES (4, N'nombre4', N'detalle4', 1, 4, 400000)
/****** Object:  Table [dbo].[documento_movimiento]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[documento_movimiento](
	[nro_doc] [bigint] NOT NULL,
	[nro_movimiento] [bigint] NOT NULL,
 CONSTRAINT [PK_documento_movimiento] PRIMARY KEY CLUSTERED 
(
	[nro_doc] ASC,
	[nro_movimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[documento_movimiento] ([nro_doc], [nro_movimiento]) VALUES (1, 1)
INSERT [dbo].[documento_movimiento] ([nro_doc], [nro_movimiento]) VALUES (3, 3)
/****** Object:  Table [dbo].[Diseño_insumos]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diseño_insumos](
	[cod_diseño] [bigint] NOT NULL,
	[cod_insumo] [bigint] NOT NULL,
	[cantidad] [float] NOT NULL,
 CONSTRAINT [PK_Diseño_insumos] PRIMARY KEY CLUSTERED 
(
	[cod_diseño] ASC,
	[cod_insumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Diseño_insumos] ([cod_diseño], [cod_insumo], [cantidad]) VALUES (1, 1, 1)
INSERT [dbo].[Diseño_insumos] ([cod_diseño], [cod_insumo], [cantidad]) VALUES (1, 2, 1)
/****** Object:  Table [dbo].[cliente_movimientos]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente_movimientos](
	[id_cliente] [bigint] NOT NULL,
	[nro_movimiento] [bigint] NOT NULL,
 CONSTRAINT [PK_CuentaCorrienteCliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC,
	[nro_movimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[cliente_movimientos] ([id_cliente], [nro_movimiento]) VALUES (1, 1)
INSERT [dbo].[cliente_movimientos] ([id_cliente], [nro_movimiento]) VALUES (1, 2)
/****** Object:  Table [dbo].[proveedor_movimientos]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor_movimientos](
	[id_proveedor] [bigint] NOT NULL,
	[nro_movimiento] [bigint] NOT NULL,
 CONSTRAINT [PK_proveedor_movimientos] PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC,
	[nro_movimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[proveedor_movimientos] ([id_proveedor], [nro_movimiento]) VALUES (1, 3)
/****** Object:  Table [dbo].[lista_precios]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[lista_precios](
	[nro_lista] [bigint] NOT NULL,
	[cod_articulo] [bigint] NOT NULL,
	[fechaDesde] [datetime] NOT NULL,
	[fechaHasta] [datetime] NULL,
	[precio] [float] NULL,
	[borrado] [varchar](1) NULL,
 CONSTRAINT [PK_precioProducto] PRIMARY KEY CLUSTERED 
(
	[nro_lista] ASC,
	[cod_articulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[lista_precios] ([nro_lista], [cod_articulo], [fechaDesde], [fechaHasta], [precio], [borrado]) VALUES (1, 1, CAST(0x00009F9800B40D7D AS DateTime), CAST(0x00009F9800C4885F AS DateTime), 1.1, N'0')
INSERT [dbo].[lista_precios] ([nro_lista], [cod_articulo], [fechaDesde], [fechaHasta], [precio], [borrado]) VALUES (1, 2, CAST(0x00009F9800000000 AS DateTime), CAST(0x00009F9900000000 AS DateTime), 1.2, N'0')
INSERT [dbo].[lista_precios] ([nro_lista], [cod_articulo], [fechaDesde], [fechaHasta], [precio], [borrado]) VALUES (2, 1, CAST(0x00009F9800000000 AS DateTime), NULL, 2.1, N'0')
INSERT [dbo].[lista_precios] ([nro_lista], [cod_articulo], [fechaDesde], [fechaHasta], [precio], [borrado]) VALUES (2, 2, CAST(0x00009F9800000000 AS DateTime), NULL, 2.2, N'0')
/****** Object:  Table [dbo].[LineaOrdenDeCompra]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LineaOrdenDeCompra](
	[nro_sucursal] [bigint] NOT NULL,
	[nro_orden_compra] [bigint] NOT NULL,
	[tipo_orden_compra] [varchar](1) NOT NULL,
	[nro_linea] [bigint] NOT NULL,
	[cod_producto] [bigint] NOT NULL,
	[cantidad] [int] NULL,
	[precio] [float] NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_LineaOrdenDeCompra] PRIMARY KEY CLUSTERED 
(
	[nro_sucursal] ASC,
	[nro_orden_compra] ASC,
	[tipo_orden_compra] ASC,
	[nro_linea] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[LineaOrdenDeCompra] ([nro_sucursal], [nro_orden_compra], [tipo_orden_compra], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (1, 1, N'A', 1, 1, 10, 10, N'0')
INSERT [dbo].[LineaOrdenDeCompra] ([nro_sucursal], [nro_orden_compra], [tipo_orden_compra], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (1, 1, N'A', 2, 2, 20, 20, N'0')
INSERT [dbo].[LineaOrdenDeCompra] ([nro_sucursal], [nro_orden_compra], [tipo_orden_compra], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (1, 2, N'B', 1, 1, 10, 10, N'0')
INSERT [dbo].[LineaOrdenDeCompra] ([nro_sucursal], [nro_orden_compra], [tipo_orden_compra], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (1, 2, N'B', 2, 1, 10, 10, N'0')
/****** Object:  Table [dbo].[LineaFactura]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LineaFactura](
	[nro_sucursal] [bigint] NOT NULL,
	[nro_factura] [bigint] NOT NULL,
	[tipo_factura] [varchar](1) NOT NULL,
	[nro_linea] [bigint] NOT NULL,
	[cod_producto] [bigint] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_LineaFactura] PRIMARY KEY CLUSTERED 
(
	[nro_sucursal] ASC,
	[nro_factura] ASC,
	[nro_linea] ASC,
	[tipo_factura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[LineaFactura] ([nro_sucursal], [nro_factura], [tipo_factura], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (1, 1, N'A', 1, 1, 10, 10, N'0')
INSERT [dbo].[LineaFactura] ([nro_sucursal], [nro_factura], [tipo_factura], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (1, 1, N'A', 2, 2, 10, 20, N'0')
INSERT [dbo].[LineaFactura] ([nro_sucursal], [nro_factura], [tipo_factura], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (2, 1, N'B', 1, 1, 10, 10, N'0')
INSERT [dbo].[LineaFactura] ([nro_sucursal], [nro_factura], [tipo_factura], [nro_linea], [cod_producto], [cantidad], [precio], [borrado]) VALUES (2, 1, N'B', 2, 2, 10, 20, N'0')
/****** Object:  Table [dbo].[Pedido]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pedido](
	[cod_pedido] [bigint] NOT NULL,
	[comentario] [nvarchar](500) NULL,
	[id_cliente] [bigint] NOT NULL,
	[tipo_pedido] [bigint] NOT NULL,
	[estadoActual] [bigint] NOT NULL,
	[fechaInicio] [datetime] NULL,
	[fechaFinal] [datetime] NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[cod_pedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Pedido] ([cod_pedido], [comentario], [id_cliente], [tipo_pedido], [estadoActual], [fechaInicio], [fechaFinal], [borrado]) VALUES (1, N'comentario1', 1, 1, 3, CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900D63BC0 AS DateTime), N'0')
INSERT [dbo].[Pedido] ([cod_pedido], [comentario], [id_cliente], [tipo_pedido], [estadoActual], [fechaInicio], [fechaFinal], [borrado]) VALUES (2, N'comentario2', 2, 2, 3, CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900D63BC0 AS DateTime), N'0')
INSERT [dbo].[Pedido] ([cod_pedido], [comentario], [id_cliente], [tipo_pedido], [estadoActual], [fechaInicio], [fechaFinal], [borrado]) VALUES (3, N'comentario3', 1, 2, 0, CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900D63BC0 AS DateTime), N'0')
INSERT [dbo].[Pedido] ([cod_pedido], [comentario], [id_cliente], [tipo_pedido], [estadoActual], [fechaInicio], [fechaFinal], [borrado]) VALUES (4, N'comentario4', 1, 1, 0, CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900D63BC0 AS DateTime), N'0')
/****** Object:  Table [dbo].[producto_reparacion]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto_reparacion](
	[id_reparacion] [bigint] NOT NULL,
	[cod_producto] [bigint] NOT NULL,
 CONSTRAINT [PK_producto_reparacion] PRIMARY KEY CLUSTERED 
(
	[id_reparacion] ASC,
	[cod_producto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto_insumo]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto_insumo](
	[cod_producto] [bigint] NOT NULL,
	[cod_insumo] [bigint] NOT NULL,
 CONSTRAINT [PK_producto_insumo] PRIMARY KEY CLUSTERED 
(
	[cod_producto] ASC,
	[cod_insumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produccion_operador]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produccion_operador](
	[cod_prodcuccion] [bigint] NOT NULL,
	[id_operador] [bigint] NOT NULL,
	[porcentaje] [int] NOT NULL,
 CONSTRAINT [PK_produccion_operador] PRIMARY KEY CLUSTERED 
(
	[cod_prodcuccion] ASC,
	[id_operador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[produccion_operador] ([cod_prodcuccion], [id_operador], [porcentaje]) VALUES (1, 1, 50)
INSERT [dbo].[produccion_operador] ([cod_prodcuccion], [id_operador], [porcentaje]) VALUES (1, 2, 50)
INSERT [dbo].[produccion_operador] ([cod_prodcuccion], [id_operador], [porcentaje]) VALUES (2, 2, 100)
INSERT [dbo].[produccion_operador] ([cod_prodcuccion], [id_operador], [porcentaje]) VALUES (3, 1, 70)
INSERT [dbo].[produccion_operador] ([cod_prodcuccion], [id_operador], [porcentaje]) VALUES (3, 2, 30)
INSERT [dbo].[produccion_operador] ([cod_prodcuccion], [id_operador], [porcentaje]) VALUES (4, 1, 100)
INSERT [dbo].[produccion_operador] ([cod_prodcuccion], [id_operador], [porcentaje]) VALUES (5, 2, 100)
/****** Object:  Table [dbo].[produccion]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[produccion](
	[cod_produccion] [bigint] NOT NULL,
	[cod_pedido] [bigint] NULL,
	[cod_articulo] [bigint] NOT NULL,
	[cod_maquina] [bigint] NULL,
	[comentario] [nvarchar](50) NULL,
	[estadoActual] [bigint] NOT NULL,
	[fechaInicio] [datetime] NULL,
	[fechaFinal] [datetime] NULL,
	[utilizacion] [float] NOT NULL,
	[borrado] [varchar](1) NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_produccion_1] PRIMARY KEY CLUSTERED 
(
	[cod_produccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[produccion] ([cod_produccion], [cod_pedido], [cod_articulo], [cod_maquina], [comentario], [estadoActual], [fechaInicio], [fechaFinal], [utilizacion], [borrado], [cantidad]) VALUES (1, 1, 1, 1, N'comentario 11', 3, CAST(0x0000A0E500A4CB80 AS DateTime), CAST(0x0000A0E500E6B680 AS DateTime), 4, N'0', 10)
INSERT [dbo].[produccion] ([cod_produccion], [cod_pedido], [cod_articulo], [cod_maquina], [comentario], [estadoActual], [fechaInicio], [fechaFinal], [utilizacion], [borrado], [cantidad]) VALUES (2, 1, 2, 1, N'comentario 12', 2, CAST(0x0000A0E50107AC00 AS DateTime), CAST(0x0000A0E600C5C100 AS DateTime), 6, N'0', 10)
INSERT [dbo].[produccion] ([cod_produccion], [cod_pedido], [cod_articulo], [cod_maquina], [comentario], [estadoActual], [fechaInicio], [fechaFinal], [utilizacion], [borrado], [cantidad]) VALUES (3, 1, 3, 2, N'comentario 13', 0, CAST(0x0000A0E500D63BC0 AS DateTime), CAST(0x0000A0E80128A180 AS DateTime), 1, N'0', 10)
INSERT [dbo].[produccion] ([cod_produccion], [cod_pedido], [cod_articulo], [cod_maquina], [comentario], [estadoActual], [fechaInicio], [fechaFinal], [utilizacion], [borrado], [cantidad]) VALUES (4, 2, 5, 3, N'comentario 21', 0, CAST(0x0000A0E500F73140 AS DateTime), CAST(0x0000A0E800D63BC0 AS DateTime), 7, N'0', 10)
INSERT [dbo].[produccion] ([cod_produccion], [cod_pedido], [cod_articulo], [cod_maquina], [comentario], [estadoActual], [fechaInicio], [fechaFinal], [utilizacion], [borrado], [cantidad]) VALUES (5, 2, 6, 1, N'comentario 22', 0, CAST(0x0000A0E600C5C100 AS DateTime), CAST(0x0000A0E60107AC00 AS DateTime), 4, N'0', 10)
INSERT [dbo].[produccion] ([cod_produccion], [cod_pedido], [cod_articulo], [cod_maquina], [comentario], [estadoActual], [fechaInicio], [fechaFinal], [utilizacion], [borrado], [cantidad]) VALUES (6, 3, 4, 3, N'comentario 31', 0, CAST(0x0000A0E900D63BC0 AS DateTime), CAST(0x0000A0EB0128A180 AS DateTime), 5, N'0', 10)
/****** Object:  Table [dbo].[historico_estados_pedido]    Script Date: 10/30/2012 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[historico_estados_pedido](
	[nro_estado] [bigint] NOT NULL,
	[cod_pedido] [bigint] NOT NULL,
	[comentario] [nvarchar](100) NULL,
	[fechaDesde] [datetime] NOT NULL,
	[fechaHasta] [datetime] NULL,
	[estado] [bigint] NOT NULL,
	[borrado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_RelEstadoPedido] PRIMARY KEY CLUSTERED 
(
	[nro_estado] ASC,
	[cod_pedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[historico_estados_pedido] ([nro_estado], [cod_pedido], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (1, 1, N'comentario 11', CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900E6B680 AS DateTime), 1, N'0')
INSERT [dbo].[historico_estados_pedido] ([nro_estado], [cod_pedido], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (1, 2, N'comentario 12', CAST(0x0000A0C900D63BC0 AS DateTime), CAST(0x0000A0C900E6B680 AS DateTime), 1, N'0')
INSERT [dbo].[historico_estados_pedido] ([nro_estado], [cod_pedido], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (2, 1, N'comentario 21', CAST(0x0000A0C900E6B680 AS DateTime), CAST(0x0000A0C900F73140 AS DateTime), 2, N'0')
INSERT [dbo].[historico_estados_pedido] ([nro_estado], [cod_pedido], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (2, 2, N'comentario 22', CAST(0x0000A0C900E6B680 AS DateTime), CAST(0x0000A0C900F73140 AS DateTime), 2, N'0')
INSERT [dbo].[historico_estados_pedido] ([nro_estado], [cod_pedido], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (3, 1, N'comentario 31', CAST(0x0000A0C900F73140 AS DateTime), NULL, 3, N'0')
INSERT [dbo].[historico_estados_pedido] ([nro_estado], [cod_pedido], [comentario], [fechaDesde], [fechaHasta], [estado], [borrado]) VALUES (3, 2, N'comentario 32', CAST(0x0000A0C900F73140 AS DateTime), NULL, 3, N'0')
/****** Object:  Default [DF_Articulos_borrado]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Articulos] ADD  CONSTRAINT [DF_Articulos_borrado]  DEFAULT ((0)) FOR [borrado]
GO
/****** Object:  Default [DF_Cliente_newsletter]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_newsletter]  DEFAULT ((0)) FOR [newsletter]
GO
/****** Object:  Default [DF_Diseño_borrado]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Diseño] ADD  CONSTRAINT [DF_Diseño_borrado]  DEFAULT ((0)) FOR [borrado]
GO
/****** Object:  Default [DF_Factura_borrado]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Factura] ADD  CONSTRAINT [DF_Factura_borrado]  DEFAULT ((0)) FOR [borrado]
GO
/****** Object:  Default [DF_Mensaje_borrado]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Mensaje] ADD  CONSTRAINT [DF_Mensaje_borrado]  DEFAULT ((0)) FOR [borrado]
GO
/****** Object:  Default [DF_newsletter_enviado]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[newsletter] ADD  CONSTRAINT [DF_newsletter_enviado]  DEFAULT ((0)) FOR [enviado]
GO
/****** Object:  Default [DF_Pedido_borrado]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Pedido] ADD  CONSTRAINT [DF_Pedido_borrado]  DEFAULT ((0)) FOR [borrado]
GO
/****** Object:  Default [DF_Usuario_bloqueado]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_bloqueado]  DEFAULT ((0)) FOR [bloqueado]
GO
/****** Object:  ForeignKey [FK_PrecioDiseñoPrenda_Diseño]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_PrecioDiseñoPrenda_Diseño] FOREIGN KEY([diseñoID])
REFERENCES [dbo].[Diseño] ([cod_diseño])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_PrecioDiseñoPrenda_Diseño]
GO
/****** Object:  ForeignKey [FK_PrecioDiseñoPrenda_TipoPrenda]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_PrecioDiseñoPrenda_TipoPrenda] FOREIGN KEY([tipoPrendaID])
REFERENCES [dbo].[TipoPrenda] ([tipo_prenda])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_PrecioDiseñoPrenda_TipoPrenda]
GO
/****** Object:  ForeignKey [FK_Cliente_Usuario]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuario] ([usuarioID])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
/****** Object:  ForeignKey [FK_CuentaCorrienteCliente_Cliente]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[cliente_movimientos]  WITH CHECK ADD  CONSTRAINT [FK_CuentaCorrienteCliente_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[cliente_movimientos] CHECK CONSTRAINT [FK_CuentaCorrienteCliente_Cliente]
GO
/****** Object:  ForeignKey [FK_CuentaCorrienteCliente_MovimientosCuenta]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[cliente_movimientos]  WITH CHECK ADD  CONSTRAINT [FK_CuentaCorrienteCliente_MovimientosCuenta] FOREIGN KEY([nro_movimiento])
REFERENCES [dbo].[MovimientosCuenta] ([nro_movimiento])
GO
ALTER TABLE [dbo].[cliente_movimientos] CHECK CONSTRAINT [FK_CuentaCorrienteCliente_MovimientosCuenta]
GO
/****** Object:  ForeignKey [FK_Diseño_insumos_Diseño]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Diseño_insumos]  WITH CHECK ADD  CONSTRAINT [FK_Diseño_insumos_Diseño] FOREIGN KEY([cod_diseño])
REFERENCES [dbo].[Diseño] ([cod_diseño])
GO
ALTER TABLE [dbo].[Diseño_insumos] CHECK CONSTRAINT [FK_Diseño_insumos_Diseño]
GO
/****** Object:  ForeignKey [FK_Diseño_insumos_insumo]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Diseño_insumos]  WITH CHECK ADD  CONSTRAINT [FK_Diseño_insumos_insumo] FOREIGN KEY([cod_insumo])
REFERENCES [dbo].[insumo] ([cod_insumo])
GO
ALTER TABLE [dbo].[Diseño_insumos] CHECK CONSTRAINT [FK_Diseño_insumos_insumo]
GO
/****** Object:  ForeignKey [FK_documento_movimiento_Documento]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[documento_movimiento]  WITH CHECK ADD  CONSTRAINT [FK_documento_movimiento_Documento] FOREIGN KEY([nro_doc])
REFERENCES [dbo].[Documento] ([nro_doc])
GO
ALTER TABLE [dbo].[documento_movimiento] CHECK CONSTRAINT [FK_documento_movimiento_Documento]
GO
/****** Object:  ForeignKey [FK_documento_movimiento_MovimientosCuenta]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[documento_movimiento]  WITH CHECK ADD  CONSTRAINT [FK_documento_movimiento_MovimientosCuenta] FOREIGN KEY([nro_movimiento])
REFERENCES [dbo].[MovimientosCuenta] ([nro_movimiento])
GO
ALTER TABLE [dbo].[documento_movimiento] CHECK CONSTRAINT [FK_documento_movimiento_MovimientosCuenta]
GO
/****** Object:  ForeignKey [FK_RelEstadosDiseño_Diseño]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[historico_estados_diseño]  WITH CHECK ADD  CONSTRAINT [FK_RelEstadosDiseño_Diseño] FOREIGN KEY([cod_diseño])
REFERENCES [dbo].[Diseño] ([cod_diseño])
GO
ALTER TABLE [dbo].[historico_estados_diseño] CHECK CONSTRAINT [FK_RelEstadosDiseño_Diseño]
GO
/****** Object:  ForeignKey [FK_RelEstadoPedido_EstadoPedido]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[historico_estados_pedido]  WITH CHECK ADD  CONSTRAINT [FK_RelEstadoPedido_EstadoPedido] FOREIGN KEY([estado])
REFERENCES [dbo].[EstadoPedido] ([estado_pedido])
GO
ALTER TABLE [dbo].[historico_estados_pedido] CHECK CONSTRAINT [FK_RelEstadoPedido_EstadoPedido]
GO
/****** Object:  ForeignKey [FK_RelEstadoPedido_Pedido]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[historico_estados_pedido]  WITH CHECK ADD  CONSTRAINT [FK_RelEstadoPedido_Pedido] FOREIGN KEY([cod_pedido])
REFERENCES [dbo].[Pedido] ([cod_pedido])
GO
ALTER TABLE [dbo].[historico_estados_pedido] CHECK CONSTRAINT [FK_RelEstadoPedido_Pedido]
GO
/****** Object:  ForeignKey [FK_insumo_tipoInsumo]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[insumo]  WITH CHECK ADD  CONSTRAINT [FK_insumo_tipoInsumo] FOREIGN KEY([id_tipo_insumo])
REFERENCES [dbo].[tipoInsumo] ([tipo_insumo])
GO
ALTER TABLE [dbo].[insumo] CHECK CONSTRAINT [FK_insumo_tipoInsumo]
GO
/****** Object:  ForeignKey [FK_JoinFamiliaToPatente_Familia]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[JoinFamiliaToPatente]  WITH CHECK ADD  CONSTRAINT [FK_JoinFamiliaToPatente_Familia] FOREIGN KEY([familiaID])
REFERENCES [dbo].[Familia] ([familiaID])
GO
ALTER TABLE [dbo].[JoinFamiliaToPatente] CHECK CONSTRAINT [FK_JoinFamiliaToPatente_Familia]
GO
/****** Object:  ForeignKey [FK_JoinFamiliaToPatente_Patente]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[JoinFamiliaToPatente]  WITH CHECK ADD  CONSTRAINT [FK_JoinFamiliaToPatente_Patente] FOREIGN KEY([patenteID])
REFERENCES [dbo].[Patente] ([patenteID])
GO
ALTER TABLE [dbo].[JoinFamiliaToPatente] CHECK CONSTRAINT [FK_JoinFamiliaToPatente_Patente]
GO
/****** Object:  ForeignKey [FK_JoinMaquinaToTipoPrenda_TipoPrenda]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[JoinMaquinaToTipoPrenda]  WITH CHECK ADD  CONSTRAINT [FK_JoinMaquinaToTipoPrenda_TipoPrenda] FOREIGN KEY([tipo_prenda])
REFERENCES [dbo].[TipoPrenda] ([tipo_prenda])
GO
ALTER TABLE [dbo].[JoinMaquinaToTipoPrenda] CHECK CONSTRAINT [FK_JoinMaquinaToTipoPrenda_TipoPrenda]
GO
/****** Object:  ForeignKey [FK_JoinPatenteToUsuario_Patente]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[JoinPatenteToUsuario]  WITH CHECK ADD  CONSTRAINT [FK_JoinPatenteToUsuario_Patente] FOREIGN KEY([patenteID])
REFERENCES [dbo].[Patente] ([patenteID])
GO
ALTER TABLE [dbo].[JoinPatenteToUsuario] CHECK CONSTRAINT [FK_JoinPatenteToUsuario_Patente]
GO
/****** Object:  ForeignKey [FK_JoinPatenteToUsuario_Usuario]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[JoinPatenteToUsuario]  WITH CHECK ADD  CONSTRAINT [FK_JoinPatenteToUsuario_Usuario] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuario] ([usuarioID])
GO
ALTER TABLE [dbo].[JoinPatenteToUsuario] CHECK CONSTRAINT [FK_JoinPatenteToUsuario_Usuario]
GO
/****** Object:  ForeignKey [FK_JoinUsuarioToFamilia_Familia]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[JoinUsuarioToFamilia]  WITH CHECK ADD  CONSTRAINT [FK_JoinUsuarioToFamilia_Familia] FOREIGN KEY([familiaID])
REFERENCES [dbo].[Familia] ([familiaID])
GO
ALTER TABLE [dbo].[JoinUsuarioToFamilia] CHECK CONSTRAINT [FK_JoinUsuarioToFamilia_Familia]
GO
/****** Object:  ForeignKey [FK_JoinUsuarioToFamilia_Usuario]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[JoinUsuarioToFamilia]  WITH CHECK ADD  CONSTRAINT [FK_JoinUsuarioToFamilia_Usuario] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuario] ([usuarioID])
GO
ALTER TABLE [dbo].[JoinUsuarioToFamilia] CHECK CONSTRAINT [FK_JoinUsuarioToFamilia_Usuario]
GO
/****** Object:  ForeignKey [FK_LineaFactura_DiseñoPrenda]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[LineaFactura]  WITH CHECK ADD  CONSTRAINT [FK_LineaFactura_DiseñoPrenda] FOREIGN KEY([cod_producto])
REFERENCES [dbo].[Articulos] ([cod_articulo])
GO
ALTER TABLE [dbo].[LineaFactura] CHECK CONSTRAINT [FK_LineaFactura_DiseñoPrenda]
GO
/****** Object:  ForeignKey [FK_LineaFactura_Factura]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[LineaFactura]  WITH CHECK ADD  CONSTRAINT [FK_LineaFactura_Factura] FOREIGN KEY([nro_sucursal], [nro_factura], [tipo_factura])
REFERENCES [dbo].[Factura] ([nro_sucursal], [nro_factura], [tipo_factura])
GO
ALTER TABLE [dbo].[LineaFactura] CHECK CONSTRAINT [FK_LineaFactura_Factura]
GO
/****** Object:  ForeignKey [FK_LineaOrdenDeCompra_insumo]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[LineaOrdenDeCompra]  WITH CHECK ADD  CONSTRAINT [FK_LineaOrdenDeCompra_insumo] FOREIGN KEY([cod_producto])
REFERENCES [dbo].[insumo] ([cod_insumo])
GO
ALTER TABLE [dbo].[LineaOrdenDeCompra] CHECK CONSTRAINT [FK_LineaOrdenDeCompra_insumo]
GO
/****** Object:  ForeignKey [FK_LineaOrdenDeCompra_OrdenDeCompra]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[LineaOrdenDeCompra]  WITH CHECK ADD  CONSTRAINT [FK_LineaOrdenDeCompra_OrdenDeCompra] FOREIGN KEY([nro_sucursal], [nro_orden_compra], [tipo_orden_compra])
REFERENCES [dbo].[OrdenDeCompra] ([nro_sucursal], [nro_orden_compra], [tipo_orden_compra])
GO
ALTER TABLE [dbo].[LineaOrdenDeCompra] CHECK CONSTRAINT [FK_LineaOrdenDeCompra_OrdenDeCompra]
GO
/****** Object:  ForeignKey [FK_lista_precios_DiseñoPrenda]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[lista_precios]  WITH CHECK ADD  CONSTRAINT [FK_lista_precios_DiseñoPrenda] FOREIGN KEY([cod_articulo])
REFERENCES [dbo].[Articulos] ([cod_articulo])
GO
ALTER TABLE [dbo].[lista_precios] CHECK CONSTRAINT [FK_lista_precios_DiseñoPrenda]
GO
/****** Object:  ForeignKey [FK_MovimientosCuenta_Cuenta]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[MovimientosCuenta]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosCuenta_Cuenta] FOREIGN KEY([cuentaID])
REFERENCES [dbo].[Cuenta] ([cuentaID])
GO
ALTER TABLE [dbo].[MovimientosCuenta] CHECK CONSTRAINT [FK_MovimientosCuenta_Cuenta]
GO
/****** Object:  ForeignKey [FK_MovimientosCuenta_TipoMovimiento]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[MovimientosCuenta]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosCuenta_TipoMovimiento] FOREIGN KEY([tipoMovimientoID])
REFERENCES [dbo].[TipoMovimiento] ([tipoMovimientoID])
GO
ALTER TABLE [dbo].[MovimientosCuenta] CHECK CONSTRAINT [FK_MovimientosCuenta_TipoMovimiento]
GO
/****** Object:  ForeignKey [FK_operador_Usuario]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[operador]  WITH CHECK ADD  CONSTRAINT [FK_operador_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([usuarioID])
GO
ALTER TABLE [dbo].[operador] CHECK CONSTRAINT [FK_operador_Usuario]
GO
/****** Object:  ForeignKey [FK_OrdenDeCompra_Documento]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[OrdenDeCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenDeCompra_Documento] FOREIGN KEY([nro_doc])
REFERENCES [dbo].[Documento] ([nro_doc])
GO
ALTER TABLE [dbo].[OrdenDeCompra] CHECK CONSTRAINT [FK_OrdenDeCompra_Documento]
GO
/****** Object:  ForeignKey [FK_OrdenDeCompra_ProveedorGeneral]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[OrdenDeCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenDeCompra_ProveedorGeneral] FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[Proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[OrdenDeCompra] CHECK CONSTRAINT [FK_OrdenDeCompra_ProveedorGeneral]
GO
/****** Object:  ForeignKey [FK_Pedido_Cliente]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
/****** Object:  ForeignKey [FK_Pedido_TipoPedido]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_TipoPedido] FOREIGN KEY([tipo_pedido])
REFERENCES [dbo].[TipoPedido] ([tipo_pedido])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_TipoPedido]
GO
/****** Object:  ForeignKey [FK_produccion_Maquina]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[produccion]  WITH CHECK ADD  CONSTRAINT [FK_produccion_Maquina] FOREIGN KEY([cod_maquina])
REFERENCES [dbo].[Maquina] ([cod_maquina])
GO
ALTER TABLE [dbo].[produccion] CHECK CONSTRAINT [FK_produccion_Maquina]
GO
/****** Object:  ForeignKey [FK_Trabajo_Pedido]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[produccion]  WITH CHECK ADD  CONSTRAINT [FK_Trabajo_Pedido] FOREIGN KEY([cod_pedido])
REFERENCES [dbo].[Pedido] ([cod_pedido])
GO
ALTER TABLE [dbo].[produccion] CHECK CONSTRAINT [FK_Trabajo_Pedido]
GO
/****** Object:  ForeignKey [FK_produccion_operador_operador]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[produccion_operador]  WITH CHECK ADD  CONSTRAINT [FK_produccion_operador_operador] FOREIGN KEY([id_operador])
REFERENCES [dbo].[operador] ([id_operador])
GO
ALTER TABLE [dbo].[produccion_operador] CHECK CONSTRAINT [FK_produccion_operador_operador]
GO
/****** Object:  ForeignKey [FK_producto_insumo_insumo]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[producto_insumo]  WITH CHECK ADD  CONSTRAINT [FK_producto_insumo_insumo] FOREIGN KEY([cod_insumo])
REFERENCES [dbo].[insumo] ([cod_insumo])
GO
ALTER TABLE [dbo].[producto_insumo] CHECK CONSTRAINT [FK_producto_insumo_insumo]
GO
/****** Object:  ForeignKey [FK_producto_reparacion_Reparacion]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[producto_reparacion]  WITH CHECK ADD  CONSTRAINT [FK_producto_reparacion_Reparacion] FOREIGN KEY([id_reparacion])
REFERENCES [dbo].[Reparacion] ([cod_reparacion])
GO
ALTER TABLE [dbo].[producto_reparacion] CHECK CONSTRAINT [FK_producto_reparacion_Reparacion]
GO
/****** Object:  ForeignKey [FK_proveedor_movimientos_MovimientosCuenta]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[proveedor_movimientos]  WITH CHECK ADD  CONSTRAINT [FK_proveedor_movimientos_MovimientosCuenta] FOREIGN KEY([nro_movimiento])
REFERENCES [dbo].[MovimientosCuenta] ([nro_movimiento])
GO
ALTER TABLE [dbo].[proveedor_movimientos] CHECK CONSTRAINT [FK_proveedor_movimientos_MovimientosCuenta]
GO
/****** Object:  ForeignKey [FK_proveedor_movimientos_Proveedor]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[proveedor_movimientos]  WITH CHECK ADD  CONSTRAINT [FK_proveedor_movimientos_Proveedor] FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[Proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[proveedor_movimientos] CHECK CONSTRAINT [FK_proveedor_movimientos_Proveedor]
GO
/****** Object:  ForeignKey [FK_Reparacion_Maquina]    Script Date: 10/30/2012 16:53:42 ******/
ALTER TABLE [dbo].[Reparacion]  WITH CHECK ADD  CONSTRAINT [FK_Reparacion_Maquina] FOREIGN KEY([cod_maquina])
REFERENCES [dbo].[Maquina] ([cod_maquina])
GO
ALTER TABLE [dbo].[Reparacion] CHECK CONSTRAINT [FK_Reparacion_Maquina]
GO
