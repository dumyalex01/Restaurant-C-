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
using System.Data.SqlClient;
namespace Restaurant_Catalex
{ 
    /// <summary>
    /// Interaction logic for Interfata_Client.xaml
    /// </summary>
    /// 
 
    public partial class Interfata_Client : Window
    {   
        public string[] Infos;
        public Cos_Cumparaturi Cos;
        public Interfata_Client(string[] Informatii)
        {
            InitializeComponent();
            Cos = new Cos_Cumparaturi();
            Infos = new string[11];
            for (int i = 0; i <= 10; i++)
                Infos[i] = Informatii[i];
           
            
        }
        private void show_Menu(string type)
        {
            string mesaj_conexiune = "Data Source=DESKTOP-O344N69;Initial Catalog=ABD;Integrated Security=True;";
            SqlConnection con = new SqlConnection(mesaj_conexiune);
            con.Open();
            string[] infos = new string[4];
            string query = "select* from FelMancare where CategorieMancare=@type";
            MyGrid[] vectorMyGrid = new MyGrid[10];
            Grid[] vectorGrid = new Grid[10];
            int firstMargin = 70;
            int counter = 0;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@type", type);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    infos[0] = reader["NumeMancare"].ToString();
                    infos[1] = reader["Ingrediente"].ToString();
                    infos[2] = reader["Calorii"].ToString();
                    infos[3] = reader["Pret"].ToString();

                    vectorMyGrid[counter] = new MyGrid(60, firstMargin, infos[1], infos[0], int.Parse(infos[2]), int.Parse(infos[3]),Cos);
                    vectorGrid[counter] = new Grid();
                    vectorGrid[counter] = vectorMyGrid[counter].getGrid();
                    GMeniu.Children.Add(vectorGrid[counter]);
                    counter++;
                    firstMargin += 40;


                }



            }
            con.Close();

        }


        private void Meniu_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Meniul complet al restaurantului nostru!";
            Title.FontSize = 20;

        }

        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            GMeniu.Children.Clear();
            Title.Content = "         Meniul nostru de pizza!";
            Title.FontSize = 22;

            show_Menu("Pizza");

        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            GMeniu.Children.Clear();
            Title.Content = "         Burgerii nostri faimosi!";
            Title.FontSize = 22;
            show_Menu("Burger");
        }

        private void Supe_Click(object sender, RoutedEventArgs e)
        {
            GMeniu.Children.Clear();
            Title.Content = "       Ce ai zice de o supa ca la mama acasa?";
            Title.FontSize = 20;
            show_Menu("Supa");
        }

        private void Bauturi_Click(object sender, RoutedEventArgs e)
        {
            GMeniu.Children.Clear();
            Title.Content = "           Insetat sau pasionat?";
            Title.FontSize = 20;
            show_Menu("Bautura");
        }

        private void Salata_Click(object sender, RoutedEventArgs e)
        {
            GMeniu.Children.Clear();
            Title.Content = "           Modul dieta activat!";
            Title.FontSize = 20;
            show_Menu("Salata");
        }

        private void MicDejun_Click(object sender, RoutedEventArgs e)
        {
            GMeniu.Children.Clear();
            Title.Content = "          Mic dejunul campionilor!";
            Title.FontSize = 20;
            show_Menu("Mic Dejun");
            Cos.Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cos.Show();
        }
    }
}
