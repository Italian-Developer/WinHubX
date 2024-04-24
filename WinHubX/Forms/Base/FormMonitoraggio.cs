using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinHubX.Forms.Base
{
    public partial class FormMonitoraggio : Form
    {
        private bool isMonitoringOn = false;
        private Button MonitoraggioButton;
        private Form1 form1;

        public FormMonitoraggio(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            StopMonitoringRam();
            StartMonitoringCPU();
        }

        private void StartMonitoringRam()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // Imposta l'intervallo a 3 secondi

            timer.Tick += (sender, e) =>
            {
                MEMORYSTATUSEX memStatus = GetMemoryStatus();
                double ramUsagePercentage = ((double)(memStatus.ullTotalPhys - memStatus.ullAvailPhys) / memStatus.ullTotalPhys) * 100;

                BarRAM.Value = (int)ramUsagePercentage;

                if (ramUsagePercentage > 40)
                {
                    CleanMemory();
                }
                Cpureduct();
                OptimizeMemory();
            };
            timer.Start();
        }

        private void StopMonitoringRam()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; // Imposta l'intervallo a 1 secondo

            timer.Tick += (sender, e) =>
            {
                MEMORYSTATUSEX memStatus = GetMemoryStatus();
                double ramUsagePercentage = ((double)(memStatus.ullTotalPhys - memStatus.ullAvailPhys) / memStatus.ullTotalPhys) * 100;

                BarRAM.Value = (int)ramUsagePercentage;
            };

            timer.Start();
            OptimizeMemory();
        }

        private void CleanMemory()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    IntPtr processHandle = OpenProcess(PROCESS_SET_QUOTA | PROCESS_QUERY_INFORMATION, false, process.Id);

                    if (processHandle != IntPtr.Zero)
                    {
                        SetProcessWorkingSetSize(processHandle, IntPtr.Zero, IntPtr.Zero);
                        EmptyWorkingSet(processHandle);
                        CloseHandle(processHandle);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private bool ReduceMemoryUse(int processId)
        {
            IntPtr processHandle = OpenProcess(PROCESS_SET_QUOTA | PROCESS_QUERY_INFORMATION, false, processId);

            if (processHandle == IntPtr.Zero)
                return false;

            bool result = EmptyWorkingSet(processHandle);

            CloseHandle(processHandle);

            return result;
        }

        private MEMORYSTATUSEX GetMemoryStatus()
        {
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            memStatus.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            GlobalMemoryStatusEx(ref memStatus);
            return memStatus;
        }

        private void OptimizeMemory()
        {
            var currentProcess = Process.GetCurrentProcess();
            ReduceMemoryUse(currentProcess.Id);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("psapi.dll")]
        private static extern bool EmptyWorkingSet(IntPtr hProcess);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetProcessWorkingSetSize(IntPtr hProcess, IntPtr dwMinimumWorkingSetSize, IntPtr dwMaximumWorkingSetSize);

        private const uint PROCESS_SET_QUOTA = 0x0100;
        private const uint PROCESS_QUERY_INFORMATION = 0x0400;

        private async void StartMonitoringCPU()
        {
            while (true)
            {
                double cpuUsagePercentage = await Task.Run(() => GetCPUUsagePercentage());
                BarCPU.Value = (int)cpuUsagePercentage;
                await Task.Delay(2000); // Attendere 2 secondi prima di aggiornare nuovamente
            }
        }

        private double GetCPUUsagePercentage()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            double cpuUsage = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            cpuUsage = cpuCounter.NextValue();
            return cpuUsage;
        }

        private void btnOttCPU_Click(object sender, EventArgs e)
        {
            Cpureduct();
        }


        private void Cpureduct()
        {
            {
                Process[] processes = Process.GetProcesses();

                foreach (Process process in processes)
                {
                    try
                    {
                        if (ProcessDaOttimizzare(process))
                        {
                            OttimizzaProcesso(process);
                        }
                        else if (ProcessDaTerminare(process))
                        {
                            process.Kill();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            static bool ProcessDaOttimizzare(Process process)
            {
                if (process.TotalProcessorTime > TimeSpan.FromSeconds(5) && process.WorkingSet64 > 200 * 1024 * 1024)
                {
                    return true;
                }

                return false;
            }

            static bool ProcessDaTerminare(Process process)
            {
                if (process.TotalProcessorTime > TimeSpan.FromSeconds(10) && process.WorkingSet64 > 500 * 1024 * 1024)
                {
                    return true;
                }

                return false;
            }

            static void OttimizzaProcesso(Process process)
            {
                process.PriorityClass = ProcessPriorityClass.BelowNormal;
            }
        }

        private void btnOttRam_Click(object sender, EventArgs e)
        {
            CleanMemory();
            OptimizeMemory();
        }

        private void bottoniSwap_CheckedChanged_1(object sender, EventArgs e)
        {
            if (bottoniSwap.Checked)
            {
                MessageBox.Show("Monitoraggio Attivo");
                StartMonitoringRam();
            }
            else
            {
                MessageBox.Show("Monitoraggio Disattivo");
                StopMonitoringRam();
            }
        }
    }
}




