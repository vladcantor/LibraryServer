using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [DataContract(Name="model.Subscriber")]
    public class Subscriber
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}
