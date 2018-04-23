Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Ribbon
Imports Fluent.Sample.Mvvm.ViewModels
Imports Fluent.Sample.Mvvm.Model
Imports DevExpress.Xpf.Bars

Namespace TestCommandBindings
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DXRibbonWindow
		Public Sub New()
			InitializeComponent()
			Dim model As New MainViewModel()
			DataContext = model
			AddHandler model.PersonCreated, AddressOf model_PersonCreated
			AddHandler model.PersonRemoved, AddressOf model_PersonRemoved
			AddHandler model.CurrentPersonChanged, AddressOf model_CurrentPersonChanged
			model.Init()
		End Sub

		Private Sub model_CurrentPersonChanged(ByVal sender As Object, ByVal e As PersonChangedEventArgs)
            If e._Person Is Nothing Then
                Return
            End If
            GetItemByPerson(e._Person).IsChecked = True
		End Sub
		Private Function GetItemByPerson(ByVal person As Person) As GalleryItem
			For Each item As GalleryItem In galleryPersons.Groups(0).Items
                If item.Caption Is person Then
                    Return item
                End If
			Next item
			Return Nothing
		End Function
		Private Sub model_PersonRemoved(ByVal sender As Object, ByVal e As PersonChangedEventArgs)
            galleryPersons.Groups(0).Items.Remove(GetItemByPerson(e._Person))
		End Sub

		Private Sub model_PersonCreated(ByVal sender As Object, ByVal e As PersonChangedEventArgs)
            galleryPersons.Groups(0).Items.Insert(0, New GalleryItem() With {.Caption = e._Person})
		End Sub

		Private Sub galleryPersons_ItemClick(ByVal sender As Object, ByVal e As GalleryItemEventArgs)
			CType(DataContext, MainViewModel).Current = CType(e.Item.Caption, Person)
		End Sub

		Private Sub itemPersons_DropDownGalleryInit(ByVal sender As Object, ByVal e As DropDownGalleryEventArgs)
			e.DropDownGallery.Gallery.ColCount = 4
			e.DropDownGallery.Gallery.IsGroupCaptionVisible = DevExpress.Utils.DefaultBoolean.False
			e.DropDownGallery.Gallery.AllowFilter = False
		End Sub
	End Class
End Namespace
