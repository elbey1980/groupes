using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRESTGroupesService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public int AddPersonne(Personne personne)
        {
           return GroupesDataProvider.AddPersonne(personne);
        }

        public Boolean checkUser(string courriel, string passWord)
        {
            return GroupesDataProvider.checkPassWord(courriel, passWord);
        }

        public int AddGroupe(Groupe groupe, string courriel, string passWord)
        {
            return GroupesDataProvider.AddGroupe(groupe, courriel, passWord);
        }

        public int AddAdhesion(Adhesion adhesion, string courriel, string passWord)
        {
            return GroupesDataProvider.AddAdhesion(adhesion, courriel, passWord);
        }


        public int UpdateAdhesion(Adhesion adhesion,string courriel, string passWord)
        {
            return GroupesDataProvider.UpdateAdhesion(adhesion, courriel,passWord);
        }

        public List<Groupe> GetGroupes(string courriel, string passWord)
        {
            return GroupesDataProvider.GetGroupes(courriel,passWord);
        }

        
        public String getUserName(string courriel, string passWord)
        {
            return GroupesDataProvider.getUserName(courriel, passWord);
        }
        
    }
}
