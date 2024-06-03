using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class BallController : MonoBehaviour
{

    //public float minDirection = 0.5f;
    public float ballSpeed;
    public GameObject sparksVFX;
    
    public float minDirection = 0.5f;
    public Vector3 direction;
    private Rigidbody _rb;
    private bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        //todo
    }

    void FixedUpdate()
    {
        if (stopped)
        {
            return;
        }
        _rb.MovePosition(this._rb.position +( ballSpeed * Time.fixedDeltaTime * direction));
    }

    
    // CODE SNIPPET FOR RACKET DIRECTION CHANGE
    
    

    public void Stop() {
        stopped = true;
    }

    public void Go()
    {
        stopped = false;
        BallDirection();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;
        if (other.CompareTag("Wall"))
        {
            hit = true;
            direction.z = -direction.z;
        }

        if (other.CompareTag("Racket"))
        {
            hit = true;
            Vector3 dirNew = (transform.position - other.transform.position).normalized;
            dirNew.x =Mathf.Sign(dirNew.x) * Mathf.Max(Mathf.Abs(dirNew.x), this.minDirection);
            dirNew.z =Mathf.Sign(dirNew.z) * Mathf.Max(Mathf.Abs(dirNew.z), this.minDirection);

            direction = dirNew;
        }

        if (hit)
        {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks,4f);
        }
    }

    private void BallDirection()
    {
        float SignX = Mathf.Sign(Random.Range(-1, 1));
        float SignZ = Mathf.Sign(Random.Range(-1, 1));
        this.direction = new Vector3(0.5f * SignX, 0, 0.5f * SignZ);
        
    }
    
}
