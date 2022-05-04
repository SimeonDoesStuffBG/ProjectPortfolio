<?php
if(isset($_POST["submit"])){
	$username = $_POST["Username"];
	$pwd = $_POST["passwd"];
	
	require_once 'db.inc.php';
	require_once 'functions.inc.php';
	
	if(emptyInputLogin($username, $pwd) !== false){
			header("location: ../Login.php?error=emptyInput");
			 exit();
	}
	
	loginUser($connection, $username, $pwd);
}else{
	header("location: ../Login.php");
	exit();
}
?>