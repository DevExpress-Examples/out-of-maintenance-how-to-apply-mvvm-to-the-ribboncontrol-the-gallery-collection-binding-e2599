using System;
using System.Windows.Input;

namespace DXSample {
    public class CustomCommand : ICommand {
        Action _executeMethod;
        Func<bool> _canExecuteMethod;
        public CustomCommand(Action executeMethod, Func<bool> canExecuteMethod) {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public bool CanExecute(object parameter) {
            return _canExecuteMethod();
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter) {
            _executeMethod();
        }
        public void CheckCanExecuteChanged() {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}