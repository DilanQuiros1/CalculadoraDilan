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
        public MainWindow()
        {
            InitializeComponent();
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

        public void BinarioDecimal()
        {
            int binario = 1011011;        
            int originalBinario = binario;
            int count = 0;

            while (binario > 0)
            {
                binario /= 10;
                count++;
            }//esta parte si use gtp porque solo sabia como hacelo con String y no solo int

            int va =0;
            binario = originalBinario;
         
            int suma = 0;
            for (int i = 0; i < count; i++)
            {
               
                int digito = binario % 10;//da un residuo que es el ultimo dijito 
                          
                    if(digito==1)
                    {   
                        Double a = Math.Pow(2, va); //elevado 2 a la posicion donde encuentra un dijito 1
                        suma = suma + Convert.ToInt32(a);
                       
                    }

                va++;
                   
                binario /= 10;
            }
            MessageBox.Show(suma.ToString());
        }

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

        private void btnPruebas(object sender, RoutedEventArgs e)
        {
            BinarioDecimal();
        }
    }
}
