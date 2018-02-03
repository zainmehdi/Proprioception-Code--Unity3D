using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Text;

/*
* Haptic functionnalities are loaded frokm the PluginImport Script
* To call a function, the code must be stated as below:
* PluginImport.function(Arg1,Arg2);
* In the case the functions is returning Array or required Arguments
* of Array type, it will be necessary tpo convert the data from/To IntPtr.
* To do so, call one of the functions define in the class ConverterClass.
*/

public class PluginImport  {
	
	/*************************************************************/
	// Haptic Functions Import
	/*************************************************************/

	/*************************************************************/
	// Initialization and CleanUp Functions
	/*************************************************************/
	//Lets make our calls from the Plugin
	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool InitHapticDevice(); 
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool HapticCleanUp(); 

	/*************************************************************/
	// Specify the Mode of Interaction
	/*************************************************************/

	/*
	* Mode = 0 Contact
	* Mode = 1 Manipulation - So objects will have a mass when handling them
	* Mode = 2 Custom Effect - So the haptic device simulate vibration and tangential forces as power tools
	* Mode = 3 Puncture - So the haptic device is a needle that puncture inside a geometry
	*/
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetMode(int mode);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern int GetMode();

	/*************************************************************/
	// Set the touchable Face(s)
	/*************************************************************/

	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetTouchableFace(IntPtr face);
	/*Argument must be converter from string to IntPtr
	*Accepted values: (if the function is not used - the plugin set the front face as default touchable face)
	* front
	* back
	* front_and_back
	*/
	
	/*************************************************************/
	// Workspace Functions
	/*************************************************************/
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr SetWorkspacePosition(IntPtr position);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr SetWorkspaceSize(IntPtr size);
	
	//Encompass  SetWorkspacePosition +  SetWorkspaceSize + SetUpdateWorkspace
	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetWorkspace(IntPtr position,IntPtr size);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern void UpdateWorkspace(float CameraAngleOnY);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetWorkspacePosition();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetWorkspaceSize();
	
	/*************************************************************/
	// Render the Haptics (All haptic threads) - to be used in the unity loop  
	/*************************************************************/

	[DllImport ("ASimpleHapticPlugin")]
	public static extern void RenderHaptic();
	
	/*************************************************************/
	// Haptic Device and Proxy Values
	/*************************************************************/
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetDevicePosition();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetProxyPosition();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetProxyRight();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetProxyDirection();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetProxyTorque();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetProxyOrientation();
	
	/*************************************************************/
	// Set Haptic Objects Mesh and Matrix Transform
	/*************************************************************/
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetObjectTransform(int objectId,IntPtr name, IntPtr transform);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetObjectMesh(int objectId, IntPtr vertices, IntPtr triangles, int verticesNum, int trianglesNum);

	/*************************************************************/
	// Set Haptic Objects information
	/*************************************************************/
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetHapticObjectName(int ObjId);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern int GetHapticObjectCount();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern int GetHapticObjectFaceCount(int ObjId);
	
	/*************************************************************/
	// Set Haptic Properties for Haptic Objects
	/*************************************************************/

	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetHapticProperty(int ObjId, IntPtr type , float value); 

	//Haptic Property type

	/*basic properties*/	
		//stiffness													
		//damping											
		//staticFriction										
		//dynamicFriction

	/*Advanced properties for manipulation of objects*/
		//mass
		//fixed

	/*advanced properties for custom forces effects*/
		//tangentialStiffness
		//tangentialDamping

	/*Advanced properties for puncture effects */
		//popThrough
		//puncturedStaticFriction
		//puncturedDynamicFriction
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern void  SetStiffness(int ObjId, float stiffness);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetDamping(int ObjId, float damping);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetStaticFriction(int ObjId, float staticFriction);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetDynamicFriction(int ObjId, float dynamicFriction);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetTangentialStiffness(int ObjId, float tgStiffness);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetTangentialDamping(int ObjId, float tgDamping);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetPopThrough(int ObjId, float popThrough);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetPuncturedStaticFriction(int ObjId, float puncturedStaticFriction);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetPuncturedDynamicFriction(int ObjId, float puncturedDynamicFriction);

	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetMass(int ObjId,float mass);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void  SetFixed(int ObjId,bool fix);

	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool IsFixed(int ObjId);
	
	/*************************************************************/
	// Haptic Environmental Effects functions
	/*************************************************************/
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool SetEffect(IntPtr type,int effect_index, float gain, float magnitude, float duration,float frequency, IntPtr position, IntPtr direction);
	// Effects:		
	// constant			// vibrationMotor
	// spring			// vibrationContact
	// viscous			// tangentialForce
	// friction
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool StartEffect(int effect_index);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool StopEffect(int effect_index);
	
	/*************************************************************/
	// Haptic Events Functions
	/*************************************************************/
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern  void LaunchHapticEvent();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool GetButton1State();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool GetButton2State();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetTouchedObjectName();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern int GetTouchedObjectId();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetManipulatedObjectName();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern int GetManipulatedObjectId();

	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool GetContact();

	/*************************************************************/
	// Puncture Mode Specific Functions
	/*************************************************************/

	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetMaximumPunctureLenght(float maxPenetration);

	[DllImport ("ASimpleHapticPlugin")]
	public static extern bool GetPunctureState();

	[DllImport ("ASimpleHapticPlugin")]
	public static extern float GetPenetrationRatio();
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetFirstScpPt();

    [DllImport("ASimpleHapticPlugin")]
    public static extern void SetPunctureDirection(IntPtr punctureVectorDirection);
	
	[DllImport ("ASimpleHapticPlugin")]
	public static extern IntPtr GetPunctureDirection();

	[DllImport ("ASimpleHapticPlugin")]
	public static extern void SetPunctureLayers(int layerNb, IntPtr[] nameObjects , IntPtr layerDepth);

	/*************************************************************/
	
}
