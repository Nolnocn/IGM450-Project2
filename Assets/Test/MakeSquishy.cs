using UnityEngine;
using System.Collections;

public class MakeSquishy : MonoBehaviour
{
	public SquishPoint squishPointPrefab;
	public Transform armatureRoot;

	void Start()
	{
		SquishPoint firstPoint = null;
		SquishPoint lastPoint = null;

		foreach( Transform bone in armatureRoot )
		{
			print( "meep" );
			SquishPoint s = Instantiate( squishPointPrefab ) as SquishPoint;
			s.transform.position = bone.position;
			s.transform.parent = bone;
			s.SetBone( bone );

			if( firstPoint != null )
			{
				s.SetConnectedPoint( lastPoint );
				lastPoint = s;
			}
			else
			{
				firstPoint = s;
				lastPoint = s;
			}
		}

		print( lastPoint );
		print( firstPoint );
		firstPoint.SetConnectedPoint( lastPoint );
	}
}
