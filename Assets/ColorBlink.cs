using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlink : MonoBehaviour
{	

	public int delay;
	public Sprite[] pics;
	public SpriteRenderer render;
	bool running = false;
	int curIndex = 0,curTick = 0;

    // Update is called once per frame
    void Update()
    {
        if(!running){return;}
        curTick ++;
        if(curTick == delay){
        	curTick = 0;
        	curIndex = (curIndex+1)%pics.Length;
        	render.sprite = pics[curIndex];
        }
    }

    public void Run(){
    	running = true;
    }
}
