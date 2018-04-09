<?php

$db = mysqli_connect('127.0.0.1', 'root', '', 'application-boutique');

if(mysqli_connect_errno()) 
{
    echo 'Database connection failed with following errors: '.mysqli_connect_errno();
    die();
}

require_once $_SERVER['DOCUMENT_ROOT'].'/RainbowStyleBoutique/config.php';
require_once BASE_URL.'helpers/helpers.php';