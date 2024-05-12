using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Remnant2SaveAnalyzer.Logging;
using Wpf.Ui.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;

namespace Remnant2SaveAnalyzer.Views.Pages;

/// <summary>
/// Interaction logic for BackupsPage.xaml
/// </summary>
public partial class BackupsPage : INavigableView<ViewModels.BackupsViewModel>
{
    public ViewModels.BackupsViewModel ViewModel
    {
        get;
    }

    public BackupsPage(ViewModels.BackupsViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}

public class BackupSaveViewedEventArgs(SaveBackup saveBackup) : EventArgs
{
    public SaveBackup SaveBackup { get; set; } = saveBackup;
}

public class LocalizedColumnHeader(string key)
{
    public string Key => key;

    public string Name => Loc.T(key);

    public override string ToString()
    {
        return Name;
    }
}