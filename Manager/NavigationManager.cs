using AnschreibenCreator.Lib.Contracts;
using CkWPF.Base.MvvmBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnschreibenCreator.Lib.Manager
{
    public class NavigationManager : IPageNavigator, INotifyPropertyChanged
    {

        private BaseViewModel _viewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _viewModel;
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value;
                    OnPropertyChanged();
                }
            }
        }



        private static IPageNavigator _instance = null!;

        public static IPageNavigator Instance => _instance ?? (_instance = new NavigationManager());


        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public ICommand UpdateCurrentViewModel => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
