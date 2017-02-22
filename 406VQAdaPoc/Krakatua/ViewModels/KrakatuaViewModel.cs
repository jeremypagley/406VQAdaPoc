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
        private Attraction selectedAttraction;
        private readonly ReadScript readScript;

        public KrakatuaViewModel()
        {
            Messenger.Default.Register<SelectAttraction>(this, SelectAttractionMethod);
            readScript = new ReadScript();
        }

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

        private void SelectAttractionMethod(SelectAttraction attraction)
        {
            var ID = attraction.ID;

            if (ID == Properties.Resources.Krakatau)
            {
                selectedAttraction = Attraction.GetSampleAttraction(ID);

                readScript.Read(selectedAttraction.Script);
            }
        }
    }
}
