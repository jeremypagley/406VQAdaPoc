using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _406VQAdaPoc.Model
{
    public class Attraction : ObservableObject
    {
        private string id;
        private string script;
        private string returnTime;

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                Set<string>(() => this.ID, ref id, value);
            }
        }

        public string Script
        {
            get
            {
                return script;
            }
            set
            {
                Set<string>(() => this.Script, ref script, value);
            }
        }

        public string ReturnTime
        {
            get
            {
                return returnTime;
            }
            set
            {
                Set<string>(() => this.ReturnTime, ref returnTime, value);
            }
        }

        public static ObservableCollection<Attraction> GetSampleAttractions()
        {
            ObservableCollection<Attraction> attractions = new ObservableCollection<Attraction>();
            var curMin = DateTime.Now.Minute.ToString();

            string krakatauScript = String.Format("Home Screen. Use this kiosk to get a return time for Krakatau. The return time is currently {0} minutes. This oval-shaped kiosk includes a rectangular touchscreen and a TapuTapu wearable reader beneath it. Hold your TapuTapu wearable wristband against the reader to get a return time. The reader is about four inches wide and has a raised patterned surface.", curMin);
            string honuScript = String.Format("Home Screen. Use this kiosk to get a return time for Honu. The return time is currently {0} minutes. This oval-shaped kiosk includes a rectangular touchscreen and a TapuTapu wearable reader beneath it. Hold your TapuTapu wearable wristband against the reader to get a return time. The reader is about four inches wide and has a raised patterned surface.", curMin);

            attractions
                .Add(new Attraction
                {
                    id = "krakatau",
                    Script = krakatauScript,
                    ReturnTime = curMin
                });
            attractions.Add(new Attraction
                {
                    id = "honu",
                    Script = honuScript,
                    ReturnTime = curMin
                });

            return attractions;
        }
    }
}
