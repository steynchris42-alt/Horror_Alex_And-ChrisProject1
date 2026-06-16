using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_State_Controll : MonoBehaviour
{
    protected float Speed = 1f;
    protected float Dis_From_Player;
    protected bool IsPatrolligActivated;
    //Genrator stuff
    public int[] iGeneratorsIndex = { 0,1,2,3 };      
    protected int iCurrentGeneratorsIndex = -1;
    
    public Transform[] Generators;

    protected float Player_Dis_Generator;
    public Transform Current_Gen = null;   
    public Transform player;
    protected EnemyPatrollState Patroll_State_Script; 
protected enum EnemyState 
        {
        Patrolling,
        Chasing,
        Searching,
        Stunned,
        JumpScare,
         }
    [SerializeField] 
  protected EnemyState enemy_state;
    protected virtual void Update()
    {
        Dis_From_Player = Vector3.Distance(transform.position, player.position);
       // Debug.Log(Dis_From_Player);
        switch (Dis_From_Player)
        {
            case > 20: enemy_state = EnemyState.Patrolling; break;
            case < 20: enemy_state = EnemyState.Chasing; break;
        }
        //Realted to the generators   
        //iCurrentGeneratorsIndex = iGeneratorsIndex;
        // int Current_gen_asInt;
    
    }
       
      }
