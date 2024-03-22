using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraficaOP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Converciones c;
        public MainWindow()
        {
            InitializeComponent();
            c = new Converciones();
        }

        private void resultado(object sender, RoutedEventArgs e)
        {
          
        }

        public void validador()
        {
            int binario = 11101;
            string bina = binario.ToString();
            int num = 10;
            double elevadoAlCuadrado = Math.Pow(num, 2); // Elevarlo a la potencia 2
            char[] numero = new char[5];
            char[] numero2 = new char[5];        
            for (char i = (char)0;i<numero.Length;i++)
            {
                if (numero[i] == 1)
                {
                    numero2[i] = numero[i];
                    MessageBox.Show("numero" + numero[i]);
                }
            }
          
        }
        //Binario a decimal listo
        //octal a decimal listo
        //binario a hexadecimal, luego dividir
        //hexadecimal a decimal
       

        private void hexadecimal(object sender, RoutedEventArgs e)
        {
            habilitarbtnHexadecimal(true);
        }

        private void btnDEC_Click(object sender, RoutedEventArgs e)
        {
            habilitarbtnHexadecimal(false);
        }

        private void btnOCT_Click(object sender, RoutedEventArgs e)
        {
            habilitarbtnOctales(false);
            habilitarbtnHexadecimal(false);
        }

        private void btnBIN_Click(object sender, RoutedEventArgs e)
        {
            habilitarbtnBinarios(false);
            habilitarbtnOctales(false);
            habilitarbtnHexadecimal(false);
        }

        public void habilitarbtnHexadecimal(Boolean habilitar)
        {
            btnA.IsEnabled = habilitar;
            btnB.IsEnabled = habilitar;
            btnC.IsEnabled = habilitar;
            btnD.IsEnabled = habilitar;
            btnE.IsEnabled = habilitar;
            btnF.IsEnabled = habilitar;
        }

        public void habilitarbtnOctales(Boolean habilitar)
        {
            btn9.IsEnabled = habilitar;
            btn8.IsEnabled = habilitar;
        }

        public void habilitarbtnBinarios(Boolean habilitar)
        {
            btn7.IsEnabled = habilitar;
            btn6.IsEnabled = habilitar;
            btn5.IsEnabled = habilitar;
            btn4.IsEnabled = habilitar;
            btn3.IsEnabled = habilitar;
            btn2.IsEnabled = habilitar;
        }

       

        private void btnPruebasnum(object sender, RoutedEventArgs e)
        {

            //c.BinarioDecimal(Convert.ToInt32(numeroEntrada.Text));
            c.Octal_Decimal(Convert.ToInt32(numeroEntrada.Text));
           
        }
    }
}
