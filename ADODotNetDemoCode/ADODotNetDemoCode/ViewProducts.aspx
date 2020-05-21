<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="ADODotNetDemoCode.ViewProducts" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products</title>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="SaveProduct.aspx">Create</a>
            <asp:GridView runat="server" ID="gvProductDetails" AutoGenerateColumns="false" DataKeyNames="ProductID" OnRowCommand="gvProductDetails_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Product ID" DataField="ProductID" />
                    <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
                    <asp:BoundField HeaderText="Rate" DataField="Rate" />
                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName="cmdEdit" CommandArgument='<%#Eval("ProductID") %>' />
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="cmdDelete" CommandArgument='<%#Eval("ProductID") %>' OnClientClick="Confirm();" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
