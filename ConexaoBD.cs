using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_MySql
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader rd;
        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;DataBase=dbLogin;Uid=root;Pwd=;SslMode=none");
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = txtUsuario.Text;
                var senha = txtSenha.Text;
                // criar comando sql
                cmd = new MySqlCommand();
                // abre conexao
                con.Open();
                // seta a conexao do comando
                cmd.Connection = con;
                // determina o comando sql
                cmd.CommandText = "SELECT * FROM dbluser where usr='" + txtUsuario.Text + "' AND pwd='" + txtSenha.Text + "'";
                // executa o select no banco
                rd = cmd.ExecuteReader();
                // verifica se consulta retornou algo
                if (rd.Read())
                {
                    MessageBox.Show("Sucesso");
                }
                else
                {
                    MessageBox.Show("Login inválido, por favor, verfique usuario e senha");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Ocorreu um erro no sistema");
            }
        }
    }
}
