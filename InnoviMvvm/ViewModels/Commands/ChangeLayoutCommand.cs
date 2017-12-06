using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InnoviMvvm.ViewModels.Commands
{
   public class ChangeLayoutCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public MainViewModel LocalMainViewModel { get; set; }

        public ChangeLayoutCommand(MainViewModel MainViewModel)
        {
            this.LocalMainViewModel = MainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.LocalMainViewModel.ChangeView();
        }
    }
}
