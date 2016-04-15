<%@ Page Title="Grafiek" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Charts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Charts</h1>

    <div class="chart">
        <canvas id="chart" height="450" width="600"></canvas>
    </div>
</asp:Content>

<asp:Content ID="ContentFooter" ContentPlaceHolderID="ContentFooter" runat="server">
    <script type="text/javascript">
        var objects = [
            <% foreach (Theft Theft in Thefts) { %>
                ['<%: Theft.Name %>'],
            <% } %>
        ];

        var thefts = [
            <% foreach (Theft Theft in Thefts) { %>
                ['<%: Theft.Year %>', <%: Theft.Amount %>],
            <% } %>
        ];
    </script>
</asp:Content>