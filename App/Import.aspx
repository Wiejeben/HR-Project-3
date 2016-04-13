<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import.aspx.cs" Inherits="ImportPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Import streets" onClick="ButtonImport" />
        <asp:Button ID="Button2" runat="server" Text="Import tranport stops" onClick="ButtonImportTr" />
    </div>
    </form>
</body>
</html>
