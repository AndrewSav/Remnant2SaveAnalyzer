using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Reactive;
using System.Reflection;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using Remnant2SaveAnalyzer.Models;
using System.Collections.Generic;
using System.Globalization;

namespace Remnant2SaveAnalyzer.ViewModels;

public class SettingsViewModel : ReactiveObject, INavigationAware
{
    private bool _isInitialized;

    public ReactiveCommand<Unit, Unit>? CheckUpdateCommand { get; set; }
    public ReactiveCommand<ApplicationTheme, Unit>? ChangeThemeCommand { get; set; }

    public string AppVersion { get; } = GetAssemblyVersion();

    public List<CultureInfo> Languages
    {
        get => (App.Current.Properties["langs"] as List<CultureInfo>)!;
    }

    public List<ComboBoxModel> Wikis { get; } = [
        new ComboBoxModel { Name = Loc.T("Fextralife"), Tag = "fextrawiki" },
        new ComboBoxModel { Name = Loc.T("RemnantWiki"), Tag = "remwiki" }
    ];

    public List<ComboBoxModel> StartPages { get; } = [
        new ComboBoxModel { Name = Loc.T("Save Backups"), Tag = "backups" },
        new ComboBoxModel { Name = Loc.T("World Analyzer"), Tag = "world-analyzer" }
    ];

    public List<ComboBoxModel> MissingItemColors { get; } = [
        new ComboBoxModel { Name = Loc.T("Text_Normal"), Tag = "Normal" },
        new ComboBoxModel { Name = Loc.T("Text_Highlight"), Tag = "Highlight" }
    ];

    public List<ComboBoxModel> UnobtainableItemColors { get; } = [
        new ComboBoxModel { Name = Loc.T("Text_Normal"), Tag = "Normal" },
        new ComboBoxModel { Name = Loc.T("Text_Dim"), Tag = "Dim" }
    ];

    public List<ComboBoxModel> NoPrerequisiteItemColors { get; } = [
        new ComboBoxModel { Name = Loc.T("Text_Normal"), Tag = "Normal" },
        new ComboBoxModel { Name = Loc.T("Text_Italic"), Tag = "Italic" }
    ];

    public List<ComboBoxModel> LogLevels { get; } = [
        new ComboBoxModel { Name = Loc.T("Text_Verbose"), Tag = "Verbose" },
        new ComboBoxModel { Name = Loc.T("Text_Debug"), Tag = "Debug" },
        new ComboBoxModel { Name = Loc.T("Text_Information"), Tag = "Information" },
        new ComboBoxModel { Name = Loc.T("Text_Warning"), Tag = "Warning" },
        new ComboBoxModel { Name = Loc.T("Text_Error"), Tag = "Error" },
        new ComboBoxModel { Name = Loc.T("Text_Fatal"), Tag = "Fatal" }
    ];

    public void OnNavigatedTo()
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    public void OnNavigatedFrom()
    {
    }

    private void InitializeViewModel()
    {
        _isInitialized = true;
        CheckUpdateCommand = ReactiveCommand.Create(CheckUpdate);
        ChangeThemeCommand = ReactiveCommand.Create<ApplicationTheme>(ChangeTheme);
    }

    private static string GetAssemblyVersion()
    {
        return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
    }

    private void CheckUpdate()
    {
        // TODO
    }

    private void ChangeTheme(ApplicationTheme theme)
    {
        ApplicationThemeManager.Apply(theme);
    }
}