using System;
using Newtonsoft.Json.Linq;

namespace deepin_ext_cal_sync.Models
{
    public class DeepinCalEvent
    {
        public DeepinCalEvent()
        {
            this.ID = 0;
            this.Ignore = new JArray();
            this.Type = 1;
            this.RecurID = 0;
        }
        
        public int ID { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public bool AllDay { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Description { get; set; }
        public string RRule { get; set; }
        public string Remind { get; set; }
        public int RecurID { get; set; }
        public JArray Ignore { get; set; }
    }
}