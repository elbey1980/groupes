using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WcfRESTGroupesClient.Models
{
    [DataContract]
    public class ListeGroupes
    {
        [DataMember]
        public List<Groupe> GetGroupesResult { get; set; }
    }
}
