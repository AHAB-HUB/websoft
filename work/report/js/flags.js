function createFlag(flag){

    var _flag = document.getElementById("flag");
        _flag.style.opacity = 1;
        _flag.style.visibility = "visible";

    var frenchFlag = "<div style='width:100px;height:100%;background-color:blue;'></div><div style='width:100px;height:100%;background-color:white;'></div><div style='width:100px;height:100%;background-color:red;'></div>";
    var italianFlag ="<div style='width:100px;height:100%;background-color:green;'></div><div style='width:100px;height:100%;background-color:white;'></div><div style='width:100px;height:100%;background-color:red;'></div>";
    var belgiumFlag = "<div style='width:100PX;height:100%;background-color:black;'></div><div style='width:100px;height:100%;background-color:yellow;'></div><div style='width:100px;height:100%;background-color:red;'></div>";

    switch (flag) {
      case 'France':
        _flag.innerHTML = frenchFlag;
      break;

      case 'Italy':
        _flag.innerHTML = italianFlag;
      break;
      case 'Belgium':
        _flag.innerHTML = belgiumFlag;
      break;
      default:
    }

    _flag.addEventListener("click", function(){
      _flag.style.visibility = "hidden";
      _flag.style.opacity = 0;
    });
}
