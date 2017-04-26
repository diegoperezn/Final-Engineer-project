Public Class Columna

    Enum TIPO
        NUMERICO = 0
        TEXTO = 1
        BOOLEANO = 2
        ' El campo MANY_TO_ONE debe tener un Join con la columna/propiedad con la que esta relacionado el objeto
        ' la tabla contiene el id de la entidad a la que esta relacionado, la propiedad columna indica en que propiedad
        ' del objeto de la relacion se cargara este id que tenemos en la tabla. 
        MANY_TO_ONE = 3
        ONE_TO_MANY = 4
        MANY_TO_MANY = 5
        ONE_TO_ONE = 6
        FECHA = 7
        [DOUBLE] = 8

        ARCHIVO = 9

    End Enum

    Sub New(ByVal nombre As String, ByVal columna As String, ByVal tipo As TIPO, ByVal join As Join)
        Me.nombre = nombre
        Me.columna = columna
        Me.tipoColuman = tipo
        Me.join = join
        Me.esIdentidad = False
        Me.esDuenioRelacion = False
    End Sub

    Sub New(ByVal nombre As String, ByVal columna As String, ByVal tipo As TIPO)
        Me.nombre = nombre
        Me.columna = columna
        Me.tipoColuman = tipo
        Me.esIdentidad = False
    End Sub

    Sub New(ByVal nombre As String, ByVal tipo As TIPO)
        Me.nombre = nombre
        Me.columna = nombre
        Me.tipoColuman = tipo
        Me.esIdentidad = False
    End Sub

    Sub New(ByVal nombre As String, ByVal tipo As TIPO, ByVal esIdentidad As Boolean)
        Me.nombre = nombre
        Me.columna = nombre
        Me.tipoColuman = tipo
        Me.esIdentidad = esIdentidad
    End Sub

    Sub New(ByVal nombre As String, ByVal columna As String, ByVal tipo As TIPO, ByVal esIdentidad As Boolean)
        Me.nombre = nombre
        Me.columna = columna
        Me.tipoColuman = tipo
        Me.esIdentidad = esIdentidad
    End Sub

    Sub New(ByVal nombre As String, ByVal tipo As Columna.TIPO, ByVal join As Join, ByVal esDuenioRelacion As Boolean)
        Me.nombre = nombre
        Me.columna = nombre
        Me.tipoColuman = tipo
        Me.esIdentidad = False
        Me.join = join
        Me.esDuenioRelacion = esDuenioRelacion
    End Sub

    Sub New(ByVal nombre As String, ByVal col As String, ByVal tipo As Columna.TIPO, ByVal join As Join, ByVal esDuenioRelacion As Boolean)
        Me.nombre = nombre
        Me.columna = col
        Me.tipoColuman = tipo
        Me.esIdentidad = False
        Me.join = join
        Me.esDuenioRelacion = esDuenioRelacion
    End Sub

    Sub New(ByVal nombre As String, ByVal columna As String, ByVal tipo As Columna.TIPO, ByVal esIdentidad As Boolean, ByVal join As Join)
        Me.nombre = nombre
        Me.columna = columna
        Me.tipoColuman = tipo
        Me.esIdentidad = esIdentidad
        Me.join = join
    End Sub


    Private _esDuenioRelacion As Boolean
    Public Property esDuenioRelacion() As Boolean
        Get
            Return _esDuenioRelacion
        End Get
        Set(ByVal value As Boolean)
            _esDuenioRelacion = value
        End Set
    End Property

    Private _esIdentidad As Boolean
    Public Property esIdentidad() As Boolean
        Get
            Return _esIdentidad
        End Get
        Set(ByVal value As Boolean)
            _esIdentidad = value
        End Set
    End Property


    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property


    Private _tipoColumna As TIPO
    Public Property tipoColuman() As TIPO
        Get
            Return _tipoColumna
        End Get
        Set(ByVal value As TIPO)
            _tipoColumna = value
        End Set
    End Property


    Private _columna As String
    Public Property columna() As String
        Get
            Return _columna
        End Get
        Set(ByVal value As String)
            _columna = value
        End Set
    End Property


    Private _join As Join
    Public Property join() As Join
        Get
            Return _join
        End Get
        Set(ByVal value As Join)
            _join = value
        End Set
    End Property


End Class
