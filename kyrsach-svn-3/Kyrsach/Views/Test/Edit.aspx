<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kyrsach.Models.Test>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Изменение теста
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Изменение</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Contacts</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Thema) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Thema) %>
            <%: Html.ValidationMessageFor(model => model.Thema) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Question1)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Question1) %>
            <%: Html.ValidationMessageFor(model => model.Question1) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Answer1)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Answer1) %>
            <%: Html.ValidationMessageFor(model => model.Answer1) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Question2)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Question2) %>
            <%: Html.ValidationMessageFor(model => model.Question2) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Answer2)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Answer2) %>
            <%: Html.ValidationMessageFor(model => model.Answer2) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Question3)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Question3) %>
            <%: Html.ValidationMessageFor(model => model.Question3) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Answer3)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Answer3) %>
            <%: Html.ValidationMessageFor(model => model.Answer3) %>
        </div>
   
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Question4)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Question4) %>
            <%: Html.ValidationMessageFor(model => model.Question4) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Answer4)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Answer4) %>
            <%: Html.ValidationMessageFor(model => model.Answer4) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Question5)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Question5) %>
            <%: Html.ValidationMessageFor(model => model.Question5) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Answer5)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Answer5) %>
            <%: Html.ValidationMessageFor(model => model.Answer5) %>
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
