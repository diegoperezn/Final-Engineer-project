Public Class Encuesta

    Sub New(ByVal id As Long, ByVal atencion As Integer, ByVal calidad As Integer, ByVal eficiencia As Integer)
        Me.id = id
        Me.atencion = atencion
        Me.calidad = calidad
        Me.eficiencia = eficiencia
    End Sub

    Sub New()

    End Sub

    Private _id As Long
    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property


    Private _atencion As Integer
    Public Property atencion() As Integer
        Get
            Return _atencion
        End Get
        Set(ByVal value As Integer)
            _atencion = value
        End Set
    End Property


    Private _calidad As Integer
    Public Property calidad() As Integer
        Get
            Return _calidad
        End Get
        Set(ByVal value As Integer)
            _calidad = value
        End Set
    End Property


    Private _eficiencia As Integer
    Public Property eficiencia() As Integer
        Get
            Return _eficiencia
        End Get
        Set(ByVal value As Integer)
            _eficiencia = value
        End Set
    End Property



End Class
