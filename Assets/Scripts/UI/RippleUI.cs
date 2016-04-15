using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RippleUI : MonoBehaviour {

	[SerializeField]
	private Rippler rippleScript;
	[SerializeField]
	private Slider rippleUI;
	[SerializeField]
	private FollowTransformUIObject followScript;

	private Transform targetTransform;

	// Use this for initialization
	void Start () {
		targetTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (rippleScript.GetRippleForcePercent ());
		rippleUI.value = rippleScript.GetRippleForcePercent ();
		targetTransform.position = new Vector3(rippleScript.TouchPosition.x,rippleScript.TouchPosition.y + 2.0f, 0f);
		followScript.targetTransform = targetTransform;
	}
}
