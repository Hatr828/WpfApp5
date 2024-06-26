using System;
using System.ComponentModel;
using System.Windows.Input;
using TemperatureConverter.Models;
using WpfApp.Command;

namespace TemperatureConverter.ViewModels
{
    public class TemperatureViewModel : INotifyPropertyChanged
    {
        private TemperatureModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ConvertCommand { get; }

        public TemperatureViewModel()
        {
            _model = new TemperatureModel();
            ConvertCommand = new RelayCommand(Convert);
        }

        public double Celsius
        {
            get { return _model.Celsius; }
            set
            {
                _model.Celsius = value;
                OnPropertyChanged(nameof(Celsius));
                OnPropertyChanged(nameof(Fahrenheit));
                OnPropertyChanged(nameof(Kelvin));
            }
        }

        public double Fahrenheit => _model.Fahrenheit;

        public double Kelvin => _model.Kelvin;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Convert()
        {
            OnPropertyChanged(nameof(Fahrenheit));
            OnPropertyChanged(nameof(Kelvin));
        }
    }
}
