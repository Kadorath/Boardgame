using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private int file;
    private int rank;
    private int health;
    private int power;
    private int speed;
    private Board board;
    public int[] keywords = new int[5];

    private int playerId;

    void Start()
    {
        Summon(0, 0, 1, 1, 1, null, new int[5], -1);
    }

    public int GetFile() { return file; }
    public void SetFile(int n) { file = n; }
    public int GetRank() { return rank; }
    public void SetRank(int n) { rank = n; }
    public int GetHealth() { return health; }
    public void SetHealth(int n) { health = n; }
    public int GetPower() { return power; }
    public void SetPower(int n) { power = n; }
    public int GetSpeed() { return speed; }
    public void SetSpeed(int n) { speed = n; }

    public void Attack(Follower defender){
        defender.SetHealth(defender.GetHealth() - power);
        health -= defender.GetPower();
        if(defender.GetHealth() <= 0) { defender.Die(); }
        if (health <= 0) { Die(); }
    }

    public void SelectMove(int f, int r)
    {
        if((Mathf.Abs(f - file) <= speed) && (Mathf.Abs(r - rank) <= speed)){
            if (board.GetCells()[r * board.GetFiles() + f].GetComponent<BoardCell>().GetStatus() >= 0)
            {
                MoveTo(f, r);
            }
        }
    }

    private void MoveTo(int f, int r)
    {
        file = f;
        rank = r;
    }

    public void Summon(int f, int r, int h, int p, int s, Board b, int[] k, int player)
    {
        file = f;
        rank = r;
        health = h;
        power = p;
        speed = s;
        board = b;
        keywords = k;
        playerId = player;
        //Notify board of summon
    }

    public void Die()
    {
        print("i ded");
        //TODO: notify game board of death
        Destroy(gameObject);
    }

}
