using System;
using System.Collections.Generic;
using System.Text;
using Project3.ViewModels;
using Xamarin.Forms;
using HSLInClass.Models; 

namespace HSLInClass.ViewModels
{
    public class HslColorViewModel: ViewModelBase
    {
        private Color color; 
        private string name; 

        public string HueValue { set; get; }
        public  double Hue
        {
            set
            {
                HueValue = $"{value * 360:F0}";
                OnPropertyChanged("HueValue"); 
                if(color.Hue != value)
                {
                    Color = Color.FromHsla(value, color.Saturation, color.Luminosity); 
                }
            }
            get => color.Hue;
        }
        public string SaturationValue { set; get; }
        public double Saturation
        {
            set
            {
                SaturationValue = $"{value * 100:F0}";
                OnPropertyChanged("SaturationValue");
                if (color.Saturation != value)
                {
                    Color = Color.FromHsla(color.Hue, value, color.Luminosity);
                }
            }
            get => color.Saturation;
        }
        public string LuminosityValue { set; get; }
        public double Luminosity
        {
            set
            {
                LuminosityValue = $"{value * 100:F0}";
                OnPropertyChanged("LuminosityValue");
                if (color.Luminosity != value)
                {
                    Color = Color.FromHsla(color.Hue, color.Saturation, value);
                }
            }
            get => color.Luminosity;
        }

        public Color Color
        {
            set
            {
                if(color != value)
                {
                    color = value; 
                    OnPropertyChanged();

                    Name = NamedColor.GetNearestColorName(color); 
                }
            }
            get => color; 
        }
        public string Name
        {
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged(); 
                }
            }
            get => name; 
        }
    }
}
