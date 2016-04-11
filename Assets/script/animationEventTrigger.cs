using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class animationEventTrigger : StateMachineBehaviour {

	Button eventBtn = null;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.IsName ("eventnormal")) {
			if(eventBtn == null){
				eventBtn = GameObject.Find("reserved").GetComponent<Button>();
			}
			ControlEvent.eventSpriteName = ControlEvent.eventSpriteName.Replace("eventbtnsmall","eventbtn");
			eventBtn.image.sprite = ControlEvent.ResourcesDictionary[ControlEvent.currentLanguage+ControlEvent.eventSpriteName];
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.IsName ("eventnormal")) {
			if(eventBtn == null){
				eventBtn = GameObject.Find("reserved").GetComponent<Button>();
			}
			ControlEvent.eventSpriteName = ControlEvent.eventSpriteName.Replace("eventbtn","eventbtnsmall");
			eventBtn.image.sprite = ControlEvent.ResourcesDictionary[ControlEvent.currentLanguage+ControlEvent.eventSpriteName];
		}
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
