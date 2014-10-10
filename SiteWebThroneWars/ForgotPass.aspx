<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="SiteWebThroneWars.ForgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Throne Wars -Projet FinDec - Forgot Password</title>
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
				 	<li><a href="Stats2.aspx">Statistiques</a></li>
				 	<li><a href="Media.aspx">Média</a></li>
				 </li>
			</ul>
		</div>
		<div class="FormForgot">
			<form runat="server" action="ForgotPass.aspx" autocomplete="on">
  			Courriel: <asp:Textbox ID="TB_Email" TextMode="Email" runat="server"/><br/><br/>
  			<asp:Button Text="Envoyer" runat="server" onclick="PasswordRecovery" />
            </form>
  		</div>
  	</body>
</html>
