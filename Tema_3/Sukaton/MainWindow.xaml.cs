using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sukaton
{
    public partial class MainWindow : Window
    {
        private double valorActual = 0;
        private double resultado = 0;
        private string operadorActual = "";
        private bool nuevaOperacion = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Numero_Click(object listener, RoutedEventArgs e)
        {
            Button boton = (Button)listener;


            if (nuevaOperacion)
            {
                textBox.Clear();
                nuevaOperacion = false;
            }


            textBox.Text += boton.Content.ToString();
        }


        private void Operador_Click(object listener, RoutedEventArgs e)
        {
            Button boton = (Button)listener;
            operadorActual = boton.Content.ToString();


            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Error: campo vacío";
                return;
            }

            if (!double.TryParse(textBox.Text, out resultado))
            {
                textBox.Text = "Error: entrada inválida";
                return;
            }

            nuevaOperacion = true;
        }


        private void Igual_Click(object listener, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Error: vacío";
                return;
            }


            if (!double.TryParse(textBox.Text, out valorActual))
            {
                textBox.Text = "Error: entrada inválida";
                return;
            }


            switch (operadorActual)
            {
                case "+":
                    resultado += valorActual;
                    break;
                case "-":
                    resultado -= valorActual;
                    break;
                case "x":
                    resultado *= valorActual;
                    break;
                case "÷":
                    if (valorActual != 0)
                        resultado /= valorActual;
                    else
                    {
                        textBox.Text = "Error: División por cero";
                        return;
                    }
                    break;
                default:
                    textBox.Text = "Error: Operador desconocido";
                    return;
            }


            textBox.Text = resultado.ToString();
            nuevaOperacion = true;
        }


        private void Pi_Click(object listener, RoutedEventArgs e)
        {
            textBox.Text = Math.PI.ToString("F2");
            nuevaOperacion = true;
        }


        private void Borrar_Click(object listener, RoutedEventArgs e)
        {
            textBox.Clear();
            resultado = 0;
            valorActual = 0;
            operadorActual = "";
            nuevaOperacion = false;

        }
    }
}