using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{	
	public GameObject score;
	public AnimImg ended;
	int type = 0;
    // Start is called before the first frame update
    void Awake()
    {
		score.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if(ended.Running()){
        	score.SetActive(true);
        	if(type == 0){return;}
        	score.GetComponent<Text>().text = LocalState.Score[type -1].ToString();
        }else{
        	score.SetActive(false);
        }
    }

    public void SetType(int t){
    	type = t;
    }
}
