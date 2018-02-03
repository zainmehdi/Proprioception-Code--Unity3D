using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using UnityEngine.VR;
using System.IO;



public class test : HapticClassScript
{

	public GameObject ball;
	GameObject[] target;
	GameObject visibility;
	bool button1 = false;
	bool previousbutton1state = false;
	bool previousbutton1stateI = true;
	int i = 0;
	float j = 1f;
	int targetwritecounter = 0;
	float Rotation ;
	public Quaternion rotation; 


	//Generic Haptic Functions
	private GenericFunctionsClass myGenericFunctionsClassScript;
	Vector3 temp;

	/*****************************************************************************/

	void Awake ()
	{
		myGenericFunctionsClassScript = transform.GetComponent<GenericFunctionsClass> ();
	}


	void Start ()
	{

		rotation = Quaternion.Euler(0, 90, 0);     // rotation of 90 degrees about y axis

		int size = 10;
		target = new GameObject[size];

		visibility = GameObject.FindWithTag ("Cursor"); // search object with tag cursor


		if (PluginImport.InitHapticDevice ()) {
			Debug.Log ("OpenGL Context Launched");
			Debug.Log ("Haptic Device Launched");



		} else
			Debug.Log ("Haptic Device cannot be launched");


		/***************************************************************/
		//Launch the Haptic Event for all different haptic objects
		/***************************************************************/
	//	PluginImport.LaunchHapticEvent ();
	}


	void Update ()
	{


      //  myGenericFunctionsClassScript.GetProxyValues();

        /////////////////////////////////// getting position of Haptic device ///////////////////////
        double[] pos = ConverterClass.ConvertIntPtrToDouble3 (PluginImport.GetProxyPosition ());
		//Vector3 position1 = new Vector3 ((float)pos [2], (float)pos [1], -(float)pos [0]);                   // applying rotation as device is rotated 90 degrees to left... swapping coordinates
		/////////////////////////////////////////////////////////////////////////////////////////////

		Vector3 position1 = new Vector3 ((float)pos [0], (float)pos [1], (float)pos [2]);
		position1 = rotation * position1;

		///////////////////////////////// Instantiation of Targets as Key B is pressed + writing target coordinates to text file //////////////////////////

		button1 = PluginImport.GetButton1State (); 
		if (button1 && !previousbutton1stateI) {

			target [i] = Instantiate (ball);
			target [i].transform.position = new Vector3 (i * 0.1f, j*1.0f, -1.0f);

			using (StreamWriter writer = new StreamWriter ("D:\\log.txt", true)) {

				writer.WriteLine ("");
				writer.Write ("Position for Target ");
				writer.Write (i+1);
				writer.Write (" = ");
				writer.Write (target[i].transform.position);
			}

			if (i > 0) {
				Destroy (target [i - 1]);   // destroying previous targets as the next target is displayed
			}
			i++;
			j = j + 0.1f;
		}

		previousbutton1stateI = button1;
		//////////////////////////////////////////////////////////////////////////////////////////////////////////




		button1 = PluginImport.GetButton1State ();    // getting state of button 1 on phantom

		///////////////////////////// routine for writing pointer current position to text file/////////////////////////////////////
		if (button1 && !previousbutton1state) {


			if (targetwritecounter > 0) {
				using (StreamWriter writer = new StreamWriter ("D:\\log.txt", true)) {

					writer.WriteLine ("");
					writer.Write ("Hand position for target ");
					writer.Write (targetwritecounter);
					writer.Write (" = ");
					writer.Write (gameObject.transform.position  );
				}
			}

			targetwritecounter++;
		}

		previousbutton1state = button1;
		//////////////////////////////////////////////////////////////////////////////////////////////


		//////////////////////////////////// Controlling visibility of haptic sphere /////////////////

		if (Input.GetKeyDown (KeyCode.A)) {                              // Controlling invisibility of the pointer object
			visibility.GetComponent<MeshRenderer> ().enabled = false;      // making object invisible on pressing A


		} 


		if (Input.GetKeyDown (KeyCode.S)) {
			visibility.GetComponent<MeshRenderer> ().enabled = true;                // Making object visible again on pressing S
		}
		//////////////////////////////////////////////////////////////////////////////////////////////






		////////////////////////// Recentering of Head Set (Occulus)/////////////////////////////////////////
		if (Input.GetKeyDown (KeyCode.F12)) {
			InputTracking.Recenter ();
		}
		//////////////////////////////////////////////////////////////////////////////////////////////////////


		/***************************************************************/
		//Haptic Rendering Loop
		/***************************************************************/
	//	PluginImport.RenderHaptic ();


		///////////// Origin offset for phantom local coordinates/////////////////////
		position1 [0] = position1 [0] - (-0.2178f);
		position1 [1] = position1 [1] - (-0.8274f);
		position1 [2] = position1 [2] - (-0.0001f);
		///////////////////////////////////////////////////////////////////////////////
		Debug.Log ("Phantom Coordinates" + position1.ToString ("F4"));

		////////////////// scaling between real world distance and unity distance ///////////////

		position1 [0] = position1 [0] * 0.33f;                     //Real world 10cm = 30cm in unity      // scaling factor10/30
		position1 [1] = position1 [1] * 0.5882f;                   //Real world 10cm = 17cm in unity      // scaling factor10/17
		position1 [2] = position1 [2] * 0.625f;                    //Real world 10cm = 16cm in unity      // scaling factor10/16

		//////////////////////////////////////////////////////////////////////////////////////////

		//////////////// Linear transformation from phantom origin to occulus origin /////////////////
	//	position1 [0] = position1 [0]   + 0.006f+ 0.08f;
		position1 [1] = position1 [1] + 0.63f;
     	position1 [2] = position1 [2] + 0.3f;
		transform.position = position1;
		//Debug.Log ("Phantom Coordinates" + position1.ToString ("F4"));

		//////////////////////////////////////////////////////////////////////////////////////////////



		////////////////////////////// Printing Phantom coordinates to console //////////////////////

		//Debug.Log ("Phantom Coordinates" + position1.ToString ("F4"));

		//////////////////////////////////////////////////////////////////////////////////////////////

		//Debug.Log ("Button 1: " + PluginImport.GetButton1State());
		//Debug.Log ("Button 2: " + PluginImport.GetButton2State());



	}




	void OnDisable ()
	{
		if (PluginImport.HapticCleanUp ()) {
			Debug.Log ("Haptic Context CleanUp");
			Debug.Log ("Desactivate Device");
			Debug.Log ("OpenGL Context CleanUp");
		}
	}



}
