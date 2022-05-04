<?php
	include_once 'Header.php';
?>

<section>

	<h2>Log In</h2>
	<form action = "includes/login.inc.php" method = "post">
		<table>
			<tr>
				<td><label>Username</label></td>
				<td><input type = "text" name = "Username" placeholder = "Enter Username"></td>
			</tr>
			<tr>
				<td><label>Password</label></td>
				<td><input type = "password" name = "passwd" placeholder = "Enter password"></td>
			</tr>
		</table>
		<button type = "submit" name = "submit">Log In</button>
	</form>
</section>
</body>