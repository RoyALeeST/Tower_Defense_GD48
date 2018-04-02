using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM {
	//you call variable NPC from NPCBaseFSM

	GameObject [] Waypoints; //does an array to move between the waypoints created
	int currentWP;//npc must know what waypoint is going to

	private void Awake()
	{
		Waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		base.OnStateEnter(animator,stateInfo,layerIndex); // to call all the variables from the state enter
		currentWP = 0; //when npc changes states is going back again to waypoint 0
		//for minervas garden I can make the last waypoint of the array the last point to go, so it 

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		if (Waypoints.Length==0) return;
		if (Vector3.Distance(Waypoints[currentWP].transform.position,NPC.transform.position)<accuracy) // accuracy is created at npcbasefsm,it helps to know how close to the waypoint it should be
		{
			currentWP++;
			//Restart the index so it becomes a circular pattern of patrol movement
			if(currentWP>=Waypoints.Length)
			{
				currentWP = 0; //probably going to destroy npc when reaching this instead of doing a patrol
			}
		}

        agent.SetDestination(Waypoints[currentWP].transform.position); // we give the navmesh agent the waypoint it needs to go

		//rotate towards target 
		//var direction = Waypoints[currentWP].transform.position-NPC.transform.position; //makes the npc travel to the waypoint, its the movement of the unit
		//NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,Quaternion.LookRotation(direction),rotSpeed * Time.deltaTime); //we use slerp to make the npc 
		//slowly look at the waypoint is traveling you can change the speed of the roration with the rotspeed(which is created in npcbasefsm)
		//NPC.transform.Translate(0,0,Time.deltaTime*speed); //you can use speed to change velocity of the movement (which is created in npcbasefsm)

	
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
	
	}

}
