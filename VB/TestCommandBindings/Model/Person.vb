Imports Microsoft.VisualBasic
#Region "Copyright and License Information"

' Fluent Ribbon Control Suite
' http://fluent.codeplex.com/
' Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
' 
' Distributed under the terms of the Microsoft Public License (Ms-PL). 
' The license is available online http://fluent.codeplex.com/license

#End Region

Imports System.ComponentModel
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace Fluent.Sample.Mvvm.Model
	''' <summary>
	''' Represents person
	''' </summary>
	Public Class Person
		Implements INotifyPropertyChanged
		#Region "Events"

		''' <summary>
		''' Occurs when a property value changes.
		''' </summary>
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		' Raise PropertyChanged event
		Private Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub

		#End Region

		#Region "Fields"

		' Name
		Private name_Renamed As String = "Untitled"
		' E-mail
		Private email_Renamed As String
		' Phone
		Private phone_Renamed As String
		' Photo
		Private photo_Renamed As ImageSource

		#End Region

		#Region "Properies"

		''' <summary>
		''' Gets or sets name
		''' </summary>
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

		''' <summary>
		''' Gets or sets e-mail
		''' </summary>
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


		''' <summary>
		''' Gets or sets phone
		''' </summary>
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

		''' <summary>
		''' Gets or sets photo
		''' </summary>
		Public Property Photo() As ImageSource
			Get
				Return photo_Renamed
			End Get
			Set(ByVal value As ImageSource)
				If photo_Renamed Is value Then
					Return
				End If
				photo_Renamed = value
				RaisePropertyChanged("Photo")
			End Set
		End Property

		#End Region

		#Region "Methods"

		''' <summary>
		''' Creates new person
		''' </summary>
		''' <param name="name">Name</param>
		''' <param name="email">E-mail</param>
		''' <param name="phone">Phone</param>
		''' <param name="photo">Photo</param>
		''' <returns>Person</returns>
		Public Shared Function Create(ByVal name As String, ByVal email As String, ByVal phone As String, ByVal photo As ImageSource) As Person
			Dim person As New Person()
			person.name = name
			person.email = email
			person.phone = phone
			person.photo = photo
			Return person
		End Function

		#End Region
	End Class
End Namespace
