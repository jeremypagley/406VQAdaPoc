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
        private int returnTime;

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

        public int ReturnTime
        {
            get
            {
                return returnTime;
            }
            set
            {
                Set<int>(() => this.ReturnTime, ref returnTime, value);
            }
        }

        public static ObservableCollection<Attraction> GetSampleAttractions()
        {
            ObservableCollection<Attraction> attractions = new ObservableCollection<Attraction>();
            attractions
                .Add(new Attraction
                {
                    id = "krakatau",
                    Script = "this is a Kraktau script",
                    ReturnTime = 59
                });
            attractions.Add(new Attraction
                {
                    id = "honu",
                    Script = "this is a script for the Honu second one",
                    ReturnTime = 40
                });

            return attractions;
        }
    }
}
