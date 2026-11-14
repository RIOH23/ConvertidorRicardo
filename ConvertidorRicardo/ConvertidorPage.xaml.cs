using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ConvertidorRicardo
{
    public partial class ConvertidorPage : ContentPage
    {
        public ConvertidorPage()
        {
            InitializeComponent();
        }

        private readonly Operaciones _operaciones = new Operaciones();
        private string _operacionSeleccionada = string.Empty;

        public class Operaciones
        {
            public double CelsiusAFahrenheit(double a) => (a * 9 / 5) + 32;
            public double FahrenheitACelsius(double a) => (a - 32) * 5 / 9;
        }

        private void OnOperacionCambiada(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value) return;

            var radioSeleccionado = (RadioButton)sender;

            _operacionSeleccionada = radioSeleccionado.Content.ToString();
        }

        private void OnCalcularClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(EntryTemp.Text, out double numero1))
            {
                lblResultado.Text = "Ingrese un número válido";
                return;
            }

            if (string.IsNullOrEmpty(_operacionSeleccionada))
            {
                lblResultado.Text = "Seleccione una operación";
                return;
            }

            try
            {
                double resultado = _operacionSeleccionada switch
                {
                    "C a F" => _operaciones.CelsiusAFahrenheit(numero1),
                    "F a C" => _operaciones.FahrenheitACelsius(numero1)
                };
                lblResultado.Text = $"Resultado: {resultado}";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
