using AnschreibenCreator.WPF.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnschreibenCreator.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private IPageNavigator _Navigator = null!;
        public bool CanExecute(object? parameter) => true;


        public UpdateCurrentViewModelCommand(IPageNavigator navigator)
        {
            _Navigator = navigator;
        }


        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }

        


}
