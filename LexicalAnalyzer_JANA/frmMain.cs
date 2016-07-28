using System;
using System.Windows.Forms;

namespace LexicalAnalyzer_JANA
{
    public partial class frmMain : Form
    {
        public static frmMain Self;
        public frmMain()
        {
            InitializeComponent();
            Self = this;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (btnAnalyze.Text == "Analyze")
            {
                btnAnalyze.Text = "Reset";

                Analyzer Lex = new Analyzer();
                txtOut.Text = Lex.analyze(txtIn.Text);

            } else
            {
                btnAnalyze.Text = "Analyze";
                txtIn.Clear();
                txtOut.Clear();
                dGridResults.Rows.Clear();
            }
        }
    }
}
