using System;
using System.Windows;
using System.Windows.Input;

namespace Molesley
{
  public class NotifyIconViewModel
  {
    public ICommand ExitCommand
    {
      get
      {
        return new DelegateCommand { CommandAction = () => Application.Current.Shutdown() };
      }
    }

    public class DelegateCommand : ICommand
    {
      public Action CommandAction { get; set; }

      public bool CanExecute(object parameter)
      {
        return true;
      }

      public void Execute(object parameter)
      {
        CommandAction();
      }

      public event EventHandler CanExecuteChanged;
    }
  }
}
