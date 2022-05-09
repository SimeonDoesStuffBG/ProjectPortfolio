package Sudoku;

import java.util.Random;

public enum Dificulty {
    EASY(35, 41), MEDIUM(25, 35), HARD(23, 25);

    private final int lowerLimit;

    private final int higherLimit;

    private Dificulty(int lowerLimit, int higherLimit){
        this.lowerLimit = lowerLimit;
        this.higherLimit = higherLimit;
    }

    int getAmmount(){
        Random r = new Random();
        return lowerLimit + r.nextInt(higherLimit-lowerLimit);
    }
}
