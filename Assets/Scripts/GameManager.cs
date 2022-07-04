using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject board;

    private GameObject activeBoard;

    void Start()
    {
        activeBoard = Instantiate(board);
        activeBoard.GetComponent<Board>().Initialize(12,12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
