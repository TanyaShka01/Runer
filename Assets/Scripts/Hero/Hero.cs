using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public CapsuleCollider MainCollider;
    public Rigidbody Body;
    public HeroScore Score;
    public List<GameObject> Boots;
    GamePlayUI uI;
    MapGeneration Generation;
    ShieldAbility shild;
    float LastObstaclesPositionZ = 0;
    float LastCoinPositionZ = 0;
    float LastAbilityPositionZ = 0;
    public Animator Anim;
    public float SpeedForvard = 50;
    public float JumpForse = 300;
    public float SpeedTurn = 50;
    int Xposition = 0;
    bool IsTerning = false;
    bool IsJumping = false;
    bool IsRolling = false;
    Vector3 MoveDirection;
    void Start()
    {
        MoveDirection.z = SpeedForvard;
        Anim.SetBool("Run", true);
        Application.targetFrameRate = 30;
    }

    void Update()
    {
        GenerateAndDeleteObstacles();
        GenerateAndDeleteCoins();
        GenerateAndDeleteAbility();
        SwitchRightAndLeft();
        CheckJump();
        CheckRoll();
        Move();
    }

    public void SetUp(MapGeneration mapGeneration, GamePlayUI gamePlayUI)
    {
        Generation = mapGeneration;
        uI = gamePlayUI;
    }

    public void ActivateShildAbility(bool IsActive, ShieldAbility shieldAbility = null)
    {
        if (IsActive == true)
        {
            GetComponent<ShildHeroCollision>().enabled = true;
            GetComponent<UsualHeroCollision>().enabled = false;
            shild = shieldAbility;
        }
        else
        {
            GetComponent<ShildHeroCollision>().enabled = false;
            GetComponent<UsualHeroCollision>().enabled = true;
        }
    }

    public void ShildDisableForce()
    {
        shild.Stop();
    }

    public void ActivateJerkAbility(bool IsActive)
    {
        if (IsActive == true)
        {
            GetComponent<UsualHeroCollision>().enabled = false;
            GetComponent<JerkHeroCollision>().enabled = true;
            MoveDirection.z = SpeedForvard * 2;
            Anim.speed = 2;
        }
        else
        {
            MoveDirection.z = SpeedForvard;
            GetComponent<JerkHeroCollision>().enabled = false;
            GetComponent<UsualHeroCollision>().enabled = true;
            Anim.speed = 1;
        }
    }

    public void ActivateShoesAbility(bool IsActive)
    {
        if (IsActive == true)
        {
            foreach (GameObject Boot in Boots)
            {
                Boot.SetActive(true);
            }
            JumpForse = 450;
        }
        else
        {
            foreach(GameObject Boot in Boots)
            { 
                Boot.SetActive(false); 
            }
            JumpForse = 300;
        }
    }

    public void StopRun() 
    {
        uI.ShowLosePanel(Score.GetScore());
        enabled = false;
    }

    private void GenerateAndDeleteObstacles()
    {
        if (transform.position.z - LastObstaclesPositionZ > 100)
        {
            Generation.GenerateObstacles(transform.position.z + 20);
            Generation.DeleteUnusedObstacles(transform.position.z);
            LastObstaclesPositionZ = transform.position.z;
        }
    }

    private void GenerateAndDeleteCoins()
    {
        if(transform.position.z - LastCoinPositionZ > 30)
        {
            Generation.GenerateCoin(transform.position.z + 25);
            LastCoinPositionZ = transform.position.z;
        }
    }

    private void GenerateAndDeleteAbility()
    {
        if(transform.position.z - LastAbilityPositionZ > 60)
        {
            Generation.GenerateAbility(transform.position.z + 20);
            LastAbilityPositionZ = transform.position.z;
        }
    }

    void Move()
    {
        Body.MovePosition(transform.position + MoveDirection * 0.01f);
    }

    private void SwitchRightAndLeft()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && Xposition != -3)
        {
            if (IsTerning == false)
            {
                Xposition -= 3;
                Vector3 NewPosition = new Vector3(Xposition, transform.position.y, transform.position.z);
                SmoothlyMoveX(NewPosition.x);
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && Xposition != 3)
        {
            if (IsTerning == false)
            {
                Xposition += 3;
                Vector3 NewPosition = new Vector3(Xposition, transform.position.y, transform.position.z);
                SmoothlyMoveX(NewPosition.x);
            }
        }
    }

    async void SmoothlyMoveX(float FinishX)
    {
        Body.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        float StartX = transform.position.x;
        IsTerning = true;
        float Derection = FinishX - transform.position.x;
        float xStep = Math.Clamp(Derection, -1, 1);
        MoveDirection.x = xStep * SpeedTurn;
        while(Math.Abs(StartX - transform.position.x) < Math.Abs(Derection))
        {
            await UniTask.WaitForFixedUpdate(); 
        }
        IsTerning = false;
        MoveDirection.x = 0;
        transform.position = new Vector3(FinishX, transform.position.y, transform.position.z);
        Body.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX;
    }
    async void CheckJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsJumping == false && IsRolling == false)
        {
            IsJumping = true;
            Anim.SetTrigger("Jump");
            Body.AddForce(Vector3.up * JumpForse);
            await UniTask.Delay(1500);
            IsJumping = false;
        }
    }

    async void CheckRoll()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && IsRolling == false)
        {
            IsRolling = true;
            MainCollider.height = 0.1f;
            MainCollider.center = new Vector3(0, 0.5f, 0);
            Anim.SetTrigger("Roll");
            await UniTask.Delay(1200);
            MainCollider.height = 1.82f;
            MainCollider.center = new Vector3(0, 0.9f, 0);
            IsRolling = false;
        }
    }
}
