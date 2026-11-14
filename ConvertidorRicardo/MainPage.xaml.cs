using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ConvertidorRicardo
{
    public partial class MainPage : ContentPage
    {
        public class Operaciones
        {
            public double Sumar(double a, double b) => a + b;
            public double Restar(double a, double b) => a - b;
            public double Multiplicar(double a, double b) => a * b;

            public double Dividir(double a, double b)
            {
                if (a == 0 || b == 0)
                    throw new DivideByZeroException("No se puede dividir entre cero.");

                return a / b;
            }
        }

        private readonly Operaciones _operaciones = new();
        private string _operacionSeleccionada = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnOperacionCambiada(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value) return;

            var radioSeleccionado = sender as RadioButton;
            if (radioSeleccionado is null)
                return;

            _operacionSeleccionada = radioSeleccionado.Content?.ToString() ?? string.Empty;
        }

        private void OnCalcularClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(EntryNumero1.Text, out double numero1) ||
                !double.TryParse(EntryNumero2.Text, out double numero2))
            {
                LabelResultado.Text = "Por favor ingrese números válidos.";
                return;
            }

            if (string.IsNullOrEmpty(_operacionSeleccionada))
            {
                LabelResultado.Text = "Por favor seleccione una operación.";
                return;
            }

            try
            {
                double resultado = _operacionSeleccionada switch
                {
                    "Suma (+)" => _operaciones.Sumar(numero1, numero2),
                    "Resta (-)" => _operaciones.Restar(numero1, numero2),
                    "Multiplicación (*)" => _operaciones.Multiplicar(numero1, numero2),
                    "División (/)" => _operaciones.Dividir(numero1, numero2),
                    _ => throw new InvalidOperationException("Operación no válida.")
                };

                LabelResultado.Text = $"Resultado: {resultado}";
            }
            catch (DivideByZeroException ex)
            {
                LabelResultado.Text = ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                LabelResultado.Text = ex.Message;
            }
        }
    }
}
