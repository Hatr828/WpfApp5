using System;
using System.ComponentModel;

namespace TemperatureConverter.Models
{
    public class TemperatureModel
    {
        private double _celsius;

        public double Celsius
        {
            get { return _celsius; }
            set
            {
                _celsius = value;
                OnPropertyChanged(nameof(Celsius));
            }
        }

        public double Fahrenheit => _celsius * 9 / 5 + 32;

        public double Kelvin => _celsius + 273.15;

        public event EventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
