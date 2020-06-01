using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfRESTGroupesService
{
    [DataContract]
    public class Adhesion
    {
      //  [DataMember]
      //  public string id { get; set; }
        [DataMember]
        public string nomGroupe { get; set; }
        [DataMember]
        public int status { get; set; }
        [DataMember]
        public string userName { get; set; }

        /*
        desc.Champ Status
        1 : Inviter
        2 : Accepter
        3 : Refuser
        4 : Demander
        5 : se désabonner
        */
    }
}