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

namespace CalculadoraDinamica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = WindowGrid;
            int fila = 0, columna = 0;

            //creo botones con las etiquetas
            for (int i = 0; i < 10; i++)
            {
                //creo viewbox, label y button
                Viewbox viewbox = new Viewbox();
                Label label = new Label();
                Button button = new Button();
                //añado evento al botón
                button.Click += Button_Click;
                //añado contenido al label y añado el label al viewbox
                label.Content = i.ToString();
                viewbox.Child = label;

                button.Content = viewbox; //añado el viewbox al botón
                button.Margin = new Thickness(5); //añado margen
                button.Tag = i.ToString(); //añado tag según i

                //Valor dentro del Grid
                if (i == 0) //boton 0
                {
                    //element, value
                    Grid.SetRow(button, 4);
                    Grid.SetColumn(button, 0);
                    Grid.SetColumnSpan(button, 3);
                    fila++;
                }
                else //demás botones
                {
                    Grid.SetRow(button, fila);
                    Grid.SetColumn(button, columna - 1); //columna-1 por haber incrementado después de i=0
                }
                //cada vez que el valor de columna sea 3, se reinicia a 0 y se incrementa el valor de la fila
                if (columna == 3)
                {
                    columna = 0;
                    fila++;
                }
                columna++;
                //añado el botón al grid
                WindowGrid.Children.Add(button);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PantallaTextBlock.Text += (sender as Button).Tag.ToString();
        }
    }
}
