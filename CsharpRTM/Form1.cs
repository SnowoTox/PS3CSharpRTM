using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;

namespace CsharpRTM
{
    public partial class Form1 : Form
    {
        public static PS3API PS3 = new PS3API();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
            MessageBox.Show("API Changed to CCAPI!", "API Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
            MessageBox.Show("API Changed To TMAPI!", "API Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PS3.ConnectTarget(0);
                label16.Text = "Connected!";
                label16.ForeColor = Color.Green;
            }
            catch
            {
                MessageBox.Show("Could not connect! Is the PS3 even on? lol", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label16.Text = "Failed!";
                label16.ForeColor = Color.Gold;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PS3.AttachProcess();
                label18.Text = "Attached!";
                label18.ForeColor = Color.Green;
            }
            catch
            {
                MessageBox.Show("Could not attach to the process! Is the process active?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label18.Text = "Failed!";
                label18.ForeColor = Color.Gold; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 1)
            {
                PS3.CCAPI.SetConsoleLed(CCAPI.LedColor.Red, CCAPI.LedMode.On);
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 2)
            {
                PS3.CCAPI.SetConsoleLed(CCAPI.LedColor.Red, CCAPI.LedMode.Off);
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 3)
            {
                PS3.CCAPI.SetConsoleLed(CCAPI.LedColor.Red, CCAPI.LedMode.Blink);
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1)
            {
                PS3.CCAPI.SetConsoleLed(CCAPI.LedColor.Green, CCAPI.LedMode.On);      
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 2)
            {
                PS3.CCAPI.SetConsoleLed(CCAPI.LedColor.Green, CCAPI.LedMode.Off);
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 3)
            {
                PS3.CCAPI.SetConsoleLed(CCAPI.LedColor.Green, CCAPI.LedMode.Blink);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.TROPHY4, textBox1.Text);
            // Adding selectable Icon support later... but would take too long to write all of them..
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.RingBuzzer(CCAPI.BuzzerMode.Single);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.RingBuzzer(CCAPI.BuzzerMode.Double);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.RingBuzzer(CCAPI.BuzzerMode.Triple);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.RingBuzzer(CCAPI.BuzzerMode.Continuous);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.ShutDown(CCAPI.RebootFlags.SoftReboot);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.ShutDown(CCAPI.RebootFlags.HardReboot);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.ShutDown(CCAPI.RebootFlags.ShutDown);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label11.Text = PS3.CCAPI.GetTemperatureCELL();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            label12.Text = PS3.CCAPI.GetTemperatureRSX();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label13.Text = PS3.CCAPI.GetFirmwareVersion();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            label14.Text = PS3.CCAPI.GetFirmwareType();
        }
    }
}
