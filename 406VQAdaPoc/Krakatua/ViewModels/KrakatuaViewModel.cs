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
        private Attraction attraction;
        private Attraction selectedAttraction;

        public KrakatuaViewModel()
        {
            Messenger.Default.Register<SelectAttraction>(this, SelectAttractionMethod);
        }

        private void SelectAttractionMethod(SelectAttraction msg)
        {
            var ID = msg.ID;

            selectedAttraction = Attraction.GetSampleAttraction(ID);

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
