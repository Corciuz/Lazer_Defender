using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
   [SerializeField]GameObject ProjectilePrefabs;
   [SerializeField] float projectileSpeed=10f;
   [SerializeField] float projectileLifeTime=5f;
   [SerializeField]float BaseFiringRate=0.2f;
   [Header("AI")]
   [SerializeField]bool UsingIA;
   [SerializeField] float FirinigRateVariance=0f;
   [SerializeField] float MinimumFiringRate=0.1f;
   [HideInInspector]public bool IsFiring;
   Coroutine FiringCoroutine;
   AudioPlayer AudioPlayer;
   void Awake(){
    AudioPlayer=FindObjectOfType<AudioPlayer>();
   }
    void Start()
    {
        if(UsingIA){
IsFiring=true;
float TimeToNextProjectile=Random.Range(BaseFiringRate-FirinigRateVariance,BaseFiringRate+FirinigRateVariance);
TimeToNextProjectile=Mathf.Clamp(TimeToNextProjectile,MinimumFiringRate,float.MaxValue);
BaseFiringRate=TimeToNextProjectile;
        }
        
    }

    
    void Update()
    {
       Fire(); 
    }
    void Fire(){
        if(IsFiring&&FiringCoroutine==null){
FiringCoroutine=StartCoroutine(FireContinuously());
        }else if(!IsFiring&&FiringCoroutine!=null){
StopCoroutine(FiringCoroutine);
FiringCoroutine=null;
        }

    }
    IEnumerator FireContinuously(){
while(true){
    GameObject instance=Instantiate(ProjectilePrefabs,
transform.position,Quaternion.identity);
Rigidbody2D rb=instance.GetComponent<Rigidbody2D>();
if(rb!=null){
rb.velocity=transform.up*projectileSpeed;
}
Destroy(instance,projectileLifeTime);
AudioPlayer.PlayShootingClip();
yield return new WaitForSeconds(BaseFiringRate);
}
    }
}
