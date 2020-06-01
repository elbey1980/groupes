using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WcfRESTGroupesClient.Models
{
    [DataContract]
    public class Groupe
    {
        [DataMember]
        public string nomGroupe { get; set; }
        [DataMember]
        public string admin { get; set; }

            public Groupe(string nomGroupe, string admin)
            {
                this.nomGroupe = nomGroupe;
                this.admin = admin;
            }

        public Groupe()
        {
           
        }

    }
}
