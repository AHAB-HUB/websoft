<?php

require_once 'db_connection.php';

if($_POST) {
    $label = $_POST['label'];
    $type = $_POST['type'];
    $course = $_POST['course'];

    $sql = "INSERT INTO tech (label, type, course) VALUES ('$label', '$type', '$course')";
    if($connect->query($sql) === TRUE) {
        echo "<p>New Record Successfully Created</p><br><a href='../../create.php'>go back</a>";

    } else {
        echo "Error " . $sql . ' ' . $connect->connect_error;
    }
    $connect->close();
}
?>
