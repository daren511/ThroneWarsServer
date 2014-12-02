<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOBILERecherche.aspx.cs" EnableEventValidation="false" Inherits="SiteWebThroneWars.MOBILERecherche" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Throne Wars -Projet FinDec - Recherche</title>
<meta charset="utf-8"/> 
<link rel="stylesheet" type="text/css" href="FinDec_Mobile.css"/>
<link rel="stylesheet" type="text/css" href="/sweet-alert.css"/>
<link rel="shortcut icon" href="/Images/Icon.png" />
<script src="/sweet-alert.min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="/Menu/jquery.mmenu.min.js" type="text/javascript"></script>
<link href="/Menu/jquery.mmenu.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" action="MOBILERecherche.aspx">
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
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Vous êtes connecté", type: "success", confirmButtonText: "Ok" });
                });
            }
            function MessageBoxErreur(textadaptatif) {
                $(document).ready(function () {
                    swal({ title: "Échec! ", text: textadaptatif, type: "error", confirmButtonText: "Ok" });
                });
            }
            function changeVisibility() {
                $(document).ready(function () {
                    document.getElementById("Leaderboard_Classement_Mobile").style.visibility = "visible";
                    document.getElementById("Stats_Classement_Mobile").style.visibility = "visible";
                });
            }
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
        <div class="FormRecherche_Mobile">
            <label>Nom d'utilisateur</label><br />
            <asp:TextBox ID="TB_UsernameSearch" TextMode="SingleLine" runat="server" style="width: 38%; font-size:30px;"/><br/><br />
            <asp:Button Text="Rechercher" runat="server" OnClick="Rechercher_Click" style="width:20%; font-size:35px;"/>
        </div>
        <div id="Leaderboard_Classement_Mobile">
            <asp:GridView runat="server" ID="GV_Leaderboard" OnRowDataBound="GV_Leaderboard_OnRowDataBound"  
                AutoPostBack="true" OnSelectedIndexChanged="GV_Leaderboard_SelectedIndexChanged"
                AllowPaging ="true" OnPageIndexChanging = "GV_Leaderboard_PageIndexChanging" PageSize = "5">    
            </asp:GridView>
        </div>

        <div id="Stats_Classement_Mobile">
           <asp:GridView runat="server" ID="GV_Stats">
           </asp:GridView>
        </div>
    </form>
</body>
</html>
