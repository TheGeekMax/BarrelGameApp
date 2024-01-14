using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{	
	public int[] score;
    
    //pour mode normal
    public int normalScore;
    public int normalLevel;

    //les options
    public int soundValue;
    public int touchValue;

    public void SaveData(){
    	score = LocalState.Score;

		normalScore = LocalState.NormalScore;
		normalLevel = LocalState.NormalLevel;

		touchValue = Stats.Touchtype;
		soundValue = Stats.Music;

    	save.SavePlayer(this);
    }

	public void LoadData(){
		FormatedData data = save.LoadPlayer();
		if(data == null){return;}

		LocalState.Score = data.score;

		LocalState.NormalScore = data.normalScore;
		LocalState.NormalLevel = data.normalLevel;

		Stats.Touchtype = data.touchValue;
		Stats.Music = data.soundValue;
	}
}
