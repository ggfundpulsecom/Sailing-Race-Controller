using FTD2XX_NET;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Marconi
    {
    public class MarconiRaceControllerLogic :SailingRace
        {
         private static readonly ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string RaceName { get;set;}
        public DateTime RaceScheduledStartTime { get;set;}
        public DateTime RaceStartTime { get;private set;}
        public DateTime RaceEndTime{get;set;}
        public string RaceCategory { get;set;}

        public bool RaceInCourse { get {return _raceInCourse; } }
       
        public string RaceCountDown {
            get {
                if(RaceInCourse)
                    _raceCountDown=(DateTime.Now.Subtract(RaceStartTime));

                return _raceCountDown.ToString(@"mm\:ss");
                }

            } 
        public bool RaceCancelled { get { return _raceCancelled;} }

        public bool IndividualRecallIsOn { get { return _individualRecall;}  }

        public bool GeneralRecallIsOn {get {return _generalRecall;}}

        public RelayBoardDriver BoardDriver
            {
            get { return _boardDriver;}
            set { _boardDriver = value;}
            }

       public System.Media.SoundPlayer InternalPlayer { get;set;}
            

        private bool _raceInCourse;
        private bool _raceCancelled;
        private TimeSpan _raceCountDown = new TimeSpan(0,5,0);

       
        private bool _generalRecall;
        private bool _individualRecall;



        public event EventHandler<RaceEvent> NewRaceEvent;
        public event EventHandler<HighPrecisionTimer.TickEventArgs> NewRaceClockEvent;
        private TimeSpan span= new TimeSpan(0,5,0);
            
        private HighPrecisionTimer _timer;
        public RaceEventCode LastEventCode;
        private RelayBoardDriver _boardDriver;
     
        public MarconiRaceControllerLogic()
                {
                         
            this.LastEventCode=RaceEventCode.W;


            if (ConfigurationManager.AppSettings["HornPatternEventT5"]!=null)
                    HornPatternEventT5=ConfigurationManager.AppSettings["HornPatternEventT5"];
                else
                    HornPatternEventT5="1,1";

            if (ConfigurationManager.AppSettings["HornPatternEventT4"]!=null)
                    HornPatternEventT4=ConfigurationManager.AppSettings["HornPatternEventT4"];
                else
                    HornPatternEventT4="1,1";


            if (ConfigurationManager.AppSettings["HornPatternEventT1"]!=null)
                    HornPatternEventT1=ConfigurationManager.AppSettings["HornPatternEventT1"];
                else
                    HornPatternEventT1="1,1";


            if (ConfigurationManager.AppSettings["HornPatternEventStart"]!=null)
                    HornPatternEventStart=ConfigurationManager.AppSettings["HornPatternEventStart"];
                else
                    HornPatternEventStart="1,1";


            if (ConfigurationManager.AppSettings["HornPatternEventGeneralRecall"]!=null)
                    HornPatternEventGeneralRecall=ConfigurationManager.AppSettings["HornPatternEventGeneralRecall"];
                else
                    HornPatternEventGeneralRecall="1,1";

              if (ConfigurationManager.AppSettings["HornPatternIndividualRecall"]!=null)
                    HornPatternIndividualRecall=ConfigurationManager.AppSettings["HornPatternIndividualRecall"];
                else
                    HornPatternIndividualRecall="1,1";
                }

     
        
        #region Events
        private void EventT5()
            {
           

            log.Debug("ËventT5 triggered, horn pattern is" + HornPatternEventT5 + ", using Relay 1");
            string[] _hornPattern =null;
            
            try
            { 
              if(_boardDriver ==null)
                    throw new Exception("Relay board not connected or in used by a different race.");

                _boardDriver.Relay1_PowerOn ();
                _boardDriver.PlaySoundPattern(HornPatternEventT5,InternalPlayer);
            }
            catch (Exception ex)
            {
                log.Fatal("Event T1 has thrown an exception: ", ex);
            }

            
             lock (this)
            {
                LastEventCode=RaceEventCode.T5;
            }
             NewRaceEvent?.Invoke (this, new RaceEvent (LastEventCode.ToString ()));

            }
        private void EventT4()
            {

            log.Debug("ËventT4 triggered, horn pattern is" + HornPatternEventT4 + ", using Relay3 ");

           
            try{
                 if (_boardDriver ==null)
                    throw new Exception("Relay board not connected or in used by a different race.");

                _boardDriver.Relay3_PowerOn ();
                _boardDriver.PlaySoundPattern(HornPatternEventT4,InternalPlayer);

                }
            catch (Exception ex)
                {
                    log.Fatal("Event T1 has thrown an exception: ", ex);
                }
             lock (this)
            {
            LastEventCode=RaceEventCode.T4;
            }

                                          
            }
        private void EventT1()
            {

            log.Debug("ËventT1 triggered, horn pattern is" + HornPatternEventT1 + ", using Relay 6");
            
            try
                {

                if (_boardDriver ==null)
                    throw new Exception("Relay board not connected or in used by a different race.");


                _boardDriver.Relay6_PowerOn ();
                _boardDriver.PlaySoundPattern (HornPatternEventT1,InternalPlayer);
                   
                }
            catch (Exception ex)
                {
                    log.Fatal("Event T1 has thrown an exception: ", ex);
                }
                             lock (this)
            {
            LastEventCode=RaceEventCode.T1;
            }

            }
        private void EventStart()
            {
                log.Debug("Event Race Started was triggered, horn pattern is" + HornPatternEventStart + ", using Relay 1,3,5 all off");
                
                try
                { 
                
                if (_boardDriver ==null)
                    throw new Exception("Relay board not connected or in used by a different race.");

                   
                    _boardDriver.PlaySoundPattern(HornPatternEventStart,InternalPlayer);
                    _boardDriver.Relay1_PowerOff ();
                    _boardDriver.Relay3_PowerOff();
                    _boardDriver.Relay6_PowerOff();

                }
                catch (Exception ex)
                {
                    log.Fatal("Event Race Started has thrown an exception: ", ex);
                }
                        
                lock (this)
                {
                LastEventCode=RaceEventCode.T0;
                RaceStartTime=DateTime.Now;
                _raceInCourse=true;
                _timer.Tick-=  _timer_Tick;
                _timer.CancelTimer();
                _timer.Dispose();
                }

                 

            }
        public void EventGeneralRecall()
            {
               log.Debug("Ëvent General Recall was triggered, horn pattern is: " + HornPatternEventGeneralRecall + " / using Relay 7 ");
            
               try
                    { 
                
                if (_boardDriver ==null)
                    throw new Exception("Relay board not connected or in used by a different race.");

                    
                 if (_boardDriver.Relay7Status)
                                {
                                    _boardDriver.Relay7_PowerOff ();
                                    _generalRecall=false;
                                }
                                else
                                {
                                    _boardDriver.Relay7_PowerOn ();
                                    _generalRecall=true;
                                    _boardDriver.PlaySoundPattern (HornPatternEventGeneralRecall,InternalPlayer);
                                }
                                
                    


                  _raceCancelled=true;

                    }
                catch (Exception ex)
                    {

                    log.Fatal("Event General Recall has thrown an exception: ", ex);
                    }

               
            }
        
        public void EventIndividualRecall()
            {
              log.Debug("Ëvent Individual Recall triggered, horn pattern is" + HornPatternIndividualRecall + ", using Relay 4");
                
                try{

                                
                    if (_boardDriver ==null)
                        throw new Exception("Relay board not connected or in used by a different race.");


                        if (_boardDriver.Relay4Status)
                        {
                            _boardDriver.Relay4_PowerOff ();
                            _individualRecall=false;
                        }
                        else
                        {
                            _boardDriver.Relay4_PowerOn ();
                            _individualRecall=true;
                            _boardDriver.PlaySoundPattern (HornPatternIndividualRecall,InternalPlayer);
                        }
                                
                    }
                catch (Exception ex)
                    {
                        log.Fatal("Event Individual Recall has thrown an exception: ", ex);
                    }
                
                            int _seconds;

              
            
            }
        public void EventReset()
            {
            _boardDriver.BoardReset();
         
            if(_timer!=null)
                {            _timer.CancelTimer();
                             _timer.Dispose();
                }
            }

      
        public void EventRacingAbandon()
            {

                
            }




        #endregion Events


        public void StartCountDown()
            {
                _boardDriver= RelayBoardDriver.Instance;
              
             
                _timer = new HighPrecisionTimer(1000);
                _timer.Tick += _timer_Tick;
              
                Task.Factory.StartNew(()=>
                { 
                        EventT5();
                });
            }
        
        private void _timer_Tick (object sender, HighPrecisionTimer.TickEventArgs e)
            {
               _raceCountDown=span.Subtract(new TimeSpan(0,0,Convert.ToInt32(e.Duration.TotalSeconds)));

            //this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() 
            //{
            //            lbCounter.Text = span.ToString();
                         
                
            //});

            if (e.Duration.TotalSeconds>=60 && LastEventCode==RaceEventCode.T5)
            {
                lock (this)
                    {
                    LastEventCode=RaceEventCode.T4;
                    }
                Task.Factory.StartNew(()=>
                { 
                        EventT4();
                });
              
              
                }
            if(e.Duration.TotalSeconds>=240 && LastEventCode==RaceEventCode.T4)
            {
                 lock (this)
                    {
                    LastEventCode=RaceEventCode.T1;
                    }
                Task.Factory.StartNew(()=>
                { 
                        EventT1();
                });
                 
              //  pict1minleft.Image=Marconi.Properties.Resources.race_red_light;
            }

            if (e.Duration.TotalSeconds>=300 && LastEventCode==RaceEventCode.T1)
            {
               lock (this)
                    {
                    LastEventCode=RaceEventCode.T0;
                    }
                Task.Factory.StartNew(()=>
                { 
                        EventStart();
                });

                
            }

              NewRaceClockEvent?.Invoke (this, e);  
              NewRaceEvent?.Invoke (this, new RaceEvent (LastEventCode.ToString ()));
            
            }

    
        }
        public class RaceEvent: EventArgs
        {

            private string _eventCode;
            public RaceEvent(string code)
            {
                _eventCode=code;
            }
            public string EventCode { get { return _eventCode;}  }
        }
    }
 
