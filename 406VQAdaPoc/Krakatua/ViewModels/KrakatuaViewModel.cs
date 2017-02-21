using _406VQAdaPoc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Speech.Synthesis;
using GalaSoft.MvvmLight.Messaging;

namespace _406VQAdaPoc.Krakatua.ViewModels
{
    public class KrakatuaViewModel : ViewModelBase
    {
        private ObservableCollection<Attraction> attractions;
        private Attraction selectedAttraction;

        public KrakatuaViewModel()
        {
            Messenger.Default.Register<SelectAttraction>(this, (action) => SelectAttractionMethod());
        }

        private void SelectAttractionMethod()
        {
            attractions = Attraction.GetSampleAttractions();
            
            //TODO: Use message from the messenger here to select proper attraction
            var attractionOne = attractions[0];

            selectedAttraction = attractionOne;

            ReadScript();

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
