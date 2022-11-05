using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App01
{
    public partial class FrmPessoa : Form
    {
        public FrmPessoa()
        {
            InitializeComponent();
        }

        private void FrmPessoa_Load(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Deseja realmente sair?", "Sair do Aplicativo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" && txtCidade.Text == "" && txtEndereco.Text == "" && txtCelular.Text == "" && txtEmail.Text == "" && txtData.Text == "")
            {
                MessageBox.Show("Não existem dados para cadastrar, por favor preencha o formulário!!", "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNome.Focus();
            }
            else
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Inserir(txtNome.Text, txtCidade.Text, txtEndereco.Text, txtCelular.Text, txtEmail.Text, txtData.Text);
                MessageBox.Show("Pessoa cadastrada com sucesso!");
                List<Pessoa> pessoas = pessoa.listapessoa();
                dgvPessoa.DataSource = pessoas;
                txtNome.Text = "";
                txtCidade.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                txtData.Text = "";

                this.txtNome.Focus();
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "")
            {
                MessageBox.Show("Por favor digite um ID válido!!");
                this.txtId.Focus();
            }
            else
            {
                int Id = Convert.ToInt32(txtId.Text.Trim());
                Pessoa pessoa = new Pessoa();
                pessoa.Localizar(Id);
                txtNome.Text = pessoa.nome;
                txtCidade.Text = pessoa.cidade;
                txtEndereco.Text = pessoa.endereco ;
                txtCelular.Text = pessoa.celular;
                txtEmail.Text = pessoa.email;
                txtData.Text =  pessoa.data;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Atualizar(Id, txtNome.Text, txtCidade.Text, txtEndereco.Text, txtCelular.Text, txtEmail.Text, txtData.Text);
            MessageBox.Show("Pessoa atualizada com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.txtNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Excluir(Id);
            MessageBox.Show("Pessoa excluida com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.txtNome.Focus();
        }

        private void dgvPessoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPessoa.Rows[e.RowIndex];
                row.Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCidade.Text = row.Cells[2].Value.ToString();
                txtEndereco.Text = row.Cells[3].Value.ToString();
                txtCelular.Text = row.Cells[4].Value.ToString();
                txtEmail.Text = row.Cells[5].Value.ToString();
                txtData.Text = row.Cells[6].Value.ToString();
            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
