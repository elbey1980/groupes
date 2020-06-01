using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WcfRESTGroupesClient.Models
{
    [DataContract]
    public class Personne
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string courriel { get; set; }
        [DataMember]
        public string passWord { get; set; }
        [DataMember]
        public string userName { get; set; }

        public Personne()
        {
        }
    }
}
