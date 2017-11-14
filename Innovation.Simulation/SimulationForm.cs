using System.Windows.Forms;
using System;
using Sockets.Plugin;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Innovation.Simulation
{
    public partial class SimulationForm : Form
    {

        private static Timer myTimer = new Timer();
        private TcpSocketClient client = new TcpSocketClient();
        private Model myModel = new Model();
        private int numCasEnabled = 0;

        public SimulationForm()
        {
            InitializeComponent();
            myTimer.Tick += new EventHandler(DisplayMasterTime);

            // Sets the timer interval to 1 seconds.
            myTimer.Interval = 1000;
            myTimer.Start();

            var port = 12000;
            var address = "127.0.0.1";
            client.ConnectAsync(address, port);

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
            numCasEnabled += ch.Checked ? 1 : -1;

            myModel.casEnabled = numCasEnabled >= 0;
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
    }

}
