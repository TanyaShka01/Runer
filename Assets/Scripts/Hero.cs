using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public CapsuleCollider MainCollider;
    public Rigidbody Body;
    public MapGeneration Generation;
    float LastPositionZ = 0;
    public Animator Anim;
    public float SpeedForvard = 50;
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
    }

    void Update()
    {
        GenerateAndDeleteObstacles();
        SwitchRightAndLeft();
        CheckJump();
        CheckRoll();
        Move();
    }

    public void StopRun() 
    {
        
        enabled = false;
    }

    private void GenerateAndDeleteObstacles()
    {
        if (transform.position.z - LastPositionZ > 100)
        {
            Generation.GenerateObstacles(transform.position.z + 20);
            Generation.DeleteUnusedObstacles(transform.position.z);
            LastPositionZ = transform.position.z;
        }
    }

    void Move()
    {
        Body.MovePosition(transform.position + MoveDirection * Time.deltaTime);
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
    }
    async void CheckJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsJumping == false && IsRolling == false)
        {
            IsJumping = true;
            Anim.SetTrigger("Jump");
            Body.AddForce(Vector3.up * 300);
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
