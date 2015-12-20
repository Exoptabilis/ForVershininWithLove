<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Article>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Редактирование статьи
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Редактирование</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Article</legend>


        <div class="editor-label">
            <%: Html.LabelFor(model => model.name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.name) %>
            <%: Html.ValidationMessageFor(model => model.name) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.thema) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.thema) %>
            <%: Html.ValidationMessageFor(model => model.thema) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.text) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.text, 0, 100, null)%>
            <%: Html.ValidationMessageFor(model => model.text) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.dataAdd) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.dataAdd) %>
            <%: Html.ValidationMessageFor(model => model.dataAdd) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idUser) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idUser) %>
            <%: Html.ValidationMessageFor(model => model.idUser) %>
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
