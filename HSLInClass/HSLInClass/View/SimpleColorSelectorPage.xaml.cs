using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSLInClass.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleColorSelectorPage : ContentPage
    {
        public SimpleColorSelectorPage()
        {
            InitializeComponent();
        }
    }
}