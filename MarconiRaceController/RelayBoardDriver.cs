using FTD2XX_NET;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Marconi
    {
    public class RelayBoardDriver
        {

        private static readonly ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FTDI myFtdiDevice ;
        FTDI.FT_STATUS ftStatus;
        byte[] sentBytes = new byte[2];
        uint receivedBytes;

        private Task TaskHorn=null;
        private TaskFactory tsk=null;
        Timer horn_timer;

         System.Media.SoundPlayer hornplayer=null;

       

        public bool RelayConnection { get; private set;}
        public bool Relay8Status {get; private set; }
        public bool Relay7Status {get; private set; }
        public bool Relay6Status {get; private set; }
        public bool Relay5Status {get; private set; }
        public bool Relay4Status {get; private set; }
        public bool Relay3Status {get; private set; }
        public bool Relay2Status {get; private set; }
        public bool Relay1Status { get; private set;}

        public string RelayBoardMessage { get;set;}
      
        private static readonly RelayBoardDriver instance = new RelayBoardDriver();
        
        static RelayBoardDriver()
            { }
        
         private RelayBoardDriver()
            {

           
                
            
                horn_timer = new Timer();
                horn_timer.Interval=1000;
                tsk= new TaskFactory();
            
            

               //try to load relay board usb drivers
                try{
                       

                        myFtdiDevice  = new FTDI();
              
                        if(myFtdiDevice!=null)
                        {
                            RelayBoardMessage ="Online";
                            log.Debug("USB board found and ready.");
                        }
                        else
                        { 
                            RelayBoardMessage="Offline";
                            log.Debug("USB board not found or not ready");
                        }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    RelayBoardMessage = ex.Message;
                    
                }

                RelayConnection = ConnectToRelayBoard();
            }

        public static RelayBoardDriver Instance {get { return instance;} }

        private bool ConnectToRelayBoard()
            {
                
            //Get serial number of device with index 0
                if(myFtdiDevice==null)
                return false;
                ftStatus = myFtdiDevice.OpenByIndex(0);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    log.Error("OpenByIndex returned: " + ftStatus.ToString() );            
                    return false;
                }
                log.Debug("OpenByIndex returned: " + ftStatus.ToString() );            
                    
                //Reset device
                ftStatus = myFtdiDevice.ResetDevice();
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {               
                    log.Error("ResetDevice returned: " + ftStatus.ToString() );            
                    return false;
                }
                 log.Debug("ResetDevice returned: " + ftStatus.ToString() );            
                
                //Set Baud Rate
                ftStatus = myFtdiDevice.SetBaudRate(921600);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {     
                    log.Error("SetBaudRate(921600) returned: " + ftStatus.ToString() );               
                    return false;
                }
                 log.Debug("ResetDevice returned: " + ftStatus.ToString() );            
                
                //Set Bit Bang
                ftStatus = myFtdiDevice.SetBitMode(255, FTD2XX_NET.FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_BITBANG);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                { 
                    log.Error("SetBitMode(255, FTD2XX_NET.FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_BITBANG) returned: " + ftStatus.ToString() );
                    return false;
                }
                log.Error("SetBitMode(255, FTD2XX_NET.FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_BITBANG) returned: " + ftStatus.ToString() );
                
                //Read Relays Status
                log.Debug("--------------------------------Start reading devide pin states--------------------------");
                ftStatus = myFtdiDevice.GetPinStates(ref sentBytes[0]);
               
                log.Debug("GetPingStates returned " + ftStatus.ToString() );

                if ((sentBytes[0] & 1) == 0)    //5 min light
                {     Relay1Status= false;
                      log.Debug("sentBytes[0] & 1 returned 0  ---Relay 1 Status OFF");

                } else
                {
                      Relay1Status = true;
                      log.Debug("sentBytes[0] & 1 returned " + (sentBytes[0] & 1) + "  --- Relay 1 Status ON");

                }

                if ((sentBytes[0] & 2) == 0)   //4 min light
                {

                    log.Debug("sentBytes[0] & 2 returned 0  --- Relay 2 Status OFF");

                    Relay2Status = false;

                } else
                {
                     log.Debug("sentBytes[0] & 2 returned " + (sentBytes[0] & 2) + "  --- Relay 2 Status ON");


                     Relay2Status = true;
                }
                if ((sentBytes[0] & 4) == 0)    //1 min light
                {
                    log.Debug("sentBytes[0] & 4 returned 0  --- Relay 3 Status OFF");

                    Relay3Status = false;
                } else
                {
                     log.Debug("sentBytes[0] & 4 returned " + (sentBytes[0] & 4) + "  --- Relay 3 Status ON");

                    Relay3Status = true;
                }
                if ((sentBytes[0] & 8) == 0)    //general recall light
                {
                    log.Debug("sentBytes[0] & 8 returned 0  --- Relay 4 Status OFF");

                    Relay4Status = false;
                } else
                {
                    log.Debug("sentBytes[0] & 8 returned " + (sentBytes[0] & 8) + "  --- Relay 4 Status ON");

                    Relay4Status = true;
                }
                if ((sentBytes[0] & 16) == 0)   //horne connected
                {
                     log.Debug("sentBytes[0] & 16 returned 0  --- Relay 5 Status OFF");

                    Relay5Status = false;
                } else
                {
                    log.Debug("sentBytes[0] & 16 returned " + (sentBytes[0] & 16) + "  --- Relay 5 Status ON");

                    Relay5Status = true;
                }
                if ((sentBytes[0] & 32) == 0)
                {
                     log.Debug("sentBytes[0] & 32 returned 0  --- Relay 6 Status OFF");

                     Relay6Status = false;

                } else
                {
                    log.Debug("sentBytes[0] & 32 returned " + (sentBytes[0] & 32) + "  --- Relay 6 Status ON");
                    Relay6Status = true;
                }
                if ((sentBytes[0] & 64) == 0)
                {
                     log.Debug("sentBytes[0] & 64 returned 0  --- Relay 7 Status OFF");

                    Relay7Status = false;
                }
                else
                {
                    log.Debug("sentBytes[0] & 64 returned " + (sentBytes[0] & 64) + "  --- Relay 7 Status ON");
                    
                    Relay7Status = true;
                }
                if ((sentBytes[0] & 128) == 0)
                {
                    log.Debug("sentBytes[0] & 128 returned 0  --- Relay 8 Status OFF");

                    Relay8Status = false;
                } else
                {
                    log.Debug("sentBytes[0] & 128 returned " + (sentBytes[0] & 128) + "  --- Relay 8 Status ON");
                    Relay8Status = true;
                }
                return true;
            }

        private void PlayHorn(int seconds)
            {
            try { 
                hornplayer.LoadTimeout=seconds*1000;

                //horn_timer.Stop();

                //horn_timer.Interval = new TimeSpan(0,0,seconds).TotalMilliseconds;
                
                //horn_timer.Elapsed += Horn_timer_Elapsed; //Horn_timer_Elapsed(this,_horn_event);

               

                log.Debug("Playing horn for " + seconds + " seconds on Relay 8");

                Relay8_PowerOn ();
                hornplayer.PlayLooping();
                TaskHorn.Wait(seconds*1000);
    
                Relay8_PowerOff();
                hornplayer.Stop();
               
                }
                catch (Exception ex)
                {
                    log.Error("Play horn failed with error: ", ex);
                }
               
            }
        private void PlaySilence(int seconds)
            {
                try
                {
                    log.Debug("Horn is playing silence for " + seconds + " seconds.");
                    TaskHorn.Wait(seconds*1000);
                    log.Debug("Done");
                }
                catch (Exception ex )
                {
                    log.Error("Horn has thrown an exception while playing silence. The error is: " , ex);
                }
             }

        private bool IsOdd(int value)
         {
            return value % 2 != 0;
         }
        

        public void PlaySoundPattern(string hornPattern,  System.Media.SoundPlayer localmedia)
            {
            hornplayer= localmedia;

            if(string.IsNullOrEmpty(hornPattern))
               return;
            string[] _hornPattern =null;
            _hornPattern = hornPattern.Split(',');

            if (_hornPattern==null)
            {
                    log.Warn("No horn pattern found for Event T5.");
            }


            int _seconds;
           

            TaskHorn =  tsk.StartNew(()=> {   
               
                for (int i = 0; i < _hornPattern.Count(); i++)
                {
                    int.TryParse(_hornPattern[i], out _seconds);

                    if(IsOdd(i)) // we have a pause
                        PlaySilence(_seconds);
                     
                    else
                        PlayHorn(_seconds);
                     
                }

            });
            }
   
        public void BoardReset()
            {
            Relay1_PowerOff();
            Relay2_PowerOff();
            Relay3_PowerOff();
            Relay4_PowerOff();
            Relay5_PowerOff();
            Relay6_PowerOff();
            Relay7_PowerOff();
            Relay8_PowerOff();

            }

          public void EventTest()
            {
                Relay1_PowerOn();
                Relay2_PowerOn();
                Relay3_PowerOn();
                Relay4_PowerOn();
                Relay5_PowerOn();
                Relay6_PowerOn();
                Relay7_PowerOn();

            }
        #region Relay_ON_Off

        public bool Relay1_PowerOn()
            {
            try { 
                    //if (!Relay1Status)
                    //{
                    //    log.Error("Relay1: Unable to power on, channel is not open.");
                    //    return false;
                    //}
                    sentBytes[0]=(byte)(sentBytes[0] | 1);

                    log.Debug("Relay1: Sending sentBytes[0] | 1 on channel");

                    var ftdStatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay1: Channel replied with " + receivedBytes.ToString());

                    if (ftdStatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay1: Unable to write on channel. Error is:  " + ftdStatus.ToString());
                        RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay1: Relay is ON");
                    Relay1Status=true;
                    return true;

                }
                catch (Exception ex)
                {
                    log.Error("Relay1: Power_on failed", ex);
                    return false;
                }
            }
        public bool Relay1_PowerOff()
            {
                try { 
                    //if (!Relay1Status)
                    //{
                    //    log.Warn("Relay1: Warning unable to power off, channel is closed.");
                    
                    //}
                    log.Debug("Relay1: Sending sentBytes[0] & 254 on channel");

                    sentBytes[0]=(byte)(sentBytes[0] & 254);

                    var ftdstatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay1: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay1: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                        RelayBoardMessage = "Relay board not connected or in fault.";

                        return false;
                    }
                    log.Debug("Relay1: Relay is OFF");
                    Relay1Status=false;
                    return true;

                }catch(Exception ex)
                {
                    log.Error("Relay1: Power off failed", ex);

                    return false;
                }
            }
                   
        public bool Relay2_PowerOn()
            {
            try { 
                    //if (!Relay1Status)
                    //{
                    //    log.Error("Relay1: Unable to power on, channel is not open.");
                    //    return false;
                    //}
                    sentBytes[0]=(byte)(sentBytes[0] | 2);

                    log.Debug("Relay2: Sending sentBytes[0] | 2 on channel");

                    var ftdStatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay2: Channel replied with " + receivedBytes.ToString());

                    if (ftdStatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay2: Unable to write on channel. Error is:  " + ftdStatus.ToString());
                        RelayBoardMessage = "Relay board not connected or in fault.";

                        return false;
                    }
                    log.Debug("Relay2: Relay is ON");
                    Relay2Status=true;
                    return true;

                }
                catch (Exception ex)
                {
                    log.Error("Relay2: Power_on failed", ex);
                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            }
        public bool Relay2_PowerOff()
            {
                try { 
                    //if (!Relay1Status)
                    //{
                    //    log.Warn("Relay1: Warning unable to power off, channel is closed.");
                    
                    //}
                    log.Debug("Relay2: Sending sentBytes[0] & 253 on channel");

                    sentBytes[0]=(byte)(sentBytes[0] & 253);

                    var ftdstatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay2: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay1: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                        RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay2: Relay is OFF");
                    Relay2Status=false;
                    return true;

                }catch(Exception ex)
                {
                    log.Error("Relay2: Power off failed", ex);
                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            }

        public bool Relay3_PowerOn()
            {
                 try {
                        //if (!Relay3Status)
                        //{
                        //        log.Error("Relay3: Unable to power on, channel is not open.");
                        //        return false;
                        //}

                        sentBytes[0] = (byte)(sentBytes[0] | 4);

                        log.Debug("Relay3: Sending (sentBytes[0] | 4 on channel");

                        var ftdstatus =myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                        log.Debug("Relay3: Channel replied with " + receivedBytes.ToString());

                        if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                         {   
                                log.Error("Relay3: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                                RelayBoardMessage = "Relay board not connected or in fault.";
                                return false;
                         }
                         log.Debug("Relay3: Relay is ON");
                        Relay3Status=true;
                         return true;

                    }
                    catch (Exception ex)
                    {
                        log.Error("Relay3: Power_on failed", ex);
                        RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                        return false;
                    }             
               
            }
        public bool Relay3_PowerOff()
            {
            try
                { 
                    //if (!Relay3Status)
                    //{
                    //        log.Warn("Relay3: Warning powering off but channel is closed.");
                            
                    //}

                    sentBytes[0] = (byte)(sentBytes[0] & 251);

                    log.Debug("Relay3: Sending (sentBytes[0] & 251 on channel");

                    var ftdstatus = myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay3: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {             
                        log.Error("Relay3: Unable to write on channel. Error is:  " + ftStatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay3: Relay is OFF");
                    Relay3Status=false;
                    return true;
                }
            catch (Exception ex)
                {
                    log.Error("Relay3: Power_off failed", ex);
                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }

            }

        public bool Relay4_PowerOn()
            {
             try {
                        //if (!Relay5Status)
                        //{
                        //        log.Error("Relay5: Unable to power on, channel is not open.");
                        //        return false;
                        //}

                        sentBytes[0] = (byte)(sentBytes[0] | 8);

                        log.Debug("Relay4: Sending (sentBytes[0] | 8 on channel");

                        var ftdstatus =myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                        log.Debug("Relay4: Channel replied with " + receivedBytes.ToString());

                        if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                         {   
                                log.Error("Relay5: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                                RelayBoardMessage = "Relay board not connected or in fault.";
                                return false;
                         }
                         log.Debug("Relay4: Relay is ON");
                         Relay4Status=true;
                         return true;

                    }
                    catch (Exception ex)
                    {
                        log.Error("Relay4: Power_on failed", ex);

                        RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                        return false;
                    }             


            }
        public bool Relay4_PowerOff()
            {
               try { 
                    //if (!Relay5Status)
                    //{
                    //    log.Warn("Relay5: Warning unable to power off, channel is closed.");
                    
                    //}
                    log.Debug("Relay4: Sending sentBytes[0] & 247 on channel");

                    sentBytes[0] = (byte)(sentBytes[0] & 247);

                    var ftdstatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay4: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay4: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay4: Relay is OFF");
                    Relay4Status=false;
                    return true;

                }catch(Exception ex)
                {
                    log.Error("Relay4: Power off failed", ex);
                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            
            }

        public bool Relay5_PowerOn()
            {
             try {
                        //if (!Relay5Status)
                        //{
                        //        log.Error("Relay5: Unable to power on, channel is not open.");
                        //        return false;
                        //}

                        sentBytes[0] = (byte)(sentBytes[0] | 16);

                        log.Debug("Relay5: Sending (sentBytes[0] | 16 on channel");

                        var ftdstatus =myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                        log.Debug("Relay5: Channel replied with " + receivedBytes.ToString());

                        if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                         {   
                                log.Error("Relay5: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                                RelayBoardMessage = "Relay board not connected or in fault.";
                                return false;
                         }
                         log.Debug("Relay5: Relay is ON");
                         Relay5Status=true;
                         return true;

                    }
                    catch (Exception ex)
                    {
                        log.Error("Relay5: Power_on failed", ex);
                        RelayBoardMessage = "Relay board failed with error: " + ex.Message;
                    
                        return false;
                    }             


            }
        public bool Relay5_PowerOff()
            {
               try { 
                    //if (!Relay5Status)
                    //{
                    //    log.Warn("Relay5: Warning unable to power off, channel is closed.");
                    
                    //}
                    log.Debug("Relay5: Sending sentBytes[0] & 239 on channel");

                    sentBytes[0] = (byte)(sentBytes[0] & 239);

                    var ftdstatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay5: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay5: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay5: Relay is OFF");

                    Relay5Status =false;

                    return true;

                }catch(Exception ex)
                {
                    log.Error("Relay5: Power off failed", ex);

                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            
            }
       
        public bool Relay6_PowerOn()
            {
             try {
                        //if (!Relay5Status)
                        //{
                        //        log.Error("Relay5: Unable to power on, channel is not open.");
                        //        return false;
                        //}

                        sentBytes[0] = (byte)(sentBytes[0] | 32);

                        log.Debug("Relay6: Sending (sentBytes[0] | 32 on channel");

                        var ftdstatus =myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                        log.Debug("Relay6: Channel replied with " + receivedBytes.ToString());

                        if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                         {   
                                log.Error("Relay6: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                                RelayBoardMessage = "Relay board not connected or in fault.";
                                return false;
                         }
                         log.Debug("Relay6: Relay is ON");
                         Relay6Status=true;
                         return true;

                    }
                    catch (Exception ex)
                    {
                        log.Error("Relay6: Power_on failed", ex);

                        RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                        return false;
                    }             


            }
        public bool Relay6_PowerOff()
            {
               try { 
                    //if (!Relay5Status)
                    //{
                    //    log.Warn("Relay5: Warning unable to power off, channel is closed.");
                    
                    //}
                    log.Debug("Relay6: Sending sentBytes[0] & 239 on channel");

                    sentBytes[0] = (byte)(sentBytes[0] & 223);

                    var ftdstatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay6: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay6: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay6: Relay is OFF");

                    Relay6Status =false;

                    return true;

                }catch(Exception ex)
                {
                    log.Error("Relay6: Power off failed", ex);

                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            
            }
                        
        public bool Relay7_PowerOn()
            {
            try { 
                    //if (!Relay7Status)
                    //{
                    //    log.Error("Relay7: Unable to power on, channel is not open.");
                    //    return false;
                    //}
                    sentBytes[0] = (byte)(sentBytes[0] | 64);

                    log.Debug("Relay7: Sending sentBytes[0] | 64 on channel");

                    var ftdStatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay7: Channel replied with " + receivedBytes.ToString());

                    if (ftdStatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay7: Unable to write on channel. Error is:  " + ftdStatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay7: Relay is ON");

                    Relay7Status =true;
                    return true;

                }
                catch (Exception ex)
                {
                    log.Error("Relay7: Power_on failed", ex);

                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            }
        public bool Relay7_PowerOff()
            {
               try { 
                    //if (!Relay7Status)
                    //{
                    //    log.Warn("Relay7: Warning unable to power off, channel is closed.");
                    
                    //}
                    log.Debug("Relay7: Sending sentBytes[0] & 191 on channel");

                    sentBytes[0] = (byte)(sentBytes[0] & 191);

                    var ftdstatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay7: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay7: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay7: Relay is OFF");
                    Relay7Status=false;
                    return true;

                }catch(Exception ex)
                {
                    log.Error("Relay7: Power off failed", ex);

                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            
            }

        public bool Relay8_PowerOn()
            {
              try { 
                    //if (!Relay8Status)
                    //{
                    //    log.Error("Relay8: Unable to power on, channel is not open.");
                    //    return false;
                    //}
                    sentBytes[0]=(byte)(sentBytes[0] | 128);


                    log.Debug("Relay8: Sending sentBytes[0] | 128 on channel");

                    var ftdStatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay8: Channel replied with " + receivedBytes.ToString());

                    if (ftdStatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay8: Unable to write on channel. Error is:  " + ftdStatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay8: Relay is ON");
                    Relay8Status=true;
                    return true;

                }
                catch (Exception ex)
                {
                    log.Error("Relay8: Power_on failed", ex);

                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }

            }
        public bool Relay8_PowerOff()
            {
               try { 
                    //if (!Relay8Status)
                    //{
                    //    log.Warn("Relay8: Warning unable to power off, channel is closed.");
                    
                    //}
                    log.Debug("Relay8: Sending sentBytes[0] & 127 on channel");

                   sentBytes[0]=(byte)(sentBytes[0] & 127);

                    var ftdstatus= myFtdiDevice.Write(sentBytes, 1, ref receivedBytes);

                    log.Debug("Relay8: Channel replied with " + receivedBytes.ToString());

                    if (ftdstatus != FTDI.FT_STATUS.FT_OK)
                    {   
                        log.Error("Relay8: Unable to write on channel. Error is:  " + ftdstatus.ToString());
                       RelayBoardMessage = "Relay board not connected or in fault.";
                        return false;
                    }
                    log.Debug("Relay8: Relay is OFF");
                    Relay8Status=false;
                    return true;

                }catch(Exception ex)
                {
                    log.Error("Relay8: Power off failed", ex);

                    RelayBoardMessage = "Relay board failed with error: " + ex.Message;

                    return false;
                }
            
            }
        #endregion


        }
    }
