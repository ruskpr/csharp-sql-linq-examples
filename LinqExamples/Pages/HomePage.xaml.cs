﻿using System.Diagnostics;
using System.Windows.Controls;
namespace LinqExamples.pages;

public partial class HomePage : Page
{
    public HomePage() => InitializeComponent();

    private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
        e.Handled = true;
    }
}
