using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Database.Minden
{
    public class Emberek : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }

        private string nev;
        public string Nev
        {
            get { return nev; }
            set
            {
                nev = value;
                OnPropertyChanged();
            }
        }

        private string kor;
        public string Kor
        {
            get { return kor; }
            set
            {
                kor = value;
                OnPropertyChanged();
            }
        }

        private string varos;
        public string Varos
        {
            get { return varos; }
            set
            {
                varos = value;
                OnPropertyChanged();
            }
        }

        private string melo;
        public string Melo
        {
            get { return melo; }
            set
            {
                melo = value;
                OnPropertyChanged();
            }
        }

        private string hobbi;
        public string Hobbi
        {
            get { return hobbi; }
            set
            {
                hobbi = value;
                OnPropertyChanged();
            }
        }

        public Emberek()
        {
            Id = 0;
        }

        public Emberek(string nev, string kor, string varos, string melo, string hobbi)
        {
            Nev = nev;
            Kor = kor;
            Varos = varos;
            Melo = melo;
            Hobbi = hobbi;
        }

        public Emberek(string sor)
        {
            string[] t = sor.Split(';');
            Nev = t[0];
            Kor = t[1];
            Varos = t[2];
            Melo = t[3];
            Hobbi = t[4];
        }

        public override string? ToString()
        {
            return $"{Nev}, neve a(z)ebben a  {Varos} városban lakik, és ezt {Melo}-za ,ennyi {Kor} éves,és a hobbija: {Hobbi}.";
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}