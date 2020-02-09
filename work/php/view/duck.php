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

<img src="img/duck.png" id ="duck" style="position:fixed;top:30px;height:100px;width:100px;visibility:hidden" alt="hi" >
