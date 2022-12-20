using BE.U1_W1_D1.Azienda_Edile.Classi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BE.U1_W1_D1.Azienda_Edile
{
    public partial class SchedaDipendenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["IdDipendente"];

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Edil_Portale"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.CommandText = "SELECT * FROM Dipendente WHERE IdDipendente=@IdDipendente";
                com.Connection = conn;

                com.Parameters.AddWithValue("idDipendente", id);

                SqlDataReader reader = com.ExecuteReader();

                Dipendente d = new Dipendente();

                while (reader.Read())
                {
                    d.Id = Convert.ToInt32(reader["IdDipendente"]);
                    d.Nome = reader["Nome"].ToString();
                    d.Cognome = reader["Cognome"].ToString();
                    d.Coniugato = Convert.ToBoolean(reader["Coniugato"].ToString());
                    d.Indirizzo = reader["Indirizzo"].ToString();
                    d.CF = reader["CodiceFiscale"].ToString();
                    d.Figli = Convert.ToInt32(reader["FigliACarico"]);
                    d.Mansione = reader["Mansione"].ToString();
                    d.StipendioMensile = Convert.ToDouble(reader["StipendioMensile"]);
                }

                lblId.Text = d.Id.ToString();
                lblCognome.Text = d.Cognome.ToString();
                lblNome.Text = d.Nome.ToString();
                lblMansione.Text = d.Mansione.ToString();
                lblIndirizzo.Text = d.Indirizzo.ToString();
                lblCF.Text = d.CF.ToString();
                lblStipendio.Text = d.StipendioMensile.ToString("c2");
                if (d.Coniugato)
                {
                    lblConiugato.Text = "Coniugato";
                }
                else
                {
                    lblConiugato.Text = "Non Coniugato";
                }
                if (d.Figli > 0)
                {
                    lblFigli.Text = $"{d.Figli} figli a carico";
                }
                else
                {
                    lblFigli.Text = "Nessun figlio a carico";
                }



                conn.Close();
            }

            catch (Exception ex)
            {
                lblErrore.Text = ex.Message;
                lblMessages.Visible = true;
                lblErrore.Visible = true;
            
             }
            try { 

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Edil_Portale"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.Parameters.AddWithValue("Id", id);
                com.CommandText = "SELECT * FROM Dipendente AS D FULL JOIN PAGAMENTI AS P ON D.IdDipendente = P.IdDipendente INNER JOIN STIPENDIO AS S on S.IdStipendio = P.IdStipendio where D.IdDipendente=@Id";
                com.Connection = conn;


                SqlDataReader reader = com.ExecuteReader();

                List<Dipendente> listdip = new List<Dipendente>();

                while (reader.Read())
                {
                    Dipendente dip = new Dipendente();
                    dip.TipoStipendio = reader["TipoStipendio"].ToString();
                    dip.DataPagamento = Convert.ToDateTime(reader["DataPagamento"]);
                    dip.ImportoPagamento = Convert.ToDouble(reader["ImportoPagamento"]);
                    listdip.Add(dip);
                }

                GridViewPage.DataSource= listdip;
                GridViewPage.DataBind();

                conn.Close();


            }
            catch (Exception ex)
            {
                lblErrore.Text = ex.Message;
                lblMessages.Visible = true;
                lblErrore.Visible = true;
            }
            if (!IsPostBack)
            {

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["Edil_Portale"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM STIPENDIO";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Dipendente s = new Dipendente();
                    s.IdStipendio = Convert.ToInt32(reader["IdStipendio"]);
                    s.TipoStipendio = reader["TipoStipendio"].ToString();
                    ListItem l = new ListItem(s.TipoStipendio, s.IdStipendio.ToString());
                    ddlTipoStip.Items.Add(l);
                }



                connection.Close();

            }
        }

        protected void AddPay_Click(object sender, EventArgs e)
        {
            Payment.Visible = true;
        }


        protected void SavePay_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["IdDipendente"];
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Edil_Port"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = "AddPayment";
                com.Connection = conn;

                com.Parameters.AddWithValue("IdDipendente", id);
                com.Parameters.AddWithValue("IdStipendio", ddlTipoStip.SelectedItem.Value);
                com.Parameters.AddWithValue("DataPagamento", Calendar1.SelectedDate);
                com.Parameters.AddWithValue("ImportoPagamento", txtImporto.Text);

                int row = com.ExecuteNonQuery();

                if (row > 0)
                {
                    Payment.Visible = false;
                    lblMessages.Visible = true;
                    lblPayInsert.Visible = true;
                    lblPayInsert.Text = "Pagamento inserito con successo!";
                }

                conn.Close();


            }
            catch (Exception ex)
            {
                lblErrore.Text = ex.Message;
                lblMessages.Visible = true;
                lblErrore.Visible = true;
            }
        }
    }
}
