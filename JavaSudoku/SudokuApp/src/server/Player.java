package server;

import com.Playable;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Player extends UnicastRemoteObject implements Playable {

    public Player() throws  RemoteException{

    }

    @Override
    public void NewGame() throws RemoteException{

    }
}
