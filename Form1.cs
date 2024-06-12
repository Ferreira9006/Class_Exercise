using System.Drawing.Imaging;
using System.Data.SqlClient;

namespace AutenticarV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // vars de autenticação
            string sloginName = txtUsername.Text;
            string sPassword = txtPassword.Text;

            // testar se preenchidos
            if (sloginName != "" && sPassword != "")
            {
                // Token para acesso à base de dados
                SqlConnection conexaoBD = new SqlConnection();

                // Token para acesso ao comando SQL à executar
                SqlCommand sqlCmd = new SqlCommand();

                // Sql Reader - registo(s) da tabela da BD
                SqlDataReader recordsReader;

                // SQL Connection String
                conexaoBD.ConnectionString = @"Data Source=DESKTOP-QJ9KR1M\SQLEXPRESS;Initial Catalog=autenticar;Integrated Security=True";

                //Controlar a ocorrência de erros
                try
                {

                    // Acesso à BD
                    conexaoBD.Open();

                    // Atribuição do Token da BD ao SQL Command
                    sqlCmd.Connection = conexaoBD;

                    // Passar Parametros ao comando SQL (Username & Password)
                    sqlCmd.Parameters.AddWithValue("@sLoginName", sloginName);
                    sqlCmd.Parameters.AddWithValue("@sPassword", sPassword);

                    // Query a executar
                    sqlCmd.CommandText = "SELECT * FROM tblLogin WHERE loginName = @sLoginName AND password= @sPassword";

                    // Executar o Query
                    recordsReader = sqlCmd.ExecuteReader();

                    // Se existerem registos
                    if (recordsReader.HasRows)
                    {
                        MessageBox.Show("Credenciais válidas!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Inicializar novo form
                        frmPagInicial frmPagInicial = new frmPagInicial();

                        // Mostra Novo Form
                        frmPagInicial.Show(); // O ShowDialog() deixa ativa apenas a janela que esta a ser utilizada

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Credenciais inválidas!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtUsername.Text = "";
                    }

                    recordsReader.Close();
                    conexaoBD.Close();

                }
                catch (SqlException Ex)
                {
                    MessageBox.Show(Ex.ErrorCode + " - " + Ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Preencher todos os campos!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegisto frmRegisto = new frmRegisto();
            frmRegisto.ShowDialog();
        }
    }
}
