<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Complain>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Изменение жалобы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Изменение</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Contacts</legend>

        <%: Html.HiddenFor(model => model.IdComplain) %>

       

        <div class="editor-label">
            <%: Html.LabelFor(model => model.type) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.type) %>
            <%: Html.ValidationMessageFor(model => model.type) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.text) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.text) %>
            <%: Html.ValidationMessageFor(model => model.text) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.dataAdd) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.dataAdd) %>
            <%: Html.ValidationMessageFor(model => model.dataAdd) %>
        </div>

        <div style="visibility:hidden;" class="editor-label">
            <%: Html.LabelFor(model => model.idArticle) %>
        </div>
        <div style="visibility:hidden;"  class="editor-field">
            <%: Html.EditorFor(model => model.idArticle) %>
            <%: Html.ValidationMessageFor(model => model.idArticle) %>
        </div>

        <p>
            <input type="submit" value="Сохранить" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Назад", "Index") %>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
