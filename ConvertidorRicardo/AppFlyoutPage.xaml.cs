using ConvertidorRicardo;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace ConvertidorRicardo
{
    public partial class AppFlyoutPage : FlyoutPage
    {
        public AppFlyoutPage()
        {
            InitializeComponent();
        }

        private void OnCalculadoraClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainPage());
            IsPresented = false;
        }

        private void OnConvertidorClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ConvertidorPage());
            IsPresented = false;
        }
    }
}
