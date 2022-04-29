using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.IO;

namespace Sporizma.YoneticiPanel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.KategoriListele(true);
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            Makale mak = new Makale();
            mak.Baslik = tb_isim.Text;
            mak.Icerik = tb_icerik.Text;
            mak.Ozet = tb_ozet.Text;
            mak.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            mak.YazarID = ((Yonetici)Session["yonetici"]).ID;
            mak.EklemeTarih = DateTime.Now;
            mak.Durum = cb_durum.Checked;
            mak.GoruntulemeSayi = 0;
            if(fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                if(uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string isim = Guid.NewGuid().ToString() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/resim/MakaleResim" + isim));
                    mak.KapakResim = isim;
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Dosya Formatını Tekrardan Kontrol Ediniz.(Dosya Formatı png, jpg, jpeg olmalıdır)";
                }               
            }
            else
            {
                mak.KapakResim = "none.png";
            }
            if(dm.MakaleEkle(mak))
            {
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
            }
            else
            {
                pnl_basarisiz.Visible= true;
                pnl_basarili.Visible= false;
                lbl_mesaj.Text = "Makale Eklenirken Bir Hata Meydana Geldi";
            }
        }

    }
}