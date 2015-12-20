<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Comment>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Добавление комментария
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Комментарии</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

        <legend>Comment</legend>

        <div hidden class="editor-field">
            <%: Html.EditorFor(model => model.idTest) %>
            <%: Html.ValidationMessageFor(model => model.idTest) %>
        </div>

        <div hidden class="editor-field">
            <%: Html.EditorFor(model => model.dataAdd) %>
            <%: Html.ValidationMessageFor(model => model.dataAdd) %>
        </div>
        
        <div class="display-label">
            <%: Html.Label(Model.Test.Question1) %>
        </div>
        <div class ="editor-field">
            <%: Html.EditorFor(model => model.Answer1) %>
            <%: Html.ValidationMessageFor(model => model.Answer1) %>
        </div>

        <div class="display-label">
            <%: Html.Label(Model.Test.Question2) %>
        </div>
        <div class ="editor-field">
            <%: Html.EditorFor(model => model.Answer2) %>
            <%: Html.ValidationMessageFor(model => model.Answer2) %>
        </div>

        <div class="display-label">
            <%: Html.Label(Model.Test.Question3) %>
        </div>
        <div class ="editor-field">
            <%: Html.EditorFor(model => model.Answer3) %>
            <%: Html.ValidationMessageFor(model => model.Answer3) %>
        </div>
        
        <div class="display-label">
            <%: Html.Label(Model.Test.Question4) %>
        </div>
        <div class ="editor-field">
            <%: Html.EditorFor(model => model.Answer4) %>
            <%: Html.ValidationMessageFor(model => model.Answer4) %>
        </div>

        <div class="display-label">
            <%: Html.Label(Model.Test.Question5) %>
        </div>
        <div class ="editor-field">
            <%: Html.EditorFor(model => model.Answer5) %>
            <%: Html.ValidationMessageFor(model => model.Answer5) %>
        </div>     

        <p>
            <input type="submit" value="Добавить" />
        </p>

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
