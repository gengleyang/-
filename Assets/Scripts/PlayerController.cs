using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour


{
    private Rigidbody2D rb;
    public PlayerInputControl inputControl;
    public Vector2 inputDirection;
    public float speed;

    public bool isInteracting;

    public bool hasKey1;

    private Collider2D collidedObject;
    

   
    private void Awake() {

      inputControl= new PlayerInputControl(); 
      rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        inputControl.Enable();
        inputControl.Gameplay.Interact.performed += OnInteract;

    }

    // Update is called once per frame
    private void OnDisable() {
        inputControl.Disable();
        inputControl.Gameplay.Interact.performed -= OnInteract;
        
    }
    private void Update(){
        inputDirection=inputControl.Gameplay.Move.ReadValue<Vector2>();
        //?
        isInteracting = inputControl.Gameplay.Interact.ReadValue<float>() > 0;

    }
    private void FixedUpdate() {
        Move();
    }
    public void Move(){
        rb.velocity=new Vector2(inputDirection.x*speed*Time.deltaTime,rb.velocity.y);

        int faceDir =(int)transform.localScale.x;
        if(inputDirection.x>0){
            faceDir=1;
        }
        if(inputDirection.x<0){
            faceDir=-1;
        }
        transform.localScale=new Vector3(faceDir,1,1);
        
    }
    private void OnInteract(InputAction.CallbackContext context)
    {
        // 这里可以处理Interact动作触发时的逻辑
        isInteracting = context.ReadValue<float>() > 0;
        if (isInteracting)
        {
            Debug.Log("Interacting");
            
            // 在这里添加交互逻辑
        }
    }
    public void GetKey1()
    {
        if(isInteracting){
        Debug.Log("hasKey1!");
        hasKey1 =true;
        DeActive();

        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            collidedObject = other;
            Debug.Log("getItem");
        }
    }
    private void DeActive(){
        if (collidedObject != null)
        {
            collidedObject.gameObject.SetActive(false);
            collidedObject = null;
            Debug.Log("deactive"); // 清除引用，防止重复处理
        }


    }
    public void OpenDoor()
    {
        if(isInteracting== true &&hasKey1==true){   
        Debug.Log("opendoor");
        DeActive();
        }
        
    }

    








}
