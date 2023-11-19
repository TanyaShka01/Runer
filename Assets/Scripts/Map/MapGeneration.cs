using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject Ground;
    List<GameObject> DeleteObstacles;  
    List<GameObject> Grounds;                                                                  
    void Start()
    {
        DeleteObstacles = new List<GameObject>();
        Grounds = new List<GameObject>();
        GenerateObstacles(20);
    }

    void Update()
    {
        
    }

    public void GenerateObstacles(float StartPositionZ)
    {
        GameObject GroundPart = Instantiate(Ground);
        Grounds.Add(GroundPart);
        GroundPart.transform.position = new Vector3(0, -2, StartPositionZ + 25);
        for ( float i =  StartPositionZ; i < StartPositionZ + 50; i += 5)
        {
            GameObject RandomObstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            GameObject NewObstacle = Instantiate(RandomObstacle);
            DeleteObstacles.Add(NewObstacle);
            int x = Random.Range(1, 4);
            if (x == 1)
            {
                x = -3;
            }
            else if (x == 2)
            {
              x = 0; 
            }
            NewObstacle.transform.position = new Vector3(x, 0, i);
        }
    }

    public async void DeleteUnusedObstacles(float PlayerZ)
    {
        for(int r = 0; r < DeleteObstacles.Count; r += 1)
        {
            if (PlayerZ > DeleteObstacles[r].transform.position.z)
            {
                GameObject.Destroy(DeleteObstacles[r]);
            }
        }
        await UniTask.WaitForFixedUpdate();
        List<GameObject> UndDeleted = new List<GameObject>();
        for(int t = 0; t < DeleteObstacles.Count; t += 1)
        {
            if(DeleteObstacles[t] != null)
            {
                UndDeleted.Add(DeleteObstacles[t]);
            }
        }
        DeleteObstacles = UndDeleted;
        if (Grounds.Count > 2)
        {
            GameObject.Destroy(Grounds[0]);
            Grounds.RemoveAt(0);
        }
    }
}
