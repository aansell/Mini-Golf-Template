using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPoint : MonoBehaviour
{
    public int points;
    public Text countText;
    public Text winText;
    public int numberOfBalls = 12;
    public int ballsRemaining;
    public float ballSpawn;
    public ClubHeadFollower club;


    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        club = FindObjectOfType<ClubHeadFollower>();
        LoadNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadBalls(int _numberOfBalls)
    {
        for (int i = 0; i < _numberOfBalls; i++)
        {
            Instantiate(ball, gameObject.transform.position + new Vector3(0, 0, ballSpawn), Quaternion.identity);
            ballSpawn += .2f;

        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + points.ToString();
        if (points >= numberOfBalls * 3)
        {

            winText.text = "You Win!";
        }
    }

    public void AddPoints(int value)
    {
        points += value;
        SetCountText();
    }

    public void LoadNewGame()
    {
        club.strokeCount = 0;
        
        points = 0;
        ballSpawn = -1.9f;
        SetCountText();
        winText.text = "";
        SetCountText();
        LoadBalls(numberOfBalls);
    }
}
