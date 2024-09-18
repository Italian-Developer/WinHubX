namespace WinHubX.Forms.Base
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            SetMarquee(); // Imposta la progressBar in modalità Marquee all'inizio
        }

        // Imposta la progressBar in modalità Marquee
        public void SetMarquee()
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            lblStatus.Text = "Operazione in corso...";
        }

        // Imposta lo stato e, se necessario, aggiorna il valore della progressBar
        public void SetStatus(string status, int percentComplete)
        {
            lblStatus.Text = status;
            // Se la progressBar è in modalità Blocks, aggiorna il valore
            if (progressBar.Style == ProgressBarStyle.Blocks)
            {
                progressBar.Value = percentComplete;
            }
        }

        // Completa l'operazione impostando la progressBar al 100%
        public void CompleteOperation()
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;
            lblStatus.Text = "Operazione completata";
        }
    }
}

