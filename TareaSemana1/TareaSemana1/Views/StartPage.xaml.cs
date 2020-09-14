using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSemana1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void btnPlay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Preferences.ContainsKey("nombre"))
                cmpNombre.Text = Preferences.Get("nombre", "0").ToString();
            if (Preferences.ContainsKey("ciudad"))
                cmpCiudad.Text = Preferences.Get("ciudad", "0").ToString();
            if (Preferences.ContainsKey("saldo"))
                cmpSaldo.Text = Preferences.Get("saldo", "0").ToString();

        }

        protected override void OnDisappearing()
        {   
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("nombre", cmpNombre.Text);
            Preferences.Set("ciudad", cmpCiudad.Text);
            Preferences.Set("saldo", cmpSaldo.Text);
        }
    }
}