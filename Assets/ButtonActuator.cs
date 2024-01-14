using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActuator : MonoBehaviour
{	
	public GameObject content;
	bool activated = false;

	void Start(){
		content.SetActive(false);
	}

    public void Open(){
    	content.SetActive(true);
    	activated = true;
    }

    public void Close(){
		content.SetActive(false);
		activated = false;
    }

    public bool IsActivated(){
    	return activated;
    }
}
