<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2599)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GalleryHelper.cs](./CS/Helpers/GalleryHelper.cs) (VB: [GalleryHelper.vb](./VB/Helpers/GalleryHelper.vb))
* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [Person.cs](./CS/Model/Person.cs) (VB: [Person.vb](./VB/Model/Person.vb))
* [PersonCollection.cs](./CS/Model/PersonCollection.cs) (VB: [PersonCollection.vb](./VB/Model/PersonCollection.vb))
* [MainViewModel.cs](./CS/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/ViewModel/MainViewModel.vb))
<!-- default file list end -->
# How to apply MVVM to the RibbonControl (the gallery collection binding)


<p>In the v10.1 version, our galleries cannot be bound to any collection, and a gallery item itself does not provide a way to execute a command. <br />
The gallery is a complex element, and it spends time to create these two new features (<a href="https://www.devexpress.com/Support/Center/p/S35347">S35347</a> and <a href="https://www.devexpress.com/Support/Center/p/S35982">Provide a way to apply a command for the GalleryBarItem </a>). As a solution, we suggest you use commands and add <br />
gallery items manually via the commands. Handle the gallery item ItemClick to imitate the command functionality.</p>

<br/>


