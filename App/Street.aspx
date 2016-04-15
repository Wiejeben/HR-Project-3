<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Street.aspx.cs" Inherits="StreetLocation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Name %></h1>
    <div class="row">
        <div class="col-md-4">
            <div id="map" class="map">
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
                
                <% 
                    if (Robberies.Count > 0)
                    {
                        %>
                            <h2>Crime index</h2>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Object</th>
                                        <th>Gestolen hoeveelheid</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                    foreach (Theft robbery in Robberies){ %>
                                        <tr><td><%=robbery.ObjectName %></td><td><%=robbery.Total %></td></tr>
                                    <%
                                    }
                                    %>
                               </tbody>             
                       </table><%
                    } 
                %>
            </div>
        </div>
    </div>
</asp:Content>

<%-- Import-query from database --%>

<asp:Content ID="ContentFooter" ContentPlaceHolderID="ContentFooter" runat="server">
    <script type="text/javascript">

        var locations = [
            <% foreach (TransportStop Stop in TransportStops) { %>
                ['<%: Stop.Name %>', <%: Stop.Pos.X %>, <%: Stop.Pos.Y %>],
            <% } %>
        ];

        var center = ['<%: Name %>', <%: Lat %>, <%: Long %>];
    </script>
</asp:Content>