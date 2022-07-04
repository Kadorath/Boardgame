using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject cell;
    public GameObject[] cells;
    private Follower[] followers;
    private int files;
    private int ranks;

    public int GetFiles() { return files; }
    public int GetRanks() { return ranks; }
    public GameObject[] GetCells() { return cells; }

    public void Initialize(int f, int r)
    {
        files = f;
        ranks = r;
        cells = new GameObject[files * ranks];
        for(int i = 0; i < ranks; i++)
        {
            for(int j = 0; j < files; j++)
            {
                cells[i * ranks + j] = Instantiate(cell);
                if (i == 0 || i == ranks - 1 || j == 0 || j == files - 1)
                {
                    cells[i * ranks + j].GetComponent<BoardCell>().Initialize(j, i, -2);
                }
                else
                {
                    cells[i * ranks + j].GetComponent<BoardCell>().Initialize(j, i, 0);
                }
            }
        }

        //Set adjacencies for non-border spaces
        for (int i = 0; i < files * ranks; i++)
        {
            if(cells[i].GetComponent<BoardCell>().GetStatus() != -2)
            {
                cells[i].GetComponent<BoardCell>().SetAdj(this); //Will this send this specific board, or just the general blueprint for a board?
            }
        }
    }

}
