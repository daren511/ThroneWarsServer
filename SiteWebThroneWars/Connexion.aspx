<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="SiteWebThroneWars.Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="/Images/Icon.png" />
    <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css" />
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <title></title>
</head>
<body>
   <form runat="server" action="Connexion.aspx" autocomplete="on">
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
        </script>
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
            </li>
        </ul>
    </div>

        <div class="Inscription">
            <asp:Label ID="usernameLB" runat="server">Nom d'utilisateur</asp:Label><br />
            <asp:TextBox ID="username" TextMode="SingleLine" runat="server" /><br />
            <asp:Label ID="passwordLB" runat="server">Mot de Passe</asp:Label><br />
            <asp:TextBox ID="password" TextMode="password" runat="server" /><br /><br />
            <asp:Button Text="Se connecter" OnClick="Connexion_Click" runat="server" /><br />
            <a href="ForgotPass.aspx">Mot de passe oublié?</a><br />
            <a href="ForgotUsername.aspx">Nom d'utilisateur oublié?</a><br />
            <a href="ChangePassword.aspx">Changer son mot de passe</a>
        </div>
        <div class="Leaderboard">
            <asp:GridView runat="server" ID="GV_Leaderboard" OnRowDataBound="GV_Leaderboard_OnRowDataBound">
                
            </asp:GridView>
        </div>

        <div class="Stats">

                 <asp:GridView runat="server" ID="GV_Stats">
                 </asp:GridView>
        </div>
    </form>
</body>
</html>
