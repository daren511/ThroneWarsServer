﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Media.aspx.cs" Inherits="SiteWebThroneWars.Media" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Throne Wars -Projet FinDec - Media</title>
    <link rel="stylesheet" type="text/css" href="./FinDec.css" />
    <script type="text/javascript" src="/highslide/highslide.js"></script>
    <link rel="stylesheet" type="text/css" href="/highslide/highslide.css" />
    <link rel="shortcut icon" href="/Images/Icon.png" />
    <script type="text/javascript">
    // override Highslide settings here
    // instead of editing the highslide.js file
    hs.graphicsDir = '/highslide/graphics/';
    </script>
</head> 

<body>
    <form runat="server" action="Media.aspx" autocomplete="on">
        
        <div class="Entete">
            <img src="./Images/Logo_Grand.png" style="max-height: 100%; max-width: 100%;" />
            <!-- A checker les dimensions ou plus grosse image -->
        </div>
        <br />
        <br />
        <div class="Table">
            <ul id="menu-bar">
                <li class="active">
                    <li><a href="default.aspx">Accueil</a></li>
                    <li><a href="Inscription.aspx">Inscription</a></li>
                    <li><a href="Connexion.aspx">Connexion</a></li>
                    <li><a href="Recherche.aspx">Classement</a></li>
                    <li><a href="Media.aspx">Média</a></li>
                    <li><a href="Magasin.aspx">Magasin</a></li>
                </li>
            </ul>
        </div>
        <div class="Photos">
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
