<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcDB4O.ViewModels.StoreBrowseViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	StoreBrowseViewModel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Products</h2>
    <%: Model.Category.Name %>
        <ul>     
        <% foreach (MvcDB4O.Models.Product product in Model.Products)
           { %>         
        <li>
            <%: Html.ActionLink(product.Name, "Details", "Store", new { id = product.ProductId }, null)%>
        </li>     
        <% } %>
    </ul>
</asp:Content>
