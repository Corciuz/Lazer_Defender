using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed=5f;
    [SerializeField] float paddingleft;
    [SerializeField] float paddingright;
    [SerializeField] float paddingtop;
    [SerializeField] float paddingbottom;
    Shooter shooter;
    Vector2 RawValue;
    Vector2 minBounds;
    Vector2 maxBounds;
    void Awake(){
        shooter=GetComponent<Shooter>();
    }
    void Start(){
        InitBounds();
    }
    
    void Update()
    {
        Move();
        
    }
    void InitBounds(){
        Camera mainCamera=Camera.main;
        minBounds=mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds=mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    void Move(){
Vector2 delta=RawValue*moveSpeed*Time.deltaTime;
Vector2 newPos=new Vector2();
newPos.x=Mathf.Clamp(transform.position.x+delta.x,minBounds.x+paddingleft,maxBounds.x-paddingright);
newPos.y=Mathf.Clamp(transform.position.y+delta.y,minBounds.y+paddingbottom,maxBounds.y-paddingtop);
transform.position=newPos;
    }
    void OnMove(InputValue value){
RawValue= value.Get<Vector2>();
    }
    void OnFire(InputValue value){
if(shooter!=null){
shooter.IsFiring=value.isPressed;
}
    }
}
