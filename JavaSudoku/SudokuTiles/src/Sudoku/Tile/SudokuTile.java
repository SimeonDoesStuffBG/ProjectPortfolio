/*
* Represents a square in the grid. Makes the process of verifying the correctness of a solution
* Simeon Milev
* 13.02.2019
* */
package Sudoku.Tile;

public class SudokuTile {
    private int displayedValue;//the value displayed on screen
    private final int DESIRED_VALUE;//the value the cell takes when solved
    private final boolean CAN_BE_CHANGED;//determines weather the cell is filled at the start of the game. Prevents the displayed value from being changed

    //no argument constructor
    public SudokuTile(){
        this(1, true);
    }//end no argument constructor

    //value only constructor
    public  SudokuTile(int value){
        this(value,true);
    }//end of value only constructor

    //copy constructor
    public SudokuTile(SudokuTile tile){
        this(tile.getDesiredValue(),tile.isChangeable());
        setDisplayedValue(tile.getDisplayedValue());
    }//end of copy constructor
    //main constructor
    public SudokuTile(int value, boolean changeable){
        this.DESIRED_VALUE = value;
        this.CAN_BE_CHANGED = changeable;
        //0 is the default value for the displayed value
        setDisplayedValue(0);
    }//end of main constructor

    //displayed value setter
    public void setDisplayedValue(int displayedValue) {
        this.displayedValue = this.CAN_BE_CHANGED ? displayedValue : DESIRED_VALUE;
    }//end of displayed value setter

    //displayed value getter
    public int getDisplayedValue() {
        return displayedValue;
    }//end of displayed value getter

    //desired value getter(used in copy-constructor)
    public int getDesiredValue() {
        return DESIRED_VALUE;
    }//end of desired value getter

    //checks for changeability
    public boolean isChangeable() {
        return CAN_BE_CHANGED;
    }//end of changeability checker

    //verifies that the tile is sorted
    public boolean isSolved(){
        return this.displayedValue == this.DESIRED_VALUE;
    }//end of sorted verifier

    //solves the tile
    public void solve(){
        setDisplayedValue(DESIRED_VALUE);
    }//end of solve function

    //toString function
    @Override
    public String toString() {
        String strTile = (displayedValue == 0)?" ":String.format("%d",displayedValue);
        return strTile;
    }//end of toString
}//End of SudokuTile class
