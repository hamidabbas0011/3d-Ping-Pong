using UnityEngine;
using UnityEngine.Events;

public class ScoreControl : MonoBehaviour
{
    public UnityEvent scoreInvoke;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            scoreInvoke.Invoke();
        }
    }
}
