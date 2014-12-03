<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendConfirmation.aspx.cs" Inherits="SiteWebThroneWars.SendConfirmation" %>

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
    <form id="form1" runat="server" action="SendConfirmation.aspx">
        <script type="text/javascript">
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Votre nouveau lien de confirmation est envoyé", type: "success", confirmButtonText: "Ok" });
                }); 
            }
            function MessageBoxErreur(textadaptatif) {
                $(document).ready(function () {
                    swal({ title: "Échec! ", text: textadaptatif, type: "error", confirmButtonText: "Ok" });
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
                <li><a href="Magasin.aspx">Magasin</a></li>
            </li>
        </ul>
    </div>
    <div class="FormRecherche">
            <label>Nom d'utilisateur</label><br />
            <asp:TextBox ID="username" TextMode="SingleLine" runat="server" /><br/><br />
            <asp:Button Text="Envoyer" ID="SendLinkBack" runat="server" OnClick="SendLinkBack_Click" />
        </div>
    </form>
</body>
</html>
