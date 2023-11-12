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
    /// Interaction logic for Cos_Cumparaturi.xaml
    /// </summary>
    ///
    public partial class Cos_Cumparaturi : Window
    {
        Grid[] grids;
        static int gridsCounter;
        private string[] info;
       
        public Cos_Cumparaturi(string[] informatii)
        {
            InitializeComponent();
            grids = new Grid[15];
            gridsCounter = 0;
            this.info = new string[11];
            this.info = informatii;
            this.Bani.Content = this.info[10] + " lei";


        }
       public int getTotalCumparaturi()
        {
            int sum = 0;
            for (int i = 0; i < gridsCounter; i++)
            {
                foreach (UIElement element in grids[i].Children)
                {
                    if (element is Label)
                    {
                        Label eticheta = (Label)element;
                        if (eticheta.Content.ToString().Contains("lei"))
                        {
                            string aux = eticheta.Content.ToString();
                            var numar = aux.Split(' ');
                            sum = sum + int.Parse(numar[0]);
                        }
                    }
                }
            }
            return sum;
        }
        public void add_to_cart(Grid A)
        {
            grids[gridsCounter] = new Grid();
            grids[gridsCounter] = A;
            CartGrid.Children.Add(grids[gridsCounter]);
            gridsCounter++;
        }
        public void removeProduct(int index)
        {
            grids[index].Children.Clear();
            for (int i = index; i < gridsCounter-1; i++)
                grids[i] = grids[i + 1];
            gridsCounter--;
            Reconstruct();
        }
        public void Reconstruct()
        {
            int marginTop = 0;
            for (int i = 0; i < gridsCounter; i++)
            {
                grids[i].Margin = new Thickness(0, marginTop, 0, 0);
                marginTop += 35;
            }
            int sum = getTotalCumparaturi();
            Total.Content = sum.ToString() + " lei";

        }
        public int getIndexToRemove(string nume)
        {
            for(int i=0;i<=gridsCounter;i++)
            {
                foreach(UIElement element in grids[i].Children)
                {
                    if(element is Label)
                    {
                        Label eticheta = (Label)element;
                        if (eticheta.Content.ToString() == nume)
                            return i;
                    }
                }
            }
            return -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}