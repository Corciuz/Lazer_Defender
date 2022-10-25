using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
   int Score;
   static ScoreKeeper Instance;
   void Awake(){
       ManageSingleton();
   }
   void ManageSingleton(){
if(Instance!=null){
    gameObject.SetActive(false);
Destroy(gameObject);
}else{
Instance=this;
DontDestroyOnLoad(Instance);
}
    }
   public int GetScore(){
    return Score;
   }
   public void ModifyScore(int Value){
   Score+=Value;
Mathf.Clamp(Score,0,int.MaxValue);

   }
   public void ResetScore(){
    Score=0;
   }
}
