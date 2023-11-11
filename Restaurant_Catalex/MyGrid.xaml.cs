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
    /// Interaction logic for MyGrid.xaml
    /// </summary>
    public partial class MyGrid : Window
    {
        private Label Nume;
        public Grid A;
        private Label Ingrediente;
        private Label Pret;
        private Button butonAdd;
        public Cos_Cumparaturi myCos;
        static int margine = 0;
        public MyGrid(int leftMargin,int topMargin,string ingrediente,string numeProdus,int calorii,int pret,Cos_Cumparaturi  Cos)
        {
            A = new Grid();
            myCos = Cos;
            A.Margin = new Thickness(leftMargin, topMargin, 0, 0);
            Ingrediente = new Label();
            Ingrediente.Content = ingrediente + "..." + calorii.ToString() + " calorii";
            Ingrediente.FontSize = 12;
            Nume = new Label();
            Nume.Content = "• " + numeProdus;
            Nume.FontSize = 14;
            Nume.FontStyle = FontStyles.Italic;
            Nume.FontWeight = FontWeights.Bold;
            Pret = new Label();
            Nume.FontStretch = FontStretches.SemiExpanded;
            Pret.Content = pret.ToString() + " lei";
            Pret.FontSize = 14;
            Pret.FontWeight = FontWeights.Bold;
            Nume.Margin = new Thickness(20, 0, 0, 0);
            Ingrediente.Margin = new Thickness(25, 15, 0, 0);
            Pret.Margin = new Thickness(150, 30, 0, 0);
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("C:/Users/Alex/Desktop/Anul_3/ABD/Restaurant_Catalex/add-to-cart.png", UriKind.Absolute));
            butonAdd = new Button();
            butonAdd.Width = 20;
            butonAdd.Height = 20;
            butonAdd.HorizontalAlignment = HorizontalAlignment.Center;
            butonAdd.VerticalAlignment = VerticalAlignment.Top;
            butonAdd.Margin = new Thickness(350, 10, 0, 0);
            butonAdd.Background = imageBrush;
            butonAdd.Click += butonAdd_Click;
            A.Children.Add(Nume);
            A.Children.Add(Ingrediente);
            A.Children.Add(Pret);
            A.Children.Add(butonAdd);
         

        }
   
        private void butonAdd_Click(object sender, RoutedEventArgs e)
        {
            CartGrid G = new CartGrid(Nume.Content.ToString(), Pret.Content.ToString(), Ingrediente.Content.ToString(), 10, margine,myCos);
            margine += 30;
            myCos.add_to_cart(G.getGrid());
        }
        public Grid getGrid()
        {
            return this.A;
        }
        public string getName()
        {
            return this.Nume.Content.ToString();
        }
        public string getIngrediente()
        {
            return this.Ingrediente.Content.ToString();
        }

        public string getPret()
        {
            return this.Pret.Content.ToString();
        }
    }
}
