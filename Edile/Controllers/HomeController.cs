using Edile.Models;
using Edile.WievModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edile.Controllers
{
    public class HomeController : Controller
    {


        static string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);


        public ActionResult Index()
        {

            List<RecordPagamento> pagamenti = new List<RecordPagamento>();
            List<Dipendente> dipendenti = new List<Dipendente>();

            //-----------------PAGAMENTI------------------------------
            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT IdPagamento, Data, Ammontare, Acconto, idDipendente, Nome , Cognome  FROM Pagamenti INNER JOIN Dipendenti ON Pagamenti.idDip = Dipendenti.idDipendente";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string IdPagamento = reader["IdPagamento"].ToString();
                    string Data = reader["Data"].ToString().Substring(0, 10);

                    string Ammontare = reader["Ammontare"].ToString();
                    string[] Cifra;

                    Cifra = Ammontare.Split(',');

                    string Totale = Cifra[0] + "." + Cifra[1].Substring(0, 2);

                    string Acconto = reader["Acconto"].ToString() == "True" ? "Si" : "No";
                    string IdDipendente = reader["idDipendente"].ToString();
                    string Nome = reader["Nome"].ToString();
                    string Cognome = reader["Cognome"].ToString();

                    RecordPagamento pagamentoToAdd = new RecordPagamento(IdPagamento, Data, Totale, Acconto, IdDipendente, Nome, Cognome);

                    pagamenti.Add(pagamentoToAdd);



                }
                reader.Close();


            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }

            //---------------DIPENDENTI--------------------------------
            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Dipendenti";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string IdDipendente = reader["IdDipendente"].ToString();
                    string Nome = reader["Nome"].ToString();

                    string Cognome = reader["Cognome"].ToString();
                    string CF = reader["CF"].ToString().Substring(0, 4);

                    bool Coniugato = reader["Coniugato"].ToString() == "True" ? true : false;
                    int NumFigli = int.Parse(reader["NumeroFigli"].ToString());
                    string Mansione = reader["Mansione"].ToString();


                    Dipendente Dipendente = new Dipendente(IdDipendente, Nome, Cognome, CF, Coniugato, NumFigli, Mansione);

                    dipendenti.Add(Dipendente);



                }
                reader.Close();


            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }



            Pagamenti_Lista vm = new Pagamenti_Lista();
            vm.Pagamenti = pagamenti;
            vm.Dipendenti = dipendenti;
            return View(vm);


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult EditPerson(int id)
        {

            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"SELECT * FROM Dipendenti WHERE IdDipendente = {id}";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string IdDipendente = reader["IdDipendente"].ToString();
                    string Nome = reader["Nome"].ToString();

                    string Cognome = reader["Cognome"].ToString();
                    string CF = reader["CF"].ToString();

                    bool Coniugato = reader["Coniugato"].ToString() == "True" ? true : false;
                    int NumFigli = int.Parse(reader["NumeroFigli"].ToString());
                    string Mansione = reader["Mansione"].ToString();


                    Dipendente DipendenteSelezionato = new Dipendente(IdDipendente, Nome, Cognome, CF, Coniugato, NumFigli, Mansione);

                    return View(DipendenteSelezionato);



                }
                reader.Close();


            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }



            return RedirectToAction("Index");
            // return View(DipendenteSelezionato);
        }

        [HttpPost]

        public ActionResult EditPerson(Dipendente DipendenteUpdate)
        {

            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"UPDATE Dipendenti SET Nome = @Nome, Cognome = @Cognome, CF = @CF, Coniugato = @Coniugato, NumeroFigli = @NumeroFigli, Mansione = @Mansione  WHERE IdDipendente = @ID";

                cmd.Parameters.AddWithValue("@ID", DipendenteUpdate.ID);
                cmd.Parameters.AddWithValue("@Nome", DipendenteUpdate.Nome);
                cmd.Parameters.AddWithValue("@Cognome", DipendenteUpdate.Cognome);
                cmd.Parameters.AddWithValue("@CF", DipendenteUpdate.CF);
                cmd.Parameters.AddWithValue("@Coniugato", DipendenteUpdate.Coniugato);
                cmd.Parameters.AddWithValue("@NumeroFigli", DipendenteUpdate.NumeroFigli);
                cmd.Parameters.AddWithValue("@Mansione", DipendenteUpdate.Mansione);


                cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DeletePerson(int id)
        {

            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"SELECT * FROM Dipendenti WHERE IdDipendente = {id}";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string IdDipendente = reader["IdDipendente"].ToString();
                    string Nome = reader["Nome"].ToString();

                    string Cognome = reader["Cognome"].ToString();
                    string CF = reader["CF"].ToString();

                    bool Coniugato = reader["Coniugato"].ToString() == "True" ? true : false;
                    int NumFigli = int.Parse(reader["NumeroFigli"].ToString());
                    string Mansione = reader["Mansione"].ToString();


                    Dipendente DipendenteSelezionato = new Dipendente(IdDipendente, Nome, Cognome, CF, Coniugato, NumFigli, Mansione);

                    return View(DipendenteSelezionato);



                }
                reader.Close();


            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }



            return RedirectToAction("Index");
            // return View(DipendenteSelezionato);
        }




        [HttpPost]

        public ActionResult DeletePerson(Dipendente DipendenteDelete)
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"DELETE FROM Dipendenti WHERE IdDipendente = {DipendenteDelete.ID}";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");

        }
    }
    
}