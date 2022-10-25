using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]bool IsPlayer;
    [SerializeField] int health=50;
    [SerializeField] int score=50;
    [SerializeField] ParticleSystem HitEffect;
    [SerializeField]bool ApplyCameraShake;
    CameraShake CameraShake;
    AudioPlayer AudioPlayer;
    ScoreKeeper ScoreKeeper;
    LevelManager LevelManager;
    void Awake(){
        CameraShake=Camera.main.GetComponent<CameraShake>();
        AudioPlayer=FindObjectOfType<AudioPlayer>();
        ScoreKeeper=FindObjectOfType<ScoreKeeper>();
        LevelManager=FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        DamgeDealer damageDealer=other.GetComponent<DamgeDealer>();
        if(damageDealer!=null){
TakeDamage(damageDealer.GetDamage());
PlayHitEffect();
AudioPlayer.PlayDamageClip();
ShakeCamera();
damageDealer.hit();
if(other.tag=="Enemy"){
ScoreKeeper.ModifyScore(score);
}

        }
    }
    public int GetHealth(){
        return health;
    }
    void TakeDamage(int damage){
health-=damage;
if(health<=0){
Die();
}
    }
    void Die(){
        if(!IsPlayer){
ScoreKeeper.ModifyScore(score);
        }else{
LevelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
    void PlayHitEffect(){
        if(HitEffect!=null){
ParticleSystem Instance=Instantiate(HitEffect,transform.position,Quaternion.identity);
Destroy(Instance.gameObject,Instance.main.duration+Instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera(){
        if(CameraShake!=null&&ApplyCameraShake){
CameraShake.Play();
        }
    }
}
