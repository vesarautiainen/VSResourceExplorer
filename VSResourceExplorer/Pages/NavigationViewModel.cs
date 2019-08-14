using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VSResourceExplorer
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand FontsCommand { get; set; }
        public ICommand CustomFontsCommand { get; set; }
        public ICommand CustomXamlCommand { get; set; }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public NavigationViewModel()
        {
            FontsCommand = new BaseCommand(OpenFonts);
            CustomFontsCommand = new BaseCommand(OpenCustomFonts);
            CustomXamlCommand = new BaseCommand(OpenCustomXaml);
        }

        private void OpenFonts(object obj)
        {
            SelectedViewModel = new FontsPageModel();
        }
        private void OpenCustomFonts(object obj)
        {
            SelectedViewModel = new CustomFontsPageModel();
        }
        private void OpenCustomXaml(object obj)
        {
            SelectedViewModel = new CustomXamlPageModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    public class BaseCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}
