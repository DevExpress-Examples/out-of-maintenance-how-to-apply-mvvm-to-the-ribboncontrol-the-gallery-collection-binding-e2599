Imports System.ComponentModel

Namespace DXSample.Model
	Public Class Person
		Implements INotifyPropertyChanged

'INSTANT VB NOTE: The field name was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private name_Conflict As String = "Untitled"
'INSTANT VB NOTE: The field email was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private email_Conflict As String
'INSTANT VB NOTE: The field phone was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private phone_Conflict As String

		Public Property Name() As String
			Get
				Return name_Conflict
			End Get
			Set(ByVal value As String)
				If name_Conflict = value Then
					Return
				End If
				name_Conflict = value
				RaisePropertyChanged("Name")
			End Set
		End Property
		Public Property Email() As String
			Get
				Return email_Conflict
			End Get
			Set(ByVal value As String)
				If email_Conflict = value Then
					Return
				End If
				email_Conflict = value
				RaisePropertyChanged("Email")
			End Set
		End Property
		Public Property Phone() As String
			Get
				Return phone_Conflict
			End Get
			Set(ByVal value As String)
				If phone_Conflict = value Then
					Return
				End If
				phone_Conflict = value
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

		Public Event PropertyChanged As PropertyChangedEventHandler
		Private Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace