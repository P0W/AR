using System.Windows.Forms;
using System;
using Sockets.Plugin;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Innovation.AR;

namespace Innovation.Simulation
{
    public partial class SimulationForm : Form
    {

        private static Timer myTimer = new Timer();
        private TcpSocketClient client = new TcpSocketClient();
        private DataModel myModel = new DataModel();
        private int numCasEnabled = 0;

        private string tcpserverAddress = "127.0.0.1";
        private int tcpServerPort = 12000;

        public SimulationForm()
        {
            InitializeComponent();
            myTimer.Tick += new EventHandler(DisplayMasterTime);

            // Sets the timer interval to 1 seconds.
            myTimer.Interval = 1000;
            myTimer.Start();

            tcpAddress.Text = tcpserverAddress;
            tcpPort.Text = tcpServerPort.ToString();



        }


        async Task Send()
        {
            var text = JsonConvert.SerializeObject(myModel);
            byte[] toBytes = Encoding.ASCII.GetBytes(text);


            client.WriteStream.Write(toBytes, 0, toBytes.Length);

            await client.WriteStream.FlushAsync();

            // wait a little before sending the next bit of data
            await Task.Delay(TimeSpan.FromMilliseconds(500));
        }

        private void DisplayMasterTime(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now.ToLocalTime();

            masterTime.Text = now.ToString("HH:mm:ss");
        }

        private async void redRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var r = sender as RadioButton;
            if (r.Checked)
            {
                myModel.airdropLight = 1;
                await Send();
            }
        }

        private async void yellowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var r = sender as RadioButton;
            if (r.Checked)
            {
                myModel.airdropLight = 2;
                await Send();
            }
        }

        private async void greenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var r = sender as RadioButton;
            if (r.Checked)
            {
                myModel.airdropLight = 3;
                await Send();
            }
        }

        private async void radarAltitude_TextChanged(object sender, EventArgs e)
        {
            myModel.radarAltitude = radarAltitude.Text;
            await Send();
        }

        private async void timeToDrop_TextChanged(object sender, EventArgs e)
        {
            myModel.timeToDrop = timeToDrop.Text;
            await Send();
        }

        private async void idleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var r = sender as RadioButton;
            if (r.Checked)
            {
                myModel.airdropLight = 0;
                await Send();
            }
        }

        private async void casEnabled(CheckBox ch)
        {
            if (ch.Checked)
            {
                myModel.casMsgList.Add(ch.Text);
                myModel.textToSpeech = ch.Text;
                numCasEnabled++;

            }
            else
            {
                myModel.casMsgList.Remove(ch.Text);
                numCasEnabled--;
            }

            myModel.casEnabled = numCasEnabled > 0;
            await Send();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            casEnabled(sender as CheckBox);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            casEnabled(sender as CheckBox);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            casEnabled(sender as CheckBox);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            casEnabled(sender as CheckBox);
        }

        private void loadMasterTextToSpeech_TextChanged(object sender, EventArgs e)
        {

        }

        private void tCPDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcpPanel.Visible = true;
        }

        private void tcpAddress_TextChanged(object sender, EventArgs e)
        {
            tcpserverAddress = tcpAddress.Text;
        }

        private void tcpPort_TextChanged(object sender, EventArgs e)
        {
            tcpServerPort = int.Parse(tcpPort.Text);
        }

        private async void tcpConfirm_Click(object sender, EventArgs e)
        {
            tcpPanel.Visible = false;

            await client.ConnectAsync(tcpserverAddress, tcpServerPort);
        }

        private async void sendTextForSpeech_Click(object sender, EventArgs e)
        {
            myModel.textToSpeech = loadMasterTextToSpeech.Text;
            await Send();
        }
    }

}
