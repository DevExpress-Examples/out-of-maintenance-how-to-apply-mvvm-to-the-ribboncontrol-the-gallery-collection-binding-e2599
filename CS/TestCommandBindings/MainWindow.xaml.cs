using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Ribbon;
using Fluent.Sample.Mvvm.ViewModels;
using Fluent.Sample.Mvvm.Model;
using DevExpress.Xpf.Bars;

namespace TestCommandBindings {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow {
        public MainWindow() {
            InitializeComponent();
            MainViewModel model = new MainViewModel();
            DataContext = model;
            model.PersonCreated += new PersonChangedEventHandler(model_PersonCreated);
            model.PersonRemoved += new PersonChangedEventHandler(model_PersonRemoved);
            model.CurrentPersonChanged += new PersonChangedEventHandler(model_CurrentPersonChanged);
            model.Init();
        }

        void model_CurrentPersonChanged(object sender, PersonChangedEventArgs e) {
            if(e.Person == null) return;
            GetItemByPerson(e.Person).IsChecked = true;
        }
        GalleryItem GetItemByPerson(Person person) {
            foreach(GalleryItem item in galleryPersons.Groups[0].Items) {
                if(item.Caption == person) return item;
            }
            return null;
        }
        void model_PersonRemoved(object sender, PersonChangedEventArgs e) {
            galleryPersons.Groups[0].Items.Remove(GetItemByPerson(e.Person));
        }

        void model_PersonCreated(object sender, PersonChangedEventArgs e) {
            galleryPersons.Groups[0].Items.Insert(0, new GalleryItem() { Caption = e.Person });
        }

        private void galleryPersons_ItemClick(object sender, GalleryItemEventArgs e) {
            ((MainViewModel)DataContext).Current = (Person)e.Item.Caption;
        }

        private void itemPersons_DropDownGalleryInit(object sender, DropDownGalleryEventArgs e) {
            e.DropDownGallery.Gallery.ColCount = 4;
            e.DropDownGallery.Gallery.IsGroupCaptionVisible = DevExpress.Utils.DefaultBoolean.False;
            e.DropDownGallery.Gallery.AllowFilter = false;            
        }
    }
}
