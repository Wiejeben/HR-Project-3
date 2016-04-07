<%@ Page Title="House" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="House.aspx.cs" Inherits="House" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= houseName %></h1>
    <div class="row">
        <div class="col-md-4">
            <div class="map">

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
                        <td>Bestaat sinds</td>
                        <td>Tijdspanne</td>
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
                <h2>Introductie</h2>
                <p><%= houseIntro %></p>
                <h2>Geschiedenis</h2>
                <p><%= houseContent %></p>
            </div>
        </div>
    </div>
</asp:Content>
