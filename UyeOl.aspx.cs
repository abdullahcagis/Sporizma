using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;


namespace Sporizma
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_uyetur.DataSource = dm.UyeListele();
                ddl_uyetur.DataBind();
            }
        }

        protected void btn_grs_Click(object sender, EventArgs e)
        {
            Uyeler y = new Uyeler();
            y.UyeTurleriID = Convert.ToInt32(ddl_uyetur.SelectedItem.Value);
            y.Isim = tb_ad.Text;
            y.Soyisim = tb_soyad.Text;
            y.KullaniciAdi = tb_klncad.Text;
            y.Mail = tb_mail.Text;
            y.Sifre = tb_sifre.Text;
            y.UyelikTarih = DateTime.Now;
            y.Durum = true;
            
            if(dm.UyeGiris(y))
            {
                if (tb_sifre.Text == tb_sifretekrar.Text)
                {
                    Response.Redirect("Default.aspx");
                    pnl_basarili.Visible = true;
                    lbl_basarili.Text = "Kayıt Başarılı Şekilde Yapılmıştır";
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Şifreler Aynı Değil";
                }
            }          
        }       
    }
}