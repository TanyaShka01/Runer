using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MapGeneration : MonoBehaviour
{
    public int[] LinePositions;
    public GameObject[] Obstacles;
    public GameObject[] GroundPrefabs;
    public GameObject CoinPrefab;
    public GameObject[] AbilityPrefabs;
    public AllHerosSettings allherosSettings;
    public GamePlayUI gamePlayUI;
    public AbillityController BaseAbilityController;
    Vector3 PositionLastGround = new Vector3(0, 0, 25);

    List<GameObject> DeleteObstacles;  
    List<GameObject> Grounds;                                                                  
    void Start()
    {
        DeleteObstacles = new List<GameObject>();
        Grounds = new List<GameObject>();
        GenerateObstacles(25);
        CreatHero();
    }

    private void CreatHero()
    {
        string HeroName = PlayerProgres.GetSelectedHero();
        for (int i = 0; i < allherosSettings.AllHeros.Length; i++)
        {
            if (HeroName == allherosSettings.AllHeros[i].Name)
            {
                GameObject newHero = Instantiate(allherosSettings.AllHeros[i].GamePlayPrefab);
                newHero.GetComponent<Hero>().SetUp(this, gamePlayUI);
            }
        }
    }

    public async void GenerateObstacles(float StartPositionZ)
    {
        GenerateGrond();
        for (float i = StartPositionZ; i < StartPositionZ + 100; i += 7)
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
            await UniTask.WaitForFixedUpdate();
        }
    }

    private async void GenerateGrond()
    {
        GameObject GroundPart = Instantiate(GroundPrefabs[Random.Range(0, GroundPrefabs.Length)]);
        Grounds.Add(GroundPart);
        GroundPart.transform.position = new Vector3(0, -1.2f, PositionLastGround.z + 50);
        await UniTask.WaitForFixedUpdate();
        GameObject GroundPart2 = Instantiate(GroundPrefabs[Random.Range(0, GroundPrefabs.Length)]);
        Grounds.Add(GroundPart2);
        GroundPart2.transform.position = new Vector3(0, -1.2f, PositionLastGround.z + 100);
        PositionLastGround = GroundPart2.transform.position;
    }

    public async void DeleteUnusedObstacles(float PlayerZ)
    {
        for(int r = 0; r < DeleteObstacles.Count; r += 1)
        {
            if (DeleteObstacles[r] != null && PlayerZ > DeleteObstacles[r].transform.position.z)
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
        while (Grounds.Count > 4)
        {
            GameObject.Destroy(Grounds[0]);
            Grounds.RemoveAt(0);
        }
    }

    public void GenerateCoin(float PlayerZ)
    {
        int x = Random.Range(0, 3);
        Vector3 StartRayPosition = new Vector3(LinePositions[x], 100, PlayerZ);
        Ray ray = new Ray(StartRayPosition, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit Hit, 500))
        {
            Vector3 CoinPosition = new Vector3(LinePositions[x], Hit.point.y + 0.5f, PlayerZ);
            GameObject Coin = Instantiate(CoinPrefab);
            Coin.transform.position = CoinPosition;
        }
    }

    public void GenerateAbility(float PlayerZ)
    {
        int x = Random.Range(0, 3);
        Vector3 StartRayPosition = new Vector3(LinePositions[x], 100, PlayerZ);
        Ray ray = new Ray(StartRayPosition, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit Hit, 500))
        {
            int AbilityIndex = Random.Range(0, AbilityPrefabs.Length);
            Vector3 AbilityPosition = new Vector3(LinePositions[x], Hit.point.y + 0.5f, PlayerZ);
            GameObject Ability = Instantiate(AbilityPrefabs[AbilityIndex]);
            Ability.transform.position = AbilityPosition;
            BaseAbilityController.AddAbility(Ability.GetComponent<BaseAbility>());
        }
    }
}
