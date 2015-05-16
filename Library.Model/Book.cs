using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [DataContract(Name="model.Book")]
    public class Book
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }

        public bool IsRented { get; set; }

    }
}
