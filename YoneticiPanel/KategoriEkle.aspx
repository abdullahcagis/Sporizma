﻿<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiPanelMaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="Sporizma.YoneticiPanel.KategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formdesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtasiyici">
        <div class="kekleyazi">
            Kategori Ekle
        </div>
        <div class="formicerik">
            <asp:panel id="pnl_basarisiz" runat="server" cssclass="pnlbasarisiz" visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="pnlbasarili" Visible="false">
                Kategori Ekleme İşleminiz Başarılı Şekilde Yapılmıştır
            </asp:Panel>
            <div class="satir">
                <label>Kategori Ad</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" Text="Kategoriyi Yayınla" Checked="true" ></asp:CheckBox>
            </div>
            <div class="satir">
                <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="keklebuton">Kategori Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>