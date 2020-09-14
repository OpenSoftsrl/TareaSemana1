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
    public partial class PlayPage : ContentPage
    {
        int _saldo = 0;
        public PlayPage()
        {
            InitializeComponent();
        }

        private async void btnPlay_Clicked(object sender, EventArgs e)
        {
            try
            {
                int _apuesta = Convert.ToInt32(cmpApuesta.Text);
                if (_apuesta < 10 || _apuesta > _saldo)
                {
                    await DisplayAlert("Info", $"Su apuesta debe ser mayor a 10 y menor a {_saldo}.", "OK");
                }
                else
                {
                    Random rnd = new Random();
                    int _dado1 = rnd.Next(1, 6);
                    int _dado2 = rnd.Next(1, 6);
                    lblDado1.Text = _dado1.ToString();
                    lblDado2.Text = _dado2.ToString();
                    if (_dado1 > _dado2)
                    {
                        await DisplayAlert("You Win", $"Felicidades!!!... usted ganó {_apuesta} pesos.", "OK");
                        _saldo += _apuesta;
                        lblSaldo.Text = _saldo.ToString();
                    }
                    else if (_dado1 < _dado2)
                    {
                        await DisplayAlert("You Loose", $"Que pena... usted perdió {_apuesta} pesos.", "OK");
                        _saldo -= _apuesta;
                        lblSaldo.Text = _saldo.ToString();
                    }
                    else
                        await DisplayAlert("Tie", $"Hubo un empate.", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", $"Ocurrió un error, verifique los valores introducidos.", "OK");
            }


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            lblSaldo.Text = Preferences.Get("saldo", "0").ToString();
            _saldo = Convert.ToInt32(lblSaldo.Text);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Preferences.Set("saldo", lblSaldo.Text);

        }

    }
}