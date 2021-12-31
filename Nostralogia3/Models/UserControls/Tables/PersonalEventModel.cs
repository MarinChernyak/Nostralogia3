using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls.Tables
{
    public class PersonalEventModel
    {
       
        public bool IsDateToTheSame { get; set; }
        public string MainLabel { get; set; }
        public SimpleCalendarModel DateFrom { get; set; }
        public SimpleCalendarModel DateTo { get; set; }

        public EventPlaceModel EventPlace { get; set; }
        public short Idsource { get; set; }

        public string Notes { get; set; }
        public byte DataType { get; set; }
        public byte? CategoryId { get; set; }
        public short IdeventKind { get; set; }
        public int? PlaceEvent { get; set; }
        public int Idcontributor { get; set; }

        public List<MEventsCategory> Categories { get; set; }
        public List<MSource> Sources { get; set; }
        public List<MDataType> DataTypes { get; set; }
    }
}
