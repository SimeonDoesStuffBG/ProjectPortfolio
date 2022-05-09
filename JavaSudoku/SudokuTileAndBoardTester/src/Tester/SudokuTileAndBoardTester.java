//verifies that the SudokuTile and SudokuBoard classes work
package Tester;
import Sudoku.Dificulty;
import Sudoku.Tile.SudokuTile;
import Sudoku.SudokuBoard;

public class SudokuTileAndBoardTester {
    public static void main(String[] args){
    SudokuTile s = new SudokuTile(3,true);
    SudokuBoard board = new SudokuBoard(Dificulty.HARD);
    System.out.printf("%s%n", s.toString());
    s.solve();
    System.out.printf("%s%n", s.toString());

    System.out.printf("%s%n%n",board.toString());
    board.solve();
    System.out.printf("%s",board.toString());
    }
}
