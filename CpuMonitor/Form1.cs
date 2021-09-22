using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuMonitor
{
    public partial class form : MetroFramework.Forms.MetroForm
    {
        public form()
        {
            // Vinicius Henques de Almeida - Aluno da Etec Horácio Augusto da Silveira e FullStack pela Fullture School
            //Projeto dedicado ao enriquecimento do meu portfólio no linkedIn / GitHub.

            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Variaveis de vaalor da cpu e memoria ram.
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();

            //Alteração da progress bar conforme os valores das variaveis.
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;

            //Alteração do texto de valor conforme os valores das variaveis.
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
            lblRAM.Text = string.Format("{0:0.00}%", fram);

            //Aplicação dos valores no grafico chart atraveis de points.
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Abertura do timer 
            timer.Start();

            // alteração da label variavel do nome, que armazena o nome do dispoitivo que esta sendo analisado.
            nome.Text = (Environment.MachineName);
        }
        private void btn_about_Click(object sender, EventArgs e)
        {
            //MessageBox das minhas informações 
            MessageBox.Show("Software desenvolvido pelo dev Vinicius Henques, Brasileiro, 17 anos e Fullstack Developer pela Etec Horácio & Fullture School \r\n \r\n Enjoy 😎 ");
        }

        private void btnLinkedin_Click(object sender, EventArgs e)
        {
            //Botão de redirecionamento pro meu LinkedIn
            String myLinkedin = "https://www.linkedin.com/in/vinicius-henques-5a843a1b9/";
            System.Diagnostics.Process.Start(myLinkedin);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Reinicialização / limpeza do grafico chart atraves de um foreach
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }
    }
}