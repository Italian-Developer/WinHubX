using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace WinHubX.Forms.Personalizzazione_office
{
    public partial class PersonalizzazioneOffice : Form
    {
        private Form1 form1;
        private FormOffice formoffice;

        public PersonalizzazioneOffice(Form1 form1, FormOffice formoffice)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formoffice = formoffice;
            radiobutton_office2021.Checked = false;
            radiobutton_office365.Checked = false;
            this.ActiveControl = progressBar_office;
        }

        private void btn_avviainstallazione_Click(object sender, EventArgs e)
        {
            if (radiobutton_office2021.Checked)
            {
                if (radioButton_x64.Checked)
                {
                    string xmlFilePath = @"C:\Configurazione2021x64.xml";
                    ExtractAndSaveResource("Configurazione2021x64.xml", xmlFilePath);

                    if (checkBox_visio.Checked)
                    {
                        AddElementToXml(xmlFilePath, CreateVisioXml());
                    }
                    if (checkBox_project.Checked)
                    {
                        AddElementToXml(xmlFilePath, CreateProjectXml());
                    }
                    if (checkBox_word.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Word");
                    }
                    if (checkBox_excel.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Excel");
                    }
                    if (checkBox_powerpoint.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "PowerPoint");
                    }
                    if (checkBox_outlook.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Outlook");
                    }
                    if (checkBox_onenote.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneNote");
                    }
                    if (checkBox_onedrive.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneDrive");
                    }
                    if (checkBox_publisher.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Publisher");
                    }
                    if (checkBox_access.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Access");
                    }

                    // Avvia l'installazione personalizzata
                    StartInstallation(xmlFilePath);
                }
                else if (radioButton_x32.Checked)
                {
                    string xmlFilePath = @"C:\Configurazione2021x32.xml";
                    ExtractAndSaveResource("Configurazione2021x32.xml", xmlFilePath);

                    if (checkBox_visio.Checked)
                    {
                        AddElementToXml(xmlFilePath, CreateVisioXml());
                    }
                    if (checkBox_project.Checked)
                    {
                        AddElementToXml(xmlFilePath, CreateProjectXml());
                    }
                    if (checkBox_word.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Word");
                    }
                    if (checkBox_excel.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Excel");
                    }
                    if (checkBox_powerpoint.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "PowerPoint");
                    }
                    if (checkBox_outlook.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Outlook");
                    }
                    if (checkBox_onenote.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneNote");
                    }
                    if (checkBox_onedrive.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneDrive");
                    }
                    if (checkBox_publisher.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Publisher");
                    }
                    if (checkBox_access.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Access");
                    }

                    // Avvia l'installazione personalizzata
                    StartInstallation(xmlFilePath);
                }
            }
            if (radiobutton_office365.Checked)
            {
                if (radioButton_x64.Checked)
                {
                    string xmlFilePath = @"C:\Configurazione365x64.xml";
                    ExtractAndSaveResource("Configurazione365x64.xml", xmlFilePath);

                    if (checkBox_visio.Checked)
                    {
                        AddElementToXml365(xmlFilePath, CreateVisioXml365());
                    }
                    if (checkBox_project.Checked)
                    {
                        AddElementToXml365(xmlFilePath, CreateProjectXml365());
                    }
                    if (checkBox_word.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Word");
                    }
                    if (checkBox_excel.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Excel");
                    }
                    if (checkBox_powerpoint.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "PowerPoint");
                    }
                    if (checkBox_outlook.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Outlook");
                    }
                    if (checkBox_onenote.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneNote");
                    }
                    if (checkBox_onedrive.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneDrive");
                    }
                    if (checkBox_publisher.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Publisher");
                    }
                    if (checkBox_access.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Access");
                    }

                    // Avvia l'installazione personalizzata
                    StartInstallation(xmlFilePath);
                }
                else if (radioButton_x32.Checked)
                {
                    string xmlFilePath = @"C:\Configurazione365x32.xml";
                    ExtractAndSaveResource("Configurazione365x32.xml", xmlFilePath);

                    if (checkBox_visio.Checked)
                    {
                        AddElementToXml365(xmlFilePath, CreateVisioXml365());
                    }
                    if (checkBox_project.Checked)
                    {
                        AddElementToXml365(xmlFilePath, CreateProjectXml365());
                    }
                    if (checkBox_word.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Word");
                    }
                    if (checkBox_excel.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Excel");
                    }
                    if (checkBox_powerpoint.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "PowerPoint");
                    }
                    if (checkBox_outlook.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Outlook");
                    }
                    if (checkBox_onenote.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneNote");
                    }
                    if (checkBox_onedrive.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "OneDrive");
                    }
                    if (checkBox_publisher.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Publisher");
                    }
                    if (checkBox_access.Checked)
                    {
                        RemoveElementFromXml(xmlFilePath, "ExcludeApp", "Access");
                    }

                    // Avvia l'installazione personalizzata
                    StartInstallation(xmlFilePath);
                }
            }
        }

        private void AddElementToXml(string xmlFilePath, string xmlToAdd)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                XmlNode root = xmlDoc.DocumentElement;

                // Find the Product node for ProPlus2021Volume
                XmlNode proPlusProductNode = root.SelectSingleNode("//Product[@ID='ProPlus2021Volume']");

                if (proPlusProductNode != null)
                {
                    // Create a new Product node from the string
                    XmlDocumentFragment fragment = xmlDoc.CreateDocumentFragment();
                    fragment.InnerXml = xmlToAdd;

                    // Insert the new Product node after the ProPlus2021Volume node
                    XmlNode parentNode = proPlusProductNode.ParentNode;
                    parentNode.InsertAfter(fragment, proPlusProductNode);

                    // Update proPlusProductNode to point to the newly added node for further additions
                    proPlusProductNode = fragment.LastChild;

                    // Save the modified XML file
                    xmlDoc.Save(xmlFilePath);
                }
                else
                {
                    MessageBox.Show($"Non è stato trovato alcun nodo Product con ID='ProPlus2021Volume' nel file XML.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante l'aggiunta dell'elemento all'XML: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddElementToXml365(string xmlFilePath, string xmlToAdd)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                XmlNode root = xmlDoc.DocumentElement;

                // Find the Product node for ProPlus2021Volume
                XmlNode proPlusProductNode = root.SelectSingleNode("//Product[@ID='O365BusinessRetail']");

                if (proPlusProductNode != null)
                {
                    // Create a new Product node from the string
                    XmlDocumentFragment fragment = xmlDoc.CreateDocumentFragment();
                    fragment.InnerXml = xmlToAdd;

                    // Insert the new Product node after the ProPlus2021Volume node
                    XmlNode parentNode = proPlusProductNode.ParentNode;
                    parentNode.InsertAfter(fragment, proPlusProductNode);

                    // Update proPlusProductNode to point to the newly added node for further additions
                    proPlusProductNode = fragment.LastChild;

                    // Save the modified XML file
                    xmlDoc.Save(xmlFilePath);
                }
                else
                {
                    MessageBox.Show($"Non è stato trovato alcun nodo Product con ID='O365BusinessRetail' nel file XML.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante l'aggiunta dell'elemento all'XML: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CreateVisioXml()
        {
            // XML da aggiungere per il prodotto Visio
            string visioXml = @"
                <Product ID=""VisioPro2021Volume"" PIDKEY=""KNH8D-FGHT4-T8RK3-CTDYJ-K2HT4"">
                    <Language ID=""it-it"" />
                    <ExcludeApp ID=""Access"" />
                    <ExcludeApp ID=""Excel"" />
                    <ExcludeApp ID=""Lync"" />
                    <ExcludeApp ID=""OneDrive"" />
                    <ExcludeApp ID=""OneNote"" />
                    <ExcludeApp ID=""Outlook"" />
                    <ExcludeApp ID=""PowerPoint"" />
                    <ExcludeApp ID=""Publisher"" />
                    <ExcludeApp ID=""Word"" />
                </Product>
            ";

            return visioXml;
        }

        private string CreateProjectXml()
        {
            // XML da aggiungere per il prodotto Project
            string projectXml = @"
                <Product ID=""ProjectPro2021Volume"" PIDKEY=""FTNWT-C6WBT-8HMGF-K9PRX-QV9H8"">
                    <Language ID=""it-it"" />
                    <ExcludeApp ID=""Access"" />
                    <ExcludeApp ID=""Excel"" />
                    <ExcludeApp ID=""Lync"" />
                    <ExcludeApp ID=""OneDrive"" />
                    <ExcludeApp ID=""OneNote"" />
                    <ExcludeApp ID=""Outlook"" />
                    <ExcludeApp ID=""PowerPoint"" />
                    <ExcludeApp ID=""Publisher"" />
                    <ExcludeApp ID=""Word"" />
                </Product>
            ";

            return projectXml;
        }

        private string CreateVisioXml365()
        {
            // XML da aggiungere per il prodotto Visio
            string visioXml = @"
    <Product ID=""VisioPro2021Volume"" PIDKEY=""KNH8D-FGHT4-T8RK3-CTDYJ-K2HT4"">
      <Language ID=""it-it"" />
      <ExcludeApp ID=""Access"" />
      <ExcludeApp ID=""Excel"" />
      <ExcludeApp ID=""Groove"" />
      <ExcludeApp ID=""Lync"" />
      <ExcludeApp ID=""OneDrive"" />
      <ExcludeApp ID=""OneNote"" />
      <ExcludeApp ID=""Outlook"" />
      <ExcludeApp ID=""PowerPoint"" />
      <ExcludeApp ID=""Publisher"" />
      <ExcludeApp ID=""Teams"" />
      <ExcludeApp ID=""Word"" />
    </Product>
            ";

            return visioXml;
        }

        private string CreateProjectXml365()
        {
            // XML da aggiungere per il prodotto Project
            string projectXml = @"
    <Product ID=""ProjectPro2021Volume"" PIDKEY=""FTNWT-C6WBT-8HMGF-K9PRX-QV9H8"">
      <Language ID=""it-it"" />
      <ExcludeApp ID=""Access"" />
      <ExcludeApp ID=""Excel"" />
      <ExcludeApp ID=""Groove"" />
      <ExcludeApp ID=""Lync"" />
      <ExcludeApp ID=""OneDrive"" />
      <ExcludeApp ID=""OneNote"" />
      <ExcludeApp ID=""Outlook"" />
      <ExcludeApp ID=""PowerPoint"" />
      <ExcludeApp ID=""Publisher"" />
      <ExcludeApp ID=""Teams"" />
      <ExcludeApp ID=""Word"" />
    </Product>
            ";

            return projectXml;
        }

        private void ExtractAndSaveResource(string resourceName, string destinationPath)
        {
            try
            {
                // Assembly corrente (dove sono le risorse incorporate)
                Assembly currentAssembly = Assembly.GetExecutingAssembly();

                // Path completo della risorsa incorporata
                string resourcePath = "WinHubX.Resources.OfficePersonalizzato." + resourceName;

                // Leggi il contenuto della risorsa
                using (Stream resourceStream = currentAssembly.GetManifestResourceStream(resourcePath))
                {
                    if (resourceStream == null)
                    {
                        MessageBox.Show("Impossibile trovare la risorsa specificata.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Scrivi il contenuto della risorsa su file
                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create))
                    {
                        resourceStream.CopyTo(fileStream);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante l'estrazione e il salvataggio della risorsa: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveElementFromXml(string xmlFilePath, string elementName, string attributeValue)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                XmlNodeList elementsToRemove = xmlDoc.SelectNodes($"//{elementName}[@ID='{attributeValue}']");

                foreach (XmlNode node in elementsToRemove)
                {
                    node.ParentNode.RemoveChild(node);
                }

                xmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante la rimozione dell'elemento dall'XML: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartInstallation(string xmlFilePath)
        {
            try
            {
                progressBar_office.Value = 0;
                // Determine the path to the executable relative to the application directory
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string binExePath = Path.Combine(appDirectory, "Resources", "OfficePersonalizzato", "bin.exe");
                progressBar_office.Value = 15;
                // Check if the executable exists
                if (!File.Exists(binExePath))
                    throw new FileNotFoundException("Executable not found.", binExePath);
                progressBar_office.Value = 30;
                // Prepare the process start information
                string arguments = $"/configure \"{xmlFilePath}\"";
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = binExePath,
                    Arguments = arguments,
                    WorkingDirectory = Path.GetDirectoryName(binExePath), // Set the working directory
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Start the process
                Process.Start(startInfo);
                progressBar_office.Value = 50;
                progressBar_office.Value = 75;
                MessageBox.Show("Avviata l'installazione personalizzata.", "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Delete(xmlFilePath);
                progressBar_office.Value = 100;
            }
            catch (Exception ex)
            {
                // Inform the user about the error
                MessageBox.Show($"Si è verificato un errore durante l'avvio dell'installazione: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Office";
            form1.PnlFormLoader.Controls.Clear();
            formoffice = new FormOffice(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formoffice);
            formoffice.Show();
        }

        private void InitializeProgressBar()
        {
            progressBar_office = new ProgressBar();
            progressBar_office.Minimum = 0;
            progressBar_office.Maximum = 100;
            progressBar_office.Step = 1;
            progressBar_office.Visible = false; // Inizialmente nascosta
            Controls.Add(progressBar_office);
        }
    }
}
