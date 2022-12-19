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
    public partial class AggiungiImpiegato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void AggiungiImp_Click(object sender, EventArgs e)
        {
            try
            {
                List<Dipendente> listDip = new List<Dipendente>();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Edil_Portale"].ToString();
                con.Open();


                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = "AggiungiImpiego ";
                com.Connection = con;
                SqlDataReader reader = com.ExecuteReader();

                com.Parameters.AddWithValue("Nome", TextNome.Text);
                com.Parameters.AddWithValue("Cognome", TextCognome.Text);
                com.Parameters.AddWithValue("Indirizzo", TextIndirizzo.Text);
                com.Parameters.AddWithValue("CF", TextCf.Text);

                if(CkbNo.Checked) 
                {
                    com.Parameters.AddWithValue("Coniugato", 0);
                }else if (CkbSi.Checked) 
                {
                    com.Parameters.AddWithValue("Coniugato", 1);
                }

                com.Parameters.AddWithValue("FigliACarico", TextFigli.Text);
                com.Parameters.AddWithValue("StipendioMensile", TextStipendio.Text);


                con.Close();

              

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
