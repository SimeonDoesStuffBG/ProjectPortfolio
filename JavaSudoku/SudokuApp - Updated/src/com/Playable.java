package com;

import Sudoku.Dificulty;

import java.rmi.Remote;
import java.rmi.RemoteException;
public interface Playable extends Remote {
    void NewGame() throws RemoteException;

}
