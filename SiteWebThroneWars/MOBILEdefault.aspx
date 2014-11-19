<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOBILEdefault.aspx.cs" Inherits="SiteWebThroneWars.MOBILEdefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <link rel="shortcut icon" href="/Images/Icon.png" />
    <title>Throne Wars -Projet FinDec - Page Principale</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Entete_Mobile">
            <h4>MOBILE VERSION</h4>
            <img src="./Images/Logo_Grand.png" style="max-height: 80%; max-width: 80%;" />
            <!-- A checker les dimensions ou plus grosse image -->
        </div>
        <br />
        <br />
        <div class="Table_Mobile">
            <ul id="menu-bar_Mobile">
                <li class="active">
                    <li><a href="MOBILEdefault.aspx">Accueil</a></li>
                    <li><a href="MOBILEInscription.aspx">Inscription</a></li>
                    <li><a href="MOBILEConnexion.aspx">Connexion</a></li>
                    <li><a href="MOBILERecherche.aspx">Classement</a></li>
                    <li><a href="MOBILEMedia.aspx">Média</a></li>
                </li>
            </ul>
        </div>

        <div class="DescTele_Mobile">
            <div class="Description_Mobile">
                <h1>Description</h1>
                <p>
                    Throne Wars est un jeu de stratégie fantastique tour-par-tour impliquant 2 joueurs opposés dont le but 
                        est d’éliminer tous les personnages du joueur adverse. 
                        Une équipe est composée de 4 personnages pouvant être membre d’une des classes suivantes : 
                        Guerrier, Archer, Magicien et Prêtre. 
                        Chaque classe possède des habiletés et statistiques différentes. 
                        Les personnages possèdent leur propre inventaire et ceux-ci peuvent évoluer de niveau au fil des 
                        parties pour ainsi débloquer de nouvelles habiletés. 
                        Les joueurs possèdent, eux aussi, un inventaire et peuvent affecter des items à leurs personnages pour les préparer avant la partie.
                </p>
                <br />
                <p style="text-align: center">
                    Supervisé par Francois Jean
                </p>


            </div>
        </div>
        <div class="Membres_Mobile">
            <h2>Équipe</h2>
            <a href="mailto:Daren@thronewars.ca" target="_top">Daren Ken St-Laurent</a>
            <img src="./Images/Daren.jpg" width="200" height="200" />
            <a href="mailto:Francis@thronewars.ca" target="_top">Francis Côté</a>
            <img src="./Images/Tattoo.jpg" width="200" height="200" />
            <a href="mailto:Charles@thronewars.ca" target="_top">Charles Hunter-Roy</a>
            <img src="./Images/Charles1.jpg" width="200" height="200" />
            <a href="mailto:Alexis@thronewars.ca" target="_top">Alexis Lalonde</a>
            <img src="./Images/Alexis2.jpg" width="200" height="200" />
        </div>
    </form>
</body>
</html>
