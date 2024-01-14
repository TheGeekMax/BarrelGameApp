using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimImg : MonoBehaviour
{
    public Image render;
	public Sprite[] sprites;
	public int upd;

	int curT = 0;
	int curI = 0;
	bool running = false;

	bool finished = false;
    // Update is called once per frame
    void FixedUpdate()
    {	
    	curT ++;
    	
    	if(running && curT == upd){
    		curT = 0;
    		render.sprite = sprites[curI];
        	curI ++;
        	if(curI == sprites.Length){
        		running = false;
        		curI = 0;
        		finished = true;
        	} 
        }
        
    }

    public bool Running(){
    	return finished;
    }

    public void run(){
    	curT = upd-1;
    	running=true;
    	finished = false;
    }

    public void Close(){
    	render.sprite = sprites[0];

    }
}
