using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices; 

namespace Project3.ViewModels
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string Contac=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Contac)); 
        }
    }
}
