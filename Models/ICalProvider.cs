using System;
using System.Collections.Generic;

namespace deepin_ext_cal_sync.Models
{
    /// <summary>
    /// A basic calendar provider template for future scalability
    /// </summary>
    public interface ICalProvider
    {
        public List<DeepinCalEvent> GetEvents(DateTime startDt,DateTime endDt);
    }
}