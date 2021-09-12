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
    public partial class guest : Form
    {
        public guest()
        {
            InitializeComponent();

    
        }

        public static string guestName;
        public static string guestType;
        public static string guestAddon;
        public static string GuestfromTo;

        private void guest_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            string name1, type1, addon1;
            string name2, type2, addon2;
            string name3, type3, addon3;
            string name4, type4, addon4;
            string name5, type5, addon5;
  

            name1 = textGuest1.Text;
            name2 = textGuest2.Text;
            name3 = textGuest3.Text;
            name4 = textGuest4.Text;
            name5 = textGuest5.Text;
     

            type1 = typeGuest1.selectedValue;
            type2 = typeGuest2.selectedValue;
            type3 = typeGuest3.selectedValue;
            type4 = typeGuest4.selectedValue;
            type5 = typeGuest5.selectedValue;
        

            addon1 = guestAdd1.Text;
            addon2 = guestAdd2.Text;
            addon3 = guestAdd3.Text;
            addon4 = guestAdd4.Text;
            addon5 = guestAdd5.Text;

            string FromTo = "";
            flightDetails flight = new flightDetails();
            classDetails classDetails = new classDetails();
            

            FromTo = classDetails.fromTo;
            if (string.IsNullOrEmpty(textGuest2.Text)) {
                guestName = name1 + " ["+ type1+ "]" + "@ @ ";
                GuestfromTo = FromTo + " @ @";
                guestAddon = addon1 + " @ @";
            }
            else if (string.IsNullOrEmpty(textGuest3.Text))
            {
            
                guestName = name1 + " [" + type1 + "]" + " @ @" + name2  + " [" + type2 + "]" + " @ @";
                guestType = FromTo + " @ @" + FromTo + " @ @";
                guestAddon = addon1 + " @ @" + addon2 + " @ @";

     

            }
            else if (string.IsNullOrEmpty(textGuest4.Text))
            {
            

                guestName = name1 + " [" + type1 + "]" + " @ @" + name2 + " [" + type2 + "]" + " @ @" + name3 + " [" + type3 + "]" + " @ @";
                guestType = FromTo + " @ @" + FromTo + " @ @" + FromTo + " @ @";
                guestAddon = addon1 + " @ @" + addon2 + " @ @" + addon3 + " @ @";


            }

            else if  (string.IsNullOrEmpty(textGuest5.Text))
            {
                


                guestName = name1 + " [" + type1 + "]" + " @ @" + name2 + " [" + type2 + "]" + " @ @" + name3 + " [" + type3 + "]" + " @ @" + name4 + " [" + type4 + "]" + " @ @";
                guestType = FromTo + " @ @" + FromTo + " @ @" + FromTo + " @ @" + FromTo + " @ @";
                guestAddon = addon1 + " @ @" + addon2 + " @ @" + addon3 + " @ @" + addon4 + " @ @";


            }

            else {
                guestName = name1 + " [" + type1 + "]" + " @ @" + name2 + " [" + type2 + "]" + " @ @" + name3 + " [" + type3 + "]" + " @ @" + name4 + " [" + type4 + "]" + " @ @" + name5 + " [" + type5 + "]" + " @ @";
                guestType = FromTo + " @ @" + FromTo + " @ @" + FromTo + " @ @" + FromTo + " @ @" + FromTo + " @ @";
                guestAddon = addon1 + " @ @" + addon2 + " @ @" + addon3 + " @ @" + addon4 + " @ @" + addon5 + " @ @";

            }

  


            guestName = guestName.Replace("@", Environment.NewLine);
                classDetails.guestName = guestName;

            guestType = guestType.Replace("@", Environment.NewLine);
            classDetails.guestType = guestType;


            guestAddon = guestAddon.Replace("@", Environment.NewLine);
            classDetails.guestAddon = guestAddon;

            this.Hide();
            JtravelSystem jtravel = new JtravelSystem();
            jtravel.ShowDialog();

        }
    }
}
