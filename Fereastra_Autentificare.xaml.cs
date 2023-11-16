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
    /// Interaction logic for Fereastra_Autentificare.xaml
    /// </summary>
    public partial class Fereastra_Autentificare : Window
    {
        public Fereastra_Autentificare()
        {
            InitializeComponent();
        }
        private bool check_user(string username)
        {
            string connection = "Data Source=DESKTOP-O344N69;Initial Catalog=ABD;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            string query = "SELECT COUNT(*) FROM Utilizatori WHERE Username=@name";
            using(SqlCommand cmd=new SqlCommand(query,conn))
            {
                cmd.Parameters.AddWithValue("@name", username);
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                if (count > 0)
                    return false;
                else return true;
            }
        }
        private bool check_age(string age)
        {
            for(int i=0;i<age.Length;i++)
            {
                if (!(age[i] >= '0' && age[i] <= '9'))
                    return false;
            }
            return true;
        }
        private bool check_phone(string phone)
        {
            if (phone.Length < 10)
                return false;
            else
            {
                if (phone[0] != '0' || phone[1] != '7')
                    return false;
                else
                {
                    for(int i=2;i<10;i++)
                        if (!(phone[i] >= '0' && phone[i] <= '9'))
                            return false;

                }
            }
            return true;
        }
        private bool check_sector(string sector)
        {
            if (sector.Length > 2)
                return false;
            else if (!(sector[0] <= '6' && sector[0] >= '1'))
                return false;
            return true;
        }
        private bool check_email(string email)
        {
            int pozitie = email.IndexOf('@');
            if (pozitie < 0)
                return false;
            else
            {
                for (int i = pozitie; i < email.Length; i++)
                    if (email[i] == '.' && i != email.Length - 1)
                        return true;
            }
            return false;
        }
        private bool email_existence(string email)
        {
            string connection = "Data Source=DESKTOP-O344N69;Initial Catalog=ABD;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            string query = "SELECT COUNT(*) FROM UtilizatorSimplu WHERE Email=@email";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                if (count > 0)
                    return false;
                else return true;
            }
            return true;
        }
        private void AutentificareButon_Click(object sender, RoutedEventArgs e)
        {
            bool[] ok = new bool[7];
            ok[0] = check_user(UserBox.Text);
            ok[1] = check_age(AgeBox.Text);
            ok[2] = check_phone(PhoneBox.Text);
            ok[3] = check_sector(SectorBox.Text);
            ok[4] = check_email(EmailBox.Text);
            ok[5] = email_existence(EmailBox.Text);
            ok[6] = true;
            if (Check_Box.IsChecked == false)
                ok[6] = false;
            if (ok[0] && ok[1] && ok[2] && ok[3] && ok[4] && ok[5] && ok[6] == true)
            {
                
                string mesaj_conexiune = "Data Source=DESKTOP-O344N69;Initial Catalog=ABD;Integrated Security=True;";
                SqlConnection conn = new SqlConnection(mesaj_conexiune);
                conn.Open();
                string query = "begin tran " +
                                "declare @var int; " +
                                 "insert into Utilizatori(Username, Password) " +
                                  "values(@Cont, @Parola) " +
                                  "set @var = (select IDUtilizator from Utilizatori where Username = @Cont) " +
                                  "insert into UtilizatorSimplu(IDUtilizator, Nume, Prenume, Email, Telefon, Adresa, Sector, NumarComenzi, SumaBani, Varsta) " +
                                  "values(@var,@Nume,@Prenume,@Email,@Telefon,@Adresa,@Sector,@NumarComenzi,@SumaBani,@Varsta) " +
                                  "if @@ERROR > 0 " +
                                     "ROLLBACK; " +
                                 "else COMMIT";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nume", NameBox.Text);
                    cmd.Parameters.AddWithValue("@Prenume", PrenameBox.Text);
                    cmd.Parameters.AddWithValue("@Varsta", AgeBox.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailBox.Text);
                    cmd.Parameters.AddWithValue("@Telefon", PhoneBox.Text);
                    cmd.Parameters.AddWithValue("@Sector", SectorBox.Text);
                    cmd.Parameters.AddWithValue("@TipUtilizator", "Simplu");
                    cmd.Parameters.AddWithValue("@NumarComenzi", 0);
                    cmd.Parameters.AddWithValue("@Adresa", Adresa.Text);
                    cmd.Parameters.AddWithValue("@SumaBani", 0);
                    cmd.Parameters.AddWithValue("@Cont", UserBox.Text);
                    cmd.Parameters.AddWithValue("@Parola", PasswordBox.Text);
                    cmd.CommandText = query;
                    int number = cmd.ExecuteNonQuery();
                    if(number>0)
                    {
                        MessageBox.Show("Autentificare cu succes!", "Congratulations!");
                        this.Hide();
                        MainWindow A = new MainWindow();
                        A.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a reusit autentificarea!", "Eroare neasteptata!");
                    }
                }
                conn.Close();

            }
            else
            {

                if (!check_user(UserBox.Text))
                {
                    MessageBox.Show("Utilizatorul exista deja!", "Eroare duplicat baza de date!");
                }
                else
                if (!check_age(AgeBox.Text))
                {
                    MessageBox.Show("Varsta trebuie sa fie alcatuita din cifre!", "Eroare setare varsta!");
                }
                else
                if (!check_phone(PhoneBox.Text))
                {
                    MessageBox.Show("Nu se respecta formatul numarului de telefon!", "Eroare setare telefon!");
                }
                else
                if (!check_sector(SectorBox.Text))
                {
                    MessageBox.Show("Sectorul trebuie sa contina o cifra intre 1 si 6!", "Eroare setare sector!");
                }
                else
                if (!check_email(EmailBox.Text))
                {
                    MessageBox.Show("Emailul nu este valid!", "Eroare setare Email");
                }
                else
                if (!email_existence(EmailBox.Text))
                {
                    MessageBox.Show("Emailul este deja inregistrat!", "Eroare setare Email!");
                }
                else
                if(Check_Box.IsChecked==false)
                {
                    MessageBox.Show("Trebuie sa bifati ca acceptati termenii si conditiile!", "Eroare conditii!");
                }
            }
        }

       
    }
}
