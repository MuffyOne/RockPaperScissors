using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainModule
{
    public class SimpleAsyncCommandWithParameter : ICommand
    {
        private readonly Action _preExecute;
        private readonly Func<object, Task> _execute;
        private readonly Action<Task> _postExecute;

        public SimpleAsyncCommandWithParameter(Action preExecute, Func<object, Task> execute, Action<Task> postExecute)
        {
            _preExecute = preExecute;
            _execute = execute;
            _postExecute = postExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            _preExecute();

            await _execute(parameter).ContinueWith((t) =>
            {
                _postExecute(t);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
