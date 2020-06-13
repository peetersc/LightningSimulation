﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePool : MonoBehaviour
{
    static int numTrees = 200;
    public GameObject treePrefab;
    public GameObject treePrefab1;
    static GameObject[] trees;

    // Start is called before the first frame update
    void Start()
    {
        trees = new GameObject[numTrees];
        for (int i = 0; i < numTrees; i++)
        {
            if (Random.Range(0,50) > 25)
            {
                trees[i] = (GameObject)Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
                trees[i].SetActive(false);
            }
            else
            {
                trees[i] = (GameObject)Instantiate(treePrefab1, Vector3.zero, Quaternion.identity);
                trees[i].SetActive(false);
            }
        }
    }

    static public GameObject getTree()
    {
        for(int i = 0; i < numTrees; i++)
        {
            if (!trees[i].activeSelf)
            {
                return trees[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}