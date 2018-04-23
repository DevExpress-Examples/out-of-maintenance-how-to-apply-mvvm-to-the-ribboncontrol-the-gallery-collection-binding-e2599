Imports Microsoft.VisualBasic
#Region "Copyright and License Information"

' Fluent Ribbon Control Suite
' http://fluent.codeplex.com/
' Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
' 
' Distributed under the terms of the Microsoft Public License (Ms-PL). 
' The license is available online http://fluent.codeplex.com/license

#End Region


Imports System
Imports System.Collections.Generic
Imports System.Diagnostics.CodeAnalysis
Imports System.Windows.Input
Imports System.Windows.Threading
Imports System.Diagnostics

Namespace Fluent.Sample.Mvvm.Comands
	''' <summary>
	''' Represents base command
	''' </summary>
	Public Class RelayCommand
		Implements ICommand
		#Region "CanExecute Automatic Updating"

        <SuppressMessage("Microsoft.Performance", "CA1823", Justification:="This variable is used. I can swear")> _
        Private Shared timer As New DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.SystemIdle, AddressOf UpdateCanExcecute, Dispatcher.CurrentDispatcher)

		Private Shared Sub UpdateCanExcecute()
            For Each command_Renamed In automaticCanExecuteUpdatingCommand
                command_Renamed.RaiseCanExecuteChanged()
            Next command_Renamed
		End Sub

		Private Shared automaticCanExecuteUpdatingCommand As New List(Of RelayCommand)()

        Shared Sub RegisterForCanExecuteUpdating(ByVal command_Renamed As RelayCommand)
            automaticCanExecuteUpdatingCommand.Add(command_Renamed)
        End Sub

		#End Region

		#Region "Events"

		''' <summary>
		''' Occurs when CanExecute property changed
		''' </summary>
		Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

		#End Region

		#Region "Fields"

		Private ReadOnly execute_Renamed As Action(Of Object)
		Private ReadOnly canExecute_Renamed As Predicate(Of Object)

		#End Region ' Fields

		#Region "Constructors"

		''' <summary>
		''' Construcotor
		''' </summary>
		''' <param name="execute">Action to execute</param>
		Public Sub New(ByVal execute As Action(Of Object))
			Me.New(execute, Nothing, False)
		End Sub

		''' <summary>
		''' Construcotor
		''' </summary>
		''' <param name="execute">Action to execute</param>
		''' <param name="canExecute">Predicate to check whether command can be executed</param>
		Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object))
			Me.New(execute, canExecute, False)

		End Sub

		''' <summary>
		''' Construcotor
		''' </summary>
		''' <param name="execute">Action to execute</param>
		''' <param name="canExecute">Predicate to check whether command can be executed</param>
		''' <param name="autoCanExecuteUpdating">Use this flag only if you can not invoke RaiseCanExecuteChanged</param>
		Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object), ByVal autoCanExecuteUpdating As Boolean)
			If execute Is Nothing Then
				Throw New ArgumentNullException("execute")
			End If

			Me.execute_Renamed = execute
			Me.canExecute_Renamed = canExecute

			If autoCanExecuteUpdating Then
				RegisterForCanExecuteUpdating(Me)
			End If
		End Sub

		#End Region 

		#Region "ICommand Members"

		''' <summary>
		''' Gets whether the command can be executed
		''' </summary>
		''' <param name="parameter">Parameter</param>
		''' <returns></returns>
		<DebuggerStepThrough> _
		Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
			Return If(canExecute_Renamed Is Nothing, True, canExecute_Renamed(parameter))
		End Function

		''' <summary>
		''' Raises CanExecuteChanged event 
		''' </summary>
		<SuppressMessage("Microsoft.Design", "CA1030")> _
		Public Sub RaiseCanExecuteChanged()
			RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
		End Sub

		''' <summary>
		''' Executes the command
		''' </summary>
		''' <param name="parameter"></param>
		Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
			execute_Renamed(parameter)
		End Sub

		#End Region
	End Class
End Namespace