using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDetector : MonoBehaviour
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

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.GetComponent(_colliderScript))
        {
            OnCollisionStayEvent.Invoke();
            Debug.Log("invoke");
        }
    }


    private void OnCollisionEnter2D(Collision2D col){
    if(col.gameObject.GetComponent(_colliderScript)){
        _collisionEntered?.Invoke();
        Debug.Log("invoke1");

    }

    /* if(col.gameObject.GetComponent(_colliderScript).hasKey1){
        gameObject.SetActive(false);
    } */
   } 
    private void OnCollisionExit2D(Collision2D col){
    if(col.gameObject.GetComponent(_colliderScript)){
        _collisionExit?.Invoke();
        Debug.Log("invoke2");

    }
   } 
    private void On(Collision2D col)
    {
        while (col != null)
        {
            OnCollisionStayEvent.Invoke();
            Debug.Log("invoke");
        }
    }


}
