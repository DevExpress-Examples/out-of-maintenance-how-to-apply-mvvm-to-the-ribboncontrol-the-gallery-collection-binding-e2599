Imports System.Collections.ObjectModel

Namespace DXSample.Model

    Public Class PersonCollection
        Inherits ObservableCollection(Of Person)

        Public Shared Function Generate() As PersonCollection
            Dim persons As PersonCollection = New PersonCollection()
            persons.Add(New Person("Jane Lopes", "jane@lopes.com", "9 (679) 89086878"))
            persons.Add(New Person("Abel Tomas", "abel@tomas.com", "4 (456) 78797897"))
            persons.Add(New Person("Zig Perscot", "zig@perscot.com", "5 (568) 12489445"))
            persons.Add(New Person("John Verwolf", "john@verwolf.com", "3 (454) 851384294"))
            persons.Add(New Person("Denis Macdaff", "denis@macdaff.com", "9 (545) 454548489"))
            persons.Add(New Person("Luka Madock", "luka@madock.com", "9 (545) 454548489"))
            persons.Add(New Person("Mary Nickor", "mary@nickor.com", "9 (545) 454548489"))
            persons.Add(New Person("David Avel", "david@avel.com", "9 (545) 454548489"))
            persons.Add(New Person("Arnold Neferson", "arnold@eferson.com", "9 (545) 454548489"))
            persons.Add(New Person("Mike Anderson", "mike@anderson.com", "9 (545) 454548489"))
            Return persons
        End Function
    End Class
End Namespace
