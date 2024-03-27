using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        List<Char> charList;
        static bool ejecutador;
        static Boolean hexade = false;
        static Boolean oct = false;
        static Boolean deci = true;
        static Boolean bin = false;

        Thread operaciones;

        public MainWindow()
        {
            InitializeComponent();
            
            c = new Converciones();
            operaciones = new Thread(realizarOperaciones);
            btnDEC.Background = Brushes.Gray;
            operaciones.Start();
            ejecutador = true;

            habilitarbtnHexadecimal(false);
            habilitarbtnBinarios(true);
            habilitarbtnOctales(true);
            charList = new List<Char>();
        }

        private void resultado(object sender, RoutedEventArgs e)
        {
          
        }

       

       

        private void hexadecimal(object sender, RoutedEventArgs e)
        {
            habilitarbtnHexadecimal(true);
            vaciarTexto();
            habilitarOperaciones(true, false, false, false);
        }

        private void btnDEC_Click(object sender, RoutedEventArgs e)
        {
            habilitarbtnHexadecimal(false);
            habilitarbtnBinarios(true);
            habilitarbtnOctales(true);
            vaciarTexto();
            habilitarOperaciones(false, true, false, false);
        }

        private void btnOCT_Click(object sender, RoutedEventArgs e)
        {
            habilitarbtnOctales(false);
            habilitarbtnHexadecimal(false);
            habilitarbtnBinarios(true);
            vaciarTexto();
            habilitarOperaciones(false, false, true, false);
        }

        private void btnBIN_Click(object sender, RoutedEventArgs e)
        {
            habilitarbtnBinarios(false);
            habilitarbtnOctales(false);
            habilitarbtnHexadecimal(false);
            habilitarOperaciones(false, false, false, true);
            vaciarTexto();
        }

        public void habilitarOperaciones(Boolean hex, Boolean dec, Boolean oc, Boolean bi)
        {
            hexade = hex;
            deci = dec;
            oct = oc;
            bin = bi;

            btnDEC.Background = Brushes.AliceBlue;
            btnHEX.Background = Brushes.AliceBlue;
            btnOCT.Background = Brushes.AliceBlue;
            btnBIN.Background = Brushes.AliceBlue;
       
            if(hex)
            {
                btnHEX.Background = Brushes.Gray;
            }
            if(dec)
            {
                btnDEC.Background = Brushes.Gray;
            }
            if (oc)
            {
                btnOCT.Background = Brushes.Gray;
            }
            if(bi)
            {
                btnBIN.Background = Brushes.Gray;
            }
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

        public void vaciarTexto()
        {
            numeroEntrada.Text = "";
            verBI.Text = "";
            verDE.Text = "";
            verHe.Text = "";
            verOT.Text = "";
        }

       
       

        private void btnPruebasnum(object sender, RoutedEventArgs e)
        {

            //c.BinarioDecimal(Convert.ToInt32(numeroEntrada.Text)); //listo
            //c.Binario_Octal(Convert.ToInt32(numeroEntrada.Text)); //listo
            //c.Binario_Hexadecimal(Convert.ToInt32(numeroEntrada.Text)); //listo

            //c.Decimal_Binario(Convert.ToInt32(numeroEntrada.Text)); //listo
            //c.Decimal_Octal(Convert.ToInt32(numeroEntrada.Text));// listo
            //c.Decimal_Hexadecimal1(Convert.ToInt32(numeroEntrada.Text)); //listo

            //c.Octal_Decimal(Convert.ToInt32(numeroEntrada.Text)); //listo
            // c.Octal_Binario(Convert.ToInt32(numeroEntrada.Text)); //listo
            //c.Octal_Hexadecimal(Convert.ToInt32(numeroEntrada.Text)); //listo

            //c.Hexadecimal_Decimal(numeroEntrada.Text); //listo
            //c.Hexadecimal_Octal(numeroEntrada.Text); //listo
            //c.Hexadecimal_Binario(numeroEntrada.Text);

            //c.recorrer(Convert.ToInt32(numeroEntrada.Text));



        }

        private void teclear(object sender, RoutedEventArgs e)
        {
            Button click = (Button) sender;
            Char valor = click.Content.ToString()[0];//primer caracter del contenido del boton

            Char[] acvalor = numeroEntrada.Text.ToCharArray();
            if (valor == 'X')
            {
                if(acvalor.Length > 0)
                {
                    Array.Resize(ref acvalor, acvalor.Length - 1);//agregar el valor al final del array
                    numeroEntrada.Text = new string(acvalor);//trae todo el array
                }
            }
            else
            {
                Array.Resize(ref acvalor, acvalor.Length + 1);//agregar el valor al final del array
                acvalor[acvalor.Length - 1] = valor;
                numeroEntrada.Text = new string(acvalor);//trae todo el array
            }

            
            //acvalor[acvalor.Length - 1] = valor;
           
           
        }


        public void realizarOperaciones()
        {
            while (ejecutador)
            {
                // Actualizar el control de la interfaz de usuario desde el hilo principal
                Application.Current.Dispatcher.Invoke(() =>
                {
                    if(numeroEntrada.Text.Equals(""))
                    {

                    }
                    else
                    {
                        if(hexade)
                        { 
                            c.Hexadecimal_otras(numeroEntrada.Text, verDE, verBI, verOT);
                            verHe.Text = numeroEntrada.Text;
                        }
                        if (oct)
                        {
                            c.Octal_otras(Convert.ToInt32(numeroEntrada.Text), verDE, verBI, verHe);
                            verOT.Text = numeroEntrada.Text;
                        }
                        if (deci)
                        {
                            c.Decimal_Binario(Convert.ToInt32(numeroEntrada.Text), verBI);
                            c.Decimal_Octal(Convert.ToInt32(numeroEntrada.Text), verOT);
                            c.Decimal_Hexadecimal1(Convert.ToInt32(numeroEntrada.Text), verHe);
                            verDE.Text = numeroEntrada.Text;
                        }
                        if(bin)
                        {
                            c.Binario_otras(Convert.ToInt32(numeroEntrada.Text), verDE, verOT, verHe);
                            verBI.Text = numeroEntrada.Text;
                        }

                      
                        
                    }

                });
                Thread.Sleep(100);
               
            }
           
        }


        private void ejecutar(object sender, RoutedEventArgs e)
        {

            vaciarTexto();

        }


      

    }
}
