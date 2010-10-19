<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcDB4O.ViewModels.ShoppingBasketViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Shopping Basket
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function handleUpdate(context) {
            // Load and deserialize the returned JSON data
            var json = context.get_data();
            var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);
            // Update the page elements
            if (data.NumberOfProducts == 0) {
                $('#row-' + data.Id).fadeOut('slow');
            }
            else {
                $('#row-' + data.Id + '-quantity').text(data.NumberOfProducts);
            }
            $('#basket-status').text('Basket (' + data.BasketCount + ')');
            $('#update-message').text(data.Message);
            $('#basket-total').text(data.BasketTotal);
        }
    </script>

    <h3>
        My basket:
    </h3>

    <div id="update-message"></div>

    <table>

        <tr>
            <th>Name</th>
            <th>Price (each)</th>
            <th>Quantity</th>
            <th></th>
        </tr>

        <% foreach (var item in Model.BasketItems) { %>
        <tr id="row-<%: item.Product.ProductId %>">
            <td>
                <%: Html.ActionLink(item.Product.Name, "Details", "Store", new { id = item.Product.ProductId }, null)%>
            </td>
            <td>
                <%: item.Product.Price %>
            </td>
            <td id="row-<%: item.Product.ProductId %>-quantity">
                <%: item.Count %>
            </td>
            <td>
                <%: Ajax.ActionLink("Remove from basket", "RemoveFromBasket", new { id = item.Product.ProductId }, new AjaxOptions { OnSuccess = "handleUpdate" })%>
            </td>
        </tr>
        <% } %>

        <tr>
            <td>Total</td>
            <td></td>
            <td></td>
            <td id="basket-total">
                <%: Model.BasketTotal %>
            </td>
        </tr>

    </table>


</asp:Content>
