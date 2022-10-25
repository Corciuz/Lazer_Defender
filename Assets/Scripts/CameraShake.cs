using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]float ShakeDuration=1f;
    [SerializeField]float ShakeMagnitude=0.5f;
    Vector3 InitialPosition;
    void Start()
    {
        InitialPosition=transform.position;
    }
    public void Play(){
        StartCoroutine(Shake());
    }
IEnumerator Shake(){
    float ElapseTime=0f;
    while(ElapseTime<ShakeDuration){
transform.position=InitialPosition+(Vector3)Random.insideUnitCircle*ShakeMagnitude;
ElapseTime+=Time.deltaTime;
    yield return new WaitForEndOfFrame();

    }
    transform.position=InitialPosition;
}
}
