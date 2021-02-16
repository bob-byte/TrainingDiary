using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Painkiller.PresentationModels
{
    public class RelayCommand : ICommand
    {
        private Action<Object> execute;
        private Func<Object, Boolean> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<Object> execute, Func<Object, Boolean> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(Object parameter) =>
            canExecute == null || canExecute(parameter);

        public void Execute(Object parameter)
        {
            execute(parameter);
        }
    }
}
