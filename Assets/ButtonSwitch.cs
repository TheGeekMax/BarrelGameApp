using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour
{	
	public Image img;
	public savedB[] infos;
	int index = 0;

	void Start(){
		int infoBegining;
		switch(infos[0].type){
    		case "sound":
    			infoBegining = Stats.Music;
    			break;

    		case "touch":
    			infoBegining = Stats.Touchtype;
    			break;
    		default:
    			infoBegining = 0;
    			break;
    	}
    	if(infoBegining != 0){
    		for(int i = 0 ; i < infos.Length; i++){
    			if(infos[i].val == infoBegining){
    				index = i;
    			}
    		}
		}
		Set();
	}
    
	void Update(){
		//Debug.Log(Stats.Music);
	}

    public void onClicked(){
    	index = (index+1)%infos.Length;
    	Set();
    }

    void Set(){
    	img.sprite = infos[index].spr;
    	switch(infos[index].type){
    		case "sound":
    			Stats.Music = infos[index].val;
    			break;

    		case "touch":
    			Stats.Touchtype = infos[index].val;
    			break;
    	}
    }
}
