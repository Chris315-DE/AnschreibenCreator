using CkWPF.Base.MvvmBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnschreibenCreator.Lib.Contracts
{
    public interface IPageNavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModel { get; }
        static IPageNavigator Instance { get; }
    }

}
