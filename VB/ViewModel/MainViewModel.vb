Imports System.Linq
Imports DXSample.Model
Imports System.ComponentModel

Namespace DXSample.ViewModel
    Public Class MainViewModel
        Implements INotifyPropertyChanged

        Private _SelectedPerson As Person

        Private privateItems As PersonCollection
        Public Property Items() As PersonCollection
            Get
                Return privateItems
            End Get
            Private Set(ByVal value As PersonCollection)
                privateItems = value
            End Set
        End Property
        Private privateDeleteCommand As CustomCommand
        Public Property DeleteCommand() As CustomCommand
            Get
                Return privateDeleteCommand
            End Get
            Private Set(ByVal value As CustomCommand)
                privateDeleteCommand = value
            End Set
        End Property
        Private privateCreateCommand As CustomCommand
        Public Property CreateCommand() As CustomCommand
            Get
                Return privateCreateCommand
            End Get
            Private Set(ByVal value As CustomCommand)
                privateCreateCommand = value
            End Set
        End Property
        Public Property SelectedItem() As Person
            Get
                Return _SelectedPerson
            End Get
            Set(ByVal value As Person)
                If _SelectedPerson Is value Then
                    Return
                End If
                _SelectedPerson = value
                DeleteCommand.CheckCanExecuteChanged()
                RaisePropertyChanged("SelectedItem")
            End Set
        End Property

        Public Sub New()
            DeleteCommand = New CustomCommand(AddressOf DeleteCurrentPerson, Function() _SelectedPerson IsNot Nothing)
            CreateCommand = New CustomCommand(AddressOf CreatePerson, Function() True)
            Items = PersonCollection.Generate()
        End Sub

        Private Sub DeleteCurrentPerson()
            DeletePerson(SelectedItem)
        End Sub
        Private Sub DeletePerson(ByVal person As Person)
            If person Is Nothing Then
                Return
            End If
            If Items.Last() Is person Then
                Items.Remove(person)
                SelectedItem = Items.LastOrDefault()
                Return
            End If
            Dim index As Integer = Items.IndexOf(person)
            Items.Remove(person)
            SelectedItem = Items(index)
        End Sub
        Private Sub CreatePerson()
            Dim newPerson As New Person()
            Items.Add(newPerson)
            SelectedItem = newPerson
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Private Sub RaisePropertyChanged(Optional ByVal name As String = Nothing)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
        End Sub
    End Class
End Namespace