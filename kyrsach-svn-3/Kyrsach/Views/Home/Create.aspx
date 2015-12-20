<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Article>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Добавление статьи
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Добавление</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Article</legend>

        <div hidden class="editor-field">
            <%: Html.EditorFor(model => model.idTest) %>
            <%: Html.ValidationMessageFor(model => model.idTest) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.name) %>
        </div>

        <div  class="editor-field">
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
            <%: Html.TextAreaFor(model => model.text, 10, 100, null)%>
            <%: Html.ValidationMessageFor(model => model.text) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.dataAdd) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.dataAdd) %>
            <%: Html.ValidationMessageFor(model => model.dataAdd) %>
        </div>
        <p>
            <input type="submit" value="Добавить" />
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
