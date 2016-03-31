using UnityEngine;
using System.Collections;

public class SquishPoint : MonoBehaviour
{
	private Transform bone;

	void Start()
	{
		
	}

	void Update()
	{
		bone.position = transform.position;
	}

	public void SetBone( Transform boneTransform )
	{
		bone = boneTransform;
	}

	public void SetConnectedPoint( SquishPoint anchor )
	{
		SpringJoint2D spring = GetComponent<SpringJoint2D>();
		spring.connectedBody = anchor.GetComponent<Rigidbody2D>();
		spring.distance = Vector2.Distance( transform.position, anchor.transform.position );
	}
}
