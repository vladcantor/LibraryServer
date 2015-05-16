using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [DataContract(Name = "model.Rented")]
    public class Rented
    {
        public DateTime Date { get; set; }
        [DataMember(Name = "b")]
        public Book Book { get; set; }
        [DataMember(Name = "s")]
        public Subscriber Subscriber { get; set; }
        [DataMember(Name = "date")]
        private string serializingDate { get; set; }

        [OnSerializing]
        private void OnSerializing()
        {
            serializingDate = Date.ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture);
        }

        [OnDeserialized]
        private void OnDeserialize()
        {
            Date = DateTime.ParseExact(serializingDate, CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture);
        }
    }
}
