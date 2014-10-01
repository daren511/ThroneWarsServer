<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="SiteWebThroneWars.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Throne Wars -Projet FinDec - Inscription</title>
<meta charset="utf-8"/> 
<link rel="stylesheet" type="text/css" href="FinDec.css"/>
</head>
<body>
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
				 	<li><a href="Stats.aspx">Statistiques</a></li>
				 	<li><a href="Media.aspx">Média</a></li>
				 </li>
			</ul>
		</div>
		<div class="Inscription">
		<form runat="server" action="Inscription.aspx" autocomplete="on">
  			<label>Nom d'utilisateur</label><input type="text" name="username"/><br/>
  			<label>Mot de passe</label> <input type="password" name="password"/><br/>
  			<label>Confirmer mot de passe</label> <input type="password" name="cpassword"/><br/>
  			<label>Courriel</label> <input type="email" name="email" autocomplete="off"/><br/>
  			<label>Confirmer courriel</label> <input type="email" name="cemail" autocomplete="off"/><br/>	
            <asp:Button Text="Valider" onClick="inscriptionJoueur" runat="server"/>
		</form>
          
			<a href="ForgotPass.aspx">Mot de passe oublié?</a>
		</div>
</body>
</html>

