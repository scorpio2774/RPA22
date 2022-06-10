using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace ModelMVM
{
    class MyViewModel : INotifyPropertyChanged
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
        public ObservableCollection<MojZapis> Zapisi { get; set; }
        public string Naslov { get; set; }
        private MojZapis trenutni;
        public MojZapis Trenutni { 
            get { return trenutni; }
            set { trenutni = value;
                this.OnPropertyChanged();
                NarediZeleno.RaiseCanExecuteChanged();
            } 
        }
        public DelegateCommand NarediZeleno { get; set; }
        public MyViewModel()
        {
            Zapisi = new ObservableCollection<MojZapis>();
            NarediZeleno = new DelegateCommand(
                (p) => { Trenutni.Barva = Windows.UI.Color.FromArgb(0, 255, 0, 0); },
                (p) => { return Trenutni != null; }
                );
            for (int i = 0; i < 10; i++)
            {
                Zapisi.Add(new MojZapis { Ime = i.ToString(), Barva = Windows.UI.Color.FromArgb(255,255,165,0) });
            }
            Naslov = "Moji zapiski";
            Trenutni = Zapisi.First();
            
        }
    }
}
