using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DesktopApp.Persist
{
    class Logged
    {
        public static Logged Instance => _instance ?? (_instance = new Logged());

        public event EventHandler Changed;

        public bool LoggedState
        {
            get { return _state; }
            set
            {
                _state = value;
                OnChanged();
            }
        }

        public Rozhodci PersonR { get; set; }

        public Hraci PersonH { get; set; }

        public PrezidentKlubu PersonP { get; set; }

        private static Logged _instance;

        private bool _state;

        private Logged() { }

        private void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}
