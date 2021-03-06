using _406VQAdaPoc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Speech.Synthesis;
using _406VQAdaPoc.Krakatua.ViewModels;
using _406VQAdaPoc.Honu.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace _406VQAdaPoc.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        // Attractions view models
        readonly static KrakatuaViewModel _krakatuaViewModel = new KrakatuaViewModel();
        readonly static HonuViewModel _honuViewModel = new HonuViewModel();

        /// <summary>
        /// Manage setting or getting current view model
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                {
                    return;
                }
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        // Interfaces for the bound view commands from attractions views
        public ICommand KrakatuaViewCommand { get; private set; }
        public ICommand HonuViewCommand { get; private set; }

        public MainViewModel()
        {
            // Bound view switching commands from views
            KrakatuaViewCommand = new RelayCommand(() => ExecuteKrakatuaViewCommand());
            HonuViewCommand = new RelayCommand(() => ExecuteHonuViewCommand());

            // Set a default current View/ViewModel and hydrate the view model
            CurrentViewModel = MainViewModel._krakatuaViewModel;
            ExecuteKrakatuaViewCommand();
        }

        private void ExecuteKrakatuaViewCommand()
        {
            CurrentViewModel = MainViewModel._krakatuaViewModel;

            var attraction = new SelectAttraction() { ID = Properties.Resources.Krakatau };
            Messenger.Default.Send<SelectAttraction>(attraction);
        }

        private void ExecuteHonuViewCommand()
        {
            CurrentViewModel = MainViewModel._honuViewModel;

            var attraction = new SelectAttraction() { ID = Properties.Resources.Honu };
            Messenger.Default.Send<SelectAttraction>(attraction);
        }
    }
}