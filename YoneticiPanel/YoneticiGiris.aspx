<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="Sporizma.YoneticiPanel.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SPORİZMA-Yönetici Giriş</title>
    <link href="css/Giris.css" rel="stylesheet" />
</head>
<body>
    <div class="content"></div>
    <form id="form1" runat="server">
        <div class="tasiyici">
            <div class="Baslik">
                <h3>Yönetici Giriş</h3>
            </div>
            <div class="icerik">
                <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
                    <asp:Label ID="lbl_masaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="satir">
                    <label>E-mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" TextMode="Password"></asp:TextBox>
                </div>
                <div class ="satir">
                    <asp:Button ID="btn_giris" CssClass="butongiris" runat="server" Text="Giriş Yap" OnClick="btn_giris_Click" />
                </div>
            </div>
        </div> 
    </form>
</body>
</html>
