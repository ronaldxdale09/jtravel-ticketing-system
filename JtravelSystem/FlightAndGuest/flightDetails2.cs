using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JtravelSystem.Class;

namespace JtravelSystem.FlightAndGuest
{
    public partial class flightDetails2 : Form
    {
        public flightDetails2()
        {
            InitializeComponent();
            DateFlightDate.Value = DateTime.Now;

        }


        public string flightdate = "";
        public string departure = "";
        public string arrival = "";
        public string departtime = "";
        public string arrivetime = "";
        public string fromto = " ";
        public string flightCode = " ";
        public string Details2 = "";


        private void buttonInsert_Click(object sender, EventArgs e)
        {

            fromto = textFromTo.Text;
            flightdate = DateFlightDate.Value.ToString("MM-dd-yyyy");
            departure = textDeparture.Text;
            arrival = textArrival.Text;
            departtime = departureTime.Text;
            arrivetime = textArrivalTime.Text;
            flightCode = textFlightcode.Text;


            Details2 = "_______________________________________________________________________________" + " @ @" +
                       "✈ " + flightCode +" @"
                       +flightdate + "        DEPARTURE :      " + departure + "@" + departtime + "@ @ @" +
                      flightdate + "        ARRIVAL :        " + arrival + "  @" + arrivetime + "@ @";
            Details2 = Details2.Replace("@", Environment.NewLine);

            classDetails classDetails = new classDetails();
            classDetails.flight2 = Details2;
            classDetails.fromTo = textFromTo.Text;
            classDetails.flightcode2 = flightCode;
            this.Hide();
            guest guest = new guest();
            guest.Show();
        }
    }
}
