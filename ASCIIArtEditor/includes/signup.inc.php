<?php
	if(isset($_POST["submit"])){
		$name = $_POST["Username"];
		$email = $_POST["Email"];
		$password = $_POST["passwd"];
		$passwordRep = $_POST["passwdRepeat"];
		
		require_once 'db.inc.php';
		require_once 'functions.inc.php';
		
		if(emptyInputSignup($name, $email, $password, $passwordRep) !== false){
			header("location: ../Signup.php?error=emptyInput");
			 exit();
		}
		if(invalidUserName($name) !== false){
			header("location: ../Signup.php?error=InvalidUsername");
			 exit();
		}
		if(invalidEmail($email) !== false){
			header("location: ../Signup.php?error=InvalidEmail");
			 exit();
		}
		if(PasswordMatch($password, $passwordRep) !== false){
			header("location: ../Signup.php?error=PasswordsDontMatch");
			 exit();
		}
		if(TakenUsername($connection, $name, $email) !== false){
			header("location: ../Signup.php?takenUsername");
			exit();
		}
		
		createUser($connection, $name, $email, $password);
		
	}else{
		header("location: ../Signup.php");
		exit();
	}

?>