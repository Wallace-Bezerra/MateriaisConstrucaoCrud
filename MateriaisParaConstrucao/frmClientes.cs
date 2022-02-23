using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriaisParaConstrucao
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        Clientes novoClientes;
        private void rbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPessoaFisica.Checked)
            {
                gbDocumentosPessoaFisica.Visible = true;
                gbDocumentosPessoaJuridica.Visible = false;
            }
        }

        private void rbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPessoaJuridica.Checked)
            {
                gbDocumentosPessoaJuridica.Visible = true;
                gbDocumentosPessoaFisica.Visible = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                novoClientes = new Clientes();

                if (rbPessoaFisica.Checked)
                {
                    novoClientes.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text,
                        txtEstado.Text, txtTelefone1.Text, txtTelefone2.Text, txtEmail.Text, dtpDataCadastro.Value.Date,
                        dtpNascimento.Value.Date, txtObservacao.Text);

                    DataTable dadosTabela = new DataTable();
                    novoClientes = new Clientes();
                    dadosTabela = novoClientes.Listar();

                   // dtgClientes.DataSource = dadosTabela;
                    novoClientes = new Clientes();
                    novoClientes.SalvarPessoaFísica(Convert.ToInt32(dadosTabela.Rows[0]["ID_CLIENTE"]), txtRg.Text, txtCpf.Text);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                else
                {
                    novoClientes.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text,
                        txtEstado.Text, txtTelefone1.Text, txtTelefone2.Text, txtEmail.Text, dtpDataCadastro.Value.Date,
                        dtpNascimento.Value.Date, txtObservacao.Text);

                    DataTable dadosTabela = new DataTable();
                    novoClientes = new Clientes();
                    dadosTabela = novoClientes.Listar();

                    novoClientes = new Clientes();
                    novoClientes.SalvarPessoaJuridica(Convert.ToInt32(dadosTabela.Rows[0]["ID_CLIENTE"]), txtCnpj.Text, txtIe.Text);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarClientes()
        {
            Clientes clientes = new Clientes();
            dtgClientes.DataSource = clientes.Listar();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }
    }
}
