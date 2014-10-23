<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="SiteWebThroneWars.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Throne Wars -Projet FinDec - Inscription</title>
<meta charset="utf-8"/> 
<link rel="stylesheet" type="text/css" href="FinDec.css"/>
<link rel="stylesheet" type="text/css" href="/sweet-alert.css"/>
 <script src="/sweet-alert.min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>


</head>
<body>
    <form runat="server" action="Inscription.aspx" autocomplete="on">
        <script type="text/javascript">
            /*
            $(document).ready(function () {
                MessageBoxReussi();
            });
            */
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Votre inscription est réussie, veuillez consulter votre courriel pour confirmer votre compte ", type: "success", confirmButtonText: "Ok" });
                });
            }
            function MessageBoxErreur(textadaptatif) {
                $(document).ready(function () {
                    swal({ title: "Échec! ", text: textadaptatif, type: "error", confirmButtonText: "I'm sad" });
                });
            }
        </script>
		<div class="Entete">
			<img src="./Images/Logo_Grand.png" style="max-height:100%; max-width:100%;"/> <!-- A checker les dimensions ou plus grosse image -->
		</div>
		<br/>
		<br/>
		<div class="Table">
			<ul id="menu-bar">
 				<li class="active">
 					<li><a href="Page Principale.aspx">Accueil</a></li>
 					<li><a href="Inscription.aspx">Inscription</a></li>
                    <li><a href="Connexion.aspx">Connexion</a></li>
				 	<li><a href="Recherche.aspx">Recherche Joueur</a></li>
				 	<li><a href="Media.aspx">Média</a></li>
				 </li>
			</ul>
		</div>
		<div class="Inscription">
  			<asp:label id="usernameLB" runat="server">Nom d'utilisateur</asp:label><br/>
                <asp:Textbox ID="username" TextMode="SingleLine" runat="server"/><br/>
  			<asp:label id="PasswordLB" runat="server">Mot de Passe</asp:label><br/>
                <asp:TextBox id="password" TextMode="password" runat="server"/><br/>
  			<asp:label id="CPasswordLB" runat="server">Confirmer Mot de Passe</asp:label><br/>
                <asp:TextBox id="cpassword" TextMode="password" runat="server"/><br />
            <asp:label id="EmailLB" runat="server">Courriel</asp:label><br/>
                <asp:Textbox ID="email" TextMode="SingleLine" runat="server"/><br/>
  			<asp:label id="CEmailLB" runat="server">Confirmer Courriel</asp:label><br/>
                <asp:Textbox ID="cemail" TextMode="SingleLine" runat="server"/><br/><br />
            <asp:Button Text="Valider" onClick="inscriptionJoueur_Click" runat="server"/>
		
		</div>
        </form>
</body>
</html>

