using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starterHelper : MonoBehaviour
{	
	public AudioManager am;
    public UserData ud;
    // Start is called before the first frame update
    void Awake(){
        ud.LoadData();
    }
    void Start(){
        
    	if(Stats.Sound){
            am.Play("selected");
            Stats.Sound =false;
        }
    }

    public void NormalRun(int lvl)
    {
        Stats.Sound = true;
        Stats.Level = lvl;
        Stats.Time = 0;
        Stats.Timer = false;

        LocalState.Type = 0;
        SceneManager.LoadScene("main");
    }

    // Update is called once per frame
    public void TimedRun(int time)
    {
        Stats.Sound = true;
        Stats.Level = 0;
        Stats.Time = time;
        Stats.Timer = true;
        switch(time){
            case 30:
                LocalState.Type = 1;
                break;

            case 60:
                LocalState.Type = 2;
                break;

            case 120:
                LocalState.Type = 3;
                break;
        }
        SceneManager.LoadScene("main");
    }
}
