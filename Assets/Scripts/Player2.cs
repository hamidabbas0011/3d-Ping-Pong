using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveDown;
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    private float offset = 0.2f;
    public bool isHuman = true;
    private Transform ball;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHuman)
        {
            PlayerMove();
        }
        else
        {
            ComputerMove();
        }
    }

    private void PlayerMove()
    {
        bool pressedUp = Input.GetKey(this.moveUp);
        bool pressedDown = Input.GetKey(this.moveDown);

        
        if (pressedUp)
        {
            _rigidbody.velocity = Vector3.forward * speed;
        }
        if (pressedDown)
        {
            _rigidbody.velocity = Vector3.back * speed;
        }
        if(!pressedDown && !pressedUp)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void ComputerMove()
    {
        if (ball.position.z > transform.position.z +offset)
        {
            _rigidbody.velocity = Vector3.forward * speed;
        }
        else if (ball.position.z < transform.position.z -offset)
        {
            _rigidbody.velocity = Vector3.back * speed ;
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
