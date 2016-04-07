<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron banner">
        <h1>Zoekresultaten voor de zoekterm: '<%= query %>'</h1>
    </div>
    <div class="row">
        <% foreach (int result in results) { %>
        <div class="col-md-12 search_result">
            <a href="/house.aspx?hid=<%= result%>" class="search_container">
                <h2>Lorem ipsum dolor sit amet... mooi maken etc..</h2>
                <small>Lorem ipsum dolor sit amet.... extra tekst?</small>
                <span class="glyphicon glyphicon-chevron-right"></span>
            </a>
        </div>
        <% } %>
    </div>
</asp:Content>

