using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Text;

public class GenericFunctionsClass : MonoBehaviour {

	
	/*************************************************************/
	// Variables
	/*************************************************************/
	
	//Haptic Properties
	private HapticProperties myHapticPropertiesScript;
	

	//Access to script SimpleShapeManipulation
//	public HapticClassScript myHapticClassScript;

	
	//GetHapticWorkSpace Values
	private float[] myWSPosition = new float[3];
	private float[] myWSSize = new float[3];

	//GetProxyValues - for haptic proxy position and orientation
	private double[] myProxyPosition = new double[3];
	private double[] myProxyRight = new double[3];
	private double[] myProxyDirection = new double[3];
	private double[] myProxyTorque = new double[3];
	private double[] myProxyOrientation = new double[4];

	//Haptic Environment Effect
	private ConstantForceEffect myContantForceScript;
	private ViscosityEffect myViscosityScript;
	private SpringEffect mySpringScript;
	private FrictionEffect myFrictionScript;
	private VibrationMotor myVibrationMotorScript;
	private VibrationContact myVibrationContactScript;
	private TangentialForce myTangentialForceScript;
	
	/*************************************************************/
	


	// Use this for initialization
	void Awake () {

	}

	/******************************************************************************************************************************************************************/

	/*************************************************************/
	// Generic functionnalities
	/*************************************************************/


	/******************************************************************************************************************************************************************/
	//generic function that returns the current mode

	

	/******************************************************************************************************************************************************************/

	//Haptic workspace generic functions

	


	/******************************************************************************************************************************************************************/

	//Get Proxy Position and Orientation generic function
	public 	void GetProxyValues()
	{
		/*Proxy Position*/
		
		//Convert IntPtr to Double3Array
		myProxyPosition = ConverterClass.ConvertIntPtrToDouble3(PluginImport.GetProxyPosition());
		
		//Attach the Cursor Node
		Vector3 positionCursor = new Vector3();
		positionCursor = ConverterClass.ConvertDouble3ToVector3(myProxyPosition);
		
		//Assign Haptic Values to Cursor
		//myHapticClassScript.hapticCursor.transform.position = positionCursor;
		
		
		//Proxy Right - Not use in that case
		//Convert IntPtr to Double3Array
		/*myProxyRight =  ConverterClass.ConvertIntPtrToDouble3(PluginImport.GetProxyRight());
		//Attach the Cursor Node
		Vector3 rightCursor = new Vector3();
		rightCursor = ConverterClass.ConvertDouble3ToVector3(myProxyRight);

		//Proxy Direction
		//Convert IntPtr to Double3Array
		myProxyDirection =  ConverterClass.ConvertIntPtrToDouble3( PluginImport.GetProxyDirection());
		//Attach the Cursor Node
		Vector3 directionCursor = new Vector3();
		directionCursor = ConverterClass.ConvertDouble3ToVector3(myProxyDirection);

		//Proxy Torque
		myProxyTorque = ConverterClass.ConvertIntPtrToDouble3(PluginImport.GetProxyTorque());
		//Attach the Cursor Node
		Vector3 torqueCursor = new Vector3();
		torqueCursor = ConverterClass.ConvertDouble3ToVector3(myProxyTorque);

		//Set Orientation
		myHapticClassScript.hapticCursor.transform.rotation = Quaternion.LookRotation(directionCursor,torqueCursor);*/
	
	}

	

	}	

	/******************************************************************************************************************************************************************/


	

	//Haptic Properties generic function

	

	/******************************************************************************************************************************************************************/


	

	

	


	/******************************************************************************************************************************************************************/


	


	/******************************************************************************************************************************************************************/

