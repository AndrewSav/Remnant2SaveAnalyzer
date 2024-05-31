using ReactiveUI;
using Wpf.Ui.Controls;

namespace Remnant2SaveAnalyzer.ViewModels;

public class LogViewModel : ReactiveObject, INavigationAware
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