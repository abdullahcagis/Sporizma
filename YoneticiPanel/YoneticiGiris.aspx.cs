using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Sporizma.YoneticiPanel
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
           if(!string.IsNullOrEmpty(tb_mail.Text))
            {
                if(!string.IsNullOrEmpty(tb_sifre.Text))
                {
                   Yonetici y = dm.YoneticiGiris(tb_mail.Text, tb_sifre.Text);
                  
                        if(y != null)
                        {
                            if(y.Durum)
                            {
                                Session["yonetici"] = y;
                                Response.Redirect("Default.aspx");
                            }
                            else
                            {
                                lbl_masaj.Text = "Hesabınız Yönetici Tarafından Askıya Alınmıştır";
                                pnl_hata.Visible = true;
                            }
                        }
                        else
                        {
                            lbl_masaj.Text = "Kullanıcı Bulunamamıştır";
                            pnl_hata.Visible = true;
                        }                                    
                }
                else
                {
                    lbl_masaj.Text = "Şifre Boş Bırakılamaz";
                    pnl_hata.Visible = true;
                }
            }
           else
            {
                lbl_masaj.Text = "Mail Adresi Boş Bırakılamaz";
                pnl_hata.Visible= true;
                    
            }
        }
    }
}