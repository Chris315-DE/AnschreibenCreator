using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CkWPF.MvvmBase
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        private double _MinimumWidth;
        private double _MinumumHeight;
        public event PropertyChangedEventHandler? PropertyChanged;
        public Action<BaseViewModel>? IsReady;


        public double MinimumWidth
        {
            get => _MinimumWidth;
            set
            {
                if (_MinimumWidth != value)
                {
                    _MinimumWidth = value;
                    RaisPropertyChanged(nameof(MinimumWidth));
                }
            }
        }


        public double MinimumHeight
        {
            get => _MinumumHeight;
            set
            {
                if (value != _MinumumHeight)
                {
                    _MinumumHeight = value;
                    RaisPropertyChanged(nameof(MinimumHeight));
                }
            }
        }


        protected virtual void RaisPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void WsM_WindowStateChanged(WindowState obj)
        {
            if (obj == WindowState.Maximized)
            {

            }
        }


        public void RaisIsReady(BaseViewModel model)
        {
            IsReady?.Invoke(model);
        }




    }
}
