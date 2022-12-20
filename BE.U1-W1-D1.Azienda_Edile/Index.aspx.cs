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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                try 
                {
                    List<Dipendente> listDip = new List<Dipendente>();
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["Edil_Portale"].ToString();
                    con.Open();


                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT IdDipendente, Nome, Cognome, Mansione, StipendioMensile FROM DIPENDENTE ";
                    com.Connection = con;
                    SqlDataReader reader = com.ExecuteReader();


                    while (reader.Read()) 
                    {
                        Dipendente d = new Dipendente();
                        d.Id = Convert.ToInt32(reader["IdDipendente"]);
                        d.Nome = reader["Nome"].ToString();
                        d.Cognome = reader["Cognome"].ToString();
                        d.Mansione = reader["Mansione"].ToString();
                        d.StipendioMensile = Convert.ToDouble(reader["StipendioMensile"]);
                
                    listDip.Add(d);
                    }
                    con.Close();

                    GridViewDipendenti.DataSource= listDip; 

                    GridViewDipendenti.DataBind();

                }
                catch (Exception ex)
                {
                    lblErrore.Text = ex.Message;
                    lblErrore.Visible = true;
                    lblMessaggio.Visible = true;
                }

            }
        }
    }
}