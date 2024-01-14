using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animSprite : MonoBehaviour
{	
	public SpriteRenderer render;
	public Sprite[] sprites;
	public int upd;

	int curT = 0;
	int curI = 0;
	bool running = false;
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
        	} 
        }
        
    }


    public void run(){
    	curT = upd-1;
    	running=true;
    }
}
