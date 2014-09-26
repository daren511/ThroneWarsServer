<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Media.aspx.cs" Inherits="SiteWebThroneWars.Media" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8"/> 
	<title>Throne Wars -Projet FinDec - Media</title>
    <link rel="stylesheet" type="text/css" href="FinDec.css"/>
	</head>
	
	<body>
		<div class="Entete" align="center">
			<img src="./Images/Logo.jpg"> <!-- A checker les dimensions ou plus grosse image -->
		</div>
		<br/>
		<br/>
			<div class="Table">
			<ul id="menu-bar">
 				<li class="active">
 					<li><a href="Page Principale.html">Accueil</a></li>
 					<li><a href="Inscription.html">Inscription</a></li>
				 	<li><a href="Stats.html">Statistiques</a></li>
				 	<li><a href="Media.html">Média</a></li>
				 </li>
			</ul>
		</div>
			<div class="Photos">
				<h1>Photos</h1>
				<img src="./Images/1.jpg" width="300" height="300" ></br>
				<img src="./Images/2.jpg" width="300" height="300" >
			</div>
			
			<div class="Videos">
			<h2>Vidéos</h2>
			<iframe width="420" height="315" src="http://www.youtube.com/embed/3Yp2SvbERw8" frameborder="0" allowfullscreen></iframe>
			</div>
	</body>
</html>
