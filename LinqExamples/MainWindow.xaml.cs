using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LinqExamples;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // show home page content on start up
        GoToHomePage();
    }

    private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var item = (TreeViewItem)sender;
        string tag = item.Tag.ToString();

        mainContentFrame.NavigationService.Navigate(new Uri($"Pages/{tag}.xaml", UriKind.Relative));
    }

    private void btnNext(object sender, RoutedEventArgs e)
    {
        if (mainContentFrame.NavigationService.CanGoForward)
            mainContentFrame.NavigationService.GoForward();
        else
            GoToHomePage();
    }

    private void btnPrevious(object sender, RoutedEventArgs e)
    {
        if (mainContentFrame.NavigationService.CanGoBack)
            mainContentFrame.NavigationService.GoBack();
        else
            GoToHomePage();
    }

    void GoToHomePage() => 
        mainContentFrame.NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));

}
