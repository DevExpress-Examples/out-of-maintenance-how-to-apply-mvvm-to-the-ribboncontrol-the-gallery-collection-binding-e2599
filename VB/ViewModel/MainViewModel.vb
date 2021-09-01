Imports System.Linq
Imports DevExpress.Mvvm
Imports DXSample.Model

Namespace DXSample.ViewModel
    Public Class MainViewModel
        Inherits ViewModelBase

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
        Private privateDeleteCommand As DelegateCommand
        Public Property DeleteCommand() As DelegateCommand
            Get
                Return privateDeleteCommand
            End Get
            Private Set(ByVal value As DelegateCommand)
                privateDeleteCommand = value
            End Set
        End Property
        Private privateCreateCommand As DelegateCommand
        Public Property CreateCommand() As DelegateCommand
            Get
                Return privateCreateCommand
            End Get
            Private Set(ByVal value As DelegateCommand)
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
                RaisePropertyChanged(Function() SelectedItem)
            End Set
        End Property

        Public Sub New()
            DeleteCommand = New DelegateCommand(AddressOf DeleteCurrentPerson, Function() _SelectedPerson IsNot Nothing)
            CreateCommand = New DelegateCommand(AddressOf CreatePerson, Function() True)
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
    End Class
End Namespace