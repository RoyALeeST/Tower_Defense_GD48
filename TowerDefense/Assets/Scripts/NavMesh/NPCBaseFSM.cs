using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour //no monobehaviour is a statemachine to use the statemachines
 {
	 //variables
	 public GameObject NPC; //you create npc variable, so you know what obj is the npc
     public UnityEngine.AI.NavMeshAgent agent; //agent navmesh
     public GameObject Opponent;
	 public float speed =2.0f;
	 public float rotSpeed = 1.0f;
	 public float accuracy = 3.0f;
     

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		NPC = animator.gameObject;
		Opponent = NPC.GetComponent<TankAI>().GetPlayer();
        agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>(); 
	}
}
