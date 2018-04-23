Imports System.ComponentModel

Namespace DXSample.Model
    Public Class Person
        Implements INotifyPropertyChanged


        Private name_Renamed As String = "Untitled"

        Private email_Renamed As String

        Private phone_Renamed As String

        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                If name_Renamed = value Then
                    Return
                End If
                name_Renamed = value
                RaisePropertyChanged("Name")
            End Set
        End Property
        Public Property Email() As String
            Get
                Return email_Renamed
            End Get
            Set(ByVal value As String)
                If email_Renamed = value Then
                    Return
                End If
                email_Renamed = value
                RaisePropertyChanged("Email")
            End Set
        End Property
        Public Property Phone() As String
            Get
                Return phone_Renamed
            End Get
            Set(ByVal value As String)
                If phone_Renamed = value Then
                    Return
                End If
                phone_Renamed = value
                RaisePropertyChanged("Phone")
            End Set
        End Property

        Public Sub New()
        End Sub
        Public Sub New(ByVal name As String, ByVal email As String, ByVal phone As String)
            Me.Name = name
            Me.Email = email
            Me.Phone = phone
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Private Sub RaisePropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace