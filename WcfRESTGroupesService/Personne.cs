using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfRESTGroupesService
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

        
        public Personne(string id, string courriel, string passWord, string userName)
        {
            this.id = id;
            this.courriel = courriel;
            this.passWord = passWord;
            this.userName = userName;
        }

        public Personne()
        {
        }
    }
}