using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    
    public int lineSegments;
    protected Vector3 startLocation;  // vector to hold start location of each bolt, pass it LightningSource at first
    protected GameObject source; // to hold the source of the lightning bolt, benefit is moving it around and lightning moving with it
    public float lengthOfSegment; // distance between each vertex in the line 
    protected List<Vector3> positions = new List<Vector3>(); //list of positions for the bolt to receive
    private Vector3 currentPos; //where we are currently
    protected LineRenderer lineRenderer; //the original line segment
    private float seconds; //for seconds elapsed, resets every 5 seconds
  //  private int count =0;  //for time elapsed
    public Material zap; //holds the particle material 
    private List<LineRenderer> allBolts = new List<LineRenderer>(); //will be a collection of all bolts currently displayed


    void Start()
    {
    	
        lineRenderer = gameObject.AddComponent<LineRenderer>(); //stays because it basically is a reference to a component
    //    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
   //     Random.InitState(42);
        seconds = 0.0f;
		        // A simple 2 color gradient with a fixed alpha of 1.0f.
              
        
    //   print(lineRenderer);
	    lineRenderer.material= zap;


    
        source = GameObject.Find("LightningSource");  // set the source of the lightning to the source object
        startLocation = source.transform.position;  //save the startLocation for the lightning bolt
       // print("start location "+ startLocation);// some debugging

        positions.Add(startLocation); //add the initial location to our position array which will be edited behind the scenes
        currentPos = startLocation; // this saves the current position to our startLocation initially;
        generatePositions(startLocation); //generating the first line based on the initial vertex of the source object
        Vector3 testLocal= new Vector3(1.0f,2.0f,3.0f);
           generatePositions(testLocal);
        lineRenderer.positionCount = positions.Count;
        lineRenderer.positionCount=lineSegments;
        lineRenderer.SetPosition(0, startLocation);
        for (int i = 1; i < lineSegments; i++)

        {
            lineRenderer.SetPosition(i, positions[i-1]);
        }
        allBolts.Add(lineRenderer);
      //  print(line)
        print(allBolts + "bolts list");
        //updateLineRenderer();
        


   		 


    }

    void Update() //will just iterate over time and do stuff everything in here will change
    {
     //   LineRenderer lineRenderer = GetComponent<LineRenderer>();
       	
    	//print(Time.deltaTime);
		seconds += Time.deltaTime;
    	/*if(seconds>=2.0){
    		count ++;
    		print("2s have passed " + count);
    		seconds = 0;
    		generatePositions(startLocation);
    	//updateLineRenderer();
    	}*/
     	
    }

    void generatePositions(Vector3	startLocation)   //take in an initial vertex for a new line renderer
    //create the line renderer
    //randomize vertices to an extent
    //give it a material
    //add it to the List of all the bolts 

    {
        LineRenderer newLine = gameObject.AddComponent<LineRenderer>();;
        newLine.positionCount = 6;
        allBolts.Add(newLine);
    	//Vector3 newLocation;
    	positions.Clear();
    	//int pos = (int)Random.Range(10.0f,18.0f);

        int pos =4;  //4 set positions for now
        float chanceToArc = Random.value;
      //  print(chanceToArc + "chance to Arc ");
  
    	

    	 for( int i = 0; i <= pos; i ++){
    	   float locX = Random.Range(-1.0f,1.0f);
    	   positions.Add(currentPos = new Vector3(currentPos.x - locX,currentPos.y -lengthOfSegment,currentPos.z));
        }
        currentPos = startLocation;
    }

  /* void updateLineRenderer(){   // likely archaic and going away soon
    	lineRenderer.positionCount=lineSegments;
    	lineRenderer.SetPosition(0, startLocation);
    	for (int i = 1; i < lineSegments; i++)

        {
        	lineRenderer.SetPosition(i, positions[i-1]);
        }
               
    }*/

}
