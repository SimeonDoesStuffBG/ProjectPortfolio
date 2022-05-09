package Sudoku;

import Sudoku.Tile.SudokuTile;
import java.util.*;


public class SudokuBoard {
    private SudokuTile[] board;
    private int Unsolved;
    public SudokuBoard(Dificulty dificulty){
    boardGenerator(dificulty.getAmmount());
    }

    public SudokuBoard(SudokuBoard board){
        boardGenerator(board.getBoard());
    }
    //randomly generates a new Sudoku Board
    public void boardGenerator(int revealedAtStart) {
        int[] helper = validBoard();
        boolean[] revealedSquares = displayedGrid(revealedAtStart);
        this.Unsolved = 81 - revealedAtStart;
        board = new SudokuTile[81];
        for(int i = 0; i < 81; i++){
            board[i] = new SudokuTile(helper[i], revealedSquares[i]);
        }
    }


    public void boardGenerator(SudokuTile[] board){
        if(board != null && board.length == 81){
            this.board = new SudokuTile[81];
            for(int i = 0; i < 81; i++){
                this.board[i] = new SudokuTile(board[i]);
            }
        }
    }

    //returns an array of 81 values between 1 and 9 ordered in a way that each value is encountered once every minigrid
    private int[] initialBoard(){
        int[] initBoard = new int[81];
        ArrayList<Integer> possibleValues = new ArrayList<Integer>(9);
        for(int i = 1; i<=9; i++){
            possibleValues.add(i);
        }

        for(int i = 0; i <81; i++){
            if(i % 9==0)
                Collections.shuffle(possibleValues);//every 9th element we shuffle the array so that we get a new random arrangement of values
            //now we get the index i corresponds to when going through the array by minigrids as opposed to by rows(regular order)
            int minigridIndex =  ((i / 3) % 3) * 9 + ((i % 27) / 9) * 3 + (i / 27) * 27 + (i %3);
            initBoard[minigridIndex] = possibleValues.get(i % 9);
        }
        return initBoard;//we returned an array that when displayed as a Sudoku grid we can see has each value of 1-9 once per minigrid
        //however in rows and columns it's possible to have repeating values. now we must sort the array into a valid grid
    }//end of initial board generator

