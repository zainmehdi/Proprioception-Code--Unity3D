	using UnityEngine;
	using System.Collections;
	using System.IO;
	using UnityEngine.SceneManagement;

	public class Position : MonoBehaviour {
	bool previousbutton1state = false;
	bool previousbutton2state = false;
	bool button2= false;
	bool button1=false;
	GameObject visibility;

		// Use this for initialization
		void Start () {
		visibility= GameObject.FindWithTag ("Cursor"); // search object with tag cursor
			       
	    }
		
		// Update is called once per frame
		void Update () 
		{


		double[] pos = ConverterClass.ConvertIntPtrToDouble3 (PluginImport.GetDevicePosition ());
			Vector3 position = new Vector3 ((float)pos [0], (float)pos [1], (float)pos [2]);
		 

	    button1 = PluginImport.GetButton1State ();    // getting state of button 1 on phantom
		Debug.Log (button1+"     " + button2);        // printing button 1 and button 2 state on console
		if (button1 && !previousbutton1state)         // routine for writing coordinate values to text file
		{
			
			//////////////////////////////////////////////////////////////////
			using (StreamWriter writer = new StreamWriter ("G:\\log.txt", true))

				// Loop through ten numbers.
				for (int i = 0; i < 3; i++) {
					//Write format string to file.
					//writer.Write ("{0:0.0} ", position [i]);
					writer.WriteLine(position);
				} // for loop

			using (StreamWriter writer =
				       new StreamWriter ("G:\\log.txt", true)) {
				writer.WriteLine ("\r\n");
//				//writer.WriteLine("First target coordinates");
			} // stream
//
		}

		previousbutton1state = button1;
			/////////////////////////////////////////////////////////////////////

    button2 = PluginImport.GetButton2State ();
		if (button2 && !previousbutton2state)                              // Controlling invisibility of the pointer object
		{
			visibility.GetComponent<MeshRenderer> ().enabled = false;      // making object invisible


       } // update 
		previousbutton2state=button2;

		if (Input.GetKeyDown (KeyCode.A)) {
			visibility.GetComponent<MeshRenderer> ().enabled = true;                // Making object visible again on pressing button 2
		}

			                             
	}
}
		

