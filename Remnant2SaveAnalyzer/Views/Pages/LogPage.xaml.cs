using System;
using System.Globalization;
using Remnant2SaveAnalyzer.Logging;
using Wpf.Ui.Controls;

namespace Remnant2SaveAnalyzer.Views.Pages;

/// <summary>
/// Interaction logic for LogView.xaml
/// </summary>
public partial class LogPage : INavigableView<ViewModels.LogViewModel>
{
    public ViewModels.LogViewModel ViewModel
    {
        get;
    }

    public LogPage(ViewModels.LogViewModel viewModel)
    {
            ViewModel = viewModel;

            DataContext = this;

            InitializeComponent();
            Notifications.MessageLogged += Logger_MessageLogged;
            foreach (LogMessage logMessage in Notifications.Messages)
            {
                AddMessage(logMessage.Text, logMessage.NotificationType);
            }
        }

    private void Logger_MessageLogged(object? sender, MessageLoggedEventArgs e)
    {
            AddMessage(e.Message.Text, e.Message.NotificationType);
        }

    private void AddMessage(string message, NotificationType notificationType)
    {
            Dispatcher.Invoke(delegate {
                InfoBar infoBar = new()
                {
                    Message = message,
                    IsOpen = true,
                    Title = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                };
                if (notificationType == NotificationType.Error)
                {
                    infoBar.Severity = InfoBarSeverity.Error;
                }
                if (notificationType == NotificationType.Warning)
                {
                    infoBar.Severity = InfoBarSeverity.Warning;
                }
                if (notificationType == NotificationType.Success)
                {
                    infoBar.Severity = InfoBarSeverity.Success;
                }
                infoBar.ContextMenu = new System.Windows.Controls.ContextMenu();
                MenuItem menuCopyMessage = new()
                {
                    Header = Loc.T("Copy"),
                    Icon = new SymbolIcon { Symbol = SymbolRegular.Copy24 }
                };
                menuCopyMessage.Click += (_, _) =>
                {
                    System.Windows.Clipboard.SetDataObject(message);
                };
                infoBar.ContextMenu.Items.Add(menuCopyMessage);
                stackLogs.Children.Insert(0, infoBar);
            });
        }
}