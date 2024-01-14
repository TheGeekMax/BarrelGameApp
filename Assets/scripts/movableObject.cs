﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movableObject : MonoBehaviour
{	
	public int id;

	Vector3 targetPos;

	void Start(){
		targetPos = GetComponent<Transform>().position;
	}
	void FixedUpdate(){
		GetComponent<Transform>().position = new Vector3(Mathf.Lerp(GetComponent<Transform>().position.x, targetPos.x,.3f),Mathf.Lerp(GetComponent<Transform>().position.y, targetPos.y,.3f),0);
	}

	public void setPositionInstant(Vector3 pos){
		gameObject.GetComponent<Transform>().position = pos;
		targetPos = pos;
	}

	public void setPosition(Vector3 pos){
		targetPos += pos;
	}

	public void Destroy(){
		GetComponent<Animator>().SetBool("end",true);
		GetComponent<ColorBlink>().Run();
		Destroy(gameObject,1f);
	}
}
