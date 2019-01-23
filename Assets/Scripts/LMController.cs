using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMController : MonoBehaviour {
    public bool hasIceSpell = false;
    public bool hasFireSpell = false;
    public bool hasWindSpell = true;
    public static LMController instance;
 

    // Use this for initialization
    private void Awake()
    {
        instance = this; 
    }

   
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
