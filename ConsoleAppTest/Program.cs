


using BusinessLogic.BLL;
using System;

AfdelingBLL afdelingBLL = new AfdelingBLL();
MedarbejderBLL medarbejderBLL = new MedarbejderBLL();
SagBLL sagBLL = new SagBLL();
TidsregistreringBLL tidsregistreringBLL = new TidsregistreringBLL();

//test 

Console.WriteLine("ID Medarbejder " + medarbejderBLL.GetMedarbejder(1).MedarbejderId);

Console.WriteLine("ID Sag " + sagBLL.getSag(1).SagsId);


