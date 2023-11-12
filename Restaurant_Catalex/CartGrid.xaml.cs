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
        private TextBlock text;
        private Button removeButton;
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

            removeButton = new Button();
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("C:/Users/Alex/Desktop/Anul_3/ABD/Restaurant_Catalex/delete-button.png", UriKind.Absolute));
            removeButton.Width = 20;
            removeButton.Height = 20;
            removeButton.VerticalAlignment = VerticalAlignment.Top;
            removeButton.HorizontalAlignment = HorizontalAlignment.Center;
            removeButton.Background = imageBrush;
            removeButton.Margin = new Thickness(0, 10, 0, 0);
            removeButton.BorderThickness = new Thickness(0);
            removeButton.Click += removeButton_Clicked;


            A.Children.Add(Nume);
            A.Children.Add(Pret);
            A.Children.Add(Ingrediente);
            A.Children.Add(removeButton);
        }
        private void removeButton_Clicked(object sender, RoutedEventArgs e)
        {
            string nume = Nume.Content.ToString();
            int index = myCos.getIndexToRemove(nume);
            myCos.removeProduct(index);
           
        }

        public Grid getGrid()
        {
            return A;
        }
    }
}
