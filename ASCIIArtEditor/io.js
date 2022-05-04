const importer = document.getElementById("import");
const exporter = document.getElementById("export");
var drawingSpaces = new Array();

var canvas = document.getElementById("result");
var context = canvas.getContext('2d');

var height = document.getElementById("Height");
var width = document.getElementById("Width");
var name = document.getElementById("Image Title");

function buildArray(){      
	while(drawingSpaces.length !==0){
			drawingSpaces.shift();
	}

	for(var i = 0; i < height.value; i++){
		var subArr = new Array();
		for(var j = 0; j < width.value; j++){
			subArr.push(document.getElementsByClassName("DrawingPixel")[i*width.value + j]);
		}
		drawingSpaces.push(subArr);
	}
}

exporter.addEventListener('click', function(x){
	let imageTitle = document.getElementById("Image Title").value;
	drawOnCanvas();
	download_image(imageTitle);
});

function drawOnCanvas(){
	buildArray();
	canvas.setAttribute("width", width.value * 40 + 10);
	canvas.setAttribute("height", height.value * 40 + 10);
	
	context.fillStyle = "white";
	context.fillRect(0,0,canvas.width,canvas.height);
	context.fillStyle = "black";
	
	for(var i = 0; i < height.value; i++){
		var str = "";
		for(var j = 0; j < width.value; j++){
			str = drawingSpaces[i][j].innerHTML;
			context.font = "40px Georgia";
			context.fillText(str, 10 + (40 * j), 40 * (i+1));
			//str+=drawingSpaces[i*width.value + j];
		}
		//console.log(str);
		// Times New Roman
		//context.font = "20px Georgia"
		//context.fillText(str, 10, 20*(i+1));
	}
}

function download_image(imageTitle){
  var canvas = document.getElementById("result");
  image = canvas.toDataURL("image/png", 1.0).replace("image/png", "image/octet-stream");
  var link = document.createElement('a');
  link.download = imageTitle + ".png";
  link.href = image;
  link.click();
}