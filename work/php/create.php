<?php require_once './crud_php/crud_action/db_connection.php'; ?>

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
  <div style="color:white;font-size:30px;margin-top:30px; margin-left:30px">
    New Item
  </div>
  <div class="text-container">
    <fieldset>
        <legend>Details</legend>

        <form action="crud_php/crud_action/create.php" method="post">
            <table cellspacing="0" cellpadding="0">
                <tr>
                    <th>Label</th>
                    <td><input type="text" name="label" placeholder="Label" /></td>
                </tr>
                <tr>
                    <th>Type</th>
                    <td><input type="text" name="type" placeholder="Type" /></td>
                </tr>
                <tr>
                    <th>Course</th>
                    <td><input type="text" name="course" placeholder="Course" /></td>
                </tr>
                <tr>
                    <td><button type="submit">Add new data</button></td>
                </tr>
            </table>
        </form>
    </fieldset>
  </div>
</div>


<?php include "./view/duck.php"; ?>
<?php include "./view/footer.php"; ?>
</body>
</html>
