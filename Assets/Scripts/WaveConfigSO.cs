using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Wave Config",fileName ="New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float MoveSpeed=5f;
    [SerializeField] List<GameObject> EnemyPrefab;
[SerializeField] float TimeBetweenEnemySpawn=1f;
[SerializeField] float SpawnTimeVarient=0f;
[SerializeField] float MinimumSpawnTime=0.2f;
    public int GetEnemyCount(){
        return EnemyPrefab.Count;
    }
    public GameObject GetEnemyPrefab(int index){
return EnemyPrefab[index];
    }
  public Transform GetStartingWayPoint(){
return pathPrefab.GetChild(0);
  }
  public List<Transform>GetWayPoint(){
    List<Transform>wayPoint=new List<Transform>();
    foreach(Transform child in pathPrefab){
        wayPoint.Add(child);
    }
    return wayPoint;
  }
  public float GetMoveSpeed(){
    return MoveSpeed;
  }
  public float GetRandomSpawnTime(){
    float SpawnTime=Random.Range(TimeBetweenEnemySpawn-SpawnTimeVarient,
    TimeBetweenEnemySpawn+SpawnTimeVarient);
    return Mathf.Clamp(SpawnTime,MinimumSpawnTime,float.MaxValue);
  }
}
