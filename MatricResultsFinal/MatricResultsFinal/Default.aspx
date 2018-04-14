<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MatricResultsFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
       
    <script type="text/javascript" src="js/MainPage.js"></script>


    <button onclick="onRetrieveAll(); return false ;">GET Method </button>
    <button onclick="onPost(); return false ;">POST Method </button>

</asp:Content>
