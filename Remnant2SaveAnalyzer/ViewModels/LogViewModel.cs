﻿using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Common.Interfaces;

namespace Remnant2SaveAnalyzer.ViewModels;

public class LogViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized;

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
        }
}