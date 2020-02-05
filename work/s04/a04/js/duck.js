

    function startGame() {

      var areaHeight = window.innerHeight,
          areaWidth = window.innerWidth,
          points = document.getElementById('points'),
          duck = document.getElementById('duck'),
          holder = document.getElementById('scoreHolder'),
          startLogo = document.getElementById('startLogo'),
          exit = document.getElementById('exit');
          score = 0,
          timer = 1000;

        exit.style.visibility = "visible";
        duck.style.visibility = "visible";
        duck.style.zIndex = "10000";
        duck.style.position = "fixed";
        holder.style.visibility = "visible";
        startLogo.style.visibility = "hidden";

        duck.onclick = function(){
        score += 1;
        newPosition(duck, areaWidth, areaHeight);
        points.innerHTML = score;
        console.log(score);
        };

        console.log('Game is ready!');
    }

    function newPosition(duck, areaWidth, areaHeight) {
        var newX = Math.floor(Math.random() * (areaWidth - duck.width)),
            newY = Math.floor(Math.random() * (areaHeight - duck.height));

        duck.style.left = newX + "px";
        duck.style.top  = newY + "px";
        console.log(newX, newY);
    }

    function reset(){

      var startLogo = document.getElementById('startLogo'),
      duck = document.getElementById('duck'),
      holder = document.getElementById('scoreHolder'),
      startLogo = document.getElementById('startLogo'),
      exit = document.getElementById('exit');

      exit.style.visibility = "hidden";
      startLogo.style.visibility = "visible";
      duck.style.visibility = "hidden";
      holder.style.visibility = "hidden";
    }
