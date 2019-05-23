using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading.Tasks;
using log4net;
using System.Configuration;

namespace Marconi
    {
    public partial class MarconiRaceController : Form
        {
       
        private static readonly ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TimeSpan startspan = new TimeSpan(0,5,0);
        private TimeSpan span = new TimeSpan(0,5,0);
        MarconiRaceControllerLogic logic ;
        RelayBoardDriver relayBoard;
        private bool t4flag=true;
        private bool t1flag=true;
        private bool tstartflag=true;
        List<MarconiRaceControllerLogic> _raceList;

        public MarconiRaceController ()
            {
                InitializeComponent ();
                        relayBoard = RelayBoardDriver.Instance;

             logic = new MarconiRaceControllerLogic();
            _raceList=new List<MarconiRaceControllerLogic>();
            _raceList.Add(logic);

            if (ConfigurationManager.AppSettings["HornPatternEventT5"]!=null)
                    logic.HornPatternEventT5=ConfigurationManager.AppSettings["HornPatternEventT5"];
                else
                    logic.HornPatternEventT5="1,1";

            if (ConfigurationManager.AppSettings["HornPatternEventT4"]!=null)
                    logic.HornPatternEventT4=ConfigurationManager.AppSettings["HornPatternEventT4"];
                else
                    logic.HornPatternEventT4="1,1";


            if (ConfigurationManager.AppSettings["HornPatternEventT1"]!=null)
                    logic.HornPatternEventT1=ConfigurationManager.AppSettings["HornPatternEventT1"];
                else
                    logic.HornPatternEventT1="1,1";


            if (ConfigurationManager.AppSettings["HornPatternEventStart"]!=null)
                    logic.HornPatternEventStart=ConfigurationManager.AppSettings["HornPatternEventStart"];
                else
                    logic.HornPatternEventStart="1,1";


            if (ConfigurationManager.AppSettings["HornPatternEventGeneralRecall"]!=null)
                    logic.HornPatternEventGeneralRecall=ConfigurationManager.AppSettings["HornPatternEventGeneralRecall"];
                else
                    logic.HornPatternEventGeneralRecall="1,1";

              if (ConfigurationManager.AppSettings["HornPatternIndividualRecall"]!=null)
                    logic.HornPatternIndividualRecall=ConfigurationManager.AppSettings["HornPatternIndividualRecall"];
                else
                    logic.HornPatternIndividualRecall="1,1";

              System.Media.SoundPlayer _soundPlayer = new SoundPlayer();
              Stream str =  Marconi.Properties.Resources.marconi_race_sound1;
              _soundPlayer = new System.Media.SoundPlayer();
              _soundPlayer.Stream=str;            
              _soundPlayer.LoadAsync();
            
              logic.InternalPlayer = _soundPlayer;

              logic.BoardDriver=relayBoard;
              logic.EventReset();
                
                     
                    this.btGeneralRecall.Enabled=false;
                    this.btnIndividualRecall.Enabled=false;


               

               this.lblRelayBoardStatusValue.Text=relayBoard.RelayBoardMessage;
            }

        
        

      private void startRace_Click (object sender, EventArgs e)
            {

           
            AllLightsOff();

            logic.StartCountDown();
            logic.NewRaceClockEvent += Logic_NewRaceClockEvent;
            logic.NewRaceEvent += Logic_NewRaceEvent;
            pict5minleft.Image=Marconi.Properties.Resources.race_red_light;
           
                         
          
           // logic.EventT5();
                   

            pict5minleft.Image=Marconi.Properties.Resources.race_red_light;

             this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                 {

                     btStartRace.Enabled=false;
                     
                 });
           
            }

        private void Logic_NewRaceEvent (object sender, RaceEvent e)
            {
            switch (e.EventCode)
                {

                case  "T5":
                    
                     this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                  {

                        pict5minleft.Image=Marconi.Properties.Resources.race_red_light;

                     btnIndividualRecall.Enabled=true;
                     btGeneralRecall.Enabled=true;
                     
                     });

                    break;
                case "T4":
                      pict4minleft.Image=Marconi.Properties.Resources.race_red_light;
                    break;

                case "T1":
                     pict1minleft.Image=Marconi.Properties.Resources.race_red_light;
                    break;

                case "T0":
                    AllLightsOff();
                    break;
                           
                default:
                    break;
                }
            }

        private void Logic_NewRaceClockEvent (object sender, HighPrecisionTimer.TickEventArgs e)
            {
                span = startspan.Subtract (new TimeSpan (0, 0, Convert.ToInt32 (e.Duration.TotalSeconds)));

                this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                 {
                     lbCounter.Text = span.ToString ();


                     });
            }

        private void cancelRace_Click (object sender, EventArgs e)
            {
                
            AllLightsOff();
            this.pictindividualrecall.Image=Marconi.Properties.Resources.race_off_light;
            this.pictgeneralrecall.Image=Marconi.Properties.Resources.race_off_light;

            logic.EventReset();
            
            span = new TimeSpan(0,5,0);
             
            lbCounter.Text = span.ToString();
              
            btStartRace.Enabled=true;

            btnIndividualRecall.Enabled=false;
            btGeneralRecall.Enabled=false;
            
            }
         private void generalRecall_Click (object sender, EventArgs e)
            {

             logic.EventReset();
             AllLightsOff();   
            
            pictgeneralrecall.Image = Marconi.Properties.Resources.general_recall;
            
            logic.EventGeneralRecall();
            span = new TimeSpan(0,5,0);
            lbCounter.Text = span.ToString();
            btStartRace.Enabled=false;
            btnIndividualRecall.Enabled=false;
            btGeneralRecall.Enabled=false;
            }
        private void btnRaceAbandoned_Click (object sender, EventArgs e)
            {
                logic.EventReset();
                AllLightsOff();   
            }

        private void btnIndividualRecall_Click (object sender, EventArgs e)
            {
              
                
              

                if ( logic.IndividualRecallIsOn)
                { 
                 this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                 {
                    pictindividualrecall.Image = Marconi.Properties.Resources.race_off_light;
                     });
                 }
                 else
                 {
                    this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                    {
                     pictindividualrecall.Image = Marconi.Properties.Resources.general_recall;
                     });
                    }

                  logic.EventIndividualRecall();

            }

        private void btntestlights_Click (object sender, EventArgs e)
            {
           
            }
         
        void startrace_event()
            {

            }
      
        private void AllLightsOff()
            {
                this.pict1minleft.Image=Marconi.Properties.Resources.race_off_light;
               // this.pictindividualrecall.Image=Marconi.Properties.Resources.race_off_light;
               // this.pictgeneralrecall.Image=Marconi.Properties.Resources.race_off_light;
                this.pict4minleft.Image = Marconi.Properties.Resources.race_off_light;
                this.pict5minleft.Image = Marconi.Properties.Resources.race_off_light;
            
            }
        private void GeneralRecallLights()
            {
               
            

            }
    
        private void pictureBox2_Click (object sender, EventArgs e)
            {

            }
              
      

        private void MarconiRaceController_Load (object sender, EventArgs e)
            {

            }

        private void label3_Click (object sender, EventArgs e)
            {

            }
        }
    }
