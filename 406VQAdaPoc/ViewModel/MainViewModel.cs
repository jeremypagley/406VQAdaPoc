using _406VQAdaPoc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Speech.Synthesis;

namespace _406VQAdaPoc.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Attraction> attractions;
        private Attraction selectedAttraction;

        public MainViewModel()
        {
            SelectAttractionCommand = new RelayCommand(SelectAttractionMethod);
        }

        public ICommand SelectAttractionCommand { get; private set; }

        public Attraction SelectedAttraction
        {
            get
            {
                return selectedAttraction;
            }
            set
            {
                selectedAttraction = value;
                RaisePropertyChanged("SelectedAttraction");
            }
        }

        private void SelectAttractionMethod()
        {
            attractions = Attraction.GetSampleAttractions();

            // Should be handled differently but this is just a POC
            var attractionOne = attractions[0];
            var attractionTwo = attractions[1];

            if (selectedAttraction != null)
            {
                selectedAttraction = (selectedAttraction.ID.Equals(attractionOne.ID)) ? attractionTwo : attractionOne;
            }
            else
            {
                selectedAttraction = attractionOne;
            }

            ReadScript();

            this.RaisePropertyChanged(() => this.SelectedAttraction);
        }

        private void ReadScript()
        {
            SpeechSynthesizer speechSynth = new SpeechSynthesizer();

            if (selectedAttraction != null)
            {
                speechSynth.SpeakAsync(selectedAttraction.Script);
            }
        }

    }
}