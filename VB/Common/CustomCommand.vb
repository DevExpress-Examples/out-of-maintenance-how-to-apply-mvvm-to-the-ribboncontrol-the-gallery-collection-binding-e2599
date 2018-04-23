Imports System
Imports System.Windows.Input

Namespace DXSample
    Public Class CustomCommand
        Implements ICommand

        Private _executeMethod As Action
        Private _canExecuteMethod As Func(Of Boolean)
        Public Sub New(ByVal executeMethod As Action, ByVal canExecuteMethod As Func(Of Boolean))
            _executeMethod = executeMethod
            _canExecuteMethod = canExecuteMethod
        End Sub
        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Return _canExecuteMethod()
        End Function
        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
            _executeMethod()
        End Sub
        Public Sub CheckCanExecuteChanged()
            RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace