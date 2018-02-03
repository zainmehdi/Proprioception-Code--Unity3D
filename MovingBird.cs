using UnityEngine;
using System.Collections;

public class MovingBird : MonoBehaviour {

 public float horizontalSpeed;
 public float verticalSpeed;
 public float amplitude;
 public float[] angle=new float[3];
 int i;
 Vector3 initialpos ;

 
 private Vector3 tempPosition;

 void Start () 
  {
		angle [0] =0 ;
		angle [1] = 1;
		angle [2] = -1;
		tempPosition = transform.position;
		initialpos = new Vector3 (0.0f, 0.0f, -1.63f);


 }
 
 void Update () 
  {
		
	
			
			if(Input.GetKeyDown(KeyCode.A))
				{
			if(i==3){i = 0;}
			    tempPosition.x += horizontalSpeed;
				tempPosition.y = angle[i] * amplitude;
			    float y = Mathf.Sin (360);
			    Debug.Log (tempPosition.y);
			    transform.position = tempPosition;
			i++;
				
		       }
		if (Input.GetKeyDown (KeyCode.B)) {
			transform.position = initialpos;
			tempPosition.x = 0.0f;
		}
 }
}


//Time.realtimeSinceStartup *