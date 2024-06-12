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
    public partial class frmRegisto : Form
    {
        public frmRegisto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // testar se preenchidos
            if (username != "" && password != "")
            {
                // Token para acesso à base de dados
                SqlConnection conexaoBD = new SqlConnection();

                // Token para acesso ao comando SQL à executar
                SqlCommand sqlCmd = new SqlCommand();

                // Sql Reader - registo(s) da tabela da BD
                SqlDataReader recordsReader;

                // SQL Connection String
                conexaoBD.ConnectionString = @"Data Source=DESKTOP-QJ9KR1M\SQLEXPRESS;Initial Catalog=autenticar;Integrated Security=True";


                // Acesso à BD
                conexaoBD.Open();

                // Atribuição do Token da BD ao SQL Command
                sqlCmd.Connection = conexaoBD;

                // Passar Parametros ao comando SQL (Username & Password)
                sqlCmd.Parameters.AddWithValue("@sLoginName", username);
                sqlCmd.Parameters.AddWithValue("@sPassword", password);

                // Query a executar
                sqlCmd.CommandText = "SELECT * FROM tblLogin WHERE loginName = @sLoginName";

                // Executar o Query
                recordsReader = sqlCmd.ExecuteReader();

                // Se existerem registos
                if (recordsReader.HasRows)
                {
                    MessageBox.Show("Credenciais já utilizadas!", "Registar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                }
                else
                {
                    recordsReader.Close();
                    // Query a executar
                    sqlCmd.CommandText = "INSERT INTO tblLogin (loginName, password) VALUES (@sLoginName, @sPassword)";

                    // Executar o Query
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Utilizador registado com sucesso!", "Registar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

                recordsReader.Close();
                conexaoBD.Close();

                
        }
        else
            MessageBox.Show("Preencher todos os campos!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
