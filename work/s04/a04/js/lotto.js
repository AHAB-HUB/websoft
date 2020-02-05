function randomDrow(){
  return Math.floor(Math.random() * 35) + 1;
}

var val1 = randomDrow();
var val2 = randomDrow();
var val3 = randomDrow();
var val4 = randomDrow();
var val5 = randomDrow();
var val6 = randomDrow();
var val7 = randomDrow();

var lotteryArr;
function newRnd(){
  lotteryArr = Array(val1, val2, val3, val4, val5, val6, val7);
}
newRnd();

function NewLottery(){
    var lotteryValues = document.getElementById("lotteryValues");
    var childNodes = lotteryValues.childNodes;
    var c = 0;

    for (var i = 2; i < childNodes.length - 2; i++) {

      if (i%2 == 1){
        childNodes[i].style.transition = "all 100ms";
        childNodes[i].innerHTML = lotteryArr[c];
        c++;
      }
    }
}

var isShown = new Boolean(false);

function showButton(){
  console.log("click");
  var lotteryValues = document.getElementById("lotteryValues");
  var childNodes = lotteryValues.childNodes;
  isShown = !isShown;

  for (var i = 2; i < childNodes.length - 2; i++) {

    if (i%2 == 1){

      if(isShown){
        childNodes[i].style.color = "white";
      }else{
        childNodes[i].style.color = "black";
      }
    }
  }
}

function updateColor(){
  var lotteryValues = document.getElementById("lotteryValues");
  var childNodes = lotteryValues.childNodes;
  var userValues = document.getElementById("userList");
  var userNodes = userValues.childNodes;

  for (var i = 2; i < childNodes.length - 2; i++) {

      if (i%2 ==1) {
        console.log(userNodes[i].textContent + " " + childNodes[i].textContent );
                if (childNodes[i].textContent  == userNodes[i].textContent) {
                    userNodes[i].style.background = '#98FB98';
                }else{
                  if (userNodes[i].textContent == ""|| userNodes[i].textContent ==  null) {
                    userNodes[i].style.background = 'white';
                    return;
                  }else{
                    userNodes[i].style.background = '#FF6961';

                  }
                }

      }

  }

}





module.exports.lotteryArr = lotteryArr;
module.exports.rnd = function(){
  return [randomDrow(),randomDrow(),randomDrow(),randomDrow(),randomDrow(),randomDrow(),randomDrow()];
};
