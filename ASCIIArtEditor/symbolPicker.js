const asciiTable = document.getElementById("ASCIIthing");
const picker = document.getElementById("symbolPicker");
const mode = document.getElementById("Mode");

const draw = document.getElementById("Drawing Mode");
const erase = document.getElementById("Erase Mode");
const fill = document.getElementById("Fill Mode");
const replace = document.getElementById("Replace Mode");

var currentMode = "Drawing Mode";
draw.style.backgroundColor = "lightgray";

asciiTable.innerHTML = " ";
generateASCIItable();

picker.addEventListener('click', function(x){
	//console.log("symbol picker pressed");
	x.preventDefault();
	if(asciiTable.style.display == "none"){
		//console.log('worked');
		asciiTable.style.display = "block";
	}else{
		asciiTable.style.display = "none";
	}
});

mode.addEventListener('click', function(x){
	document.getElementById(currentMode).style.backgroundColor = "white";
	if(x.target.nodeName === 'TD'){
		currentMode = x.target.id;
		x.target.style.backgroundColor = "lightgray";
	}
});

asciiTable.addEventListener('click', function(x){
	//console.log("clicked asciiTable");
	if(x.target.nodeName === 'TD'){
		//console.log("isValid");
		
			picker.value = x.target.innerHTML;
			asciiTable.style.display = "none";
	}
});


function generateASCIItable(x){
	for(var i = 4; i >= 0; i--){
	const row = asciiTable.insertRow(0);
	for(var j = 18; j >= 0; j--){
		const cell = row.insertCell(0);
		const index = i * 19 + j;

			cell.innerHTML = String.fromCharCode(index+32);
			//console.log(String.fromCharCode(index+31));

	}
}}