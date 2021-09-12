﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using JtravelSystem.FlightAndGuest;
using JtravelSystem.Class;
using System.Collections.Generic;
using System.Linq;

namespace JtravelSystem
{
    public partial class cebupacific : UserControl
    {
   

        public cebupacific()
        {
            InitializeComponent();
            DatePickBookingDate.Value = DateTime.Now;

            List<string> details = new List<string>();

            



        }
        public static string fileLocation = "";
        public static string bookingRef = "";
       
        private void buttonEmail_Click(object sender, EventArgs e)
        {
        

            Form formBackground = new Form();
            try
            {
                using (SendEmail uu = new SendEmail())
                {
                    formBackground.StartPosition = FormStartPosition.CenterScreen;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                    formBackground.BackColor = Color.Black;
                 
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    uu.Owner = formBackground;
                    uu.ShowDialog();
                    formBackground.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }



        }



     




        private void buttonSave_Click_1(object sender, EventArgs e)
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
            else if (String.IsNullOrEmpty(richTextGuessDetails.Text))
            {
                string myStringVariable3 = string.Empty;
                MessageBox.Show("Guess Details is Required","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {




            Object oMissing = System.Reflection.Missing.Value;

            Object oTemplatePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JtravelTicket/TicketTemplate", "cebuPacificTemplate.dotx");
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
                    String fieldGuessDetail = fieldText.Substring(11, endMerge - 11);
                    String fieldFlightDate = fieldText.Substring(11, endMerge - 11);
                    String fieldTotal = fieldText.Substring(11, endMerge - 11);
                    String fieldfromTo = fieldText.Substring(11, endMerge - 11);
                        // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE

                        fieldBookingDate = fieldBookingDate.Trim();
                    fieldBookingRef = fieldBookingRef.Trim();
                    fieldFlightDetail = fieldFlightDetail.Trim();
                    fieldGuessDetail = fieldGuessDetail.Trim();
                    fieldFlightDate = fieldFlightDate.Trim();
                    fieldTotal = fieldTotal.Trim();
                    fieldfromTo = fieldfromTo.Trim();
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

                    if (fieldGuessDetail == "guessDetails")
                    {

                        myMergeField.Select();

                        wordApp.Selection.TypeText(richTextGuessDetails.Text);

                    }



                    if (fieldTotal == "total")
                    {

                        myMergeField.Select();

                        wordApp.Selection.TypeText(textTotal.Text);

                    }
                   if (fieldfromTo == "flightCode")
                        {

                            myMergeField.Select();
                            classDetails details = new classDetails(); 
                           // wordApp.Selection.TypeText(deta);

                        }

                  


                }


               

            }
         
             wordDoc.ExportAsFixedFormat(outputName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
    
            
            System.Windows.Forms.MessageBox.Show("TICKET CREATED SUCCESSFULLY","SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(fileName);
            bookingRef = textBookingRef.Text;

            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is currently not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnInsertFlight_Click(object sender, EventArgs e)
        {

            JtravelSystem JtravelSystem = new JtravelSystem();
            this.Hide();
            flightDetails flight = new flightDetails();
            flight.Show();

        }

        private void btnInsertGuest_Click(object sender, EventArgs e)
        {
 
            guest guest = new guest();
            guest.Show();
            
       
        }

        private void btnInsertFlight_Click_1(object sender, EventArgs e)
        {
            JtravelSystem jtravel = new JtravelSystem();
            jtravel.Hide();
            flightDetails flight = new flightDetails();
            flight.ShowDialog();
        }
    }
}
