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
    public partial class Pagamenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Edil_Portale"].ToString();
                conn.Open();

                SqlCommand com = new SqlCommand();
                com.CommandText = "SELECT * FROM Dipendente AS D FULL JOIN PAGAMENTI AS P ON D.IdDipendente = P.IdDipendente INNER JOIN STIPENDIO AS S on S.IdStipendio = P.IdStipendio ORDER BY P.DataPagamento desc";
                com.Connection = conn;


                SqlDataReader read = com.ExecuteReader();

                List<Dipendente> listdip = new List<Dipendente>();

                while (read.Read())
                {
                    Dipendente dip = new Dipendente();
                    dip.Nome = read["Nome"].ToString();
                    dip.Nome = read["Cognome"].ToString();
                    dip.TipoStipendio = read["TipoStipendio"].ToString();
                    dip.DataPagamento = Convert.ToDateTime(read["DataPagamento"]);
                    dip.ImportoPagamento = Convert.ToDouble(read["ImportoPagamento"]);
                    listdip.Add(dip);
                }

                GWPagamenti.DataSource = listdip;
                GWPagamenti.DataBind();

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
