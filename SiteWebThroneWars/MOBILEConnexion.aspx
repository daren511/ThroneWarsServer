<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOBILEConnexion.aspx.cs" Inherits="SiteWebThroneWars.MOBILEConnexion" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="/Images/Icon.png" />
    <link rel="stylesheet" type="text/css" href="FinDec_Mobile.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css" />
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="/Menu/jquery.mmenu.min.js" type="text/javascript"></script>
    <link href="/Menu/jquery.mmenu.css" type="text/css" rel="stylesheet" />
    <title></title>
</head>
<body>
   <form runat="server" action="MOBILEConnexion.aspx" autocomplete="on">
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
        function MessageBoxWarning(textadaptatif) {
            $(document).ready(function () {
                swal({ title: "Attention! ", text: textadaptatif, type: "warning", confirmButtonText: "Ok" });
            });
        }
        function changeVisibility() {
            $(document).ready(function () {
                document.getElementById("Leaderboard_Conn_Mobile").style.visibility = "visible";
                document.getElementById("Stats_Conn_Mobile").style.visibility = "visible";
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
        
        
        <div class="Inscription_Mobile">
            <asp:Label ID="usernameLB" runat="server">Nom d'utilisateur</asp:Label><br />
            <asp:TextBox ID="username" TextMode="SingleLine" runat="server" style="width: 38%; font-size:30px;" /><br />
            <asp:Label ID="passwordLB" runat="server">Mot de passe</asp:Label><br />
            <asp:TextBox ID="password" TextMode="password" runat="server" style="width: 38%; font-size:30px;" /><br /><br />
            <asp:Button Text="Se connecter" OnClick="MOBILEConnexion_Click" runat="server"  style="width:31%; font-size:35px;" /><br />
            <a href="MOBILEForgotPass.aspx">Mot de passe oublié?</a><br />
            <a href="MOBILEForgotUsername.aspx">Nom d'utilisateur oublié?</a><br />
            <a href="MOBILEChangePassword.aspx">Changer son mot de passe</a><br />
            <a href="MOBILESendConfirmation.aspx">Renvoyer le lien de confirmation</a>
        </div>
        <div id="Leaderboard_Conn_Mobile">
            <asp:GridView runat="server" ID="GV_Leaderboard" OnRowDataBound="GV_Leaderboard_OnRowDataBound">
                
            </asp:GridView>
        </div>

        <div id="Stats_Conn_Mobile">
          <asp:GridView runat="server" ID="GV_Stats">
          </asp:GridView>
        </div>
    </form>
</body>
</html>

