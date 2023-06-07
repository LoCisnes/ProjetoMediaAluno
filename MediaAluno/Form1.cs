using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaAluno
{
    public partial class frmCalculoMedia : Form
    {
        public frmCalculoMedia()
        {
            InitializeComponent();
        }

        private void frmCalculoMedia_Load(object sender, EventArgs e)
        {

        }

        private void txtNota1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void cboPesoNota2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numNotaCorte_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            //Variáveis responsáveis por receberem as notas calculadas com peso.
            double Nota1, Nota2, Trabalho;

            // Converte o conteúdo dos componentes TextBox e ComboBox para double e realiza a multiplicação dos mesmo.
            Nota1 = Convert.ToDouble(txtNota1.Text) * Convert.ToDouble(cboPesoNota1.Text);
            Nota2 = double.Parse(txtNota2.Text) * double.Parse(cboPesoNota2.Text);
            Trabalho = Convert.ToDouble(txtTrabalho.Text) * Convert.ToDouble(cboTrabalho.Text);

            //Soma as variáveis para obter as médias
            double Media = Nota1 + Nota2 + Trabalho;

            txtMediaFinal.Text = Media.ToString();//Convertendo e atribuindo a variável Media para txtMediaFinal.

            //Variáveis respnsáveis por receberem as quantidades de aulas e faltas
            double QtdAulas, QtdFaltas;

            //converte o conteúdo dos componentes TextBox( Qdt Aulas e Qtd Faltas)
            QtdAulas = Convert.ToDouble(txtQtdAulas.Text);
            QtdFaltas = Convert.ToDouble(txtQtdFaltas.Text);

            //Realiza a conta necessária para se achar a presença do aluno
            double PorcentagemPresenca = 100 - ((QtdFaltas / QtdAulas) * 100);

            //Realiza a conta do aproveitamento do aluno e converte o valor em string para ser exibido no txtaproveitamento 
            txtAproveitamento.Text = Convert.ToString(((Media * 10) + (PorcentagemPresenca)) / 2) + "%";

            if (txtRecuperacao.Text == "")
            {
                if (Media >= Convert.ToDouble(numNotaCorte.Value) && PorcentagemPresenca >= 75)
                {
                    lblSituacao.Text = "Aprovado";
                    lblSituacao.ForeColor = Color.Green;
                }

                    //Caso if anterior retorna falso, será verificado se a média obtida é menor que 2,5
                //OU se a presença for inferior a 75%
                else
                    if (Media <= 2.5 || PorcentagemPresenca < 75)
                    {
                        lblSituacao.Text = "Reprovado"; //Irá aparecer reprovado no campo lblSituacao.Text,
                        lblSituacao.ForeColor = Color.Firebrick; // com a cor vermelha.
                    }

                        // No caso de If e Else retornarem falsos, obrigatóriamente a execução irá passar por esse Else
                    else
                    {
                        lblSituacao.Text = "Recuperação";// irá aparecer no campo lblsituacao.Text,
                        lblSituacao.ForeColor = Color.Firebrick; // com a cor vermelha
                    }
            }
            
            //No caso do campo lblRecuperecao possuir conteúdo, a execução do programa será desviada para este Else
            else
            {
                //Calculo da nova média, somando-a ela mesma com o conteúdo  do componente txtRecuperacao e dividido por 2
                Media = (Media + Convert.ToDouble(txtRecuperacao.Text)) / 2;

                //Atribuição do novo cálculo sobre aproveitamento  do aluno para o campo txtAproveitameto
                txtAproveitamento.Text = Convert.ToString(((Media * 10) + (PorcentagemPresenca)) / 2) + "%";

                //A partir da nova média é verificado se o aluno atingiu nota igual ou maior a 5
                if (Media >= 5)
                {
                    // Se a ondição for verdade, então:
                    lblSituacao.Text = "Aprovado";// O texto aprovado aparecerá no campo lblSituacao.Text,
                    lblSituacao.ForeColor = Color.Green;// Na cor verde.
                }


                    //Caso o if acima retorne falso, será executado as instruções que estão no Else abaixo:
                else
                {
                    lblSituacao.Text = "Reprovado";// Irá aparecer Reprovado no campo lblSituacao.Text,
                    lblSituacao.ForeColor = Color.Firebrick;// Na cor vermelha  
                }
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblSituacao.Text = "";
            txtRecuperacao.Text = string.Empty;

            //Laço de repetição que irá percorrer todos os componentes do formulário 
            foreach(Control Componente in this.Controls)
            { 
                if(Componente is TextBox)
                {
                    (Componente as TextBox).Clear();
                }

                else
                    if (Componente is ComboBox)
                    {
                        (Componente as ComboBox).SelectedIndex = -1;
                    }
                    else
                        if (Componente is NumericUpDown)
                        {
                            (Componente as NumericUpDown).Value = 5;
                        }
                    }


            
        }

        private void cboPesoNota1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
        