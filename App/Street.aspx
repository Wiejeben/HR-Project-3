<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Street.aspx.cs" Inherits="StreetLocation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: Name %></h1>
    <div class="row">
        <div class="col-md-4">
            <div id="maps-street" class="map">
            </div>
        </div>
        <div class="col-md-8">
            <div class="table-responsive">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Naam</th>
                            <th>Breedtegraad</th>
                            <th>Lengtegraad</th>
                            <th>Bestaat</th>
                            <th>Tijdspanne</th>
                            <th>Afstand tot centrum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><%: Id %></td>
                            <td><%: Name %></td>
                            <td><%: Lat %></td>
                            <td><%: Long %></td>
                            <td>
                                <% if (Exists)
                                    { %>
                                <span class="glyphicon glyphicon-ok green"></span>
                                <% }
                                    else
                                    { %>
                                <span class="glyphicon glyphicon-remove red"></span>
                                <% } %>
                            </td>
                            <td><%: Timespan %></td>
                            <td><%: Distance %> meter</td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="house_content">
                <h2>Geschiedenis</h2>
                <%--<p><%: sb %></p>--%>
                <p><%: String.IsNullOrEmpty(Content) ? Intro : Content %></p>
            </div>
            <div class="crimes">
                <% if(Robberies.Count() > 0) { %>
                    <h2>Veiligheidsindex</h2>
                    <div class="chart">
                        <canvas id="chart" height="450" width="600"></canvas>
                    </div>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>

<%-- Import-query from database --%>

<asp:Content ID="ContentFooter" ContentPlaceHolderID="ContentFooter" runat="server">
    <script type="text/javascript">
        var robberies = <%=jsonRobberies %>;
        // If the json object isnt empty.
        if(!$.isEmptyObject(robberies)){
            // Required, else we don't have data to place in there in the foreach loop.
            var data = [];
            // Graphs
            $(document).ready(function () {
                // If there's a chart element, just in case.
                if ($("#chart").length) {

                    var ctx = $("#chart")[0].getContext("2d");
                    pieChart = new Chart(ctx).Pie(data, {
                        responsive: false
                    });
                    // Loop through robberies and add it to the piechart.
                    $.each(robberies, function(index, value) {
                        pieChart.addData({
                            value: value.Total,
                            label: value.ObjectName
                        });
                    });

                    var chartLegend = pieChart.generateLegend();
                    $('.chart').append(chartLegend);
                }
            });
        }
        else {
            $('.chart').remove();
        }

        var locations = [
            <% foreach (TransportStop Stop in TransportStops) { %>
                ['<%: Stop.Name %>', '<%: Stop.Description %>', <%: Stop.Distance(new Vector2(Lat, Long)) %>, <%: Stop.Pos.X %>, <%: Stop.Pos.Y %>],
            <% } %>
        ];

        var center = ['<%: Name %>', <%: Lat %>, <%: Long %>];


    </script>
</asp:Content>