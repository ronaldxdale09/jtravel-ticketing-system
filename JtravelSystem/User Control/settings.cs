using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JtravelSystem
{
    public partial class settings : UserControl
    {
        public static string agentName = "JAMEE THERESE RIVERO";
        public static string agentEmail = "jtravelticket@gmail.com";
        public static string agentPassword = "faiic_1505";
        public settings()
        {
            InitializeComponent();
            textEmail.Text = agentEmail;
            textAgentName.Text = agentName;
            textAgentPassword.Text = agentPassword;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            agentEmail = textEmail.Text;
            agentName = textAgentName.Text;
            agentPassword = textAgentPassword.Text;
        }
    }
}
