using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceGenerator : MonoBehaviour
{
	public Lightning_Spawn Lightning_Spawn;

	private Vector3 sourcePosition;

	public GameObject Rain;

    // Start is called before the first frame update
    void Start()

    {
    	Instantiate(Lightning_Spawn,sourcePosition,Quaternion.identity,this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
