using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Geo
{
    public class HistoryEventPlaceModel: EventPlaceModel
    {
        public HistoryEventPlaceModel()
        {

        }
        public HistoryEventPlaceModel(string label)
            :base(label)
        {
        }
        public HistoryEventPlaceModel(int cityId, string label, bool readOnly)
            :base(cityId, label, readOnly)
        {
        }
        public HistoryEventPlaceModel(short? countryId, int? stateId, int? cityId, string label, bool readOnly)
            :base(countryId, stateId, cityId, label, readOnly)
        {
        }
        public override bool SaveData()
        {
            return false;
        }
    }
}
