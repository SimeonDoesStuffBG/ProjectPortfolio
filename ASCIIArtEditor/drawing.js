var currentSymbol = document.getElementById("symbolPicker");

var height = document.getElementById("Height");
var width = document.getElementById("Width");
const submitButton = document.getElementById("submitBtn");
const drawingSpace = document.getElementById("DrawingSpace");


submitButton.addEventListener('click', function(x){
	//console.log("submit button pressed");
	document.getElementsByTagName("main")[0].style.display = "block";
	drawingSpace.innerHTML=" ";
	
	x.preventDefault();
	AddRow.style.display = "block";
	AddCol.style.display = "block";
	RemRow.style.display = "block";
	RemCol.style.display = "block";
	GridToggle.style.display ="block";
	generateBoard();
	buildArray();
});

drawingSpace.addEventListener('mousedown', function(x){
	curSym = currentSymbol.value;
	if(x.target.nodeName === 'TD'){
		loc = x.target;
			if(currentMode === draw.id){
				drawSymbol(loc, curSym);
			}else if(currentMode === erase.id){
				eraseSymbol(loc);
			}else if(currentMode === fill.id){
				fillSymbol(loc, curSym);
			}else if(currentMode === replace.id){
				replaceSymbol(loc.innerHTML, curSym);
			}
			buildArray();
	}
});

function generateBoard(x){
	for(var i = 0; i < height.value; i++){
		const row = drawingSpace.insertRow(0);
		for(var j = 0; j < width.value; j++){
			cell = row.insertCell(0);
			cell.innerHTML = " ";
			cell.setAttribute("class", "DrawingPixel");
			cell.setAttribute("x", height.value - i - 1 );
			cell.setAttribute("y", width.value - j - 1);
		}
	}
}

function drawSymbol(node,sym){
	
	node.innerHTML = sym;
}

function eraseSymbol(node){
	node.innerHTML = " "
}

function fillSymbol(node, sym){
	x = Number(node.getAttribute("x"));
	y = Number(node.getAttribute("y"));
	fillSymbolAt(x,y,node.innerHTML,sym);
}

function fillSymbolAt(x, y, initialSym, newSym){		
	if(x >=0 && y >= 0 && x < height.value && y < width.value && newSym != initialSym){
		if(drawingSpaces[x][y].innerHTML == initialSym){
			drawingSpaces[x][y].innerHTML = newSym;
			fillSymbolAt(x+1, y, initialSym, newSym);
			fillSymbolAt(x, y+1, initialSym, newSym);
			fillSymbolAt(x-1, y, initialSym, newSym);
			fillSymbolAt(x, y-1, initialSym, newSym);
		}	
	}
}



function replaceSymbol(initialSym, replacement){
	
	var arr = document.getElementsByClassName("DrawingPixel");
	for(var i = 0; i < height.value; i++){
		for(var j =0; j < width.value; j++){
			if(arr[i * width.value + j].innerHTML == initialSym){
				arr[i * width.value + j].innerHTML = replacement;
			}
		}
	}
}