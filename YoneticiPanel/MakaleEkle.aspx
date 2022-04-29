<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiPanelMaster.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="Sporizma.YoneticiPanel.MakaleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formdesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtasiyici">
        <div class="kekleyazi">
            Makale Ekle
        </div>
        <div class="formicerik">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="pnlbasarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="pnlbasarili" Visible="false">
                Makele Ekleme İşlemi Başarılı Şekilde Yapılmıştır
            </asp:Panel>
            <div class="yarim" style="margin-right:20px">
                <div class="satir">
                    <label>Makele Başlık</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Makele Kategori</label>
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="metinkutu" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="satir">
                    <label>Makele Resim Alanı</label><br />
                    <asp:FileUpload ID ="fu_resim" runat="server" CssClass="metinkutu" />
                </div>
                <div class="yarim">
                <div class="satir">
                    <label>Makale Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" TextMode="MultiLine" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Makale İçerik</label>
                    <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine" CssClass="metinkutu"></asp:TextBox>
                </div>
            
                <div>
                    <asp:CheckBox ID="cb_durum" runat="server" Text=" Makale Yayınla" Checked="true" />
                </div>
                <div>
                    <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" class="mekya">Makale Ekle</asp:LinkButton>
                </div>
            </div>
                </div>            
        </div>
    </div>
</asp:Content>
