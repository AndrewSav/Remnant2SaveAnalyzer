using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Appearance;
using Remnant2SaveAnalyzer.Helpers;
using Remnant2SaveAnalyzer.Logging;
using System.Configuration;
using System.Windows.Input;

namespace Remnant2SaveAnalyzer.Views.Pages;

/// <summary>
/// Interaction logic for SettingsPage.xaml
/// </summary>
public partial class SettingsPage : INavigableView<ViewModels.SettingsViewModel>
{
    public ViewModels.SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage(ViewModels.SettingsViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}
