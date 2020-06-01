using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WcfRESTGroupesClient.Models;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Collections;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;


namespace WcfRESTGroupesClient.Controllers
{
    public class GroupeController : Controller
    {

        private const string BaseUrl = "http://localhost:53323/Service1.svc/";
       
        public async Task<IActionResult> Index()
        {
          List<Groupe> liste = new List<Groupe>();

            using (var httpClient = new HttpClient())
            { 
                using (var response = await httpClient.GetAsync(BaseUrl+"groupes/" + HttpContext.Session.GetString("courriel") + "/" + HttpContext.Session.GetString("password")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    liste = JsonConvert.DeserializeObject<List<Groupe>>(apiResponse);          
                }
            }
            return View(liste);
        }

        public ActionResult Create()
        {
            Groupe groupe = new Groupe();
            return View(groupe);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Groupe groupe)
        {
            JsonObjectAttribute receivedResponse;
         
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(groupe), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl+"groupes/" + HttpContext.Session.GetString("courriel") + "/" + HttpContext.Session.GetString("password"), content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        receivedResponse = JsonConvert.DeserializeObject<JsonObjectAttribute>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Result = apiResponse;
                           return View();
                    }
                }
            }
            return View(receivedResponse);
        }

        public ActionResult Inscription()
        {
            Personne personne = new Personne();
            return View(personne);
        }


        [HttpPost]
        public async Task<IActionResult> Inscription(Personne personne)
        {
            JsonObjectAttribute receivedResponse;

            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(personne), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:53323/Service1.svc/personnes", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        receivedResponse = JsonConvert.DeserializeObject<JsonObjectAttribute>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Result = apiResponse;
                        return View();
                    }
                }
            }
              return View(receivedResponse);

        }


        public ActionResult Adhesion()
        {
            Adhesion adhesion = new Adhesion();
           
            return View(adhesion);
        }

        [HttpPost]
        public async Task<IActionResult> Adhesion(Adhesion adhesion)
        {
  
            JsonObjectAttribute receivedResponse;
        //    GetUserName();
         //   adhesion.userName = HttpContext.Session.GetString("userName").ToString();
            using (var httpClient = new HttpClient())
            {
               
                StringContent content = new StringContent(JsonConvert.SerializeObject(adhesion), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl+"adhesions/" + HttpContext.Session.GetString("courriel") + "/" + HttpContext.Session.GetString("password"), content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        receivedResponse = JsonConvert.DeserializeObject<JsonObjectAttribute>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Result = apiResponse;
                        return View();
                    }
                }
            }
            return View();
        }

        public ActionResult Invitation()
        {
            Adhesion adhesion = new Adhesion();

            return View(adhesion);
        }

        [HttpPost]
        public async Task<IActionResult> Invitation(Adhesion adhesion)
        {
            JsonObjectAttribute receivedResponse;          
            using (var httpClient = new HttpClient())
            {     
                StringContent content = new StringContent(JsonConvert.SerializeObject(adhesion), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl+"adhesions/" + HttpContext.Session.GetString("courriel") + "/" + HttpContext.Session.GetString("password"), content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        receivedResponse = JsonConvert.DeserializeObject<JsonObjectAttribute>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Result = apiResponse;
                        return View();
                    }
                }
            }
            return View();
        }

        public ActionResult TraiterDemande()
        {

            Adhesion adhesion = new Adhesion();
            return View(adhesion);
        }

        [HttpPost]
        public async Task<IActionResult> TraiterDemande(Adhesion adhesion)
        {
            string reponse = "";
            using (var httpClient = new HttpClient())
            {
                var data =new  { userName = adhesion.userName, nomGroupe= adhesion.nomGroupe, status = adhesion.status };
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(BaseUrl+ "adhesions/" + HttpContext.Session.GetString("courriel") + "/" + HttpContext.Session.GetString("password"), content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                     reponse = apiResponse;
                    ViewBag.Result = "Success";
                }
            }
            if (reponse.Equals("1"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> Login()
        {  
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection collection)
        {  
            String courriel = collection["courriel"];
            String password = collection["passWord"];
            string reponse = "";
            try
            {     
                if (courriel != null && password != null)
               {      
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync(BaseUrl+ "personnes/" + courriel + "/" + password))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            reponse = apiResponse;   
                        }
                    } 
                     if (reponse.Equals("true") )
                    {
                           HttpContext.Session.SetString("courriel", courriel);
                           HttpContext.Session.SetString("password", password);
                           return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ViewBag.error = "Invalid Account";
                        return View();
                    }            
                }
                else
                {
                    ViewBag.error = "Invalid Account";
                    return View();
                }
        }
          catch
            {
                return View();
            }  

        }

        [HttpPost]
        public ActionResult Activite(Activite a)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLlocalDB;"
                                                            + "Initial Catalog=groupesDB;"
                                                            + "Integrated Security=True;Pooling=False");
                SqlCommand cmd = new SqlCommand("newActivite", sqlConnection1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nomActivite", a.NomActivite));
                cmd.Parameters.Add(new SqlParameter("@nomAdmin", a.NomAdmin));
               
                sqlConnection1.Open();
                int nbLigne = cmd.ExecuteNonQuery();
                return RedirectToAction("Index", "Home");
            }
            catch
            { return View(); }
        }

        public ActionResult Activite()
        {
            Activite a = new Activite();
            return View(a);
        }

        public ActionResult DeleteActivite()
        {
            Activite a = new Activite();
            return View(a);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteActivite(Activite activite)
        {
            JsonObjectAttribute receivedResponse;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:52925/api/activites/"+activite.NomActivite))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        receivedResponse = JsonConvert.DeserializeObject<JsonObjectAttribute>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Result = apiResponse;
                        return View();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async void GetUserName()
        {
            string reponse = "";
            try
            {
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync(BaseUrl + "personnes/" + HttpContext.Session.GetString("password") + "/" + HttpContext.Session.GetString("courriel")  ))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            reponse = apiResponse;
                        }
                    }
                    if (!reponse.Equals(""))
                    {
                        HttpContext.Session.SetString("userName", reponse);
                    }
                    else
                    {
                        ViewBag.error = "Invalid Account";
                    }
            }
            catch
            {

            }
        }

    }
}