<%@ Page Title="Heatmap" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Heatmap.aspx.cs" Inherits="Heatmap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

	<div class="row row-align-vertical">
		
		<div class="col-md-6">
	        <canvas id="chart" class="chart-bars"></canvas>	
		</div>

		<div class="col-md-6">
			<div id="maps-heatmap"></div>	
		</div>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentFooter" Runat="Server">
    <script type="text/javascript">
        var heatmapInfo = [
            <% foreach (Theft Theft in Thefts) { %>{ location: new google.maps.LatLng(<%: Theft.Street.Pos.Y %>, <%: Theft.Street.Pos.X %>), weight: <%: Theft.Total %> },<% } %>
        ];

        var objects = [
            <% foreach (Theft Theft in TheftsByYear) { %>
                ['<%: Theft.ObjectName %>'],
            <% } %>
        ];

        var thefts = [
            <% foreach (Theft Theft in TheftsByYear) { %>
                [<%: Theft.Total %>],
            <% } %>
        ];
    </script>
</asp:Content>