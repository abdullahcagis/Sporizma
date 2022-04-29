using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }

        #region Yonetici Metotları

        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            Yonetici y = null;
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 1)
                {
                    y = new Yonetici();
                    cmd.CommandText = "SELECT Y.ID, Y.YoneticiTurID, YT.Isim, Y.Isim, Y.Soyisim,Y.Mail, Y.Sifre, Y.Durum FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTurID = YT.ID WHERE Y.mail=@m AND Y.Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.YoneticiTur = reader.GetString(2);
                        y.Isim = reader.GetString(3);
                        y.Soyisim = reader.GetString(4);
                        y.Mail = reader.GetString(5);
                        y.Sifre = reader.GetString(6);
                        y.Durum = reader.GetBoolean(7);
                    }
                }
                return y;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim, Durum) VALUES(@isim, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kategori = new Kategori();
                    kategori.ID = reader.GetInt32(0);
                    kategori.Isim = reader.GetString(1);
                    kategori.Durum = reader.GetBoolean(2);
                    kategoriler.Add(kategori);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele(bool durum)
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                if (durum)
                {
                    cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategoriler WHERE Durum = 1";
                }
                else
                {
                    cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategoriler WHERE Durum = 0";
                }
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kategori = new Kategori();
                    kategori.ID = reader.GetInt32(0);
                    kategori.Isim = reader.GetString(1);
                    kategori.Durum = reader.GetBoolean(2);
                    kategoriler.Add(kategori);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori k = new Kategori();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Durum = reader.GetBoolean(2);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim=@isim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                cmd.Parameters.AddWithValue("@id", kat.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Kategoriler SET Durum = @durum WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@durum", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Antrenmanlar(KategoriID, YazarID, Baslik, Ozet, Icerik, GoruntulemeSayi, KapakResim, EklemeTarih, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @goruntulemeSayi, @kapakResim, @eklemeTarih, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                cmd.Parameters.AddWithValue("@yazarID", mak.YazarID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@eklemeTarih", mak.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListele()
        {
            List<Makale> Makaleler = new List<Makale>();
            try
            {
                cmd.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.GoruntulemeSayi, M.KapakResim, M.EklemeTarih, M.Durum FROM Antrenmanlar AS M JOIN Kategoriler AS K ON M.KategoriID= K.ID JOIN Yoneticiler AS Y ON M.YazarID=Y.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.KategoriID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.YazarID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.GoruntulemeSayi = reader.GetInt32(8);
                    m.KapakResim = reader.GetString(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    Makaleler.Add(m);
                }
                return Makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListele(int katid)
        {
            List<Makale> Makaleler = new List<Makale>();
            try
            {
                cmd.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.GoruntulemeSayi, M.KapakResim, M.EklemeTarih, M.Durum FROM Antrenmanlar AS M JOIN Kategoriler AS K ON M.KategoriID= K.ID JOIN Yoneticiler AS Y ON M.YazarID=Y.ID WHERE M.KategoriID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.KategoriID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.YazarID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.GoruntulemeSayi = reader.GetInt32(8);
                    m.KapakResim = reader.GetString(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    Makaleler.Add(m);
                }
                return Makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.GoruntulemeSayi, M.KapakResim, M.EklemeTarih, M.Durum FROM Antrenmanlar AS M JOIN Kategoriler AS K ON M.KategoriID= K.ID JOIN Yoneticiler AS Y ON M.YazarID=Y.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale m = new Makale();
                while (reader.Read())
                {

                    m.ID = reader.GetInt32(0);
                    m.KategoriID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.YazarID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.GoruntulemeSayi = reader.GetInt32(8);
                    m.KapakResim = reader.GetString(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                }

                return m;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void MakaleGoruntulemeArttir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT GoruntulemeSayi FROM Antrenmanlar WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Antrenmanlar SET GoruntulemeSayi = @gs WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@gs", sayi + 1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Üye Metotları
        public Uyeler AntrenorGiris(string mail, string sifre)
        {
            Uyeler y = null;
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Mail=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 1)
                {
                    y = new Uyeler();
                    cmd.CommandText = "SELECT ID, Isim, Soyisim, Mail, Sifre, KullaniciAdi, UyelikTarih, Durum FROM Uyeler WHERE Mail=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim = reader.GetString(1);
                        y.Soyisim = reader.GetString(2);
                        y.Mail = reader.GetString(3);
                        y.Sifre = reader.GetString(4);
                        y.KullaniciAdi = reader.GetString(5);
                        y.UyelikTarih = reader.GetDateTime(6);
                        y.Durum = reader.GetBoolean(7);
                    }
                }
                return y;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeGiris(Uyeler u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(UyeTurleriID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, UyelikTarih, Durum) VALUES(@uyeturleriıd, @ısim, @soyisim, @kullaniciadi, @mail, @sifre, @uyeliktarih, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeturleriıd", u.UyeTurleriID);
                cmd.Parameters.AddWithValue("@ısim", u.Isim);
                cmd.Parameters.AddWithValue("@soyisim", u.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciadi", u.KullaniciAdi);
                cmd.Parameters.AddWithValue("@mail", u.Mail);
                cmd.Parameters.AddWithValue("@sifre", u.Sifre);
                cmd.Parameters.AddWithValue("@uyeliktarih", u.UyelikTarih);
                cmd.Parameters.AddWithValue("@durum", u.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Uyeler> UyeListele()
        {
            try
            {
                List<Uyeler> Uye = new List<Uyeler>();
                cmd.CommandText = "SELECT ID, Isim FROM UyeTurleri";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Uyeler u = new Uyeler();
                    u.UyeTurleriID = reader.GetInt32(0);
                    u.UyeTur = reader.GetString(1);
                    Uye.Add(u);
                }
                return Uye;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close ();
            }

        }

        #endregion

        #region Yorum Metodları

        public List<Yorum> YorumListele()
        {
            List<Yorum> Yorumlar = new List<Yorum>();
            
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.MakaleID, Y.UyeID, U.Isim Y.Icerik, Y.EklemeTarihi, Y.Durum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID = Y.MakaleID WHERE Y.MakaleID = @id AND Y.DURUM = 1 ";
                cmd.Parameters.Clear ();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while( reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.MakaleID = reader.GetInt32(1);
                    y.UyeID = reader.GetInt32(2);
                    y.Icerik = reader.GetString(3);
                    y.EklemeTarih = reader.GetDateTime(4);
                    y.Durum = reader.GetBoolean(5);
                    Yorumlar.Add(y);
                }
                return Yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public List<Yorum> YorumListele(int Yid)
        {
            List<Yorum> Yorumlar = new List<Yorum>();

            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.MakaleID, Y.UyeID, U.Isim Y.Icerik, Y.EklemeTarihi, Y.Durum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID = Y.MakaleID WHERE Y.MakaleID = @id AND Y.DURUM = 1 ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Yid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.MakaleID = reader.GetInt32(1);
                    y.UyeID = reader.GetInt32(2);
                    y.Icerik = reader.GetString(3);
                    y.EklemeTarih = reader.GetDateTime(4);
                    y.Durum = reader.GetBoolean(5);
                    Yorumlar.Add(y);
                }
                return Yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar(MakaleID, UyeID, Icerik, EklemeTarihi, Durum) VALUES(@makaleID, @uyeID, @Icerik, @eklemetarih, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@makaleID", y.MakaleID);
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@Icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@eklemetarih", y.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", y.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }




        #endregion


    }
}
