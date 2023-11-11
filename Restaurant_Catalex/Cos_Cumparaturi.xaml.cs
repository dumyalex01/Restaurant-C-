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
       
        public Cos_Cumparaturi()
        {
            InitializeComponent();
            grids = new Grid[15];
            gridsCounter = 0;
            


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
            for (int i = index; i < gridsCounter; i++)
                grids[i] = grids[i + 1];
            gridsCounter--;
            grids[index].Children.Clear();
            Reconstruct();
        }
        private void Reconstruct()
        {
            int marginTop = 20;
            for (int i = 0; i < gridsCounter; i++)
            {
                grids[i].Margin = new Thickness(20, marginTop, 0, 0);
                marginTop += 20;
            }

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
          
    }
}