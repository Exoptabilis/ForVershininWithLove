<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Comment>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Просмотр комментария
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Детализация</h2>

<fieldset>
    <legend>Комментарий</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdComment) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdComment) %>
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
<p>
    <%: Html.ActionLink("Изменить", "Edit", new {  id=Model.IdComment  }) %> |
    <%: Html.ActionLink("Назад", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
