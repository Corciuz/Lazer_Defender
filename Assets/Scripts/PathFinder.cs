using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner EnemySpawner;
     WaveConfigSO WaveConfig;
    List<Transform> WayPoints;
    int WayPointIndex=0;
    void Awake() {
        EnemySpawner= FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        WaveConfig=EnemySpawner.getCurrentWave();
        WayPoints=WaveConfig.GetWayPoint();
        transform.position=WayPoints[WayPointIndex].position;
        
    }

   
    void Update()
    {
        FollowPath();
    }
    void FollowPath(){
        if(WayPointIndex<WayPoints.Count){
Vector3 TargetPosition=WayPoints[WayPointIndex].position;
float MoveSpeed=WaveConfig.GetMoveSpeed()*Time.deltaTime;
transform.position=Vector2.MoveTowards(transform.position,TargetPosition,MoveSpeed);
if(transform.position==TargetPosition){
WayPointIndex++;
}
        }else{
    Destroy(gameObject);
}
    }
}
