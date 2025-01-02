using BusinessLogic.BLL;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Context;
using DTO.Model;
using System.Linq;

public class HomeController : Controller
{
    private readonly AfdelingBLL _afdelingBLL;
    private readonly TidsregistreringBLL _tidsregistreringBLL;
    private readonly MedarbejderBLL _medarbejderBLL;
    private readonly SagBLL _sagBLL;

    public HomeController(AfdelingBLL afdelingBLL, TidsregistreringBLL tidsregistreringBLL, MedarbejderBLL medarbejderBLL, SagBLL sagBll)
    {
        _afdelingBLL = afdelingBLL;
        _tidsregistreringBLL = tidsregistreringBLL;
        _medarbejderBLL = medarbejderBLL;
        _sagBLL = sagBll;
    }

    // This is the action that loads the view with the dropdown data for departments (afdelinger)
    public IActionResult Index()
    {
        var afdelinger = AfdelingBLL.FetchAfdelinger();
        ViewBag.Afdelinger = afdelinger;
        return View();
    }
    
    [HttpGet]
    public IActionResult GetMedarbejdere(int afdelingNr)
    {
        var medarbejdere = AfdelingBLL.FetchMedarbejdere(afdelingNr);
        //var medarbejdere = _medarbejderBLL.FetchMedarbejdere();

        return PartialView("_MedarbejderDropdown", medarbejdere);
    }

    [HttpGet]
    public IActionResult GetSager(int afdelingNr)
    {
        var sager = AfdelingBLL.FetchSager(afdelingNr);
        //var sager = _sagBLL.FetchSager();

        return PartialView("_SagDropdown", sager);
    }

    [HttpPost]
    public JsonResult RegisterTime(int medarbejderId, int sagsId, DateTime start, DateTime slut)
    {
        try
        {
            if (medarbejderId <= 0 || sagsId <= 0 || start == default || slut == default)
            {
                return Json(new { success = false, message = "Invalid input data." });
            }

            _tidsregistreringBLL.RegistrerTid(medarbejderId, sagsId, start, slut);
            return Json(new { success = true, message = "Tidsregistrering created successfully." });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"Error creating tidsregistrering: {ex.Message}" });
        }
    }

}

