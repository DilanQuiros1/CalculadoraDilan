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

        Thread operaciones;

        public MainWindow()
        {
            InitializeComponent();
            habilitarbtnHexadecimal(false);
            c = new Converciones();
            operaciones = new Thread(realizarOperaciones);
            operaciones.Start();
            ejecutador = true;
            charList = new List<Char>();
        }

        private void resultado(object sender, RoutedEventArgs e)
        {
          
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
            Array.Resize(ref acvalor, acvalor.Length + 1);//agregar el valor al final del array
            acvalor[acvalor.Length - 1] = valor;
            numeroEntrada.Text = new string(acvalor);//trae todo el array
           
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
                        //c.Binario_otras(Convert.ToInt32(numeroEntrada.Text), verDE, verOT, verHe);
                        //c.Octal_otras(Convert.ToInt32(numeroEntrada.Text), verDE, verBI, verHe);
                        //c.Hexadecimal_otras(numeroEntrada.Text, verDE, verBI, verOT);
                        c.Decimal_Binario(Convert.ToInt32(numeroEntrada.Text), verBI);
                        c.Decimal_Octal(Convert.ToInt32(numeroEntrada.Text), verOT);
                        c.Decimal_Hexadecimal1(Convert.ToInt32(numeroEntrada.Text), verHe);
                    }

                });
                Thread.Sleep(300);
               
            }
            MessageBox.Show("Finalizo");
        }


        private void ejecutar(object sender, RoutedEventArgs e)
        {

            ejecutador = false;

        }


        public void BinarioDecimal(int binario)
        {

            int originalBinario = binario;
            int count = 0;

            while (binario > 0)
            {
                binario /= 10;
                count++;
            }//esta parte si use gtp porque solo sabia como hacelo con String y no solo int

            int va = 0;
            binario = originalBinario;

            int suma = 0;
            for (int i = 0; i < count; i++)
            {

                int digito = binario % 10;//da un residuo que es el ultimo dijito 

                if (digito == 1)
                {
                    Double a = Math.Pow(2, va); //elevado 2 a la posicion donde encuentra un dijito 1
                    suma = suma + Convert.ToInt32(a);

                }

                va++;

                binario /= 10;
            }
            // Actualizar el control de la interfaz de usuario desde el hilo principal
            Application.Current.Dispatcher.Invoke(() =>
            {
                verDE.Text = suma.ToString();
            });

        }

      

        public Char[] Decimal_Octal(int numero, TextBox texto)
        {
            int resul;
            Char[] res = new char[16];
            int contador = 0;

            while (numero > 0)
            {
                resul = numero % 8;
                numero /= 8;
                res[contador] = (char)(resul + '0');
                contador++;

            }
            Array.Reverse(res, 0, contador);
            recorrer(res, contador, texto);


            return res;

        }

        public void recorrer(char[] res, int indice, TextBox texto)
        {
            int suma = 0;
            for (int i = 0; i < indice; i++)
            {
                suma = suma * 10 + (res[i] - '0'); // Convertir el carácter a su valor numérico y acumularlo
            }
            texto.Text = suma.ToString();
        }

    }
}
