/* The Clock and other effects
This clock is made by me for training purboses
coding by: Elias Haloun*/

//Make the canvas as a variable, Basic convert

var toRadians = Math.PI / 180;
var xxx = 200;
var yyy = 150;
init();
window.addEventListener('keydown',doKeyDown,true);


function init() {
	canvas = document.getElementById("Clock");
	ctx = canvas.getContext("2d");
	function klockan(){
		drawClock(xxx,yyy,300,'lightblue', 'grey', 'orange');
	}
	return setInterval(klockan, 200);
}

function drawClock(Xpos,Ypos,ClockSize,ClockColor, CBackColor, CContourColor){
	ctx.clearRect(0, 0, canvas.width, canvas.height);
	
	drawCircle(Xpos,Ypos,ClockSize * 0.9 ,CContourColor);
	drawCircle(Xpos,Ypos,ClockSize * 0.85 ,CBackColor);
	drawNumber(Xpos,Ypos,ClockSize,ClockColor);
	
	lightHands(Xpos,Ypos,ClockSize, ClockColor, 1.5, 2.0, timeSet()[1]); //Seconds
	lightHands(Xpos,Ypos,ClockSize, ClockColor, 4.0, 2.4, timeSet()[2]); //Minutes
	lightHands(Xpos,Ypos,ClockSize, ClockColor, 7.0, 2.8, timeSet()[3]); //Hours
	
	drawCircle(Xpos,Ypos,ClockSize * 0.05 ,ClockColor);
}

function drawRect(Xpos,Ypos,ClockSize,Color){
	ctx.fillStyle = Color;
	ctx.fillRect( Xpos - ClockSize / 2, Ypos - ClockSize / 2, ClockSize, ClockSize);
}
function drawCircle(Xpos,Ypos,ClockSize,Color){
	ctx.beginPath();
	ctx.arc(Xpos,Ypos, ClockSize / 2, 0, 2 * Math.PI);
	ctx.fillStyle = Color;
	ctx.fill();
}
function drawNumber(Xpos,Ypos,ClockSize,Color){
	for (var y = 6; y <= 360; y += 6) {
		if(y%5 !== 0){
			var NumlineSize1 = ClockSize * (0.80 / 2);
			var NumlineSize2 = ClockSize * (0.78 / 2);
			ctx.lineCap = "round";
			ctx.beginPath();
			ctx.lineWidth = 1.5;
			ctx.moveTo(Xpos + NumlineSize1 * Math.sin(y * toRadians), Ypos - NumlineSize1 * Math.cos(y * toRadians));
			ctx.lineTo(Xpos + NumlineSize2 * Math.sin(y * toRadians), Ypos - NumlineSize2 * Math.cos(y * toRadians));
			ctx.strokeStyle = Color;
			ctx.stroke();
		}else{
			var ClockNumSize = ClockSize / 22;
			ctx.beginPath();
			ctx.font = "italics " + ClockNumSize.toString() + "px Times New Roman";
			ctx.fillStyle = Color;
			ctx.textAlign = "center";
			ctx.textBaseline = "middle";
			var NumarcSize = ClockSize * (0.78 / 2);
			var arrNum_1 = ['','I','II','III','IV','V','VI','VII','VIII','IX','X','XI','XII'];
			var arrNum_2 = [0,1,2,3,4,5,6,7,8,9,10,11,12];
			for (var x = 30; x <= 360; x += 30) {
				ctx.fillText(arrNum_2[x/30], Xpos + NumarcSize * Math.sin(x * toRadians),
									         Ypos - NumarcSize * Math.cos(x * toRadians));				 
			}		
		}			
	}
}
function timeSet() {
	//The Times variable
	var today = new Date();
	var Ms = (today.getMilliseconds()* 6/1000) * toRadians;	
	var s  = (today.getSeconds() 	 * 6  	 ) * toRadians;
	var m  = (today.getMinutes() 	 * 6	 ) * toRadians + s/60;
	var h  = (today.getHours()   	 * 30 	 ) * toRadians + m/12;
	var Ms1Loc ={
		x :  Math.sin((today.getMilliseconds()*360/1000) * toRadians), 
		y : -Math.cos((today.getMilliseconds()*360/1000) * toRadians)
	}	
	var SecondsLoc = {
		x : Math.sin(s), y : -Math.cos(s)
	}
	var MinutesLoc = {
		x : Math.sin(m), y : -Math.cos(m)
	}
	var HoursLoc = {
		x : Math.sin(h), y : -Math.cos(h)
	}
	var TimeArr = [Ms1Loc,SecondsLoc,MinutesLoc,HoursLoc];
	return 	TimeArr;
}
function lightHands(Xpos,Ypos,ClockSize, Color, line, length, loc) {
	//the end Location of the hours, minutes and seconds
	var XHands = Xpos + ClockSize * 0.75 / length * loc.x;
	var YHands = Ypos + ClockSize * 0.75 / length * loc.y;

	//Draw the light hands function
	ctx.lineCap = "round";
	ctx.beginPath();
	ctx.lineWidth = line;
	ctx.moveTo(XHands, YHands);
	ctx.lineTo(Xpos, Ypos);
	ctx.strokeStyle = Color;
	ctx.stroke();
	
}
