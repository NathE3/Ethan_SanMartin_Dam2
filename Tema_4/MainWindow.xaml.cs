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
            Leer();

        }

        double cantidad;
        double resultado;
        string divisaOrigen;
        string divisaDestino;

        private const double DOLLAR_MONEDA = 1.0;
        private const double EURO_DOLLAR = 1.05;
        private const double LIBRA_DOLLAR = 1.30;
        private const string RUTA = "D:\\historial.txt";
        private const string EURO = "Euro";
        private const string LIBRA = "Libra";
        private const string DOLLAR = "Dollar";


        private void CargarValor(string mensajeHistorial)
        {
            StreamWriter escribir = new StreamWriter(RUTA, true);
            escribir.WriteLine(mensajeHistorial);
            escribir.Close();
        }

        private void Leer() 
        {
            if (File.Exists(RUTA))
            {
                historial.Content = File.ReadAllText(RUTA);
            }
        }
        
        private void Calcular(object sender, SelectionChangedEventArgs e)
            {

            if (primeraDivisa.SelectedItem == null || segundaDivisa.SelectedItem == null)
            {
                return;
            }
           

            divisaOrigen = (primeraDivisa.SelectedItem as ComboBoxItem)?.Content?.ToString()??"Resultado erroneo";
            divisaDestino = (segundaDivisa.SelectedItem as ComboBoxItem)?.Content?.ToString()??"Resultado erroneo";

           
            if (divisaOrigen == EURO && divisaDestino == LIBRA)
                {
                resultado = (cantidad * EURO_DOLLAR) / LIBRA_DOLLAR;
                }

            else if (divisaOrigen == LIBRA && divisaDestino == EURO)
                {
                resultado = (cantidad * LIBRA_DOLLAR) / EURO_DOLLAR;
                }

            else if (divisaOrigen == DOLLAR && divisaDestino == EURO)
                {
                resultado = cantidad / EURO_DOLLAR;
                }

            else if (divisaOrigen == EURO && divisaDestino == DOLLAR)
                {
                resultado = cantidad * EURO_DOLLAR;
                }

            else if (divisaOrigen == DOLLAR && divisaDestino == LIBRA)
                {
                resultado = cantidad / LIBRA_DOLLAR;
                }

            else if (divisaOrigen == LIBRA && divisaDestino == DOLLAR)
                {
                resultado = cantidad * LIBRA_DOLLAR;
                 }

            else
                {
             
                resultado = cantidad;
                }
            }


        private void Btn_Convertir(object sender, RoutedEventArgs e)
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

            Calcular(null,null);
            MostrarResultadoConFecha();
        }

        private void MostrarResultadoConFecha()
        {
        
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

       
            string mensajeHistorial = $"Fecha: {fechaActual} | {cantidad} {divisaOrigen} = {resultado.ToString("F2")} {divisaDestino}";
            CargarValor(mensajeHistorial);
            Leer();
            
        }

        private void CambioMoneda_Click(object sender, RoutedEventArgs e)
        {
            int aux;
            aux = primeraDivisa.SelectedIndex;
            primeraDivisa.SelectedIndex  = segundaDivisa.SelectedIndex;
            segundaDivisa.SelectedIndex = aux;
        }
    }


    }
