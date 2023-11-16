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
using System.Data.SqlClient;

namespace Restaurant_Catalex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string[] Info = new string[11];
        private string userType;
        public MainWindow()
        {
            
            InitializeComponent();
            
        }
    
        private bool verify_credentials(string a,string b)
        {   
            string mesaj_conexiune = "Data Source=DESKTOP-O344N69;Initial Catalog=ABD;Integrated Security=True;";
            SqlConnection con = new SqlConnection(mesaj_conexiune);
            con.Open();
            string query1 = "Select* From Utilizatori u inner join Admin a on u.IDUtilizator=a.IDUtilizator where Username=@username and Password=@password";
            using(SqlCommand cmd = new SqlCommand(query1,con))
            {
                cmd.Parameters.AddWithValue("@username", a);
                cmd.Parameters.AddWithValue("@password", b);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    userType = "Admin";
                    con.Close();
                    return true;
                }
                
            }
            
            con = new SqlConnection(mesaj_conexiune);
            con.Open();
            string query2 = "Select* From Utilizatori u inner join UtilizatorSimplu a on u.IDUtilizator=a.IDUtilizator where Username=@username and Password=@password";
            using (SqlCommand cmd = new SqlCommand(query2, con))
            {
                cmd.Parameters.AddWithValue("@username", a);
                cmd.Parameters.AddWithValue("@password", b);
                SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Info[0] = reader["Nume"].ToString();
                        Info[1] = reader["Prenume"].ToString();
                        Info[2] = reader["Email"].ToString();
                        Info[3] = reader["Telefon"].ToString();
                        Info[4] = reader["Adresa"].ToString();
                        Info[5] = reader["Sector"].ToString();
                        Info[6] = reader["NumarComenzi"].ToString();
                        Info[7] = reader["SumaBani"].ToString();
                        Info[8] = reader["NumarCard"].ToString();
                        Info[9] = reader["CIV"].ToString();
                    }
                if (Info[0] != null)
                {
                    userType = "Simplu";
                    return true;
                }
                
            }
            return false;
          
        }

        private void Login_Button_Click_1(object sender, RoutedEventArgs e)
        {
            string a = User_Text.Text;
            string b = Password_Text.Password;
            var ok = verify_credentials(a, b);
            if (!ok)
            {
                string message = "Autentificare nereusita! Va rugam incercati din nou ! ";
                string titlu_eroare = "Eroare de conectare!";
                MessageBox.Show(message, titlu_eroare);
            }
            else
            {
                // Aici deschid fereastra noua!!
                //Info e un vector de string-uri care retine detaliile User-ului curent;
                if (userType == "Admin")
                {
                    //..
                }
                if (userType == "Simplu")
                {
                    Interfata_Client ClientWindow = new Interfata_Client(Info);
                    ClientWindow.Show();


                }
                if (Info[8] == "Livrator")
                {
                    //...
                }
                this.Close();


            }
        }

        private void Autentificare_Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fereastra_Autentificare Window = new Fereastra_Autentificare();
            Window.Show();
            this.Close();
        }
    }
}
