using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfRESTGroupesService
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
    }
}