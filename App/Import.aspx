<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import.aspx.cs" Inherits="ImportPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import options</title>
</head>
<body>
    <form id="form1" runat="server">
        Careful!<br />
        <asp:Button ID="Button1" runat="server" Text="Import streets" OnClick="ButtonImport" /><br />
        <asp:Button ID="Button2" runat="server" Text="Import bike theft" OnClick="ButtonImportCrimes" /><br />
        <asp:Button ID="Button3" runat="server" Text="Import tranport stops" OnClick="ButtonImportTr" /><br />
        <asp:Button ID="Button4" runat="server" Text="Import vacant buildings" OnClick="ButtonImportVb" />
    </form>
</body>
</html>