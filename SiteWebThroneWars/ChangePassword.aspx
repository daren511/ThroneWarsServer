<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SiteWebThroneWars.ChangePassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css"/>
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <title>Throne Wars -Projet FinDec - Changer son mot de passe</title>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        function MessageBoxReussi() {
            $(document).ready(function () {
                swal({ title: "Bravo! ", text: "Votre mot de passe à été changé avec succès", type: "success", confirmButtonText: "Ok" });
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
            <asp:label id="usernameLB" runat="server">Nom d'utilisateur</asp:label><br/>
                <asp:TextBox id="username" TextMode="SingleLine" runat="server"/><br/>
            <asp:label id="OldPass" runat="server">Ancien mot de passe</asp:label><br/>
                <asp:TextBox id="apassword" TextMode="password" runat="server"/><br/>
  			<asp:label id="NewPass" runat="server">Nouveau mot de passe</asp:label><br/>
                <asp:TextBox id="npassword" TextMode="password" runat="server"/><br />
            <asp:label id="cNewPass" runat="server">Confirmer nouveau mot de passe</asp:label><br/>
                <asp:TextBox id="ncpassword" TextMode="password" runat="server"/><br />
            <asp:Button id="Button_Valider" Text="Valider" onClick="ChangePassword_Click" runat="server"/>

        </div>
    </form>
</body>
</html>
