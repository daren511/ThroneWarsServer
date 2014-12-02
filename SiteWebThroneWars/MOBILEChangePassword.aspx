<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOBILEChangePassword.aspx.cs" Inherits="SiteWebThroneWars.MOBILEChangePassword" %>

<<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" type="text/css" href="FinDec_Mobile.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css"/>
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="/Menu/jquery.mmenu.min.js" type="text/javascript"></script>
    <link href="/Menu/jquery.mmenu.css" type="text/css" rel="stylesheet" />
    <title>Throne Wars -Projet FinDec - Changer son mot de passe</title>
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
            <asp:label id="usernameLB" runat="server">Nom d'utilisateur</asp:label><br/>
                <asp:TextBox id="username" TextMode="SingleLine" runat="server" style="width: 38%; font-size:30px;"/><br/>
            <asp:label id="OldPass" runat="server">Ancien mot de passe</asp:label><br/>
                <asp:TextBox id="apassword" TextMode="password" runat="server" style="width: 38%; font-size:30px;"/><br/>
  			<asp:label id="NewPass" runat="server">Nouveau mot de passe</asp:label><br/>
                <asp:TextBox id="npassword" TextMode="password" runat="server" style="width: 38%; font-size:30px;"/><br />
            <asp:label id="cNewPass" runat="server">Confirmer nouveau mot de passe</asp:label><br/>
                <asp:TextBox id="ncpassword" TextMode="password" runat="server" style="width: 38%; font-size:30px;"/><br /><br />
            <asp:Button id="Button_Valider" Text="Valider" onClick="ChangePassword_Click" runat="server"  style="width:20%; font-size:35px;"/>

        </div>
    </form>
</body>
</html>
