<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Flags</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="icon" href="favicon.ico">
</head>
<script src="js/main.js"></<script type="text/javascript"></script>
<script src="js/flags.js"></<script type="text/javascript"></script>

<body>
<!-- HEADER -->
<?php include "./view/header.php"; ?>
<!-- END HEADER -->

<div class ="title" style ="border-radius:50px;display:fixed;position:fixed;left: 50%;margin-left: -350px;top: 50%;margin-top: -250px;">
  <div style="color:white;font-size:40px;padding-top:20px;padding-left:30px">Flags</div>
  <div class ="text-container" style="display:flex;flex-direction:row;padding-bottom:300px;justify-content: space-around;">
    <div id="button1" class="flag-button" onclick="createFlag('France')">France</div>
    <div id="button2" class="flag-button" onclick="createFlag('Italy')">Italy</div>
    <div id="button3" class="flag-button" onclick="createFlag('Belgium')">Belgium</div>

    <!-- flag -->
    <div id ="flag"></div>
   </div>
</div>

<!-- DUCK OBJECT -->
<script src="js/duck.js"></script>
<div id="scoreHolder" class="text-container" style="display:flex;visibility:hidden;width:100px;position:fixed;right:10px;bottom:170px;margin:0;border-radius:50px">
  <div>Points:</div>
  <div id="points" style="padding-left:5px">0</div>
</div>

<div class ="tooltip" id="startLogo">
  <span class="tooltiptext" style = "right:8px;bottom:170px;">Press to start</span>
  <img src="img/duck-logo.jpg" class ="image-duck" onclick="startGame()" alt="Duck-logo">
</div>

<div class ="tooltip" id="exit" style="visibility:hidden; background-color:red;">
  <span class="tooltiptext" style="height:3 0px;width:170px;display:fixed;right:91px;bottom:115px;"> Press to Exit the game</span>
  <img src="img/stop.png" onclick="reset()" alt="hi" class ="image-duck" >
</div>

<img src="img/duck.png" id ="duck" style="bottom:200px;height:100px;width:100px;visibility:hidden" alt="hi" >
<!-- END DUCK OBJECT -->

<!-- FOOTER -->
<?php include "./view/footer.php"; ?>
<!-- END FOOTER -->

</body>

</html>
