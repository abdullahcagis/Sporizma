<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiPanelMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="Sporizma.YoneticiPanel.KategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formdesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="listeyazi">
        Kategori Listele
    </div>
    <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
        <LayoutTemplate>
            <table cellspacing="0" cellpadding="0" class="tablo" >
            <thead>
                <tr>
                    <th>#</th>
                    <th>Kategori Adı</th>
                    <th>Durum</th>
                    <th>Seçenekler</th>
                </tr>
            </thead>
            <tbody>
                <asp:PlaceHolder ID ="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </tbody>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim")%></td>
                    <td><%# Eval("Durum")%></td>
                    <td>
                       <a href='KategoriDuzenle.aspx?kid=<%# Eval("ID") %>' class="duzenlebuton">Düzenle</a>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="listebuton durum">Durum Değiştir</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="listebuton sil">Sil</asp:LinkButton>
                    </td>
                </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
                <tr class="alt">
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim")%></td>
                    <td><%# Eval("Durum")%></td>
                    <td>
                        <a href='KategoriDuzenle.aspx?kid=<%# Eval("ID") %>' class="duzenlebuton">Düzenle</a>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="listebuton durum">Durum Değiştir</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="listebuton sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
    </asp:ListView>
</asp:Content>
