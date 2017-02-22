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

        /// <summary>
        ///     Fake microservice call to get attractions
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Attraction</returns>
        public static Attraction GetSampleAttraction(string ID)
        {
            ObservableCollection<Attraction> attractions = new ObservableCollection<Attraction>();

            // Get current minutes of day to use in scripts & fake attractions
            var curMin = DateTime.Now.Minute.ToString();

            // Fake attraction scripts, these should be retrieved from microservices
            string krakatauScript = String.Format("Home Screen. Use this kiosk to get a return time for Krakatau. The return time is currently {0} minutes. This oval-shaped kiosk includes a rectangular touchscreen and a TapuTapu wearable reader beneath it. Hold your TapuTapu wearable wristband against the reader to get a return time. The reader is about four inches wide and has a raised patterned surface.", curMin);
            string honuScript = String.Format("Home Screen. Use this kiosk to get a return time for Honu. The return time is currently {0} minutes. This oval-shaped kiosk includes a rectangular touchscreen and a TapuTapu wearable reader beneath it. Hold your TapuTapu wearable wristband against the reader to get a return time. The reader is about four inches wide and has a raised patterned surface.", curMin);

            // Fake attractions that would be returned from a fake microservice
            attractions
                .Add(new Attraction
                {
                    ID = Properties.Resources.Krakatau,
                    Script = krakatauScript,
                    ReturnTime = curMin
                });
            attractions.Add(new Attraction
            {
                ID = Properties.Resources.Honu,
                Script = honuScript,
                ReturnTime = curMin
            });

            // Get attraction by ID in fake attractions collection
            var attraction = attractions.Where(attr => attr.ID == ID).FirstOrDefault();

            return attraction;
        }
    }
}
