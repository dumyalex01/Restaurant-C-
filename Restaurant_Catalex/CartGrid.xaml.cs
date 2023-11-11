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
using System.Windows.Shapes;

namespace Restaurant_Catalex
{
    /// <summary>
    /// Interaction logic for CartGrid.xaml
    /// </summary>


    public partial class CartGrid : Window
    {
        Grid A;
        public Label Pret;
        public Label Nume;
        public Label Ingrediente;
        public Button remove;
        Cos_Cumparaturi myCos;

        public CartGrid(string nume, string pret, string ingrediente, int marginLeft, int marginTop, Cos_Cumparaturi cos)
        {
            InitializeComponent();
            myCos = cos;
            A = new Grid();
            Nume = new Label();
            Pret = new Label();
            Ingrediente = new Label();
            A.Margin = new Thickness(marginLeft, marginTop, 0, 0);
            Pret.Content = pret;
            Nume.Content = nume;
            Ingrediente.Content = ingrediente;
            Nume.Margin = new Thickness(10, 0, 0, 0);
            Nume.FontSize = 10;
            Nume.FontStyle = FontStyles.Italic;
            Nume.FontWeight = FontWeights.Bold;
            Ingrediente.Margin = new Thickness(15, 15, 0, 0);
            Ingrediente.FontSize = 8;
            Pret.Margin = new Thickness(150, 30, 0, 0);
            Pret.FontStyle = FontStyles.Italic;
            Pret.FontSize = 10;
            Pret.FontWeight = FontWeights.Bold;

            remove = new Button();
            remove.Content = "Hello!";
            remove.Width = 20;
            remove.Height = 20;
            remove.Click += remove_Clicked;

            A.Children.Add(remove);
            A.Children.Add(Nume);
            A.Children.Add(Pret);
            A.Children.Add(Ingrediente);
        }

        private void remove_Clicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("HELLO!");
        }

        public Grid getGrid()
        {
            return A;
        }
    }
}
