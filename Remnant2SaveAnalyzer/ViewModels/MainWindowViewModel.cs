using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace Remnant2SaveAnalyzer.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private bool _isInitialized;

    [ObservableProperty]
    private string _applicationTitle = string.Empty;

    [ObservableProperty]
    private ObservableCollection<NavigationViewItem> _navigationItems = [];

    [ObservableProperty]
    private ObservableCollection<NavigationViewItem> _navigationFooter = [];

    [ObservableProperty]
    private ObservableCollection<MenuItem> _trayMenuItems = [];

    public MainWindowViewModel()
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    private void InitializeViewModel()
    {
        ApplicationTitle = "Remnant 2 Save Analyzer";

        NavigationItems =
        [
            new NavigationViewItem
            {
                Content = Loc.T("Save Backups"),
                ToolTip = Loc.T("Save Backups"),
                Tag = "backups",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Database24 },
                TargetPageType = typeof(Views.Pages.BackupsPage)
            },
            new NavigationViewItem
            {
                Content = Loc.T("World Analyzer"),
                ToolTip = Loc.T("World Analyzer"),
                Tag = "world-analyzer",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Globe24 },
                TargetPageType = typeof(Views.Pages.WorldAnalyzerPage)
            }
        ];

        NavigationFooter =
        [
            new NavigationViewItem
            {
                Content = Loc.T("Log"),
                ToolTip = Loc.T("Log"),
                Tag = "log",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Notebook24 },
                TargetPageType = typeof(Views.Pages.LogPage)
            },
            new NavigationViewItem
            {
                Content = Loc.T("Settings"),
                ToolTip = Loc.T("Settings"),
                Tag = "settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        ];

        TrayMenuItems =
        [
            new() {
                Header = Loc.T("Home"),
                Tag = "tray_home"
            }
        ];

        _isInitialized = true;
    }
}