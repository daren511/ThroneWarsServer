<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="SiteWebThroneWars.Stats2" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Throne Wars -Projet FinDec - Stats</title>
    <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css" />
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Vous êtes connecté", type: "success", confirmButtonText: "Ok" });
                });
            } 
            function MessageBoxErreur(textadaptatif) {
                $(document).ready(function () {
                    swal({ title: "Échec! ", text: textadaptatif, type: "error", confirmButtonText: "I'm sad" });
                });
            }
            function changeVisibility() {
                $(document).ready(function () {
                    document.getElementById("Leaderboard_Classement").style.visibility = "visible";
                    document.getElementById("Stats_Classement").style.visibility = "visible";
                });
            }
        </script>
    <div class="Entete">
        <img src="./Images/Logo_Grand.png" style="max-height: 100%; max-width: 100%;" />
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
        <div class="FormRecherche">
            <label>Nom d'utilisateur</label><br />
            <asp:TextBox ID="TB_UsernameSearch" TextMode="SingleLine" runat="server" /><br/><br />
            <asp:Button Text="Rechercher" runat="server" OnClick="Rechercher_Click" />
        </div>
        <div id="Leaderboard_Classement">
            <asp:GridView runat="server" ID="GV_Leaderboard" OnRowDataBound="GV_Leaderboard_OnRowDataBound"  
                AutoPostBack="true" OnSelectedIndexChanged="GV_Leaderboard_SelectedIndexChanged"
                AllowPaging ="true" OnPageIndexChanging = "GV_Leaderboard_PageIndexChanging" PageSize = "5">     
            </asp:GridView>
        </div>

        <div id="Stats_Classement">
           <asp:GridView runat="server" ID="GV_Stats">
           </asp:GridView>
        </div>
    </form>
</body>
</html>
