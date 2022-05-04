<?php
function emptyInputSignup($name, $email, $password, $passwdRepeat){
	$result;
	if(empty($name) || empty($email) || empty($password) || empty($passwdRepeat)){
		$result = true;
	}else{$result = false;}
	
	return $result;
}

function invalidUserName($name){
	$result;
	if(!preg_match("/^[a-zA-Z0-9]*$/",$name)){
		$result = true;
	}else{$result = false;}
	return $result;
}

function invalidEmail($email){
	$result;
	if(!filter_var($email, FILTER_VALIDATE_EMAIL)){
		$result = true;
	}else{$result = false;}
	return $result;
}

function PasswordMatch($password, $passwdRepeat){
	$result;
	if($password !== $passwdRepeat){
		$result = true;
	}else{
		$result = false;
	}
	return $result;
}

function TakenUsername($connection, $name, $email){
	$result;
	$sql = "SELECT * FROM Users WHERE UsersName=? or UsersEmail = ?;";
	$stmt = mysqli_stmt_init($connection);
	if(!mysqli_stmt_prepare($stmt, $sql)){
		header("location: ../Signup.php?databaseError");
		exit();
	}
	
	mysqli_stmt_bind_param($stmt, "ss", $name, $email);
	mysqli_stmt_execute($stmt);
	
	$myData = mysqli_stmt_get_result($stmt);
	if($row = mysqli_fetch_assoc($myData)){
		return $row;
	}else{
		$result = false;
		return $result;
	}
	
	mysqli_stmt_close($stmt);
}

function emptyInputLogin($username, $password){
	$result;
	if(empty($username) || empty($password)){
		$result = true;
	}else{$result = false;}
	
	return $result;
}

function loginUser($connection, $username, $password){
	$uidExists = TakenUsername($connection, $username, $username);
	
	if($uidExists === false){
		header("location: ../Login.php?error=wrongUser");
		exit();
	}
	
	$pwdHashed = $uidExists["UsersPwd"];
	$checkPwd = password_verify($password, $pwdHashed);
	
	if($checkPwd === false){
		header("location: ../Login.php?error=wrongPass");
		exit();
	}else if($checkPwd === true){
		session_start();
		$_SESSION["userid"] = $uidExists["UsersID"];
		$_SESSION["username"] = $uidExists["UsersName"];
		
		header("location: ../index.php");
		exit();
	}
}

function createUser($connection, $name, $email,$password){
	$sql = "INSERT INTO Users (UsersName, UsersEmail, UsersPwd) VALUES(?,?,?);";
	$stmt = mysqli_stmt_init($connection);
	if(!mysqli_stmt_prepare($stmt, $sql)){
		header("location: ../Signup.php?databaseError");
		exit();
	}
	
	$hashedPwd = password_hash($password, PASSWORD_DEFAULT);
	
	mysqli_stmt_bind_param($stmt, "sss", $name, $email, $hashedPwd);
	mysqli_stmt_execute($stmt);	
	mysqli_stmt_close($stmt);
	header("location: ../SignedUp.php?error=none");
	exit();
}


?>