<%@ Page Title="House" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="House.aspx.cs" Inherits="House" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= houseName %></h1>
    <div class="row">
        <div class="col-md-4">
            Map hier.
        </div>
        <div class="col-md-8">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <td>#</td>
                        <td>Name</td>
                        <td>Latitude</td>
                        <td>Longitude</td>
                        <td>Exists since</td>
                        <td>Timespan</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><%= houseId %></td>
                        <td><%= houseName %></td>
                        <td><%= houseLat %></td>
                        <td><%= houseLong %></td>
                        <td><%= houseExists %></td>
                        <td><%= houseTimespan %></td>
                    </tr>
                </tbody>
            </table>
            <div class="house_content">
                <h2>Intro</h2>
                <p><%= houseIntro %></p>
                <h2>Geschiedenis</h2>
                <p><%= houseContent %></p>
            </div>
        </div>
    </div>
</asp:Content>
