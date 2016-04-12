<%@ Page Title="Zoeken" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron banner">
        <h1>Zoekresultaten voor de zoekterm: '<%= query %>'</h1>
    </div>
    <div class="row">
        <%
            if (results != null && results.Count > 0)
            {
                foreach (Street result in results)
                { %>
                    <div class="col-md-12 search_result">
                        <a href="/Street.aspx?hid=<%= result.ID%>" class="search_container">
                            <h2><%= result.Name %></h2>
                            <small class="intro_text"><%= result.Intro %></small>
                            <span class="glyphicon glyphicon-chevron-right"></span>
                        </a>
                    </div>
            <%  
                }
            } else { %>
                <h2>Er zijn geen resultaten gevonden.</h2>
            <% } %>
    </div>
</asp:Content>

