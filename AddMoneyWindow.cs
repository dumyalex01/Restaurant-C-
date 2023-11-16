using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Restaurant_Catalex
{
    public partial class AddMoneyWindow : Form
    {
        Cos_Cumparaturi myCos;
        public AddMoneyWindow(Cos_Cumparaturi cos)
        {
            InitializeComponent();
            myCos = cos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sum = textBox4.Text.ToString();
            myCos.addMoney(int.Parse(sum));
        }

        private void preia_CheckedChanged(object sender, EventArgs e)
        {
            string[] informatii = new string[4];
            string mesaj_conexiune = "Data Source=DESKTOP-O344N69;Initial Catalog=ABD;Integrated Security=True;";
            SqlConnection con = new SqlConnection(mesaj_conexiune);
            con.Open();
            string query = "SELECT NumarCard,CIV,An,Luna from UtilizatorSimplu WHERE Email=@mail";
            using (SqlCommand cmd = new SqlCommand(query,con))
            {
                cmd.Parameters.AddWithValue("@mail", myCos.info[2]);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    informatii[0] = reader["NumarCard"].ToString();
                    informatii[1] = reader["CIV"].ToString();
                    informatii[2] = reader["An"].ToString();
                    informatii[3] = reader["Luna"].ToString();
                }
                if (informatii[0] == null)
                    MessageBox.Show("Nu exista niciun card inregistrat pentru acest Utilizator!");
                else
                {
                    NumarCard.Text = informatii[0];
                    NumePosesor.Text = myCos.info[0] + " " + myCos.info[1];
                    Luna.Text = informatii[3];
                    An.Text = informatii[2];
                }
               


            }
            con.Close();
            
        }

        private void salvare_CheckedChanged(object sender, EventArgs e)
        {
            string[] informatii = new string[4];
            string mesaj_conexiune = "Data Source=DESKTOP-O344N69;Initial Catalog=ABD;Integrated Security=True;";
            SqlConnection con = new SqlConnection(mesaj_conexiune);
            con.Open();
            string query = "UPDATE UtilizatorSimplu set NumarCard=@NumarCard,CIV=@CIV,An=@An,Luna=@Luna where Email=@email";
            if (!verify_CardNumber())
                MessageBox.Show("Numarul de card trebuie sa contina 16 cifre!");
            if (!verify_CIV())
                MessageBox.Show("CIV-ul trebuie sa aiba 3 cifre!");
            
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@NumarCard", NumarCard.Text);
                cmd.Parameters.AddWithValue("@CIV", int.Parse(Civ.Text));
                cmd.Parameters.AddWithValue("@An", int.Parse(An.Text));
                cmd.Parameters.AddWithValue("@Luna", int.Parse(Luna.Text));
                cmd.Parameters.AddWithValue("@Email", myCos.info[2]);
                cmd.ExecuteNonQuery();

            }
            con.Close();

        }
        private bool verify_CardNumber()
        {
            if (NumarCard.Text.Length != 16)
                return false;
            return true;
        }
        private bool verify_CIV()
        {
            if (Civ.Text.Length != 3)
                return false;
            return true;
        }
    }
}
