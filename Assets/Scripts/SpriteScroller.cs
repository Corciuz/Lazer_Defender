using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
   [SerializeField] Vector2 MoveSpeed;
   Vector2 offset;
   Material Material;
    void Awake()
    {
        Material=GetComponent<SpriteRenderer>().material;
    }

    
    void Update()
    {
        offset=MoveSpeed*Time.deltaTime;
        Material.mainTextureOffset+=offset;
        
    }
}
