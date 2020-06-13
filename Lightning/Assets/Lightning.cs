using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
   private LineRenderer lineRenderer;

   
   public int numSegs= 12;

   private Color color = Color.white;

    private GameObject source;

   private Vector3 sourcePosition;

   private Vector3 currentPos; //where we are currently

   private float maxDif; //holds 1/2 range of values that vertex can change from point to point


    void Start()
    {
    	lineRenderer = GetComponent<LineRenderer>();
    	maxDif = 1.5f;
    	print("transform test" + lineRenderer.transform);
    	lineRenderer.positionCount = numSegs;

    	source = this.transform.parent.gameObject;  // set the source of the lightning to the source object
        sourcePosition= source.transform.position;
        currentPos = sourcePosition;
     //   print(sourcePosition);
        
        //generate the line segments in the line
       

        for(int i = 1; i < numSegs; ++i){
    		float locX = Random.Range(-1.6f,1.6f);
    		lineRenderer.SetPosition(i,currentPos = new Vector3(currentPos.x - locX,currentPos.y - Random.Range(1.0f,2.0f),currentPos.z - Random.Range(-1.0f,1.0f)));
			
		}
    	
    	lineRenderer.SetPosition(0,sourcePosition); //set initial position to the position of the transform of the lightning source
    	
        
    }

    // Update is called once per frame
  void Update()

    {
	
      color.a -= 1.5f * Time.deltaTime;
      lineRenderer.SetColors(color,color);
    	if(color.a <= 0f && this.gameObject){
    		Destroy(this.gameObject);
    	}    
    }
}

