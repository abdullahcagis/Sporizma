<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="Sporizma.MakaleDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kullanicicss/YorumStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detayTasiyici">
        <h3 class="makaleBaslik">
            <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal></h3>
        <div class="makaleResim">
            <asp:Image ID="img_resim" runat="server" />
        </div>
        <div class="makaleOzet">
            <asp:Literal ID="ltrl_ozet" runat="server"></asp:Literal>
        </div>
        <div style="clear:both"></div>
        <div class="ekbilgi">
            <label style="float: left">
                Kategori :
                <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
                Yazar:<asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
            </label>
            <label style="float: right">
                <asp:Literal ID="ltrl_goruntulemeSayi" runat="server"></asp:Literal>
                Görüntüleme
            </label>
            <div style="clear: both"></div>
        </div>
        <div class="makaleIcerik">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
        </div>
        <br />
        <div style="min-height:500px;">
            <div class="commentTittle">
                <h2>Yorumlar</h2>
            </div>
            <asp:Panel ID="pnl_Girisvar" runat="server" Visible="false">
                <br />
                <h3>Yorum yaz</h3>
                <asp:TextBox ID="tb_yorum" TextMode="MultiLine" runat="server" CssClass="area"></asp:TextBox>
                <br />
                <br />
                <asp:LinkButton ID="lbtn_yorumyap" runat="server" Text="Yorum Yap" OnClick="lbtn_yorumyap_Click" CssClass="YorumButon">Yorum Yap</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="pnl_Girisyok" runat="server" CssClass="girislink">
                <h2>Yorum Yapmak İçin Lütfen<a href="UyeGiris.aspx">Giriş Yapınız</a></h2>
            </asp:Panel>
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="YorumItem">
                        <label><%# Eval("Uye") %></label> ||  <label><%# Eval("Tarih") %></label>
                        <br />
                        <p><%# Eval("Icerik") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