    //returns an array that can be represented as a valid Sudoku grid
    private int[] validBoard(){
        int[] intBoard = initialBoard();
        boolean[] valid = new boolean[81];//keeps track of the validated values

        for(int i = 0; i < 9; i++){
            boolean backtrack = false;//checks if we need to resort to the Advance and Backtrack Method
            int rowOrigin = i * 9; //the start of the i-th row
            int colOrigin = i; //the start of the i-th column

            for(int a = 0; a < 2; a++){
                //based on weather a is even or odd we go through the row and column respectively
                boolean rowOrCol = (a % 2 == 0);

                boolean registered[] = new boolean[10];//a registered value may not be repeated in this row/column

                ROW_COL:for(int j = 0; j < 9; j++){
                    int cur = (rowOrCol) ? rowOrigin + j : colOrigin + 9 * j;
                    int val = intBoard[cur];

                    if(!registered[val])
                        registered[val] = true;//we register the current value if it's unregistered(isn't a duplicate)
                    else{
                        //we start the Minigrid and Adjacent-tile swap (MAS)
                        //we're looking for a value that's (unregistered && (unsorted || sorted)) and is in the same box as the current one
                        //this value is called a candidate
                        for(int k = j; k >= 0; k--){//in the event that there are no suitable candidates in the current value's box we go back
                            //to the last time this value was encountered in the row/column and try the MAS algorithm on it
                            int examinedIndex = (rowOrCol) ? rowOrigin + j : colOrigin + 9 * j;//the k-th element of the i-th row/column
                            if(intBoard[examinedIndex]==val){//we look for candidates in the examined value's box
                                //minigrid Stepping
                                for(int l = ((rowOrCol) ? (i % 3 + 1) * 3 : 0); l < 9; l++){//l indicates which element in a minigrid we're currently
                                    //examining. The reason it's set the way it is when we're examining rows is so that we can avoid swapping with rows that are already sorted
                                    //or swapping within the row we're currently sorting
                                    if(!rowOrCol && l % 3 <= i % 3)//this if serves the same purpose for columns that the declaration of l does for rows
                                        continue;
                                    int minigridOrigin = ((examinedIndex % 9) / 3) * 3 + (examinedIndex / 27) * 27;//The top left tile in a minigrid
                                    int minigridCur = minigridOrigin + (l / 3) * 9 + (l % 3);//The l-th element in a minigrid
                                    int minigridVal = intBoard[minigridCur];
                                    boolean sameRolCol = (rowOrCol) ? (minigridCur % 9 == examinedIndex % 9) : (minigridCur / 9 == examinedIndex / 9);
                                    boolean unregAndUnsort = (!valid[examinedIndex] && !valid[minigridCur] && !registered[minigridVal]);
                                    boolean unregAndSort = valid[examinedIndex] && !registered[minigridVal] && sameRolCol;
                                    if(unregAndUnsort || unregAndSort){//if the l-th element in the minigrid is an acceptable candidate
                                        //we swap it with the one we're curently examining, register its value and continue the main loop
                                        intBoard[examinedIndex] = minigridVal;
                                        intBoard[minigridCur] = val;
                                        registered[minigridVal] = true;
                                        continue ROW_COL;
                                    }
                                    else if(l == 8){//if we reach this condition than the MAS has failed and we need to try a new approach
                                        //preferred adjacent swap(PAS)
                                        //when sorting a row/column we swap the examined value with it's neighbour from the same column/row
                                        //this procedure is known as a blind Swap
                                        //if that value is registered we find the other instance of it and swap until we find an unregistered value
                                        int searchedVal = val;

                                        //we keep track of all blind swaps. Prevents endless loops
                                        boolean blindSwaps[] = new boolean[81];

                                        //During a PAS procedure we can do at most 18 unique swaps before we get cought in an
                                        //endless loop. We use a for loop to prevent that
                                        for(int q = 0; q < 18; q++){
                                            SWAP: for(int b = 0; b <= j; b++) {//going through the every value before the j-th element of the row/column
                                                int PAScur = (rowOrCol)? rowOrigin + b : colOrigin + 9 * b;
                                                if(intBoard[PAScur] == searchedVal){
                                                    int adjVal = -1;
                                                    int adjIndex = -1;
                                                    int decrement = (rowOrCol)? 9 : 1;

                                                    for(int c = 0; c < 3 - i % 3; c++){
                                                        adjIndex = PAScur + (c + 1) * decrement;//the neighbour to the curently examined cell

                                                        if( (rowOrCol && adjIndex >= 81) || (!rowOrCol && adjIndex % 9 == 0))
                                                            adjIndex -= decrement;
                                                        else{
                                                            adjVal = intBoard[adjIndex];
                                                            if(i % 3 != 0
                                                            || c!=1
                                                            || blindSwaps[adjIndex]
                                                            || registered[adjVal])
                                                                adjIndex -= decrement;
                                                        }
                                                        adjVal = intBoard[adjIndex];

                                                        //we swap only if we've never swapped before
                                                        if(!blindSwaps[adjIndex]){
                                                            blindSwaps[adjIndex] = true;
                                                            intBoard[PAScur] = adjVal;
                                                            intBoard[adjIndex] = searchedVal;
                                                            searchedVal = adjVal;

                                                            if(!registered[adjVal]){//if the adjacent value isn't registered we register it and continue the main sorting loop
                                                                registered[adjVal] = true;
                                                                continue ROW_COL;
                                                            }
                                                            break SWAP;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //We've reached an endless loop so we start the Advance and backtrack method
                                        //we sort the next row and column and then come back to these ones
                                        backtrack = true;
                                        break ROW_COL;
                                    }
                                }
                            }
                        }
                    }
                }
                if(rowOrCol)
                    for(int j = 0; j < 9; j++){
                        valid[rowOrigin + j] = true;//set the current row as valid
                    }
                else if(!backtrack)
                    for(int j = 0; j < 9; j++){
                        valid[colOrigin + 9 * j] = true;//set the current column as valid
                    }
                else{//we reset all cells in the precious row and column(backrack)
                    backtrack = false;
                    for(int j = 0; j < 9; j++){
                        valid[rowOrigin + j] = false;
                    }

                    for(int j = 0; j < 9; j++){
                        valid[(i-1) * 9 + j] = false;
                    }

                    for(int j = 0; j < 9; j++){
                        valid[i - 1 + 9 * j] = false;
                    }
                    i -= 2;//backtrack
                }
            }
        }
        return intBoard;
    }

    private boolean[] displayedGrid(int displayed){
        boolean display[] = new boolean[81];
        ArrayList<Boolean> helper = new ArrayList<Boolean>(81);
        for(int i = 0; i < 81; i++){
            if(i < displayed)
                helper.add(false);
            else
                helper.add(true);
        }
        Collections.shuffle(helper);
        for(int i = 0; i < 81; i++)
            display[i] = helper.get(i);
        helper.clear();
        return display;
    }

    public SudokuTile[] getBoard() {
        SudokuTile[] boardGetter = new SudokuTile[81];
        for(int i =0; i < 81; i++){
            boardGetter[i] = new SudokuTile(this.board[i]);
        }
        return boardGetter;
    }

    public int getUnsolved(){
        return Unsolved;
    }

    //toString method used for testing the if the board building method works
    @Override
    public String toString() {
        String strBoard = "";
        for(int i = 0; i < 81; i++){
            if(i % 9==0)
                strBoard+="\n";
            strBoard += String.format(" %s ", board[i].toString());
        }
        return strBoard;
    }

    public void getPlayerInput(int value, int index){
        if(index>=0 && index < 81){
            board[index].setDisplayedValue(value);
        }
    }
    //solves the current board
    public void solve(){
        for(int i = 0; i < 81; i++){
            this.board[i].solve();
        }
    }
}
