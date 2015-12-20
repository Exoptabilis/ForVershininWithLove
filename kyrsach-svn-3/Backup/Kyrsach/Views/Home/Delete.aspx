<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Article>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Удаление статьи
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Удаление</h2>

<h3>Вы уверены, что хотите удалить?</h3>
<fieldset>
    <legend>Article</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdArticle) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdArticle) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.name) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.name) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.thema) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.thema) %>
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
        <%: Html.DisplayNameFor(model => model.idUser) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idUser) %>
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
