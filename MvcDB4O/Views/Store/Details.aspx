<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcDB4O.ViewModels.StoreDetailsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Model.Product.Name %></h2>
    
    <div><%: Model.Product.Price %></div>
    <div>
        <img src="<%= Model.Product.Url %>" 
            alt="alt text" 
            class="has-border" /> 
    </div>
    <p class="button">
            <%: Html.ActionLink("Add to basket", "AddToBasket", "ShoppingBasket", new { id = Model.Product.ProductId }, "")%>
    </p>
</asp:Content>
