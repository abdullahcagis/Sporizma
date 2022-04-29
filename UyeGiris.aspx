<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="Sporizma.UyeGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kullanicicss/GirisStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="girisPanel">
        <div class="baslik">
            Hesabınıza Giriş Yapınız
        </div>
        <div class="form">
            <div class="icerik">
                <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="satir">
                    <label>E mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" TextMode="Password"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:LinkButton ID="btn_giris" runat="server" OnClick="btn_giris_Click" CssClass="girisbutton">Üye Girişi</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="PanelResim">
            <img src="resim/MakaleResim/login1.png" />
        </div>
    </div>
</asp:Content>
