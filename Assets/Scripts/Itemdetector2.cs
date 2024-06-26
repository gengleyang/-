using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDetector2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string _colliderScript;
    [SerializeField]
    private UnityEvent _collisionEntered;
    [SerializeField]
    private UnityEvent _collisionExit;
    [SerializeField]
    private UnityEvent OnCollisionStayEvent;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript) != null)
        {
            OnCollisionStayEvent.Invoke();
            Debug.Log("OnTriggerStay2D invoked");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript) != null)
        {
            _collisionEntered.Invoke();
            Debug.Log("OnTriggerEnter2D invoked");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript) != null)
        {
            _collisionExit.Invoke();
            Debug.Log("OnTriggerExit2D invoked");
        }
    }
}
