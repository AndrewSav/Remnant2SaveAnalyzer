using Remnant2SaveAnalyzer.locales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using lib.remnant2.analyzer.Model;
using Wpf.Ui.Controls;
using System.Diagnostics.CodeAnalysis;
using lib.remnant2.analyzer;
using Clipboard = System.Windows.Clipboard;
using Remnant2SaveAnalyzer.Logging;

namespace Remnant2SaveAnalyzer.Views.Pages;

/// <summary>
/// Interaction logic for WorldAnalyzerPage.xaml
/// </summary>
public partial class WorldAnalyzerPage : INavigableView<ViewModels.WorldAnalyzerViewModel> //, INotifyPropertyChanged
{
    public WorldAnalyzerPage(ViewModels.WorldAnalyzerViewModel viewModel) : this(viewModel, null)
    {

    }

    public ViewModels.WorldAnalyzerViewModel ViewModel
    {
        get;
    }

    public WorldAnalyzerPage(ViewModels.WorldAnalyzerViewModel viewModel, string? pathToSaveFiles = null)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}