using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangePos : MonoBehaviour
{	
	public UserData ud;
	public master ms;
    public void ChangePlace(string place){
    	if(LocalState.Type == 0){
    		//mode normal
    		LocalState.NormalScore = ms.scorepts;
    		if(LocalState.NormalLevel < ms.level){
    			LocalState.NormalLevel = ms.level;
    		}
    	}else{
    		//mode timed
    	}

        if(LocalState.Type == 0 || ms.QuitEnabled() || ms.isPlaying()){
    	   ud.SaveData();
    	   SceneManager.LoadScene(place);
        }
    }
}
