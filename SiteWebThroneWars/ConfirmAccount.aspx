<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmAccount.aspx.cs" Inherits="SiteWebThroneWars.ConfirmAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css"/>
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <title>Throne Wars -Projet FinDec - Confirmer son compte</title>
</head>
<body>
    <form runat="server" action="ConfirmAccount.aspx" autocomplete="on">
        <script type="text/javascript"> 
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Votre confirmation de compte est réussie", type: "success", confirmButtonText: "Ok" }, function () { window.location.assign("default.aspx");});
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
                    <li><a href="Magasin.aspx">Magasin</a></li>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
