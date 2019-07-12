using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriarClasses
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Criador criar = new Criador();
            criar.setCla(textBox1.Text);
            criar.setPro(textBox2.Text);
            CriadorBLL.validaDados(criar);
            if(Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
            }
            else
            {
                criar.setCla(CriadorBLL.ajustarLinhas(criar.getCla()));
                criar.setCla(CriadorBLL.removerAcentos(criar.getCla()));
                criar.setCla(CriadorBLL.removerCaracteresEspeciais(criar.getCla()));
                criar.prepararPro();
                criar.criarCla();
                MessageBox.Show("Arquivo criado com sucesso");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }
    }
}
