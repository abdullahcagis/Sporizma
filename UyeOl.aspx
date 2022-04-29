<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="Sporizma.UyeOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kullanicicss/GirisStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="girisPanel">
        <div class="baslik">
            Üye Olmak için Formu Doldurunuz
        </div>
        <div class="formicerik">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="pnlbasarisiz" Visible="false">
                <asp:Label ID="lbl_basarisiz" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="pnlbasarili" Visible="false">
                <asp:Label ID="lbl_basarili" runat="server"></asp:Label>
            </asp:Panel>
        <div class="form">
            <div class="icerik">
                <div class="satir">
                    <label>Adınız</label><br />
                    <asp:TextBox ID="tb_ad" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Soyadınız</label><br />
                    <asp:TextBox ID="tb_soyad" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Kullanıcı Adınız</label><br />
                    <asp:TextBox ID="tb_klncad" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>E-mail Adresiniz</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" TextMode="Password"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Şifre Tekrar</label><br />
                    <asp:TextBox ID="tb_sifretekrar" runat="server" CssClass="metinkutu" TextMode="Password"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Meslek</label><br />
                    <asp:DropDownList ID="ddl_uyetur" runat="server" CssClass="metinkutu" DataTextField="UyeTur" DataValueField="UyeTurleriID"></asp:DropDownList>
                </div>
                <div class="satir">
                    <asp:LinkButton ID="btn_grs" runat="server" OnClick="btn_grs_Click" CssClass="girisbutton">Üye Ol</asp:LinkButton>
                </div>
                
            </div>
        </div>
    </div>
        <div class="PanelResim">
            <img src="resim/sign.png" />
        </div>
  </div>
</asp:Content>
