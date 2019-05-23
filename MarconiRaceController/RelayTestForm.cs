using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marconi
    {
    public partial class RelayTestForm : Form
        {
          RelayBoardDriver logic ;
        private TimeSpan span = new TimeSpan(0,5,0);

        public RelayTestForm ()
            {
            InitializeComponent ();
            
                logic = RelayBoardDriver.Instance;
            this.label1.Text = logic.RelayBoardMessage;
            }

        private void button10_Click (object sender, EventArgs e)
            {
            logic.Relay4_PowerOn();
            }

        private void btrelay1on_Click (object sender, EventArgs e)
            {
             logic.Relay1_PowerOn();

            }

        private void btrelay2on_Click (object sender, EventArgs e)
            {
                logic.Relay2_PowerOn();
            }

        private void btrelay3on_Click (object sender, EventArgs e)
            {
            logic.Relay3_PowerOn();
            }

        private void btrelay1off_Click (object sender, EventArgs e)
            {
            logic.Relay1_PowerOff();
            }

        private void btrelay2off_Click (object sender, EventArgs e)
            {
            logic.Relay2_PowerOff();
            }

        private void btrelay3off_Click (object sender, EventArgs e)
            {
            logic.Relay3_PowerOff();
            }

        private void btrelay4off_Click (object sender, EventArgs e)
            {
            logic.Relay4_PowerOff();
            }

        private void btrelay5on_Click (object sender, EventArgs e)
            {
            logic.Relay5_PowerOn();
            }

        private void btrelay6on_Click (object sender, EventArgs e)
            {
            logic.Relay6_PowerOn();
            }

        private void btrelay7on_Click (object sender, EventArgs e)
            {
            logic.Relay7_PowerOn();
            }

        private void btrelay8on_Click (object sender, EventArgs e)
            {
            logic.Relay8_PowerOn();
            }

        private void btrelay8off_Click (object sender, EventArgs e)
            {
            logic.Relay8_PowerOff();
            }

        private void btrelay7off_Click (object sender, EventArgs e)
            {
            logic.Relay7_PowerOff();
            }

        private void btrelay6off_Click (object sender, EventArgs e)
            {
            logic.Relay6_PowerOff();
            }

        private void btrelay5off_Click (object sender, EventArgs e)
            {
            logic.Relay5_PowerOff();
            }
        }
    }
