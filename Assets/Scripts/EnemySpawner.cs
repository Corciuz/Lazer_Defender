using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]List<WaveConfigSO> WaveConfig;
    [SerializeField]float TimeBetweenWaves=0f;
    [SerializeField] bool IsLooping;
     WaveConfigSO curretnwave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWave());
        
        
    }
    public WaveConfigSO getCurrentWave(){
        return curretnwave;
    }
    IEnumerator SpawnEnemyWave(){
        do{
foreach(WaveConfigSO wave in WaveConfig){
            curretnwave=wave;
for(int i=0;i<curretnwave.GetEnemyCount();i++){
Instantiate(curretnwave.GetEnemyPrefab(i),
        curretnwave.GetStartingWayPoint().position,Quaternion.Euler(0,0,180),transform);
yield return new WaitForSeconds(curretnwave.GetRandomSpawnTime());
        }
        yield return new WaitForSeconds(TimeBetweenWaves);
        }
        }while(IsLooping);
        
        
        
    }

    
}
