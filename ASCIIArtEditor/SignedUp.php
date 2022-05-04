<?php 
include_once 'Header.php';

if(isset($_GET['error'])){

}else{
    header("location: ./index.php");
	exit();
}
?>

<section>
    <h3>Successfully Signed Up!</h3>
    <a href="Login.php"><button name='Go To Login Form'>Go to Log In</button></a>
</section>

</body>
