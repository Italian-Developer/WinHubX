using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHubX.Forms.Base
{
    public partial class FormDebloat : Form
    {
        private Form1 form1;
        public FormDebloat(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void btnAvviaSelezionatiDebloat_Click(object sender, EventArgs e)
        {
            if (Bloat1.CheckedItems.Contains("Calcolatrice"))
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript(@"Get-AppxPackage -allusers Microsoft.WindowsCalculator | Remove-AppxPackage");
                    var result = PowerShellInstance.Invoke();
                }
            }
            else if (Bloat1.CheckedItems.Contains("Foto"))
            {
                using (PowerShell PowerShellInstanceFoto = PowerShell.Create())
                {
                    PowerShellInstanceFoto.AddScript(@"Get-AppxPackage -allusers Microsoft.Windows.Photos | Remove-AppxPackage");
                    var result = PowerShellInstanceFoto.Invoke();
                }
            }
            else if (Bloat1.CheckedItems.Contains("Canonical"))
            {
                using (PowerShell PowerShellInstanceCanonical = PowerShell.Create())
                {
                    PowerShellInstanceCanonical.AddScript(@"Get-AppxPackage -allusers CanonicalGroupLimited.UbuntuonWindows | Remove-AppxPackage");
                    var result = PowerShellInstanceCanonical.Invoke();
                }
            }
            else if (Bloat1.CheckedItems.Contains("Xbox TCUI"))
            {
                using (PowerShell PowerShellInstanceXboxTcui = PowerShell.Create())
                {
                    PowerShellInstanceXboxTcui.AddScript(@"Get-AppxPackage -allusers Microsoft.Xbox.TCUI | Remove-AppxPackage");
                    var result = PowerShellInstanceXboxTcui.Invoke();
                }
            }
            else if (Bloat1.CheckedItems.Contains("Xbox APP"))
            {
                using (PowerShell PowerShellInstanceXboxapp = PowerShell.Create())
                {
                    PowerShellInstanceXboxapp.AddScript(@"Get-AppxPackage -allusers Microsoft.XboxApp | Remove-AppxPackage");
                    var result = PowerShellInstanceXboxapp.Invoke();
                }
            }





















        }
    }
}
