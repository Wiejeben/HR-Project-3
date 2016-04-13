<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import.aspx.cs" Inherits="ImportPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import options</title>
</head>
<body>
    <form id="form1" runat="server">
        Careful!<br />
        <asp:Button ID="Button1" runat="server" Text="Import streets" onClick="ButtonImport" /><br />
        <asp:Button ID="Button2" runat="server" Text="Import bike theft" onClick="ButtonImportCrimes" /><br />
        <asp:Button ID="Button3" runat="server" Text="Import tranport stops" onClick="ButtonImportTr" />
    </form>
</body>
</html>
