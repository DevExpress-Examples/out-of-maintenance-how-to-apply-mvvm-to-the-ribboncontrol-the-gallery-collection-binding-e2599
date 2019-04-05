<!-- default file list -->
*Files to look at*:

* [RelayCommand.cs](./CS/TestCommandBindings/Comands/RelayCommand.cs) (VB: [RelayCommand.vb](./VB/TestCommandBindings/Comands/RelayCommand.vb))
* [MainWindow.xaml](./CS/TestCommandBindings/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/TestCommandBindings/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/TestCommandBindings/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/TestCommandBindings/MainWindow.xaml.vb))
* [Person.cs](./CS/TestCommandBindings/Model/Person.cs) (VB: [Person.vb](./VB/TestCommandBindings/Model/Person.vb))
* [PersonCollection.cs](./CS/TestCommandBindings/Model/PersonCollection.cs) (VB: [PersonCollection.vb](./VB/TestCommandBindings/Model/PersonCollection.vb))
* [PersonTemplate.xaml](./CS/TestCommandBindings/PersonTemplate.xaml) (VB: [PersonTemplate.xaml](./VB/TestCommandBindings/PersonTemplate.xaml))
* [MainViewModel.cs](./CS/TestCommandBindings/ViewModels/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/TestCommandBindings/ViewModels/MainViewModel.vb))
<!-- default file list end -->
# How to apply MVVM to the RibbonControl (the gallery collection binding)


<p>In the v10.1 version, our galleries cannot be bound to any collection, and a gallery item itself does not provide a way to execute a command. <br />
The gallery is a complex element, and it spends time to create these two new features (<a href="https://www.devexpress.com/Support/Center/p/S35347">S35347</a> and <a href="https://www.devexpress.com/Support/Center/p/S35982">Provide a way to apply a command for the GalleryBarItem </a>). As a solution, we suggest you use commands and add <br />
gallery items manually via the commands. Handle the gallery item ItemClick to imitate the command functionality.</p>

<br/>


