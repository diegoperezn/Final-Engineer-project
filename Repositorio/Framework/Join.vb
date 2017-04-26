Public Class Join

    Private _columna As Columna

    Sub New(ByVal columna As Columna)
        _columna = columna
    End Sub

    Sub New(ByVal columna As Columna, ByVal esProp As Boolean)
        _columna = columna
        Me.esPropiedad = esProp
    End Sub

    Sub New(ByVal columna As Columna, ByVal tabla As String, ByVal esProp As Boolean)
        Me.columna = columna
        Me.tabla = tabla
        Me.esPropiedad = esProp
    End Sub


    Private _esPropiedad As Boolean
    Public Property esPropiedad() As Boolean
        Get
            Return _esPropiedad
        End Get
        Set(ByVal value As Boolean)
            _esPropiedad = value
        End Set
    End Property


    Private _columnaExterna As Columna
    Public Property columnaExterna() As Columna
        Get
            Return _columnaExterna
        End Get
        Set(ByVal value As Columna)
            _columnaExterna = value
        End Set
    End Property


    Private _tabla As String
    Public Property tabla() As String
        Get
            Return _tabla
        End Get
        Set(ByVal value As String)
            _tabla = value
        End Set
    End Property


    Public Property columna() As Columna
        Get
            Return _columna
        End Get
        Set(ByVal value As Columna)
            _columna = value
        End Set
    End Property


End Class
