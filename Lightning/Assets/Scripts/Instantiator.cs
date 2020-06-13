using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
	public int recurse;
	public int splitNumber = 0;

    void Start()
    {
      
    	recurse -=1;
    	for(int i =0; i < splitNumber; i ++){

	        if(recurse > 0){
	        	
	        	var copy = Instantiate(gameObject);		
	        	var recursive = copy.GetComponent<Instantiator>();
	        	
	        	recursive.SendMessage("Generated",i);
	        }
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
