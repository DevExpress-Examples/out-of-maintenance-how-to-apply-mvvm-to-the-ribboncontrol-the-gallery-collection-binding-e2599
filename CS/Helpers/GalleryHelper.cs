using System.Windows;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Mvvm.UI.Interactivity;

namespace DXSample {
    public class GalleryHelper : Behavior<Gallery> {
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(GalleryHelper), new PropertyMetadata(null, OnSelectedItemPropertyChanged));

        private static void OnSelectedItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((GalleryHelper)d).OnSelectedItemChanged(e);
        }

        public Gallery Gallery { get { return AssociatedObject; } }
        public object SelectedItem {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.ItemChecked += AssociatedObject_ItemChecked;
        }

        void AssociatedObject_ItemChecked(object sender, GalleryItemEventArgs e) {
            UpdateSelectedItem(e.Item);
        }
        private void OnSelectedItemChanged(DependencyPropertyChangedEventArgs e) {
            CheckItem(SelectedItem);
        }
        private void UpdateSelectedItem(GalleryItem galleryItem) {
            SelectedItem = galleryItem.DataContext;
        }
        private void CheckItem(object viewModel) {
            foreach (var group in Gallery.Groups)
                foreach (var item in group.Items)
                    if (item.DataContext == viewModel)
                        item.IsChecked = true;
        }
    }
}