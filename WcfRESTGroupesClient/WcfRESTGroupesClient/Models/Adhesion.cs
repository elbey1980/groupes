using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;

namespace WcfRESTGroupesClient.Models
{
    [DataContract]
    public class Adhesion
    {
        [DataMember]
        public string nomGroupe { get; set; }
        [DataMember]
        public int status { get; set; }
        [DataMember]
        public string userName { get; set; }

        public Adhesion(string nomGroupe, int status, string userName)
        {
            this.nomGroupe = nomGroupe;
            this.status = status;
            this.userName = userName;
        }

        public Adhesion()
        {
            
        }

    }
}
