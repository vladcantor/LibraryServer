using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [DataContract(Name="model.User")]
    public class User:Subscriber
    {
        [DataMember(Name="password")]
        public string Password { get; set; }
        [DataMember(Name="role")]
        public short Role { get; set; }
    }
}
