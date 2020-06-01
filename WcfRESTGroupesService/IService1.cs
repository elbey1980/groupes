using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRESTGroupesService
{
    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "/personnes")]
        int AddPersonne(Personne personne);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "/groupes/{courriel}/{passWord}")]
        int AddGroupe(Groupe groupe, string courriel, string passWord);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    UriTemplate = "/personnes/{courriel}/{passWord}",
                   // BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        Boolean checkUser(string courriel,string passWord);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "/adhesions/{courriel}/{passWord}")]
        int AddAdhesion(Adhesion adhesion, string courriel, string passWord);
        /*
       adhesion.status = 1 --> Inviter
       adhesion.status = 4 --> demander
        */

        [OperationContract]
        [WebInvoke(Method = "PUT",
                    UriTemplate = "/adhesions/{courriel}/{passWord}",
                    //    BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        int UpdateAdhesion(Adhesion adhesion, string courriel, string passWord);
        /*
      adhesion.status = 2 --> Accepter
      adhesion.status = 3 --> Refuser
      adhesion.status = 5 --> se désabonner
       */

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                //    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "/groupes/{courriel}/{passWord}")]
        List<Groupe> GetGroupes( string courriel, string passWord);

        
        [OperationContract]
        [WebInvoke(Method = "GET",
                    UriTemplate = "/personnes/userName/{passWord}/{courriel}/",
                    // BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        String getUserName(string courriel, string passWord);
        
    }




}
