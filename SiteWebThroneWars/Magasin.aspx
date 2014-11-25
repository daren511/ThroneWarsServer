﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Magasin.aspx.cs" Inherits="SiteWebThroneWars.Magasin" %>

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
    <form id="form1" runat="server">
    <script type="text/javascript">
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

    <asp:Label ID="usernameLB" runat="server">Nom d'utilisateur</asp:Label><br />
    <asp:TextBox ID="username" TextMode="SingleLine" runat="server" Enabled="false"/><br />
    <div id="Magasin">
          <asp:GridView runat="server" ID="GV_Magasin">
         </asp:GridView>
    </div>
    <asp:Button Text="Acheter" OnClick="Acheter_Click" runat="server" /><br />
    </form>
        </body>
</html>
