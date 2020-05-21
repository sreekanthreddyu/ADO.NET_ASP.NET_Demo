<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveProduct.aspx.cs" Inherits="ADODotNetDemoCode.SaveProduct" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Save Product</title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
               
                <tr>
                    <td></td>
                    <td>
                        <asp:Label runat="server" ID="lbProductID" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Name : </td>
                    <td class="auto-style1">
                        <asp:TextBox runat="server" ID="tbProductName" /></td>
                </tr>
                <tr>
                    <td>Product Rate : </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbRate" TextMode="Number" /></td>
                </tr>
                <tr>
                    <td>Product Quantity : </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbQuantity" TextMode="Number" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" /></td>
                    <td>
                        <asp:Button runat="server" ID="btnReset" Text="Reset" OnClick="btnReset_Click" /></td>
                </tr>
            </table>
             <a href="ViewProducts.aspx">Back</a>
        </div>
    </form>
</body>
</html>
