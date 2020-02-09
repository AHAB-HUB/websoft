<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Schools in Sweden</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="icon" href="favicon.ico">
</head>

<body onload="getMunicipalities()">

<?php include "./view/header.php"; ?>

<div class ="title" style ="border-radius:20px;transform: translate(0, 150px);padding-bottom:40px">
<div style ="font-size:40px;color:white;padding-top:20px;padding-left:20px;"> Schools in Sweden</div>

<form class ="text-container" style ="width:35%; margin-bottom:0;">
  <div>Select a Municipality:</div>
  <select
    id="select-element"
    onchange="getSchools(this.value)"
  >
  </select>
</form>

<table id="table" class="text-container table"  style="text-align:left;margin-bottom: 80px;width:0 auto; max-width:0 auto">
</table>
<script src="js/schools.js"></script>

</div>

<?php include "./view/duck.php"; ?>
<?php include "./view/footer.php"; ?>

</body>
</html>
