<?php
    include_once 'Header.php';
?>

<aside>
		<form id="sizePicker">
			<label>Grid Height:	<input type="number" id="Height" name="height" min="1" value="16" title="Set the height of the grid"></label>
			<label>Grid Width: <input type="number" id="Width" name="width" min="1" value="16"></label>
							
			<input type="submit" value="Generate Grid" id="submitBtn">
		</form>
		
		<label>
			Pick A Symbol
			<input type="button" id="symbolPicker" value=" ">
		</label>
		<table id = "Mode">
			<tr>
				<td id = "Drawing Mode">Draw</td>
				<td id = "Erase Mode">Erase</td>
			</tr>
			<tr>
				<td id = "Fill Mode">Fill</td>
				<td id = "Replace Mode">Replace</td>
			</tr>
		</table>
		<table id="ASCIIthing"></table>
		<table style="border: 0px; background-color:blue;">
			<tr>
				<td style="border: 0px;"><input type = "button" id = "AddRow" value = "Add Row"></td>
				<td style="border: 0px;"><input type = "button" id = "RemoveRow" value = "Remove Row"></td>
			<tr>
			<tr>
				<td style="border: 0px;"><input type = "button" id = "AddCol" value = "Add Column"></td>
				<td style="border: 0px;"><input type = "button" id = "RemoveCol" value = "Remove Column"></td>
			<tr>
		</table>
		<input type="button" id = "ToggleGrid" value = "Hide Grid">
 		
		<script type="text/javascript" src = "symbolPicker.js"></script>
		<script type="text/javascript" src = "ChangeTable.js"></script>
	</aside>
	
	<main>  
		<input id="Image Title" placeholder="Write Title" value = "my-image">
		<table id="DrawingSpace"></table>
		<canvas id="result"></canvas>
		<input type="button" id = "import" value="Save Image">
		<input type="button" id = "export" value="Download Image">
		<script type="text/javascript" src="io.js"></script>
		    <script type="text/javascript" src="drawing.js"></script>
	</main>


</body>
</html>