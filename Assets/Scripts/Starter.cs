using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    private GameManager _gameManager;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void StartCountdown()
    {
        _animator.SetTrigger("StartCountdown");
    }

    void StartGame()
    {
        _gameManager.StartGame();
    }
}
