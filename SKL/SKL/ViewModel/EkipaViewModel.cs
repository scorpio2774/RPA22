using SKL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SKL.ViewModel
{
    class EkipaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ObservableCollection<IgralecViewModel> Starters { get; set; }
        public ObservableCollection<IgralecViewModel> Klop { get; set; }
        private string imeEkipe;
        public string ImeEkipe {
            get { return imeEkipe; }
            set
            {
                imeEkipe = value;
                this.OnPropertyChanged();
            }
        }
        private Ekipa ekipa;
        public EkipaViewModel(Ekipa e)
        {
            ekipa = e;
            Starters = new ObservableCollection<IgralecViewModel>();
            Klop = new ObservableCollection<IgralecViewModel>();
            ImeEkipe = e.ImeEkipe;
            PosodobiEkipe();
        }
        public void PosodobiEkipe()
        {
            var začetni = from x in ekipa.Igralci
                          where x.Starter == true
                          select x;
            Starters.Clear();
            foreach(var a in začetni)
            {
                IgralecViewModel b = new IgralecViewModel(a.Ime, a.Številka);
                Starters.Add(b);
            }

            var klop = from x in ekipa.Igralci
                          where x.Starter == false
                          select x;
            Klop.Clear();
            foreach (var a in klop)
            {
                IgralecViewModel b = new IgralecViewModel(a.Ime, a.Številka);
                Klop.Add(b);
            }
        }
    }
}
