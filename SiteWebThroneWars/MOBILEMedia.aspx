<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOBILEMedia.aspx.cs" Inherits="SiteWebThroneWars.MOBILEMedia" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="FinDec_Mobile.css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="/Menu/jquery.mmenu.min.js" type="text/javascript"></script>
    <link href="/Menu/jquery.mmenu.css" type="text/css" rel="stylesheet" />
    <title>Throne Wars -Projet FinDec - Média</title>
</head>
<body>
    <form id="form1" runat="server">
         <script type="text/javascript">
             $(document).ready(function () {
                 $("#my-menu").mmenu();
             });
             $("#my-button").click(function () {
                 $("#my-menu").trigger("open.mm");
             });
             $(document).ready(function () { 
                 $("#my-menu").mmenu();
                 $("#my-button").click(function () {
                     $("#my-menu").trigger("close.mm");
                 });
             });
    </script>
    <nav id="my-menu">
            <ul>
                
                <li><a href="MOBILEdefault.aspx">Accueil</a></li>
                <li><a href="MOBILEInscription.aspx">Inscription</a></li>
                <li><a href="MOBILEConnexion.aspx">Connexion</a></li>
                <li><a href="MOBILERecherche.aspx">Classement</a></li>
                <li><a href="MOBILEMedia.aspx">Média</a></li>
                <li><a href="MOBILEMagasin.aspx">Magasin</a></li>
                <li><a href="#my-page">Fermer le menu</a></li>
            </ul>
        </nav>
        <div id="menu">
                <a href="#my-menu"><img src="./Images/menu.png" width="100" height="100" /></a>
            </div>
        <div class="Entete_Mobile">
            <img src="./Images/Logo_Grand.png" style="max-height: 80%; max-width: 80%;" />
            <br />
            
            <!-- A checker les dimensions ou plus grosse image -->
        </div>
        <br />
        <br />
        <div class="Photos_Mobile">
            <h1>Photos</h1>
            <a href="./Images/LogIn.png" class="highslide" onclick="return hs.expand(this)">
            <img src="./Images/LogIn.png" alt="Highslide JS" title="Click to enlarge" height="200" width="200" /></a>
            <a href="./Images/Wait.jpg" class="highslide" onclick="return hs.expand(this)">
            <img src="./Images/Wait.jpg" alt="Highslide JS" title="Click to enlarge" height="200" width="200" /></a>
            <a href="./Images/ScreenSelection.jpg" class="highslide" onclick="return hs.expand(this)">
            <img src="./Images/ScreenSelection.jpg" alt="Highslide JS" title="Click to enlarge" height="200" width="200" /></a>
            <a href="./Images/Placing.jpg" class="highslide" onclick="return hs.expand(this)">
            <img src="./Images/Placing.jpg" alt="Highslide JS" title="Click to enlarge" height="200" width="200" /></a>
            <a href="./Images/ingame.jpg" class="highslide" onclick="return hs.expand(this)">
            <img src="./Images/ingame.jpg" alt="Highslide JS" title="Click to enlarge" height="200" width="200" /></a>
        </div>

    </form>
</body>
</html>

