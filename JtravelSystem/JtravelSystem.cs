using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JtravelSystem.FlightAndGuest;
using JtravelSystem.Class;

namespace JtravelSystem
{
    public partial class JtravelSystem : Form
    {
        classDetails classDetails = new classDetails();
        public JtravelSystem()
        {

            InitializeComponent();

            guest guest = new guest();
            DatePickBookingDate.Value = DateTime.Now;

            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JtravelTicket"));
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JtravelTicket/TicketTemplate"));
            lblAgentName.Text = settings.agentName;
            richTextFlightDetails.Text = classDetails.flight +  classDetails.flight2;
            boxName.Text = classDetails.guestName;
            boxType.Text = classDetails.guestType;
            boxAddon.Text = classDetails.guestAddon;
        }
        public string airline = "";
        public static string fileLocation = "";
        public static string bookingRef = "";
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void showControl(Control control)
        {
            controlPanel.Controls.Clear();
        
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();
            controlPanel.Controls.Add(control);


        }
        private void buttonAirasia_Click(object sender, EventArgs e)
        {
            airasia airasia = new airasia();
            showControl(airasia);
        }

        private void buttonCebuPacific_Click(object sender, EventArgs e)
        {


        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings settings = new settings();
            showControl(settings);
        }

        private void btnPal_Click(object sender, EventArgs e)
        {
            palControl palControl = new palControl();
            showControl(palControl);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
        }




        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBookingRef.Text))
            {
                string myStringVariable1 = string.Empty;
                MessageBox.Show("Please enter the Booking referrence", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(textTotal.Text))
            {
                string myStringVariable2 = string.Empty;
                MessageBox.Show("Total is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //For combobox validation we should follow the below code.
            else if (String.IsNullOrEmpty(richTextFlightDetails.Text))
            {
                string myStringVariable3 = string.Empty;
                MessageBox.Show("Flight details is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(boxName.Text))
            {
                string myStringVariable3 = string.Empty;
                MessageBox.Show("Guess Details is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {

                
                if (radioCP.Checked)
                {
                    airline = "cebuPacificTemplate.dotx";
                }
                else if (radioAirA.Checked)
                {
                    airline = "airAsiaTemplate.dotx";
                }
                else if (radioPal.Checked)
                {
                    airline = "palTemplate.dotx";
                }


                Object oMissing = System.Reflection.Missing.Value;

                Object oTemplatePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JtravelTicket/TicketTemplate", airline);
                string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JtravelTicket", textBookingRef.Text + ".pdf");
                fileLocation = fileName;
                string outputName = fileName;


                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document wordDoc = new Document();

                wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

                foreach (Field myMergeField in wordDoc.Fields)
                {


                    Range rngFieldCode = myMergeField.Code;

                    String fieldText = rngFieldCode.Text;



                    // ONLY GETTING THE MAILMERGE FIELDS

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {

                        // THE TEXT COMES IN THE FORMAT OF

                        // MERGEFIELD  MyFieldName  \\* MERGEFORMAT

                        // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"

                        Int32 endMerge = fieldText.IndexOf("\\");

                        Int32 fieldNameLength = fieldText.Length - endMerge;

                        String fieldBookingDate = fieldText.Substring(11, endMerge - 11);
                        String fieldBookingRef = fieldText.Substring(11, endMerge - 11);
                        String fieldFlightDetail = fieldText.Substring(11, endMerge - 11);
                        String fieldGuestName = fieldText.Substring(11, endMerge - 11);
                        String fieldGuestType = fieldText.Substring(11, endMerge - 11);
                        String fieldGuessAddon = fieldText.Substring(11, endMerge - 11);
                        String fieldFlightDate = fieldText.Substring(11, endMerge - 11);
                        String fieldTotal = fieldText.Substring(11, endMerge - 11);
                        String fieldfromTo = fieldText.Substring(11, endMerge - 11);
                        // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE

                        fieldfromTo = fieldfromTo.Trim();
                        fieldBookingDate = fieldBookingDate.Trim();
                        fieldBookingRef = fieldBookingRef.Trim();
                        fieldFlightDetail = fieldFlightDetail.Trim();

                        fieldGuestName = fieldGuestName.Trim();
                        fieldGuestType = fieldGuestType.Trim();
                        fieldGuessAddon = fieldGuessAddon.Trim();

                        fieldFlightDate = fieldFlightDate.Trim();
                        fieldTotal = fieldTotal.Trim();
                        // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ****//

                        // THE PROGRAMMER CAN HAVE HIS OWN IMPLEMENTATIONS HERE

                        if (fieldBookingDate == "bookingDate")
                        {

                            myMergeField.Select();

                            wordApp.Selection.TypeText(DatePickBookingDate.Value.ToString("MM-dd-yyyy"));

                        }

                        if (fieldBookingRef == "bookRef")
                        {

                            myMergeField.Select();

                            wordApp.Selection.TypeText(textBookingRef.Text);

                        }

                        if (fieldFlightDetail == "flightDetails")
                        {

                            myMergeField.Select();

                            wordApp.Selection.TypeText(richTextFlightDetails.Text);

                        }

 

                        if (fieldGuestName == "guestName")
                        {

                            myMergeField.Select();

                            wordApp.Selection.TypeText(boxName.Text);

                        }

                        if (fieldGuestType == "guestType")
                        {

                            myMergeField.Select();

                            wordApp.Selection.TypeText(boxType.Text);

                        }


                        if (fieldGuessAddon == "guestAddon")
                        {

                            myMergeField.Select();

                            wordApp.Selection.TypeText(boxAddon.Text);

                        }


                        if (fieldTotal == "total")
                        {

                            myMergeField.Select();

                            wordApp.Selection.TypeText(textTotal.Text);

                        }

                        if (fieldfromTo == "flightCode")
                        {

                            myMergeField.Select();
     
                            wordApp.Selection.TypeText(classDetails.flightcode);

                        }



                    }




                }

                wordDoc.ExportAsFixedFormat(outputName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);


                System.Windows.Forms.MessageBox.Show("TICKET CREATED SUCCESSFULLY", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(fileName);
                bookingRef = textBookingRef.Text;

            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            if (radioCP.Checked)
            {
                airline = "Cebu Pacific";
            }
            else if (radioAirA.Checked)
            {
                airline = "AirAsia";
            }
            else if (radioPal.Checked)
            {
                airline = "Philippine Airline";
            }

            SendEmail Form2 = new SendEmail();
            this.Visible = false;
            Form2.Show();


        }

        private void btnInsertFlight_Click(object sender, EventArgs e)
        {
            this.Hide();
            flightDetails flight = new flightDetails();
            flight.ShowDialog();
        }

        private void bunifuCards2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEnterdata_Click(object sender, EventArgs e)
        {
            this.Hide();
            flightDetails flight = new flightDetails();
            flight.ShowDialog();
        }
    }
}
