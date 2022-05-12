using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HSLInClass.View; 

namespace HSLInClass
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SimpleColorSelectorPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
