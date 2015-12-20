<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Complain>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Удаление жалобы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Удаление</h2>

<h3>Вы уверены, что хотите удалить?</h3>
<fieldset>
    <legend>Complain</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdComplain) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdComplain) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.type) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.type) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.text) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.text) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.dataAdd) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.dataAdd) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.idArticle) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idArticle) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Удалить" /> |
        <%: Html.ActionLink("Назад", "Index") %>
    </p>
<% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
