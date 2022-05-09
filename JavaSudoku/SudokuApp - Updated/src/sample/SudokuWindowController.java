package sample;

import Sudoku.Dificulty;
import Sudoku.SudokuBoard;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.Button;
import javafx.scene.input.MouseEvent;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;

public class SudokuWindowController{


    int playerSelectedRow;
    int playerSelectedColum;
    int unsolvedSquares;

    SudokuBoard board;
    Dificulty diff = Dificulty.EASY;

    @FXML
    private Button btnButton1;

    @FXML
    private Button btnButton2;

    @FXML
    private Button btnButton3;

    @FXML
    private Button btnButton4;

    @FXML
    private Button btnButton5;

    @FXML
    private Button btnButton6;

    @FXML
    private Button btnButton7;

    @FXML
    private Button btnButton8;

    @FXML
    private Button btnButton9;

    @FXML
    private Canvas cnvsBoard;

    @FXML
    private Button btnNewGame;

    @FXML
    private Button btnSolve;

    @FXML
    private Button btnEasy;

    @FXML
    private Button btnMedium;

    @FXML
    private Button btnHard;

    @FXML
    void btnNewGamePressed(ActionEvent event) {
        this.initialize();
    }

    @FXML
    void btnSolvePressed(ActionEvent event) {
        board.solve();
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
    }

    @FXML
    void btnEasyPressed(ActionEvent event) {
        diff = Dificulty.EASY;
    }

    @FXML
    void btnMediumPressed(ActionEvent event) {
        diff = Dificulty.MEDIUM;
    }

    @FXML
    void btnHardPressed(ActionEvent event) {
        diff = Dificulty.HARD;
    }



    @FXML
    void btnButtonOnePressed(ActionEvent event) {
        board.getPlayerInput(1, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnButtonTwoPressed(ActionEvent event) {
        board.getPlayerInput(2, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnButtonThreePressed(ActionEvent event) {
        board.getPlayerInput(3, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnButtonFourPressed(ActionEvent event) {
        board.getPlayerInput(4, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnButtonFivePressed(ActionEvent event) {
        board.getPlayerInput(5, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnButtonSixPressed(ActionEvent event) {
        board.getPlayerInput(6, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
        unsolvedSquares--;
    }

    @FXML
    void btnButtonSevenPressed(ActionEvent event) {
        board.getPlayerInput(7, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnButtonEightPressed(ActionEvent event) {
        board.getPlayerInput(8, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnButtonNinePressed(ActionEvent event) {
        board.getPlayerInput(9, playerSelectedRow * 9 + playerSelectedColum);
        DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
        if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
            unsolvedSquares--;
    }

    @FXML
    void btnClearPressed(ActionEvent event) {

    }

    void UpdateValue(int value){
        if(value != 0){
            DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
            if(isCorrect(playerSelectedRow * 9 + playerSelectedColum))
                unsolvedSquares--;
        }
        else if(board.getBoard()[playerSelectedRow * 9 + playerSelectedColum].isSolved()){
            unsolvedSquares++;
        }
    }
    boolean isCorrect(int index) {

        return board.getBoard()[index].isSolved();
    }

    public void initialize(){
        board = new SudokuBoard(diff);
        unsolvedSquares = board.getUnsolved();
        GraphicsContext context = cnvsBoard.getGraphicsContext2D();

        DrawOnCanvas(context);
    }

    public void DrawOnCanvas(GraphicsContext context){
        context.clearRect(0,0,450,450);

        for(int i = 0; i < 81; i++){
            int row = i/9;
            int col = i%9;

            int positionX = col * 50 + 2;
            int positionY = row * 50 + 2;

            int TileWidth = 46;

            if(board.getBoard()[i].isChangeable())
                context.setFill(Color.LIGHTGRAY);
            else
                context.setFill(Color.GRAY);

            context.fillRect(positionX, positionY, TileWidth, TileWidth);

            positionX = col * 50 + 20;
            positionY = row * 50 + 30;
            //context.setFill(!board.getBoard()[i].isChangeable()? Color.BLACK : Color.DARKBLUE);
            if(!board.getBoard()[i].isChangeable()){
                context.setFill(Color.BLACK);
            }else {
                if(board.getBoard()[i].isSolved()){
                    context.setFill(Color.DARKBLUE);
                }
                else{
                    context.setFill(Color.RED);
                }
                    context.setFont(new Font(20));
            }

            context.fillText(board.getBoard()[i].toString(),positionX,positionY);


            context.setStroke(Color.RED);

            context.setLineWidth(3);

            context.strokeRect(playerSelectedColum * 50 + 2, playerSelectedRow * 50 + 2, TileWidth, TileWidth);
        }
        for(int i = 0; i < 3; i++){
            for(int j =0; j < 3; j++){
                int posX = i * 150;
                int posY = j * 150;
                int MinigridSize = 150;

                context.setStroke(Color.BLACK);
                context.setLineWidth(2);
                context.strokeRect(posX , posY, MinigridSize, MinigridSize);
            }
        }
        if(unsolvedSquares == 0){
            context.clearRect(0, 0, 450, 450);
            context.setFill(Color.GREEN);
            context.setFont(new Font(36));
            context.fillText("PUZZLE SOLVED!", 150, 250);
        }
    }

    @FXML
    public void canvasMouseClicked(MouseEvent event)  {

        cnvsBoard.setOnMouseClicked(new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent event) {

                int mouse_x = (int) event.getX();
                int mouse_y = (int) event.getY();

                playerSelectedRow = (int) (mouse_y / 50); // update player selected row
                playerSelectedColum = (int) (mouse_x / 50); // update player selected column


                DrawOnCanvas(cnvsBoard.getGraphicsContext2D());
            }
        });
    }
}

