<?php

include('./crud_php/crud_action/db_connection.php');

$item  = $_GET["item"] ?? null;
$id    = $_POST["id"] ?? null;
$label = $_POST["label"] ?? null;
$type  = $_POST["type"] ?? null;
$course = $_POST["course"] ?? null;
$save  = $_POST["save"] ?? null;

$fetch = "SELECT * FROM tech";
$result = mysqli_query($connect, $fetch);
$rows = mysqli_fetch_all($result, MYSQLI_ASSOC);

if($item){
  $sql = "SELECT * FROM tech WHERE id = '$item' ";
  $result = mysqli_query($connect, $sql);
  $results = mysqli_fetch_all($result, MYSQLI_ASSOC);
}

if($save){
  $query = "UPDATE tech SET label = '$label', type = '$type',course = '$course' WHERE id = '$id' ";
  mysqli_query($connect, $query);
  header("Location: " . $_SERVER['PHP_SELF'] . "?item=$id");
}
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
    Update
  </div>

  <form class="text-container" >
     <select name="item" style="width:100%;height:40px" onchange="this.form.submit()">
        <option value="-1">Select item</option>

        <?php foreach ($rows as $row) { ?>
            <option value="<?= $row["id"] ?>"><?= "(" . $row["id"]. ") " . $row["label"] ?></option>
        <?php } ?>

    </select>
  </form>

  <?php if ($results ?? null){ ?>
   <?php foreach($results as $result){ ?>
<form method="post">
   <fieldset>
       <legend>Details</legend>
       <p>
           <label>Id:
               <input type="text" readonly="readonly" name="id" value="<?= $result['id'] ?>">
           </label>
       </p>
       <p>
           <label>Label:
               <input type="text" name="label" value="<?= $result['label'] ?>">
           </label>
       </p>
       <p>
           <label>Type:
               <input type="text" name="type" value="<?= $result['type'] ?>">
           </label>
       </p>
       <p>
    <p>
           <label>Course:
               <input type="text" name="course" value="<?= $result['course'] ?>">
           </label>
       </p>
       <p>
           <input type="submit" name="save" value="Save">
       </p>
   </fieldset>
</form>
<?php } ?>
<?php } ?>

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
