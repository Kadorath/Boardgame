using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    public int file;
    public int rank;
    public int status; //0 is normal status, -2 is an outer wall
    public GameObject[] adj;

    public int GetStatus() { return status; }
    public void SetStatus(int n) { status = n; }
    
    public void Initialize(int f, int r, int s) {
        file = f;
        rank = r;
        status = s;
        adj = new GameObject[6];
        transform.position = new Vector3(f, -(r+(f*.45f)), 0); //Obviously only a test statement
    }

    public void SetAdj(Board board)
    {
        int width = board.GetFiles();
        //Going clockwise
        adj[0] = board.GetCells()[(rank-1)*width + file];
        adj[1] = board.GetCells()[(rank-1)*width + (file+1)];
        adj[2] = board.GetCells()[(rank)*width + (file+1)];
        adj[3] = board.GetCells()[(rank+1)*width + file];
        adj[4] = board.GetCells()[(rank + 1) * width + (file - 1)];
        adj[5] = board.GetCells()[(rank) * width + (file - 1)];
    }
}
