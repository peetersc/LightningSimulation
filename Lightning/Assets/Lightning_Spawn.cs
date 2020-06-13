using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Spawn : MonoBehaviour
{
	public Lightning lightning; //lightning bolt prefab

	private GameObject source;

	private float seconds;

	private Vector3 sourcePosition;

	public int numBolts;   //number of bolts each strike has
	public float timeBetween;  //seconds between each bolt generation

  private Vector3 movementTranslation;



	void Start(){
		        seconds = 0.0f;
            movementTranslation = transform.position;
            Debug.Log(movementTranslation);


	}
 
   void Update(){
   	seconds += Time.deltaTime;
    	if(seconds>=timeBetween){
        movementTranslation.x = Random.Range(-15f,15f);
        movementTranslation.z = Random.Range(-10f,-6f);
        transform.position=movementTranslation;
    		seconds = 0;
    		for(int i = 0; i < numBolts; i++){
    			Instantiate(lightning,sourcePosition,Quaternion.identity,this.transform);
  			}
    		
    	}
   }
}
