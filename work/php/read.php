<?php

include('./crud_php/crud_action/db_connection.php');

$search = $_POST["search"] ?? null;

$sql = "SELECT * FROM tech";

$result = mysqli_query($connect, $sql);
$rows = mysqli_fetch_all($result, MYSQLI_ASSOC);

mysqli_free_result($result);
mysqli_close($connect);

?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>About this site</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="icon" href="favicon.ico">
</head>
<body >
<?php include "./view/header.php"; ?>

<div class="title" >
  <div style="color:white;font-size:30px;margin:20px">
    Read
  </div>

<?php if ($rows ?? null) { ?>
  <div class="text-container">
    <table  class="table" style="width:100%;">
        <tr>
            <th>ID</th>
            <th>Label</th>
            <th>Type</th>
			<th>Course</th>
        </tr>

    <?php foreach ($rows as $row) { ?>
        <tr>
            <td><?= $row["id"] ?></td>
            <td><?= $row["label"] ?></td>
            <td><?= $row["type"] ?></td>
			<td><?= $row["course"] ?></td>
        </tr>
    <?php } ?>
    </table>
  </div>
<?php } ?>

<?php include "./view/duck.php"; ?>
<?php include "./view/footer.php"; ?>
</body>
</html>
