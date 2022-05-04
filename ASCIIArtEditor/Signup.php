<?php
	include_once 'Header.php';
?>

<section>
	<h2>Sign Up</h2>
	<form action = "includes/signup.inc.php" method = "post">
		<table>
			<tr>
				<td><label>Username</label></td>
				<td><input type = "text" name = "Username" placeholder = "Enter Username"></td>
			</tr>
			
			<tr>
				<td><label>E-mail</label></td>
				<td><input type = "text" name = "Email" placeholder = "Enter E-mail"></td>
			</tr>
			<tr>
				<td><label>Password</label></td>
				<td><input type = "password" name = "passwd" placeholder = "Enter password"></td>
			</tr>
			<tr>
				<td><label>Confirm Password</label></td>
				<td><input type = "password" name = "passwdRepeat" placeholder = "Confirm Password"></td>
			</tr>			
		</table>
		<button type = "submit" name = "submit">Sign Up</button>
	</form>
	
	<?php
	if(isset($_GET["error"])){
		if($_GET["error"] == "emptyInput"){
			
		}
	}
	?>
</section>


</body>