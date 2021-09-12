using JtravelSystem.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JtravelSystem.FlightAndGuest
{
    public partial class flightDetails : Form
    {
        public flightDetails()
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
        public string Details ="";

        private void buttonInsert_Click(object sender, EventArgs e)
        {


                    fromto = textFromTo.Text;
                    flightdate =  DateFlightDate.Value.ToString("MM-dd-yyyy");
                    departure =   textDeparture.Text;
                    arrival =    textArrival.Text;
                    departtime = departureTime.Text;
                    arrivetime = textArrivalTime.Text;
                    flightCode = textFlightcode.Text;


                    Details = "✈ " + flightCode + "@" +
                              flightdate + "        DEPARTURE :      " + departure + "@" + departtime + "@ @ @" +
                              flightdate + "        ARRIVAL :        " + arrival + "  @" + arrivetime + "@ @";
                    Details = Details.Replace("@", Environment.NewLine);

                     classDetails classDetails = new classDetails();
                     classDetails.flight = Details;
                     classDetails.fromTo = textFromTo.Text;
                    classDetails.flightcode = flightCode;
                    this.Hide();
                    guest guest = new guest();
                    guest.Show();
            
         
        }

        private void DateFlightDate_onValueChanged(object sender, EventArgs e)
        {
      

        }

        private void textFromTo_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFlight2_Click(object sender, EventArgs e)
        {

            fromto = textFromTo.Text;
            flightdate = DateFlightDate.Value.ToString("MM-dd-yyyy");
            departure = textDeparture.Text;
            arrival = textArrival.Text;
            departtime = departureTime.Text;
            arrivetime = textArrivalTime.Text;
            flightCode = textFlightcode.Text;


            Details = "✈ " + flightCode + "@" +
                      flightdate + "        DEPARTURE :      " + departure + "@" + departtime + "@ @ @" +
                      flightdate + "        ARRIVAL :        " + arrival + "  @" + arrivetime + "@";
            Details = Details.Replace("@", Environment.NewLine);

            classDetails classDetails = new classDetails();
            classDetails.flight = Details;
            classDetails.fromTo = textFromTo.Text;
            classDetails.flightcode = flightCode;
            this.Hide();;
            flightDetails2 flightDetails2 = new flightDetails2();
            flightDetails2.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            JtravelSystem JtravelSystem = new JtravelSystem();
            JtravelSystem.Show();
         
        }
    }
}
