using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [DataContract(Name="model.BookKeeper")]
    public class Librarian:Subscriber
    {
        [DataMember(Name="firstN")]
        public string FirstName { get; set; }
    }
}
