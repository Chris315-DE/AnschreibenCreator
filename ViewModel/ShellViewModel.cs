using AnschreibenCreator.WPF.Commands;
using AnschreibenCreator.WPF.Contracts;
using AnschreibenCreator.WPF.Manager;
using CkWPF.Base.MvvmBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnschreibenCreator.WPF.ViewModel
{
    public class ShellViewModel : BaseViewModel
    {
        #region private fields

        private Window _Window;
        private int _outerMarginSize = 10;
        private int _WindowRadius = 10;

        #endregion

        #region Commands 
        public DelegateCommand MenuCommand { get; set; }
        public DelegateCommand MinimizeCommand { get; set; }
        public DelegateCommand MaximizeCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        public UpdateCurrentViewModelCommand UpdateCommand { get; set; }

        #endregion


        #region Propertys 

        public int ResizeBorder { get; set; } = 6;
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        public int OuterMarginSize
        {
            get => _Window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;

            set => _outerMarginSize = value;
        }
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);
        public Thickness InnerContentPadding => new Thickness(ResizeBorder);

        public int WindowRadius => _Window.WindowState == WindowState.Maximized ? 0 : _WindowRadius;

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public int TitleHeight { get; set; } = 42;

        public GridLength TitelHeightGrid => new GridLength(TitleHeight + ResizeBorder);

        public double WindowMinimumWidth { get; set; } = 1200;
        public double WindowMinimumHeight { get; set; } = 700;

        public IPageNavigator Navigator { get; }

        #endregion

        #region Helperfunktionen
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_Window);
            if (_Window.WindowState == WindowState.Maximized)
            {
                return new Point(position.X, position.Y);
            }
            // Position of the mouse relative to the window

            // Add the window position
            return new Point(position.X + _Window.Left, position.Y + _Window.Top);

        }

        #endregion

        #region Ctor
        public ShellViewModel(Window window)
        {
            Navigator = NavigationManager.Instance;
            Navigator.CurrentViewModel  = BriefKopfViewModel.Instance;
           

            UpdateCommand = new(Navigator);


            _Window = window;
            _Window.StateChanged += (sender, e) =>
            {
                RaisPropertyChanged(nameof(ResizeBorder));
                RaisPropertyChanged(nameof(ResizeBorderThickness));
                RaisPropertyChanged(nameof(OuterMarginSize));
                RaisPropertyChanged(nameof(OuterMarginSizeThickness));
                RaisPropertyChanged(nameof(WindowRadius));
                RaisPropertyChanged(nameof(WindowCornerRadius));
                RaisPropertyChanged(nameof(InnerContentPadding));
            };





            MenuCommand = new DelegateCommand((o) => SystemCommands.ShowSystemMenu(_Window, GetMousePosition()));
            MinimizeCommand = new DelegateCommand((o) => _Window.WindowState = WindowState.Minimized);
            MaximizeCommand = new DelegateCommand((o) => _Window.WindowState ^= WindowState.Maximized);
            CloseCommand = new DelegateCommand(o => _Window.Close());
        }

        #endregion



    }
}


  


