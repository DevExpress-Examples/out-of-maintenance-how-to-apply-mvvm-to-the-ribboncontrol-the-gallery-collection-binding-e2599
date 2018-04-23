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
Imports System.Windows.Input
Imports Fluent.Sample.Mvvm.Comands
Imports Fluent.Sample.Mvvm.Model
Imports System

Namespace Fluent.Sample.Mvvm.ViewModels
	Public Class PersonChangedEventArgs
		Inherits EventArgs
        Public _Person As Person
		Public Sub New(ByVal person As Person)
            _Person = person
		End Sub
	End Class
	Public Delegate Sub PersonChangedEventHandler(ByVal sender As Object, ByVal e As PersonChangedEventArgs)
	''' <summary>
	''' Represents main view model
	''' </summary>
	Public Class MainViewModel
		Implements INotifyPropertyChanged
		#Region "Events"

		''' <summary>
		''' Occurs when a property value changes.
		''' </summary>
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Public Event PersonCreated As PersonChangedEventHandler
		Public Event PersonRemoved As PersonChangedEventHandler
		Public Event CurrentPersonChanged As PersonChangedEventHandler

		' Raise PropertyChanged event
		Private Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
		Private Sub RaisePersonCreated(ByVal newPerson As Person)
			RaiseEvent PersonCreated(Me, New PersonChangedEventArgs(newPerson))
		End Sub
		Private Sub RaisePersonRemoved(ByVal removedPerson As Person)
			RaiseEvent PersonRemoved(Me, New PersonChangedEventArgs(removedPerson))
		End Sub
		Private Sub RaiseCurrentPersonChanged(ByVal person As Person)
			RaiseEvent CurrentPersonChanged(Me, New PersonChangedEventArgs(person))
		End Sub

		#End Region

		#Region "Fields"

		' All persons
		Private ReadOnly persons_Renamed As PersonCollection = PersonCollection.Generate()
		' Current person
		Private current_Renamed As Person

		#End Region

		#Region "Properties"

		''' <summary>
		''' Gets or sets current person
		''' </summary>
		Public Property Current() As Person
			Get
				Return current_Renamed
			End Get
			Set(ByVal value As Person)
				If current_Renamed Is value Then
					Return
				End If
				current_Renamed = value
				RaiseCurrentPersonChanged(current_Renamed)
				RaisePropertyChanged("Current")
			End Set
		End Property

		''' <summary>
		''' Gets persons
		''' </summary>
		Public ReadOnly Property Persons() As PersonCollection
			Get
				Return persons_Renamed
			End Get
		End Property


		#End Region

		#Region "Commands"

		#Region "Exit"

		Private exitCommand_Renamed As RelayCommand

		''' <summary>
		''' Exit from the application
		''' </summary>
		Public ReadOnly Property ExitCommand() As ICommand
			Get
				If exitCommand_Renamed Is Nothing Then
                    exitCommand_Renamed = New RelayCommand(AddressOf System.Windows.Application.Current.Shutdown)
				End If
				Return exitCommand_Renamed
			End Get
		End Property

		#End Region

		#Region "Delete"

		Private deleteCommand_Renamed As RelayCommand

		''' <summary>
		''' Delete this person
		''' </summary>
		Public ReadOnly Property DeleteCommand() As ICommand
			Get
				If deleteCommand_Renamed Is Nothing Then
                    deleteCommand_Renamed = New RelayCommand(AddressOf DeleteCurrentPerson, Function(x) current_Renamed IsNot Nothing)

				End If
				Return deleteCommand_Renamed
			End Get
		End Property

		' Deletes current person
		Private Sub DeleteCurrentPerson()
			If current_Renamed Is Nothing Then
				Return
			End If
			Dim deleted As Person = current_Renamed

			If persons_Renamed.Count <> 1 Then
				Dim index As Integer = persons_Renamed.IndexOf(deleted)
				Current = persons_Renamed(If(index = 0, 1, index - 1))
			Else
				Current = Nothing
				deleteCommand_Renamed.RaiseCanExecuteChanged()
			End If

			persons_Renamed.Remove(deleted)
			RaisePersonRemoved(deleted)
		End Sub

		#End Region

		#Region "Create"

		Private createCommand_Renamed As RelayCommand

		''' <summary>
		''' Delete this person
		''' </summary>
		Public ReadOnly Property CreateCommand() As ICommand
			Get
				If createCommand_Renamed Is Nothing Then
                    createCommand_Renamed = New RelayCommand(AddressOf CreatePerson)

				End If
				Return createCommand_Renamed
			End Get
		End Property

		' Creates person
		Private Sub CreatePerson()
			Dim newPerson As New Person()
			persons_Renamed.Insert(0, newPerson)
			RaisePersonCreated(newPerson)
			Current = persons_Renamed(0)
			deleteCommand_Renamed.RaiseCanExecuteChanged()
		End Sub

		#End Region

		#End Region

		#Region "Initialization"

		''' <summary>
		''' Default constructor
		''' </summary>
		Public Sub New()
		End Sub
		Public Sub Init()
			If Persons.Count > 0 Then
				For Each person As Person In Persons
					RaisePersonCreated(person)
				Next person
				Current = Persons(0)
			End If
		End Sub
		#End Region
	End Class
End Namespace