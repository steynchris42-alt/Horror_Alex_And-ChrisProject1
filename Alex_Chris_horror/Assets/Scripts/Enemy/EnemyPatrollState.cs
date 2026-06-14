using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyPatrollState : Enemy_State_Controll
{
   public Transform[] PatrolRouteFull;
    public Transform[] PatrolRoute1;
   public Transform[] PatrolRoute2;
    public Transform[] PatrolRoute3;
   public Transform[] PatrolRoute4;

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

    protected float MoveSpeed = 10f;

    public enum PatrolCircuts
    {
        CircutFull,
        Circut0,
        Circut1,
        Circut2,
        Circut3,
    }
    public PatrolCircuts patrolcircuts;
    protected void Start()
    {
   Debug.Log(IsPatrolligActivated);
        // TargetPath = PatrolRouteFull[0];
    }
    protected override void Update()
    {
        base.Update();
        foreach (Transform gen in Generators)
        {
            Player_Dis_Generator = Vector3.Distance(player.position, gen.position);
   
            if (Player_Dis_Generator < 60)
            {
                Current_Gen = gen;
            }

        }
        if (Current_Gen != null)
        {
            iGen_Index = System.Array.IndexOf(Generators, Current_Gen);
        }
 
        switch (iGen_Index)
        {
            case 0: SetCircut(PatrolRoute1); break;
           case 1: SetCircut(PatrolRoute2); break;
          case 2: SetCircut(PatrolRoute3); break;
           case 3: SetCircut(PatrolRoute4); break;

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
     DirToPath0 = (transform.position - route[0].transform.position).normalized;
    DirToPath1 = (transform.position - route[1].transform.position).normalized;
    DirToPath2 = (transform.position - route[2].transform.position).normalized;
    DirToPath3 = (transform.position - route[3].transform.position).normalized;
    DirToPath4 = (transform.position - route[4].transform.position).normalized;

        switch (iPatrolRoute_Index)
        {
            case 0: Debug.Log("MoveTo Pathpoint1"); transform.Translate( DirToPath1 * Time.deltaTime * MoveSpeed, Space.World); break;
          //  case 1: Debug.Log("MoveTo Pathpoint2"); transform.Translate(route[2].transform.position * Time.deltaTime * MoveSpeed, Space.World); break;
         ////   case 2: Debug.Log("MoveTo Pathpoint3"); transform.Translate(route[3].transform.position * Time.deltaTime * MoveSpeed, Space.World); break;
           // case 3: Debug.Log("MoveTo Pathpoint4"); transform.Translate(route[4].transform.position * Time.deltaTime * MoveSpeed, Space.World); break;
           // case 4: Debug.Log("MoveTo Pathpoint0"); transform.Translate(route[0].transform.position * Time.deltaTime * MoveSpeed, Space.World); break;
                // transform.Translate(CurrentPath.position, TargetPath);
        }
    }
    protected void CDIrections()
    {
    
        
    }
}

//Nice for compressing else if chains. performance heavy in thsi conetx.

/*
   switch (Current_Gen)
   {
       case var gen when gen = Generators[0]: patrolcircuts = PatrolCircuts.CircutFull; break;

   }
   */
