using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CambioDivisa
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        
            InitializeComponent();
            leer();

        }

        double cantidad;
        double resultado;
        string divisaOrigen;
        string divisaDestino;
        private const double euroDolar = 1.05;
        private const double libraDolar = 1.30;
        string ruta = "D:\\historial.txt";


        private void CargarValor(string mensajeHistorial)
        {
            StreamWriter escribir = new StreamWriter(ruta, true);
            escribir.WriteLine(mensajeHistorial);
            escribir.Close();
        }

        private void leer() 
        {
            if (File.Exists(ruta))
            {
                historial.Content = File.ReadAllText(ruta);
            }
        }
        
        private void Calcular(object sender, SelectionChangedEventArgs e)
            {
           
            if (primeraDivisa.SelectedItem == null || segundaDivisa.SelectedItem == null)
                return;

           
            divisaOrigen = (primeraDivisa.SelectedItem as ComboBoxItem).Content.ToString();
            divisaDestino = (segundaDivisa.SelectedItem as ComboBoxItem).Content.ToString();

           
            if (divisaOrigen == "Euro" && divisaDestino == "Libra")
                {
                resultado = (cantidad * euroDolar) / libraDolar;
                }

            else if (divisaOrigen == "Libra" && divisaDestino == "Euro")
                {
                resultado = (cantidad * libraDolar) / euroDolar;
                }

            else if (divisaOrigen == "Dollar" && divisaDestino == "Euro")
                {
                resultado = cantidad / euroDolar;
                }

            else if (divisaOrigen == "Euro" && divisaDestino == "Dollar")
                {
                resultado = cantidad * euroDolar;
                }

            else if (divisaOrigen == "Dollar" && divisaDestino == "Libra")
                {
                resultado = cantidad / libraDolar;
                }

            else if (divisaOrigen == "Libra" && divisaDestino == "Dollar")
                {
                resultado = cantidad * libraDolar;
                 }

            else
                {
             
                resultado = cantidad;
                }
            }


        private void boton_1_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrEmpty(importe.Text))
            {
                importe.Text = ("Error de entrada");
                return;
            }

            if (!double.TryParse(importe.Text, out cantidad))
            {
                importe.Text = ("Dame un número");
                return;
            }

         
            Calcular(null, null);

    
            MostrarResultadoConFecha();
        }

        private void MostrarResultadoConFecha()
        {
        
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

       
            string mensajeHistorial = $"Fecha: {fechaActual} | {cantidad} {divisaOrigen} = {resultado.ToString("F2")} {divisaDestino}";
            CargarValor(mensajeHistorial);
            leer();
            
        }

    }


    }
