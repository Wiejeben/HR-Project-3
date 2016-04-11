<%@ Page Title="Straat" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Street.aspx.cs" Inherits="StreetLocation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Name %></h1>
    <div class="row">
        <div class="col-md-4">
            <div id="map" class="map">

            </div>
        </div>
        <div class="col-md-8">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <td>#</td>
                        <td>Naam</td>
                        <td>Breedtegraad</td>
                        <td>Lengtegraad</td>
                        <td>Bestaat</td>
                        <td>Tijdspanne</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><%= Id %></td>
                        <td><%= Name %></td>
                        <td><%= Lat %></td>
                        <td><%= Long %></td>
                        <td>
                            <% if (Exists){ %>
                                <span class="glyphicon glyphicon-ok green"></span>
                            <% } else { %>
                                <span class="glyphicon glyphicon-remove red"></span>
                            <% } %>
                        </td>
                        <td><%= Timespan %></td>
                    </tr>
                </tbody>
            </table>
            <div class="house_content">
                <h2>Introductie</h2>
                <p><%= Intro %></p>
                <h2>Geschiedenis</h2>
                <p><%= Content %></p>
            </div>
        </div>
    </div>
</asp:Content>
