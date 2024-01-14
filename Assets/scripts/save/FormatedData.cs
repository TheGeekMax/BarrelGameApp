using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FormatedData{
    //pour 30 sec , 60 sec et 120 sec
    public int[] score;
    
    //pour mode normal
    public int normalScore;
    public int normalLevel;

    //les options
    public int soundValue;
    public int touchValue;


    public FormatedData(UserData player){
		//pour 30 sec , 60 sec et 120 sec
	    score = player.score;
	    
	    //pour mode normal
	    normalScore = player.normalScore;
	    normalLevel = player.normalLevel;

	    //les options
	    soundValue = player.soundValue;
	    touchValue = player.touchValue;
	}
}
