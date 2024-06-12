using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutenticarV
{
    public partial class frmPagInicial : Form
    {
        public frmPagInicial()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lstCredenciais.Clear();

            lstCredenciais.Columns.Add("ID", 50);
            lstCredenciais.Columns.Add("Username", 150);
            lstCredenciais.Columns.Add("Password", 150);
            lstCredenciais.View = View.Details;

            lstCredenciais.FullRowSelect = true;

            SqlConnection conexaoDB = new SqlConnection();

            SqlCommand sqlCmdSelect = new SqlCommand();

            SqlDataReader recordPointer;

            conexaoDB.ConnectionString = @"Data Source=DESKTOP-QJ9KR1M\SQLEXPRESS;Initial Catalog=autenticar;Integrated Security=True";

            try
            {
                conexaoDB.Open();
                sqlCmdSelect.Connection = conexaoDB;
                sqlCmdSelect.CommandText = "SELECT * FROM tblLogin";
                recordPointer = sqlCmdSelect.ExecuteReader();

                if (recordPointer.HasRows) 
                {
                    string login = "";
                    string pwd = "";
                    int cont = 0;

                    while (recordPointer.Read())
                    {
                        login = recordPointer.GetString(0);
                        pwd = recordPointer.GetString(1);
                        string indice = Convert.ToString(cont + 1);

                        string[] registo = { indice, login, pwd };

                        var lstCredenciaisView = new ListViewItem(registo);
                        lstCredenciais.Items.Add(lstCredenciaisView);

                        cont++;
                    }
                    conexaoDB.Close();
                    recordPointer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
