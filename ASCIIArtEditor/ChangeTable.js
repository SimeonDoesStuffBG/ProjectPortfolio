const AddRow = document.getElementById("AddRow");
const AddCol = document.getElementById("AddCol");
const RemRow = document.getElementById("RemoveRow");
const RemCol = document.getElementById("RemoveCol");

const GridToggle = document.getElementById("ToggleGrid");
const Hidden = "Hide Grid";
const Shown = "Show Grid";

GridToggle.addEventListener('click', function(x){
	const cells = drawingSpace.getElementsByTagName("td");
	if(GridToggle.value === Hidden){
			for(var i =0; i < cells.length; i++){
				cells[i].style.borderStyle = "none";	
			}
		GridToggle.value = Shown;
	}else if(GridToggle.value === Shown){
		for(var i =0; i<cells.length; i++){
		cells[i].style.borderStyle = "solid";
	}
		GridToggle.value = Hidden;
	}
});

AddRow.addEventListener('click', function(x){
	const newRow = drawingSpace.insertRow(height.value);
	var subArr = new Array();
	for(var i = 0; i < width.value; i++){
		const cell = newRow.insertCell(0);
		cell.innerHTML = " ";
		cell.setAttribute("class", "DrawingPixel");
		cell.setAttribute("x", height.value);
		cell.setAttribute("y", i);
		if(GridToggle.value === Shown)cell.style.borderStyle = "none";
		subArr.push(cell);
	}
	height.value = Number(height.value) + 1;
	drawingSpaces.push(subArr);
});

AddCol.addEventListener('click', function(x){
	const rows = drawingSpace.getElementsByTagName("tr");
	for(var i = 0; i < height.value; i++){
		const cell = rows[i].insertCell(width.value);
		cell.innerHTML = " ";
		cell.setAttribute("class", "DrawingPixel");
		cell.setAttribute("x", i);
		cell.setAttribute("y", width.value);
		if(GridToggle.value === Shown)cell.style.borderStyle = "none";
		drawingSpaces[i].push(cell);
	}
	width.value = Number(width.value) + 1;
});

RemRow.addEventListener('click', function(x){
	if(drawingSpaces.length > 1){
	var subArr = drawingSpace.getElementsByTagName("tr")[height.value-1];
    
	subArr.getElementsByTagName("td").remove;
	subArr.remove();
    
	height.value = Number(height.value) - 1;
	buildArray();
	}
});

RemCol.addEventListener('click', function(x){
	if(drawingSpaces[0].length>1){
		const rows = drawingSpace.getElementsByTagName("tr");
	for(var i = 0; i < height.value; i++){
		const thisCell = rows[i].getElementsByTagName("td")[width.value-1];
       
        thisCell.remove();
	}
	width.value = Number(width.value) - 1;
	buildArray();
}
});

