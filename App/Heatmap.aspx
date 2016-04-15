<%@ Page Title="Heatmap" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Heatmap.aspx.cs" Inherits="Heatmap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="map"></div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentFooter" Runat="Server">
    <script type="text/javascript">
        var center = ['Heatmap', 51.919980, 4.479993];

        var heatMapPoints = [
            <% foreach (Theft Theft in Thefts) { %>{ location: new google.maps.LatLng(<%: Theft.Street.Pos.Y %>, <%: Theft.Street.Pos.X %>), weight: <%: Theft.Total %> },<% } %>
        ];
    </script>
</asp:Content>