<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
        <table style="width: 359px">
            <tbody>
              <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Upload the file" Font-Names="Arial"></asp:Label>
                  </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
              </tr>
              <tr>
                <td colspan="5">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                  </td>
              </tr>
              <tr>
                <td>
                    &nbsp;<asp:Button ID="btnProcesar" runat="server" Text="Upload &amp; Process" OnClick="btnProcesar_Click" />
                  </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
              </tr>
              <tr>
                <td>
                    <asp:Label ID="lblResultado" runat="server" Text="Result" Font-Names="Arial"></asp:Label>
                  </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
              </tr>
            </tbody>
            </table>
    </div>
    </form>
</body>
</html>
