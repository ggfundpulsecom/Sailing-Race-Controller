using EventScheduler;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Marconi
    {
    public partial class RaceMainController : Form
        {
         private static readonly ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<MarconiRaceControllerLogic> _raceQueue;
        private Timer internalClock;
        private RelayBoardDriver relayBoard;
        private string countDownSpan= new TimeSpan(0,5,0).ToString(@"mm\:ss");
        private MarconiRaceControllerLogic _activeRace=null;
        private System.Media.SoundPlayer _soundPlayer;
        public RaceMainController ()
            {
            InitializeComponent ();
            Scheduler.OnSchedulerEvent += Scheduler_OnSchedulerEvent;
             relayBoard = RelayBoardDriver.Instance;
            _raceQueue = new List<MarconiRaceControllerLogic>();
            
            
            _soundPlayer= new SoundPlayer();
            Stream str =  Marconi.Properties.Resources.marconi_race_sound1;
            _soundPlayer = new System.Media.SoundPlayer();
            _soundPlayer.Stream=str;            
            _soundPlayer.LoadAsync();


            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Value=DateTime.Now.AddMinutes(1);
            internalClock = new Timer();
            internalClock.Interval=1000;
            internalClock.Tick += InternalClock_Tick;
            internalClock.Start();

            panelButtons.Visible=false;
            panelRaces.Visible=false;
            oblist.UseAlternatingBackColors=true;
            
            this.Status.ImageGetter = delegate (object rowObject) {

                MarconiRaceControllerLogic s = (MarconiRaceControllerLogic)rowObject;
                if (s.LastEventCode== SailingRace.RaceEventCode.W)
                        return "red";
                else if  (
                    s.LastEventCode== SailingRace.RaceEventCode.T1 ||
                    s.LastEventCode== SailingRace.RaceEventCode.T4 ||
                    s.LastEventCode== SailingRace.RaceEventCode.T5 
                    )
                    return "yellow";

                else if(s.LastEventCode== SailingRace.RaceEventCode.T0)
                    return "green";

                    else
                    return "";

                };

                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; 
                lblVersion.Text = "Running version: "  + version.ToString();
            }

        private void Scheduler_OnSchedulerEvent (SchedulerEventType type, string scheduleName)
            {
               
                if(type!=SchedulerEventType.INVOKED)
                return;
              

            }

        private void R_NewRaceEvent (object sender, RaceEvent e)
            {
            Logic_NewRaceEvent(sender,e);
            }

        private void R_NewRaceClockEvent (object sender, HighPrecisionTimer.TickEventArgs e)
            {
                Logic_NewRaceClockEvent(sender,e);
            }

        private void InternalClock_Tick (object sender, EventArgs e)
            {
                //update UI Clock
                 
                    this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                        {
                            this.lblsystemtimevalue.Text=DateTime.Now.ToString(@"HH\:mm\:ss");
                            this.Status.ImageGetter = delegate (object rowObject) {

                            MarconiRaceControllerLogic s = (MarconiRaceControllerLogic)rowObject;
                            if (s.LastEventCode== SailingRace.RaceEventCode.W)
                                    return "red";
                            else if  (
                                s.LastEventCode== SailingRace.RaceEventCode.T1 ||
                                s.LastEventCode== SailingRace.RaceEventCode.T4 ||
                                s.LastEventCode== SailingRace.RaceEventCode.T5 
                                )
                                return "yellow";

                            else if(s.LastEventCode== SailingRace.RaceEventCode.T0)
                                return "green";

                                else
                                return "";

                            };
                            oblist.SetObjects(_raceQueue,true);
                

                            });
                
                
                //update status of list view

            }


     
 

        private void oblist_Click (object sender, EventArgs e)
            {

            if(oblist.SelectedItem==null)
                return;

           

            Schedule s = Scheduler.GetSchedule((oblist.SelectedItem.RowObject as MarconiRaceControllerLogic).RaceName);
            if(s==null)
                {
                    this.buttonDelayButton.Enabled=false;
                    this.buttonundodelay.Enabled = false;
                    this.btRaceComplete.Enabled=false;
                    
                    return;
                }
            else
                {
                    this.buttonDelayButton.Enabled=true;
                    this.btRaceComplete.Enabled=true;
                    if(s.NextInvokeTime.AddMinutes(-6)>=DateTime.Now)
                        this.buttonundodelay.Enabled=true;

                }

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
                if((sender as MarconiRaceControllerLogic)!=null && (sender as MarconiRaceControllerLogic).RaceInCourse)
                    return;

                countDownSpan = (sender as MarconiRaceControllerLogic).RaceCountDown;
                
                this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                 {
                     lbCounter.Text = countDownSpan;

                     oblist.SetObjects(_raceQueue,true);
                     
                     });
               

            }

       
         private void generalRecall_Click (object sender, EventArgs e)
            {
                 relayBoard.BoardReset();
                AllLightsOff();   
            }
        private void btnRaceAbandoned_Click (object sender, EventArgs e)
            {

                relayBoard.BoardReset();
                AllLightsOff();   
            }

        private void btnIndividualRecall_Click (object sender, EventArgs e)
            {
              
                if(_activeRace==null)
                    return;
                               
                if ( _activeRace.IndividualRecallIsOn)
                { 
                 this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                 {
                    pictindividualrecall.Image = Marconi.Properties.Resources.race_off_light;
                      btnIndividualRecall.Text="Turn Individual Recall OFF";
                     });
                 _activeRace.EventIndividualRecall();

                 }
                    
                 else
                 {
                    this.BeginInvoke ((System.Windows.Forms.MethodInvoker)delegate ()
                    {
                    pictindividualrecall.Image = Marconi.Properties.Resources.general_recall;
                        btnIndividualRecall.Text="Turn Individual Recall OFF";
                     });

                 _activeRace.EventIndividualRecall();

                    }

                 

            }

        private void AllLightsOff()
            {
                this.pict1minleft.Image=Marconi.Properties.Resources.race_off_light;
               // this.pictindividualrecall.Image=Marconi.Properties.Resources.race_off_light;
               // this.pictgeneralrecall.Image=Marconi.Properties.Resources.race_off_light;
                this.pict4minleft.Image = Marconi.Properties.Resources.race_off_light;
                this.pict5minleft.Image = Marconi.Properties.Resources.race_off_light;
            
            }

        //Start the application, creates each race. 
        private void btStartRace_Click (object sender, EventArgs e)
            {
            if(dateTimePicker1.Value<=DateTime.Now.AddSeconds(10))
                {
                DialogResult dialogResult = MessageBox.Show("The time of the first date is too soon or in the past. Select a valid time for the first race", "WARNING", MessageBoxButtons.OK);
                return;

                }
             panelStart.Visible=false;
             panel1.Visible=true;
             AllLightsOff();

            int _races = int.Parse(this.textBox1.Text);
            DateTime _lastStartTime=dateTimePicker1.Value;

            
            panelButtons.Visible=true;
            panelRaces.Visible=true;

            for (int x=1;x<=_races;x++)
                {
                    MarconiRaceControllerLogic _newRace = new MarconiRaceControllerLogic();

                    _newRace.RaceName="Race " + x.ToString();
                    _newRace.RaceScheduledStartTime=_lastStartTime;
                  
                    _newRace.BoardDriver=relayBoard;
                    _newRace.InternalPlayer=_soundPlayer;

                   

                    OneTimeSchedule sc= new OneTimeSchedule("Race " + x.ToString(),_lastStartTime);
                    sc.OnTrigger += Sc_OnTrigger;

                    _raceQueue.Add(_newRace);
                    Scheduler.AddSchedule(sc);

                   _lastStartTime=  _lastStartTime.AddMinutes(6);

                }
            oblist.SetObjects(_raceQueue,true);
          
            }

        private void Sc_OnTrigger (string scheduleName)
            {
             var r = _raceQueue.Where(p=>p.RaceName==scheduleName).SingleOrDefault();

                if (r==null)
                    MessageBox.Show("The scheduled race does not exists anymore.");

               

                _activeRace =r;

                r.NewRaceClockEvent += R_NewRaceClockEvent;

                r.NewRaceEvent += R_NewRaceEvent;
            
                r.StartCountDown();
          
                pict5minleft.Image=Marconi.Properties.Resources.race_red_light;
           
                pict5minleft.Image=Marconi.Properties.Resources.race_red_light;

               

            }

       
        private void buttonDelayButton_Click (object sender, EventArgs e)
            {
            MarconiRaceControllerLogic rcl = oblist.SelectedObject as MarconiRaceControllerLogic;
            if(rcl==null)
                return;


            foreach (var item in _raceQueue.Where(p=>p.RaceScheduledStartTime>=DateTime.Now && p.RaceScheduledStartTime>=rcl.RaceScheduledStartTime).ToList())
            {
                item.RaceScheduledStartTime = item.RaceScheduledStartTime.AddMinutes(5);

                var sched = Scheduler.GetSchedule(item.RaceName);
                
                Scheduler.RemoveSchedule(item.RaceName);

                OneTimeSchedule sc= new OneTimeSchedule(item.RaceName ,item.RaceScheduledStartTime);
                sc.OnTrigger += Sc_OnTrigger;

                Scheduler.AddSchedule(sc);

            }
            
             oblist.SetObjects(_raceQueue,true); 
            buttonDelayButton.Enabled=false;        
            }

        private void buttonundodelay_Click (object sender, EventArgs e)
            {
             MarconiRaceControllerLogic rcl = oblist.SelectedObject as MarconiRaceControllerLogic;
            if(rcl==null)
                return;


            foreach (var item in _raceQueue.Where(p=>p.RaceScheduledStartTime.AddMinutes(-6)>=DateTime.Now).ToList())            {
                item.RaceScheduledStartTime = item.RaceScheduledStartTime.AddMinutes(-5);
            }
            
             oblist.SetObjects(_raceQueue,true); 
            buttonDelayButton.Enabled=false;   
            }

        private void buttonReset_Click (object sender, EventArgs e)
            {
                    DialogResult dialogResult = MessageBox.Show("Please confirm you want to reset all races and shut down all lights.", "WARNING: Reset All Races", MessageBoxButtons.OKCancel);
                if(dialogResult == DialogResult.OK)
                {
                         
                    AllLightsOff();
                    

                    relayBoard.BoardReset();
            
                    countDownSpan = new TimeSpan(0,5,0).ToString(@"mm\:ss");
             
                    lbCounter.Text = countDownSpan;
              
           
                    panel1.Visible=false;
                    panelButtons.Visible=false;
                    panelStart.Visible=true;
                    panelRaces.Visible=false;
              if(_activeRace!=null)
                _activeRace.EventReset();

                foreach (var item in _raceQueue)
                    {
                       
                       item.NewRaceClockEvent -= R_NewRaceClockEvent;

                       item.NewRaceEvent -= R_NewRaceEvent;
                       item.EventReset();
                     
                    try
                        {
                            var sc=Scheduler.GetSchedule(item.RaceName);
                            sc.OnTrigger -= Sc_OnTrigger;

                            Scheduler.RemoveSchedule(item.RaceName);

                        }
                    catch (Exception ex)
                        {
                        log.Warn(ex);
                        }
                    }
                    _raceQueue.Clear();

                    btnIndividualRecall.Enabled=false;
                    btGeneralRecall.Enabled=false;
                    dateTimePicker1.Value=DateTime.Now.AddMinutes(1);

               
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    //do something else
                }
            }

        private void btntestlights_Click (object sender, EventArgs e)
            {
            new RelayTestForm();
            }

        private void oblist_SelectedIndexChanged (object sender, EventArgs e)
            {

            }

        private void panel1_Paint (object sender, PaintEventArgs e)
            {

            }
        }
    }
