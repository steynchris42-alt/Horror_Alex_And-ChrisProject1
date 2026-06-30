using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using UnityEngine;

public class EnemyPatrollState : Enemy_State_Controll
{
    public Transform[] PatrolRoute;

    [SerializeField] protected Transform[] Relocate;
    [SerializeField] protected Transform[] Relocate_1;
    [SerializeField] protected Transform[] Relocate_2;
    [SerializeField] protected Transform[] Relocate_3;
    [SerializeField] protected Transform[] Relocate_4;

    protected Vector3 DirToPath0;
    protected Vector3 DirToPath1;
    protected Vector3 DirToPath2;
    protected Vector3 DirToPath3;
    protected Vector3 DirToPath4;

    public Transform CurrentPath;
    public Transform TargetPath;
    protected float DisToPath;


    [SerializeField] private int iGen_Index;
    [SerializeField] private int iPatrolRoute_Index;

    protected float MoveSpeed = 30f;
    protected void Start()
    {
        Debug.Log(IsPatrolligActivated);
        //TargetPath = PatrolRouteFull[0];
    }
    protected override void PatrollState()
    {
        Debug.Log("enemy patroll state activated");
        foreach (Transform gen in Generators)
        {
            Player_Dis_Generator = Vector3.Distance(player.position, gen.position);

            if (Player_Dis_Generator < 60)
            {
                Current_Gen = gen;
                //Debug.Log("GenerratorDistances" + Player_Dis_Generator);
            }

        }
        if (Current_Gen != null)
        {
            iGen_Index = System.Array.IndexOf(Generators, Current_Gen);
        }
       
            SetCircut(PatrolRoute);
        
      

        switch (iGen_Index)
        {
            case 0: Relocate_(Relocate); Debug.Log("Patrolroute0 Activated"); break;
            case 1: Relocate_(Relocate_1); Debug.Log("Patrolroute1 Activated"); break;
            case 2: Relocate_(Relocate_2); Debug.Log("Patrolroute2 Activated"); break;
            case 3: Relocate_(Relocate_3); Debug.Log("Patrolroute3 Activated"); break;

        }
    }
    protected void SetCircut(Transform[] route)
    {
        foreach (Transform Path in route)
        {
            DisToPath = Vector3.Distance(transform.position, Path.position);

            if (DisToPath <= 10)
            {
                CurrentPath = Path;
            }
        }
        if (CurrentPath != null)
        {
            iPatrolRoute_Index = System.Array.IndexOf(route, CurrentPath);
        }
        DirToPath0 = (route[0].transform.position - transform.position).normalized;
        DirToPath1 = (route[1].transform.position - transform.position).normalized;
        DirToPath2 = (route[2].transform.position - transform.position).normalized;
        DirToPath3 = (route[3].transform.position - transform.position).normalized;
        DirToPath4 = (route[4].transform.position - transform.position).normalized;

        switch (iPatrolRoute_Index)
        {
            case 0: transform.Translate(DirToPath1 * MoveSpeed * Time.deltaTime); break;
            case 1: transform.Translate(DirToPath2 * MoveSpeed * Time.deltaTime); break;
            case 2: transform.Translate(DirToPath3 * MoveSpeed * Time.deltaTime); break;
            case 3: transform.Translate(DirToPath4 * MoveSpeed * Time.deltaTime); break;
            case 4: transform.Translate(DirToPath0 * MoveSpeed * Time.deltaTime); break;

        }
    }

    protected void Relocate_(Transform[] relocate)
    {
        PatrolRoute[0].position = relocate[0].position;
        PatrolRoute[1].position = relocate[1].position;
        PatrolRoute[2].position = relocate[2].position;
        PatrolRoute[3].position = relocate[3].position;
        PatrolRoute[4].position = relocate[4].position;

    }
 
}

//Nice for compressing else if chains. performance heavy in thsi conetx.

/*
   switch (Current_Gen)
   {
       case var gen when gen = Generators[0]: patrolcircuts = PatrolCircuts.CircutFull; break;

   }
   */
