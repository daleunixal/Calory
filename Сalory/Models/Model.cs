using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Сalory.Annotations;

namespace Сalory.Models
{
    public class Model : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public DateTime DateTime = DateTime.Now;
        private double _calory;
        
        private NameEnergy _state;

        public NameEnergy State
        {
            get => _state;
            set
            {
                _state = value;
                UpdateEnergy(_state);
                OnPropertyChanged("State");
            }
        }

        public double Calory {
            get => _calory;
            set 
            {
                _calory = Math.Round(value, 2);
                OnPropertyChanged("Calory");
            } 
        }
        private double _fats;
        public double Fats {
            get => _fats;
            set
            {
                if(value<0) throw new InvalidOperationException("Число должно быть не отрицательным");
                _fats = Math.Round(value, 2);
                UpdateEnergy(_state);
                OnPropertyChanged("Fats");
            }
        }

        private double _carbs;
        public double Carbs
        {
            get => _carbs;
            set
            {
                if(value<0) throw new InvalidOperationException("Число должно быть не отрицательным");
                _carbs = Math.Round(value, 2);
                UpdateEnergy(_state);
                OnPropertyChanged("Carbs");
            }
        }

        private double _proteins;
        public double Proteins {
            get => _proteins;
            set
            {
                if(value<0) throw new InvalidOperationException("Число должно быть не отрицательным");
                _proteins = Math.Round(value, 2);
                UpdateEnergy(_state);
                OnPropertyChanged("Proteins");
            }
        }

        private void UpdateEnergy(NameEnergy State)
        {
            switch (State)
            {
                case NameEnergy.Calory: Calory = _carbs * 4 + _fats * 9 + _proteins * 4;
                    break;
                case NameEnergy.Joule: Calory = (_carbs * 4 + _fats * 9 + _proteins * 4)*4.1868;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(State), State, null);
            }
        } 
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}