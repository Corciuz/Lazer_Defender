using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField]AudioClip ShootingClip;
    [SerializeField][Range(0f,1f)]float ShootingVolume=1f;
     [Header("Damage")]
    [SerializeField]AudioClip DamageClip;
    [SerializeField][Range(0f,1f)]float DamageVolume=1f;
    public void PlayDamageClip(){
        PlayClip(DamageClip,DamageVolume);
    }
    public void PlayShootingClip(){
        PlayClip(ShootingClip,ShootingVolume);
    }
    void PlayClip(AudioClip Clip,float Volume){
if(Clip!=null){
Vector3 CameraPos=Camera.main.transform.position;
AudioSource.PlayClipAtPoint(Clip,CameraPos,Volume);
}
    }

}
