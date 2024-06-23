namespace WinHubX
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale per l'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_Uninstalling); // Aggiungi il gestore per ApplicationExit
            Application.Run(new Form1());
        }

        private static void Application_Uninstalling(object sender, EventArgs e)
        {
            // Rimuovi le chiavi del registro qui
            Form1.RemoveRegistryKeys();
        }
    }
}