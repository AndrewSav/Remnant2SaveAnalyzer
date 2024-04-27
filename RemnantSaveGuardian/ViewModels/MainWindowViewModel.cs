﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;

namespace RemnantSaveGuardian.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized;

        [ObservableProperty]
        private string _applicationTitle = string.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        public MainWindowViewModel()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "Remnant Save Guardian";

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem
                {
                    Content = Loc.T("Save Backups"),
                    ToolTip = Loc.T("Save Backups"),
                    PageTag = "backups",
                    Icon = SymbolRegular.Database24,
                    PageType = typeof(Views.Pages.BackupsPage)
                },
                new NavigationItem
                {
                    Content = Loc.T("World Analyzer"),
                    ToolTip = Loc.T("World Analyzer"),
                    PageTag = "world-analyzer",
                    Icon = SymbolRegular.Globe24,
                    PageType = typeof(Views.Pages.WorldAnalyzerPage)
                }
            };

            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem
                {
                    Content = Loc.T("Log"),
                    ToolTip = Loc.T("Log"),
                    PageTag = "log",
                    Icon = SymbolRegular.Notebook24,
                    PageType = typeof(Views.Pages.LogPage)
                },
                new NavigationItem
                {
                    Content = Loc.T("Settings"),
                    ToolTip = Loc.T("Settings"),
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new() {
                    Header = Loc.T("Home"),
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }
    }
}
