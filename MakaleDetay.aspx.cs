using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Sporizma
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                dm.MakaleGoruntulemeArttir(id);
                Makale m = dm.MakaleGetir(id);
                ltrl_baslik.Text = m.Baslik;
                img_resim.ImageUrl = "resim/MakaleResim/" + m.KapakResim;
                ltrl_goruntulemeSayi.Text = m.GoruntulemeSayi.ToString();
                ltrl_icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.Kategori;
                ltrl_yazar.Text = m.Yazar;
                ltrl_ozet.Text = m.Ozet;

                if(Session["uye"] !=null)
                { 
                    pnl_Girisvar.Visible = true;
                    pnl_Girisyok.Visible = false;
                }
                else
                {
                    pnl_Girisvar.Visible = false;
                    pnl_Girisyok.Visible = true;
                }
                rp_yorumlar.DataSource = dm.YorumListele(id);
                rp_yorumlar.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_yorumyap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Yorum y = new Yorum();
            y.ID = id;
            y.UyeID = ((Uyeler)Session["uye"]).ID;
            y.Icerik = tb_yorum.Text;
            y.EklemeTarih = DateTime.Now;
            y.Durum = true;
            if(dm.YorumEkle(y))
            {
                Response.Write("<script>alert('Yorum Alındı. Onay verilince yayınlanacktır')</script>");
            }
            else
            {
                Response.Write("<script>alert('Başarısız')</script>");
            }
        }
    }
}