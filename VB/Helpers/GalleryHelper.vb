Imports System.Windows
Imports DevExpress.Xpf.Bars
Imports DevExpress.Mvvm.UI.Interactivity

Namespace DXSample
    Public Class GalleryHelper
        Inherits Behavior(Of Gallery)

        Public Shared ReadOnly SelectedItemProperty As DependencyProperty = DependencyProperty.Register("SelectedItem", GetType(Object), GetType(GalleryHelper), New PropertyMetadata(Nothing, AddressOf OnSelectedItemPropertyChanged))

        Private Shared Sub OnSelectedItemPropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            CType(d, GalleryHelper).OnSelectedItemChanged(e)
        End Sub

        Public ReadOnly Property Gallery() As Gallery
            Get
                Return AssociatedObject
            End Get
        End Property
        Public Property SelectedItem() As Object
            Get
                Return DirectCast(GetValue(SelectedItemProperty), Object)
            End Get
            Set(ByVal value As Object)
                SetValue(SelectedItemProperty, value)
            End Set
        End Property

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AddHandler AssociatedObject.ItemChecked, AddressOf AssociatedObject_ItemChecked
        End Sub

        Private Sub AssociatedObject_ItemChecked(ByVal sender As Object, ByVal e As GalleryItemEventArgs)
            UpdateSelectedItem(e.Item)
        End Sub
        Private Sub OnSelectedItemChanged(ByVal e As DependencyPropertyChangedEventArgs)
            CheckItem(SelectedItem)
        End Sub
        Private Sub UpdateSelectedItem(ByVal galleryItem As GalleryItem)
            SelectedItem = galleryItem.DataContext
        End Sub
        Private Sub CheckItem(ByVal viewModel As Object)
            For Each group In Gallery.Groups
                For Each item In group.Items
                    If item.DataContext Is viewModel Then
                        item.IsChecked = True
                    End If
                Next item
            Next group
        End Sub
    End Class
End Namespace