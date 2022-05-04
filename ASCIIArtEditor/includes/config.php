<?php
   $dbhost = 'localhost';
   $dbuser = 'root';
   $dbpass = '';
   $conn = mysqli_connect($dbhost, $dbuser, $dbpass);
   
   if(mysqli_connect_errno() ) {
      die('Could not connect: ' . mysqli_connect_error());
   }
   
   echo 'Connected successfully';
   
   $sql = 'CREATE Database if not exists asciidb';
   $retval = mysqli_query( $conn,$sql );
   
   if(! $retval ) {
      die('Could not create database: ' . mysqli_error($conn));
   }
   
   echo "\nDatabase asciidb created successfully\n";
     
   mysqli_select_db( $conn, 'asciidb' );
   
   $query_file = 'setup.sql';
   
   $fp = fopen($query_file, 'r');
   $sql = fread($fp, filesize($query_file));
   fclose($fp);
   $retval = mysqli_query( $conn, $sql );
   if(! $retval ) {
    die('Could not create database: ' . mysqli_error($conn));
 }
   
   echo "tables added sucessfully";
   mysqli_close($conn);
   ?>