using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour{

	public GameObject menu;
	public Text title;
	public starterHelper sh;
	public GameObject valise;
	public ScoreText score;
	public GameObject levChoice;
	public Text normalLvl;

	int curType = -1;
    // Start is called before the first frame update
    void Start(){
        menu.SetActive(false);
    }

    public void Open(int type){
    	//type, 0 - normal ; 1 - timed 30; 2 - timed 60 ; 3 - timed 120
    	if(type == 0){
    		valise.SetActive(false);
    		levChoice.SetActive(true);
    		levChoice.GetComponent<counter>().Set(LocalState.NormalLevel);
    		normalLvl.text = LocalState.NormalScore.ToString();
    	}else{
    		levChoice.SetActive(false);
    		valise.SetActive(true);
    		score.SetType(type);
    		valise.GetComponent<AnimImg>().run();
    	}
    	
    	menu.SetActive(true);
    	string[] titles = {"Normal","Timed 30'","Timed 60'","Timed 120'"};
    	title.text = titles[type];
    	curType = type;
    }

    public void Close(){
    	valise.GetComponent<AnimImg>().Close();
    	menu.SetActive(false);
    	curType = -1;
    }

    public void Play(){
    	if(curType == -1){return;}
    	switch(curType){
    		case 0:
    			sh.NormalRun(levChoice.GetComponent<counter>().Get());
    			break;
    		case 1:
    			sh.TimedRun(30);
    			break;
    		case 2:
    			sh.TimedRun(60);
    			break;
    		case 3:
    			sh.TimedRun(120);
    			break;
    	}
    }
}
