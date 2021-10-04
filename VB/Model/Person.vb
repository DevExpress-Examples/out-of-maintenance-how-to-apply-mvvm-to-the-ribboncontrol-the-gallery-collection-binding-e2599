Imports System.ComponentModel

Namespace DXSample.Model

    Public Class Person
        Implements INotifyPropertyChanged

        Private nameField As String = "Untitled"

        Private emailField As String

        Private phoneField As String

        Public Property Name As String
            Get
                Return nameField
            End Get

            Set(ByVal value As String)
                If Equals(nameField, value) Then Return
                nameField = value
                RaisePropertyChanged("Name")
            End Set
        End Property

        Public Property Email As String
            Get
                Return emailField
            End Get

            Set(ByVal value As String)
                If Equals(emailField, value) Then Return
                emailField = value
                RaisePropertyChanged("Email")
            End Set
        End Property

        Public Property Phone As String
            Get
                Return phoneField
            End Get

            Set(ByVal value As String)
                If Equals(phoneField, value) Then Return
                phoneField = value
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
