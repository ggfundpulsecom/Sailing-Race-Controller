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
    public class SailingRace
        { 
        private static readonly ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
     

        
        public SailingRace()
            {
          

               
               

                
            } 
        public string HornPatternEventT5 { get;set;}
        public string HornPatternEventT4 { get;set;}
        public string HornPatternEventT1 {get;set; }
        public string HornPatternEventStart { get;set;}    
        public string HornPatternEventGeneralRecall { get;set;}
        public string HornPatternIndividualRecall { get;set;}
        public string HornPatternTest { get;set;}
        public string HornPatternRaceAb { get;set;}

        public enum RaceEventCode
            {
                W,
                T5,
                T4,
                T1,
                T0,
                GeneralRecall,
                IndividualRecall
            };

        System.Media.SoundPlayer hornplayer;
     

       
      
        }
    }
