<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcDB4O.ViewModels.HomeIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Categories</h2>
    <ul>     
        <% foreach (MvcDB4O.Models.Category category in Model.Categories)
           { %>         
        <li>
            <%: Html.ActionLink(category.Name, "Browse", "Store", new { category = category.Name }, null)%>
        </li>     
        <% } %>
    </ul>
</asp:Content>
