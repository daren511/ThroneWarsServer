<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotUsername.aspx.cs" Inherits="SiteWebThroneWars.ForgetUsername" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Throne Wars -Projet FinDec - Forgot Username</title>
<meta charset="utf-8"/> 
<link rel="stylesheet" type="text/css" href="FinDec.css"/>
<link rel="stylesheet" type="text/css" href="/sweet-alert.css"/>
<script src="/sweet-alert.min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</head>
	<body>
        <form runat="server" action="ForgotUsername.aspx" autocomplete="on">
        <script type="text/javascript">
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Veuillez visiter votre courriel pour récupérer votre nom de compte", type: "success", confirmButtonText: "Ok" });
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
 					<li><a href="default.aspx">Accueil</a></li>
 					<li><a href="Inscription.aspx">Inscription</a></li>
                    <li><a href="Connexion.aspx">Connexion</a></li>
				 	<li><a href="Recherche.aspx">Recherche Joueur</a></li>
				 	<li><a href="Media.aspx">Média</a></li>
				 </li>
			</ul>
		</div>
        
		<div class="FormForgot">
  			Courriel: <asp:Textbox ID="TB_Email" TextMode="Email" runat="server"/><br/><br/>
  			<asp:Button Text="Envoyer" runat="server" onclick="UsernameRecovery_Click" />
  		</div>
        </form>
  	</body>
</html>
