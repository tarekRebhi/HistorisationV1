using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Entitee;
using Services;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Historisation.Controllers
{
    public class HistorisationController : Controller
    {
        IHistorisationService service;
        IEmployeService service1;
        
        public HistorisationController()
        {

            service = new HistorisationService();
            service1 = new EmployeService();
        }

        
        // GET: Historisation
        public ActionResult Index()
        {
            string[] serialisedData = null;
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream fs = new FileStream(@"C:\Users\Public\Desktop\" + (string)Session["login"] + ".txt", FileMode.Open);
            serialisedData = (string[])serializer.Deserialize(fs);
            fs.Close();
            foreach (var val in serialisedData)
            {
                if (val == null)
                {
                    ViewBag.message = ("session cleared!");
                    ViewBag.color = "red";
                    return View("~/Views/Home/Index.cshtml");
                }
                if (val == "CN=ACC-PROD-TUNIS-WEB_CONTENU-AGENT")
                {
                    List<SelectListItem> li = new List<SelectListItem>();
                    li.Add(new SelectListItem { Text = "Select", Value = "0" });
                    li.Add(new SelectListItem { Text = "IPD", Value = "1" });
                    li.Add(new SelectListItem { Text = "WEB_AUTO", Value = "2" });
                    li.Add(new SelectListItem { Text = "TLF", Value = "3" });
                    Session["h_d"] = DateTime.Now;
                    Session["departement"] = "WEB_CONTENU";
                    ViewData["pole"] = li;
                    return View("~/Views/Historisation/Historisation_CONT_AL.cshtml");

                }
                else if (val == "CN=ACC-PROD-TUNIS-Bedouk_CTN-AGENT")
                {

                    DateTime h_debut = DateTime.Now;
                    List<SelectListItem> li = new List<SelectListItem>();
                    li.Add(new SelectListItem { Text = "Select", Value = "0" });
                    li.Add(new SelectListItem { Text = "WEB_BEDOUK", Value = "1" });
                    li.Add(new SelectListItem { Text = "GUIDE_BEDOUK", Value = "2" });
                    Session["h_d"] = DateTime.Now;
                    Session["departement"] = "BEDOUK";
                    ViewData["pole1"] = li;
                    return View("~/Views/Historisation/Historisation_CONT_HG.cshtml");
                }
                else if (val == "CN=ACC-PROD-TUNIS-EXPO_CTN-AGENT")
                {
                    List<SelectListItem> li = new List<SelectListItem>();
                    li.Add(new SelectListItem { Text = "Select", Value = "0" });
                    li.Add(new SelectListItem { Text = "EXPO", Value = "1" });
                    li.Add(new SelectListItem { Text = "Public_EXPO", Value = "2" });
                    Session["h_d"] = DateTime.Now;
                    Session["departement"] = "EXPO";
                    ViewData["pole2"] = li;
                    return View("~/Views/Historisation/Historisation_CONT_AF.cshtml");
                }
                if (val == "CN=ACC-TUN-DATA-TUNIS-MONITORING-REPORTING-TLF-RW")
                {
                    //List<SelectListItem> li = new List<SelectListItem>();
                    //li.Add(new SelectListItem { Text = "Select", Value = "0" });
                    //li.Add(new SelectListItem { Text = "IPD", Value = "1" });
                    //li.Add(new SelectListItem { Text = "WEB_AUTO", Value = "2" });
                    //li.Add(new SelectListItem { Text = "TLF", Value = "3" });
                    //Session["h_d"] = DateTime.Now;
                    //Session["departement"] = "WEB_CONTENU";
                    //ViewData["pole"] = li;
                    return View("~/Views/Historisation/Historisation_CONT_TLF.cshtml");

                }
            }
            return View();
        }

        public JsonResult GetSite(string id)
        {
            List<SelectListItem> site = new List<SelectListItem>();

            switch (id)
            {
                case "1":
                    site.Add(new SelectListItem { Text = "Select", Value = "0" });
                    site.Add(new SelectListItem { Text = "LSA", Value = "1" });
                    site.Add(new SelectListItem { Text = "ARG", Value = "2" });
                    site.Add(new SelectListItem { Text = "ECH", Value = "3" });
                    site.Add(new SelectListItem { Text = "UD", Value = "4" });
                    site.Add(new SelectListItem { Text = "ECHO T", Value = "5" });
                    site.Add(new SelectListItem { Text = "ADS", Value = "6" });
                    site.Add(new SelectListItem { Text = "AME", Value = "7" });
                    Session["polee"] = "IPD";
                    break;
                case "2":
                    site.Add(new SelectListItem { Text = "Select", Value = "8" });
                    site.Add(new SelectListItem { Text = "RTA", Value = "9" });
                    Session["polee"] = "WEB_AUTO";
                    break;
                case "3":
                    site.Add(new SelectListItem { Text = "Select", Value = "10" });
                    site.Add(new SelectListItem { Text = "TLF", Value = "11" });
                    Session["polee"] = "TLF";
                    break;
            }
            return Json(new SelectList(site, "Value", "Text"));
        }
        public JsonResult GetMission(string id)
        {

            List<SelectListItem> mission = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    mission.Add(new SelectListItem { Text = "Select", Value = "0" });
                    mission.Add(new SelectListItem { Text = "CREATION", Value = "1" });
                    mission.Add(new SelectListItem { Text = "MAJ", Value = "2" });
                    mission.Add(new SelectListItem { Text = "REECRITURES", Value = "3" });
                    mission.Add(new SelectListItem { Text = "GESTION_DE_CONTENU_WEB", Value = "4" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "5" });
                    Session["site"] = "LSA";
                    break;
                case "2":
                    mission.Add(new SelectListItem { Text = "Select", Value = "6" });
                    mission.Add(new SelectListItem { Text = "CREATION", Value = "7" });
                    mission.Add(new SelectListItem { Text = "MAJ", Value = "8" });
                    mission.Add(new SelectListItem { Text = "REECRITURES", Value = "9" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "10" });
                    Session["site"] = "ARG";
                    break;
                case "3":
                    mission.Add(new SelectListItem { Text = "Select", Value = "11" });
                    mission.Add(new SelectListItem { Text = "CREATION", Value = "12" });
                    mission.Add(new SelectListItem { Text = "MAJ", Value = "13" });
                    Session["site"] = "ECH";
                    break;
                case "4":
                    mission.Add(new SelectListItem { Text = "Select", Value = "14" });
                    mission.Add(new SelectListItem { Text = "CREATION", Value = "15" });
                    mission.Add(new SelectListItem { Text = "MAJ", Value = "16" });
                    mission.Add(new SelectListItem { Text = "REECRITURES", Value = "17" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "18" });
                    Session["site"] = "UD";
                    break;
                case "5":
                    mission.Add(new SelectListItem { Text = "Select", Value = "19" });
                    mission.Add(new SelectListItem { Text = "REECRITURES", Value = "20" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "21" });
                    Session["site"] = "ECHO_T";
                    break;
                case "6":
                    mission.Add(new SelectListItem { Text = "Select", Value = "22" });
                    mission.Add(new SelectListItem { Text = "GESTION_DE_CONTENU_WEB", Value = "23" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "24" });
                    Session["site"] = "ADS";
                    break;
                case "7":
                    mission.Add(new SelectListItem { Text = "Select", Value = "25" });
                    mission.Add(new SelectListItem { Text = "GESTION_DE_CONTENU_WEB", Value = "26" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "27" });
                    Session["site"] = "AME";
                    break;
                case "9":
                    mission.Add(new SelectListItem { Text = "Select", Value = "28" });
                    mission.Add(new SelectListItem { Text = "CREATION", Value = "29" });
                    mission.Add(new SelectListItem { Text = "MAJ", Value = "30" });
                    mission.Add(new SelectListItem { Text = "REECRITURES", Value = "31" });
                    mission.Add(new SelectListItem { Text = "GESTION_DE_CONTENU_WEB", Value = "32" });
                    mission.Add(new SelectListItem { Text = "CM", Value = "33" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "34" });
                    Session["site"] = "RTA";
                    break;
                case "11":
                    mission.Add(new SelectListItem { Text = "Select", Value = "35" });
                    mission.Add(new SelectListItem { Text = "CREATION", Value = "36" });
                    mission.Add(new SelectListItem { Text = "MAJ", Value = "37" });
                    mission.Add(new SelectListItem { Text = "REECRITURES", Value = "38" });
                    mission.Add(new SelectListItem { Text = "PROJETS EDITORIAUX(CONTENU)", Value = "39" });
                    Session["site"] = "TLF";
                    break;

            }

            return Json(new SelectList(mission, "Value", "Text"));
        }
        public JsonResult GetTache(string id)
        {

            List<SelectListItem> tache = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    tache.Add(new SelectListItem { Text = "Select", Value = "0" });
                    tache.Add(new SelectListItem { Text = "CDD_LSA", Value = "1" });
                    tache.Add(new SelectListItem { Text = "LSA_INNO", Value = "2" });
                    Session["mission"] = "Creation";
                    break;
                case "2":
                    tache.Add(new SelectListItem { Text = "Select", Value = "3" });
                    tache.Add(new SelectListItem { Text = "CDD_LSA", Value = "4" });
                    tache.Add(new SelectListItem { Text = "LSA_INNO", Value = "5" });
                    Session["mission"] = "MAJ";
                    break;
                case "3":
                    tache.Add(new SelectListItem { Text = "Select", Value = "6" });
                    tache.Add(new SelectListItem { Text = "REEC_LSA", Value = "7" });
                    tache.Add(new SelectListItem { Text = "REEC_LSA_INNO", Value = "8" });
                    Session["mission"] = "REECRITURES";
                    break;
                case "4":
                    tache.Add(new SelectListItem { Text = "Select", Value = "9" });
                    tache.Add(new SelectListItem { Text = "MEF_LSA_", Value = "10" });
                    Session["mission"] = "GESTION_DE_CONTENU_WEB";
                    break;
                case "5":
                    tache.Add(new SelectListItem { Text = "Select", Value = "11" });
                    tache.Add(new SelectListItem { Text = "________", Value = "12" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;
                case "7":
                    tache.Add(new SelectListItem { Text = "Select", Value = "13" });
                    tache.Add(new SelectListItem { Text = "CDDARG", Value = "14" });
                    Session["mission"] = "CREATION";
                    break;
                case "8":
                    tache.Add(new SelectListItem { Text = "Select", Value = "15" });
                    tache.Add(new SelectListItem { Text = "MAJ_CDD_ARG", Value = "16" });
                    Session["mission"] = "MAJ";
                    break;
                case "9":
                    tache.Add(new SelectListItem { Text = "Select", Value = "17" });
                    tache.Add(new SelectListItem { Text = "REEC_CDD_ARG", Value = "18" });
                    Session["mission"] = "REECRITURES";
                    break;
                case "10":
                    tache.Add(new SelectListItem { Text = "Select", Value = "19" });
                    tache.Add(new SelectListItem { Text = "________", Value = "20" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;
                case "12":
                    tache.Add(new SelectListItem { Text = "Select", Value = "21" });
                    tache.Add(new SelectListItem { Text = "CDD_ECHO_T", Value = "22" });
                    Session["mission"] = "CREATION";
                    break;
                case "13":
                    tache.Add(new SelectListItem { Text = "Select", Value = "23" });
                    tache.Add(new SelectListItem { Text = "MAJ_ECHO_T", Value = "24" });
                    Session["mission"] = "MAJ";
                    break;
                case "15":
                    tache.Add(new SelectListItem { Text = "Select", Value = "25" });
                    tache.Add(new SelectListItem { Text = "START_UP_UD", Value = "26" });
                    Session["mission"] = "CREATION";
                    break;
                case "16":
                    tache.Add(new SelectListItem { Text = "Select", Value = "27" });
                    tache.Add(new SelectListItem { Text = "MAJ_START_UP_MAJ", Value = "28" });
                    Session["mission"] = "MAJ";
                    break;
                case "17":
                    tache.Add(new SelectListItem { Text = "Select", Value = "29" });
                    tache.Add(new SelectListItem { Text = "REEC_START_UP_UD", Value = "30" });
                    Session["mission"] = "REECRITURES";
                    break;
                case "18":
                    tache.Add(new SelectListItem { Text = "Select", Value = "31" });
                    tache.Add(new SelectListItem { Text = "________", Value = "32" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;
                case "20":
                    tache.Add(new SelectListItem { Text = "Select", Value = "33" });
                    tache.Add(new SelectListItem { Text = "REEC_CDD__ECHO_T", Value = "34" });
                    Session["mission"] = "REECRITURES";
                    break;
                case "21":
                    tache.Add(new SelectListItem { Text = "Select", Value = "35" });
                    tache.Add(new SelectListItem { Text = "__________", Value = "36" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;
                case "23":
                    tache.Add(new SelectListItem { Text = "Select", Value = "37" });
                    tache.Add(new SelectListItem { Text = "MEF_ADS", Value = "38" });
                    Session["mission"] = "GESTION_DE_CONTENU_WEB";
                    break;
                case "24":
                    tache.Add(new SelectListItem { Text = "Select", Value = "39" });
                    tache.Add(new SelectListItem { Text = "__________", Value = "40" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;
                case "26":
                    tache.Add(new SelectListItem { Text = "Select", Value = "41" });
                    tache.Add(new SelectListItem { Text = "MEF_AME", Value = "42" });
                    Session["mission"] = "GESTION_DE_CONTENU_WEB";
                    break;
                case "27":
                    tache.Add(new SelectListItem { Text = "Select", Value = "43" });
                    tache.Add(new SelectListItem { Text = "________", Value = "44" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;
                case "29":
                    tache.Add(new SelectListItem { Text = "Select", Value = "45" });
                    tache.Add(new SelectListItem { Text = "DESC_RTA", Value = "46" });
                    tache.Add(new SelectListItem { Text = "GAMMES_RTA", Value = "47" });
                    Session["mission"] = "CREATION";
                    break;
                case "30":
                    tache.Add(new SelectListItem { Text = "Select", Value = "48" });
                    tache.Add(new SelectListItem { Text = "MAJ_DESC__RTA", Value = "49" });
                    tache.Add(new SelectListItem { Text = "MAJ_GAMMES_RTA", Value = "50" });
                    Session["mission"] = "MAJ";
                    break;
                case "31":
                    tache.Add(new SelectListItem { Text = "Select", Value = "51" });
                    tache.Add(new SelectListItem { Text = "REEC_DESC_RTA", Value = "52" });
                    tache.Add(new SelectListItem { Text = "REEC_GAMMES_RTA", Value = "53" });
                    Session["mission"] = "REECRITURES";
                    break;
                case "32":
                    tache.Add(new SelectListItem { Text = "Select", Value = "54" });
                    tache.Add(new SelectListItem { Text = "MEF_RTA", Value = "55" });
                    Session["mission"] = "GESTION_DE_CONTENU_WEB";
                    break;
                case "33":
                    tache.Add(new SelectListItem { Text = "Select", Value = "56" });
                    tache.Add(new SelectListItem { Text = "PARTENARIATS", Value = "57" });
                    tache.Add(new SelectListItem { Text = "CM_FB", Value = "58" });
                    tache.Add(new SelectListItem { Text = "PIRATES", Value = "59" });
                    tache.Add(new SelectListItem { Text = "E_REPUTATION", Value = "60" });
                    tache.Add(new SelectListItem { Text = "NETLINKING", Value = "61" });
                    Session["mission"] = "CM";
                    break;
                case "34":
                    tache.Add(new SelectListItem { Text = "Select", Value = "62" });
                    tache.Add(new SelectListItem { Text = "________", Value = "63" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;
                case "36":
                    tache.Add(new SelectListItem { Text = "Select", Value = "64" });
                    tache.Add(new SelectListItem { Text = "NEWS_TLF", Value = "65" });
                    tache.Add(new SelectListItem { Text = "CONCEPT_TLF", Value = "66" });
                    Session["mission"] = "CREATION";
                    break;
                case "37":
                    tache.Add(new SelectListItem { Text = "Select", Value = "67" });
                    tache.Add(new SelectListItem { Text = "MAJ_NEWS_TLF", Value = "68" });
                    tache.Add(new SelectListItem { Text = "MAJ_CONCEPT_TLF", Value = "69" });
                    Session["mission"] = "MAJ";

                    break;
                case "38":
                    tache.Add(new SelectListItem { Text = "Select", Value = "70" });
                    tache.Add(new SelectListItem { Text = "REEC_NEWS_TLF", Value = "71" });
                    tache.Add(new SelectListItem { Text = "REEC_CONCEPT_TLF", Value = "72" });
                    Session["mission"] = "REECRITURES";
                    break;
                case "39":
                    tache.Add(new SelectListItem { Text = "Select", Value = "73" });
                    tache.Add(new SelectListItem { Text = "________", Value = "74" });
                    Session["mission"] = "PROJETS EDITORIAUX(CONTENU)";
                    break;

            }
            return Json(new SelectList(tache, "Value", "Text"));
        }
        public JsonResult GetTacheValue(string id)
        {
            List<SelectListItem> tachee = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "CDD_LSA";
                    break;
                case "2":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "LSA_INNO";
                    break;
                case "4":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "CDD_LSA";
                    break;
                case "5":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "LSA_INNO";
                    break;
                case "7":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_LSA";
                    break;
                case "8":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_LSA_INNO";
                    break;
                case "10":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MEF_LSA_";
                    break;
                case "12":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;
                case "14":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "CDDARG";
                    break;
                case "16":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MAJ_CDD_ARG";
                    break;
                case "18":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_CDD_ARG";
                    break;
                case "20":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;
                case "22":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "CDD_ECHO_T";
                    break;
                case "24":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MAJ_ECHO_T";
                    break;
                case "26":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "START_UP_UD";
                    break;
                case "28":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MAJ_START_UP_MAJ";
                    break;
                case "30":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_START_UP_UD";
                    break;
                case "32":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;
                case "34":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_CDD__ECHO_T";
                    break;
                case "36":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;
                case "38":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MEF_ADS";
                    break;
                case "40":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;
                case "42":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MEF_AME";
                    break;
                case "44":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;
                case "46":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "DESC_RTA";
                    break;
                case "47":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "GAMMES_RTA";
                    break;
                case "49":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MAJ_DESC__RTA";
                    break;
                case "50":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MAJ_GAMMES__RTA";
                    break;
                case "52":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_DESC_RTA";
                    break;
                case "53":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_GAMMES_RTA";
                    break;
                case "55":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MEF_RTA";
                    break;
                case "57":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "PARTENARIATS";
                    break;
                case "58":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "CM_FB";
                    break;
                case "59":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "PIRATES";
                    break;
                case "60":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "E_REPUTATION";
                    break;
                case "61":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "NETLINKING";
                    break;
                case "63":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;
                case "65":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "NEWS_TLF";
                    break;
                case "66":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "CONCEPT_TLF";
                    break;
                case "68":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MAJ_NEWS_TLF";
                    break;
                case "69":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "MAJ_CONCEPT_TLF";
                    break;
                case "71":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_NEWS_TLF";
                    break;
                case "72":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "REEC_CONCEPT_TLF";
                    break;
                case "74":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["tache"] = "________";
                    break;

            }
            return Json(new SelectList(tachee, "Value", "Text"));
        }
        public JsonResult GetMission1(string id)
        {
            List<SelectListItem> mission = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    mission.Add(new SelectListItem { Text = "Select", Value = "0" });
                    mission.Add(new SelectListItem { Text = "Contenu_Payant", Value = "1" });
                    mission.Add(new SelectListItem { Text = "Contenu_Gratuit", Value = "2" });
                    mission.Add(new SelectListItem { Text = "Mission_SEO", Value = "3" });
                    Session["polee1"] = "WEB_BEDOUK";

                    break;
                case "2":
                    mission.Add(new SelectListItem { Text = "Select", Value = "4" });
                    mission.Add(new SelectListItem { Text = "________", Value = "5" });
                    Session["polee1"] = "GUIDE_BEDOUK";
                    break;

            }
            return Json(new SelectList(mission, "Value", "Text"));
        }
        public JsonResult GetTache1(string id)
        {
            List<SelectListItem> tache = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    tache.Add(new SelectListItem { Text = "Select", Value = "0" });
                    tache.Add(new SelectListItem { Text = "Mise en ligne fiche", Value = "1" });
                    tache.Add(new SelectListItem { Text = "Optimisation Fiche-Maj Fiche", Value = "2" });
                    tache.Add(new SelectListItem { Text = "Traduction", Value = "3" });
                    tache.Add(new SelectListItem { Text = "Audit", Value = "4" });
                    tache.Add(new SelectListItem { Text = "Depublication", Value = "5" });
                    tache.Add(new SelectListItem { Text = "Mel Publi-redact-CDP", Value = "6" });
                    Session["mission1"] = "Contenu_Payant";
                    break;
                case "2":
                    tache.Add(new SelectListItem { Text = "Select", Value = "7" });
                    tache.Add(new SelectListItem { Text = "Mise en ligne fiche", Value = "8" });
                    tache.Add(new SelectListItem { Text = "Optimisation Fiche-Maj Fiche", Value = "9" });
                    tache.Add(new SelectListItem { Text = "Traduction", Value = "10" });
                    tache.Add(new SelectListItem { Text = "Audit", Value = "11" });
                    tache.Add(new SelectListItem { Text = "Depublication", Value = "12" });
                    tache.Add(new SelectListItem { Text = "Mel Publi-redact-CDP", Value = "13" });
                    Session["mission1"] = "Contenu_Gratuit";
                    break;

                case "3":
                    tache.Add(new SelectListItem { Text = "Select", Value = "14" });
                    tache.Add(new SelectListItem { Text = "Mission SEO POI", Value = "15" });
                    tache.Add(new SelectListItem { Text = "Mission SEO-salle de reunion", Value = "16" });
                    Session["mission1"] = "Mission_SEO";
                    break;

                case "5":
                    tache.Add(new SelectListItem { Text = "Select", Value = "17" });
                    tache.Add(new SelectListItem { Text = "Insertion", Value = "18" });
                    tache.Add(new SelectListItem { Text = "Correction", Value = "19" });
                    tache.Add(new SelectListItem { Text = "Relecture", Value = "20" });
                    tache.Add(new SelectListItem { Text = "BAT Prêt", Value = "21" });
                    tache.Add(new SelectListItem { Text = "Maquette", Value = "22" });
                    tache.Add(new SelectListItem { Text = "Trafic", Value = "23" });
                    tache.Add(new SelectListItem { Text = "Attente Element Client", Value = "24" });
                    tache.Add(new SelectListItem { Text = "Bat envoyé", Value = "25" });
                    tache.Add(new SelectListItem { Text = "Ppour BAT ok", Value = "26" });
                    Session["mission1"] = "________";
                    break;
            }
            return Json(new SelectList(tache, "Value", "Text"));
        }
        public JsonResult GetTache1Value(string id)
        {
            List<SelectListItem> tachee = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "0" });
                    Session["tache1"] = "Mise en ligne fiche";

                    break;
                case "2":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "7" });
                    Session["tache1"] = "Optimisation Fiche-Maj Fiche";

                    break;

                case "3":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "14" });
                    Session["tache1"] = "Traduction";

                    break;

                case "4":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Audit";
                    break;
                case "5":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Depublication";
                    break;
                case "6":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Mel Publi-redact-CDP";
                    break;
                case "8":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "0" });
                    Session["tache1"] = "Mise en ligne fiche";
                    break;
                case "9":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "7" });
                    Session["tache1"] = "Optimisation Fiche-Maj Fiche";
                    break;
                case "10":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "14" });
                    Session["tache1"] = "Traduction";
                    break;
                case "11":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Audit";
                    break;
                case "12":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Depublication";
                    break;
                case "13":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Mel Publi-redact-CDP";
                    break;
                case "15":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Mission SEO POI";
                    break;
                case "16":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Mission SEO-salle de reunion";
                    break;
                case "18":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Insertion";
                    break;
                case "19":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Correction";
                    break;
                case "20":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Relecture";
                    break;
                case "21":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "BAT Prêt";
                    break;
                case "22":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Maquette";
                    break;
                case "23":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Trafic";
                    break;
                case "24":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Attente Element Client";
                    break;
                case "25":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Bat envoyé";
                    break;
                case "26":
                    tachee.Add(new SelectListItem { Text = "Select", Value = "17" });
                    Session["tache1"] = "Ppour BAT ok";
                    break;

            }
            return Json(new SelectList(tachee, "Value", "Text"));
        }
        public JsonResult GetMission2(string id)
        {
            List<SelectListItem> mission = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    mission.Add(new SelectListItem { Text = "Select", Value = "0" });
                    mission.Add(new SelectListItem { Text = "Rédaction et Mise en Ligne Offres", Value = "2" });
                    mission.Add(new SelectListItem { Text = "Mise à jour Offre", Value = "3" });
                    mission.Add(new SelectListItem { Text = "Rédaction d'articles", Value = "4" });
                    mission.Add(new SelectListItem { Text = "Catégorisation", Value = "5" });
                    mission.Add(new SelectListItem { Text = "Rédaction descriptions", Value = "6" });
                    mission.Add(new SelectListItem { Text = "Community Management", Value = "7" });
                    mission.Add(new SelectListItem { Text = "Autres", Value = "8" });
                    Session["polee2"] = "EXPO";
                    break;
                case "2":
                    mission.Add(new SelectListItem { Text = "Select", Value = "9" });
                    mission.Add(new SelectListItem { Text = "Rédaction et Mise en Ligne Offres", Value = "10" });
                    mission.Add(new SelectListItem { Text = "Mise à jour Offre", Value = "11" });
                    mission.Add(new SelectListItem { Text = "Rédaction d'articles", Value = "12" });
                    mission.Add(new SelectListItem { Text = "Catégorisation", Value = "13" });
                    mission.Add(new SelectListItem { Text = "Rédaction descriptions", Value = "14" });
                    mission.Add(new SelectListItem { Text = "Community Management", Value = "15" });
                    mission.Add(new SelectListItem { Text = "Autres", Value = "16" });
                    Session["polee2"] = "PUBLIC_EXPO";
                    break;

            }
            return Json(new SelectList(mission, "Value", "Text"));
        }
        public JsonResult GetMission2Value(string id)
        {
            List<SelectListItem> missionn = new List<SelectListItem>();
            switch (id)
            {
                case "2":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "0" });
                    Session["mission2"] = "Rédaction et Mise en Ligne Offres";
                    break;
                case "3":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "1" });
                    Session["mission2"] = "Mise à jour Offre";
                    break;
                case "4":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "2" });
                    Session["mission2"] = "Rédaction d'articles";
                    break;
                case "5":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "3" });
                    Session["mission2"] = "Catégorisation";
                    break;
                case "6":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "4" });
                    Session["mission2"] = "Rédaction descriptions";
                    break;
                case "7":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "5" });
                    Session["mission2"] = "Community Management";
                    break;
                case "8":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "6" });
                    Session["mission2"] = "Autres";
                    break;
                case "10":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "7" });
                    Session["mission2"] = "Rédaction et Mise en Ligne Offres";
                    break;
                case "11":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "8" });
                    Session["mission2"] = "Mise à jour Offre";
                    break;
                case "12":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "9" });
                    Session["mission2"] = "Rédaction d'articles";
                    break;
                case "13":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "10" });
                    Session["mission2"] = "Catégorisation";
                    break;
                case "14":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "11" });
                    Session["mission2"] = "Rédaction descriptions";
                    break;
                case "15":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "12" });
                    Session["mission2"] = "Community Management";
                    break;
                case "16":
                    missionn.Add(new SelectListItem { Text = "Select", Value = "13" });
                    Session["mission2"] = "Autres";
                    break;

            }
            return Json(new SelectList(missionn, "Value", "Text"));
        }

        [HttpPost]
        public ActionResult HistorisationAL()
        {
            string login = (string)(Session["login"]);
            Employe emp = service1.getByLogout(login);
            DateTime h_d = (DateTime)(Session["h_d"]);
            DateTime h_f = DateTime.Now;
            System.TimeSpan diff1 = h_f.Subtract(h_d);
            string duree = diff1.Hours + "  Heures  " + diff1.Minutes + "  Minutes " + diff1.Seconds + " Secondes"; ;
            
            Histo Historisation_Cont = new Histo()
            {

                poles = (string)(Session["polee"]),
                site = (string)(Session["site"]),
                mission = (string)(Session["mission"]),
                tache = (string)(Session["tache"]),
                h_debut = h_d,
                h_fin = h_f,
                EmployeID=emp.EmployeID,
                duree = duree,
                departement = "WEB",
            };
            service.Add(Historisation_Cont);
            service.SaveChange();
            Session["h_d"] = DateTime.Now;
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "IPD", Value = "1" });
            li.Add(new SelectListItem { Text = "WEB_AUTO", Value = "2" });
            li.Add(new SelectListItem { Text = "TLF", Value = "3" });
            ViewData["pole"] = li;
            return View("~/Views/Historisation/Historisation_CONT_AL.cshtml");
        }

        public ActionResult HistorisationHG()
        {
            string login = (string)(Session["login"]);
            Employe emp = service1.getByLogout(login);
            DateTime h_d = (DateTime)(Session["h_d"]);
            DateTime h_f = DateTime.Now;
            System.TimeSpan diff1 = h_f.Subtract(h_d);
            string duree = diff1.Hours + "  Heures  " + diff1.Minutes + "  Minutes " + diff1.Seconds + " Secondes"; 
                        
            Histo Historisation_Cont = new Histo()
            {

                poles = (string)(Session["polee1"]),
                site = (string)(Session["site1"]),
                mission = (string)(Session["mission1"]),
                tache = (string)(Session["tache1"]),
                h_debut = h_d,
                h_fin = h_f,
                EmployeID=emp.EmployeID,
                duree = duree,
                departement = "Bedouk",
                              
            };
            service.Add(Historisation_Cont);
            service.SaveChange();
            DateTime h_debut = DateTime.Now;
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "WEB_BEDOUK", Value = "1" });
            li.Add(new SelectListItem { Text = "GUIDE_BEDOUK", Value = "2" });
            Session["h_d"] = DateTime.Now;
            ViewData["pole1"] = li;
            return View("~/Views/Historisation/Historisation_CONT_HG.cshtml");
        }

        public ActionResult HistorisationAF(Histo histo)
        {
            string login = (string)(Session["login"]);
            Employe emp = service1.getByLogout(login);
            DateTime h_d = (DateTime)(Session["h_d"]);
            DateTime h_f = DateTime.Now;
            System.TimeSpan diff1 = h_f.Subtract(h_d);
            string duree = diff1.Hours + "  Heures  " + diff1.Minutes + "  Minutes " + diff1.Seconds + " Secondes"; ;
            //int nbr = histo.nbDossiersTr;
            //if (nbr == 0)
            //{
            //    nbr = 1;
            //}
            if (!ModelState.IsValid)
            {
                RedirectToAction("HistorisationAF");
            }
            else
            {
                Histo Historisation_Cont = new Histo()
                {
                    poles = (string)(Session["polee2"]),
                    mission = (string)(Session["mission2"]),
                    h_debut = h_d,
                    h_fin = h_f,
                    duree = duree,
                    departement = "Expo",
                    nbDossiersTr = histo.nbDossiersTr,
                    EmployeID=emp.EmployeID

                    //Employe= (string)(Session["nomPrenom"])
                };
                service.Add(Historisation_Cont);
                service.SaveChange();
                Session["h_d"] = DateTime.Now;
                }
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "EXPO", Value = "1" });
            li.Add(new SelectListItem { Text = "Public_EXPO", Value = "2" });
            ViewData["pole2"] = li;
            return View("~/Views/Historisation/Historisation_CONT_AF.cshtml");
        }

        public ActionResult HistorisationTLF(Histo histo)
        {
            string login = (string)(Session["login"]);
            Employe emp = service1.getByLogout(login);
            DateTime h_d = (DateTime)(Session["h_d"]);
            DateTime h_f = DateTime.Now;
            System.TimeSpan diff1 = h_f.Subtract(h_d);
            string duree = diff1.Hours + "  Heures  " + diff1.Minutes + "  Minutes " + diff1.Seconds + " Secondes";
            return View("~/Views/Historisation/Historisation_CONT_TLF.cshtml");
        }

        // GET: Historisation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Historisation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historisation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Historisation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Historisation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Historisation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Historisation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
