Imports Microsoft.VisualBasic
#Region "Copyright and License Information"

' Fluent Ribbon Control Suite
' http://fluent.codeplex.com/
' Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
' 
' Distributed under the terms of the Microsoft Public License (Ms-PL). 
' The license is available online http://fluent.codeplex.com/license

#End Region

Imports System.Collections.ObjectModel

Namespace Fluent.Sample.Mvvm.Model
	''' <summary>
	''' Represents collection of persons
	''' </summary>
	Public Class PersonCollection
		Inherits ObservableCollection(Of Person)
		''' <summary>
		''' Generates sample persons
		''' </summary>
		''' <returns></returns>
		Public Shared Function Generate() As PersonCollection
			Dim persons As New PersonCollection()
			persons.Add(Person.Create("Jane Lopes", "jane@lopes.com", "9 (679) 89086878", Nothing))
			persons.Add(Person.Create("Abel Tomas", "abel@tomas.com", "4 (456) 78797897", Nothing))
			persons.Add(Person.Create("Zig Perscot", "zig@perscot.com", "5 (568) 12489445", Nothing))
			persons.Add(Person.Create("John Verwolf", "john@verwolf.com", "3 (454) 851384294", Nothing))
			persons.Add(Person.Create("Denis Macdaff", "denis@macdaff.com", "9 (545) 454548489", Nothing))
			persons.Add(Person.Create("Luka Madock", "luka@madock.com", "9 (545) 454548489", Nothing))
			persons.Add(Person.Create("Mary Nickor", "mary@nickor.com", "9 (545) 454548489", Nothing))
			persons.Add(Person.Create("David Avel", "david@avel.com", "9 (545) 454548489", Nothing))
			persons.Add(Person.Create("Arnold Neferson", "arnold@eferson.com", "9 (545) 454548489", Nothing))
			persons.Add(Person.Create("Mike Anderson", "mike@anderson.com", "9 (545) 454548489", Nothing))
			Return persons
		End Function
	End Class
End Namespace
