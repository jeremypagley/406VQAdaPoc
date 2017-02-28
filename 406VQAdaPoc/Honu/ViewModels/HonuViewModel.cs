using _406VQAdaPoc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Speech.Synthesis;
using GalaSoft.MvvmLight.Messaging;

namespace _406VQAdaPoc.Honu.ViewModels
{
    public class HonuViewModel : ViewModelBase
    {
        private Attraction selectedAttraction;
        private readonly ReadScript readScript;

        public HonuViewModel()
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

            if (ID == Properties.Resources.Honu)
            {
                selectedAttraction = Attraction.GetSampleAttraction(ID);

                readScript.Read(selectedAttraction.Script);
            }
        }
    }
}
