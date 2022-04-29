using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Sporizma
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            Uyeler a = dm.AntrenorGiris(tb_mail.Text, tb_sifre.Text);
            if(a != null)
            {
                if(a.Durum == true)
                {
                    Session["uye"] = a;
                    Response.Redirect("default.aspx");
                }
                else 
                {
                    pnl_hata.Visible = true;
                    lbl_mesaj.Text = "Hesabınız Sistem Yöneticisi tarafından askıya alındı";
                }               
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_mesaj.Text = "Kullanıcı Bulunamadı E mail veya Şifre Hatalı";
            }
        }
    }
}