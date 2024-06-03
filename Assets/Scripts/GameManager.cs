using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    private BallController _ballController;
    public Starter _starter;
    private Vector3 startingPosition;
    private int scoreLeft = 0;
    private int scoreRight = 0;
    private bool started = false;
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public Text playText;

    private Player2 _player2;
    // Start is called before the first frame update
    void Start()
    {
        //playText.IsActive(true);
        _ballController = ball.GetComponent<BallController>();
        startingPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (started)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            started = true;
            this._starter.StartCountdown();
            //playText.enabled(false);
        }
    }
    

    public void StartGame()
    {
        this._ballController.Go();
    }

    public void ScoreLeft()
    {
        ResetBall();
        this.scoreLeft += 1;
        scoreTextLeft.text = scoreLeft.ToString();
    }
    public void ScoreRight()
    {
        ResetBall();
        this.scoreRight += 1;
        scoreTextRight.text = scoreRight.ToString();
    }

    private void ResetBall()
    {
        _ballController.Stop();
        ball.transform.position = this.startingPosition;
        _starter.StartCountdown();

    }

    
}
