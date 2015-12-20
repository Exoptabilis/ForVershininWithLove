<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Test>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Удаление теста
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Удаление</h2>

<h3>Вы уверены, что хотите удалить?</h3>
<fieldset>
    <legend>Test</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.Name) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Name) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.Thema) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Thema) %>
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
