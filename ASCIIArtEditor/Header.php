<?php
	include_once 'includes/db.inc.php';
	session_start();

?>

<!DOCTYPE html>
<html>
<head>
    <title>ASCII art tingy</title>
	<link rel = "stylesheet" href = "style.css">
</head>
<body>
	<header>
		<?php
		
		if(isset($_SESSION["username"])){
			echo "<p>".$_SESSION["username"]."</p>";
			echo "<a href = 'Logout.php'><button>Log Out</button></a>";
		}else{
			echo "<a href='Signup.php'><button>Sign Up</button></a>";
			echo "<a href='Login.php'><button>Log In</button></a>";
		}
		?>
	</header>
    <h1><a href="index.php">ASCII Art Editor<a></h1>
