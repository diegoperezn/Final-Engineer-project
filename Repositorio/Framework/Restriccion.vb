Public Class Restriccion

    Public Const CONDICION_IGUAL As String = "=value"
    Public Const CONDICION_DISTINTO As String = "!=value"
    Public Const CONDICION_MENOR_IGUAL As String = "<=value"
    Public Const CONDICION_MAYOR_IGUAL As String = ">=value"
    Public Const CONDICION_LIKE As String = " LIKE '%value%'"
    Public Const CONDICION_BETWEEN As String = " BETWEEN (value1, value2) "
    Public Const CONDICION_NULL As String = " NULL "

    Sub New(ByVal campo As Columna, ByVal valor As String, ByVal condicion As String)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = condicion
    End Sub

    Sub New(ByVal campo As Columna, ByVal valor As Long, ByVal condicion As String)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = condicion
    End Sub

    Sub New(ByVal campo As Columna, ByVal valor As Double, ByVal condicion As String)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = condicion
    End Sub

    Sub New(ByVal campo As Columna, ByVal valor As String)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = Restriccion.CONDICION_IGUAL
    End Sub

    Sub New(ByVal campo As Columna, ByVal valor As Long)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = Restriccion.CONDICION_IGUAL
    End Sub

    Sub New(ByVal campo As Columna, ByVal valor As Boolean)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = Restriccion.CONDICION_IGUAL
    End Sub

    Sub New(ByVal campo As Columna, ByVal valor As Double)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = Restriccion.CONDICION_IGUAL
    End Sub

    Sub New(ByVal campo As Columna, ByVal valor As Boolean, ByVal condicion As String)
        Me.campo = campo
        Me.valor = valor
        Me.condicion = condicion
    End Sub

    Private _campo As Columna

    Public Property campo() As Columna
        Get
            Return _campo
        End Get
        Set(ByVal value As Columna)
            _campo = value
        End Set
    End Property


    Private _valor As String
    Public Property valor() As String
        Get
            Return _valor
        End Get
        Set(ByVal value As String)
            _valor = value
        End Set
    End Property


    Private _condicion As String
    Public Property condicion() As String
        Get
            Return _condicion
        End Get
        Set(ByVal value As String)
            _condicion = value
        End Set
    End Property


End Class
