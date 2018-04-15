<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MatricResultsFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
       
    <script type="text/javascript" src="https://canvasjs.com/assets/script/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="https://canvasjs.com/assets/script/jquery.canvasjs.min.js"></script>

    <script type="text/javascript" src="js/MainPage.js"></script>
    <link rel="stylesheet" href="styles.css" type="text/css" media="screen" />

    <div id="reportHeading"> Matric Results 2016 Report </div>

    <div >
       <div id="overAllBarChart" class="inLineBlock leftChart" style="height: calc(30vh); width: 51%;position:relative"></div>
       <div id="overAllPassRate" class="inLineBlock rightChart"  style="height: calc(30vh); width: 48%;position:relative"></div>

    </div>

      <div >
       <div id="top10Best2016" class="inLineBlock leftChart" style="height: calc(30vh);width: 51%;position:relative"></div>
       <div id="top10Worst2016" class="inLineBlock rightChart"  style="height: calc(30vh); width: 48%;position:relative"></div>

    </div>

      <div >
       <div id="studentNumberPassRate" class="inLineBlock leftChart" style="height: calc(30vh);width: 100%;position:relative"></div>

    </div>
    <script>
        onLoadPageLoad();
    </script>

  <%--  <button onclick="onRetrieveAll(); return false ;">GET Method </button>
    <button onclick="onPost(); return false ;">POST Method </button>--%>

</asp:Content>
