using System;
using Services;
using System.Web.Mvc;
using System.DirectoryServices;
using Domain.Entitee;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;

namespace Historisation.Controllers
{
    public class HomeController : Controller
    {
        IEmployeService service1;
        public HomeController()
        {
            service1 = new EmployeService();
        }
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        public ActionResult Connection(Employe employe)
        {
            Session["login"] = employe.Login;
            StringBuilder groupsList = new StringBuilder();
            FileStream fs = new FileStream(@"C:\Users\Public\Desktop\" + employe.Login + ".txt", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            string[] tab = new string[100];
            if (employe.Password == null)
            {
                ViewBag.message = ("Veuiller entrer un mot de passe");
                ViewBag.color = "red";
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                try
                {
                    DirectoryEntry Ldap = new DirectoryEntry("LDAP://info.local", employe.Login, employe.Password);
                    DirectorySearcher searcher = new DirectorySearcher(Ldap);
                    searcher.Filter = "(&(objectClass=user)(sAMAccountName=" + employe.Login + "))";
                    SearchResult result = searcher.FindOne();
                    DirectoryEntry DirEntry = result.GetDirectoryEntry();
                    if (result != null)
                    {
                        //Session["nomPrenom"] = (string)result.Properties["cn"][0];
                        int groupCount = result.Properties["memberOf"].Count;
                        for (int counter = 0; counter < groupCount; counter++)
                        {
                            
                            string[] msg = new string[100];
                            string[] msg2 = new string[100];

                            groupsList.Append(DirEntry.Properties["memberOf"][counter]);
                            groupsList.Append("|");
                            msg = groupsList.ToString().Split('|');
                            msg2 = msg[counter].Split(',');
                            tab[counter] = msg2[0];
                        }
                        serializer.Serialize(fs, tab);
                        fs.Close();
                    }

                }
                catch (Exception)
                {
                    ViewBag.message = ("login ou mot de passe incorrect !!");
                    ViewBag.color = "red";
                    return View("~/Views/Home/Index.cshtml");
                }
             }
            
            string[] serialisedData = null;
            fs = new FileStream(@"C:\Users\Public\Desktop\" + employe.Login + ".txt", FileMode.Open);
            serialisedData = (string[])serializer.Deserialize(fs);
            fs.Close();
            foreach (var val in serialisedData)
            {
                if (val == "CN=ACC-PROD-TUNIS-WEB_CONTENU-AGENT" || val == "CN=ACC-PROD-TUNIS-Bedouk_CTN-AGENT" || val == "CN=ACC-PROD-TUNIS-EXPO_CTN-AGENT" || val == "CN=ACC-TUN-DATA-TUNIS-MONITORING-REPORTING-TLF-RW")
                {
                    Session["h_s"] = DateTime.Now;
                    Employe empl = new Employe();
                    empl.Login = (string)(Session["login"]);
                    empl.logEntree = DateTime.Now;
                    service1.Add(empl);
                    service1.SaveChange();
                    return View("~/Views/Home/Acceuil.cshtml");
                }
            }
            
            ViewBag.message = ("Accés refusé");
            ViewBag.color = "red";
            return View("~/Views/Home/Index.cshtml");

        }
        public ActionResult logout()
        {
            string login = (string)(Session["login"]);
            DateTime d1 = (DateTime)(Session["h_s"]);
            DateTime d2 = DateTime.Now;
            TimeSpan diff1 = d2.Subtract(d1);
            string duree = diff1.Hours + "  Heures  " + diff1.Minutes + "  Minutes " + diff1.Seconds + " Secondes"; ;
            Employe empl = service1.getByLogout(login);
            empl.logSortie = d2;
            empl.logDuree = duree;
                       
            if (TryUpdateModel(empl))
            {
                try
                {
                    service1.SaveChange();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Erreur!!!!!");
                }
            }
                       
            return RedirectToAction("Index");
        }

        public ActionResult Acceuil()
        {
            return View("~/Views/Home/Acceuil.cshtml");
        }
    }
}