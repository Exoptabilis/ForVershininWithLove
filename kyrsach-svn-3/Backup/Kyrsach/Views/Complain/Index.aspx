<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Kyrsach.Models.Complain>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Жалобы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Жалобы</h2>

<table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.IdComplain) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.type) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.text) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.dataAdd) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.idArticle) %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.IdComplain) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.type) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.text) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.dataAdd) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.idArticle) %>
        </td>
        <td>
            <%: Html.ActionLink("Просмотреть", "Details", new {  id=item.IdComplain }) %> |
        </td>
    </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
