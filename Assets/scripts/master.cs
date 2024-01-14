using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class master : MonoBehaviour
{	
	public GameObject[] barrels;
	public GameObject parent;
	public GameObject horLine, verLine;
	public Text score;
    public Text lvl;
    public Text time;
    public GameObject tot;
    public UserData ud;

    [Header("level :")]
    public int level = 0;
    int curInd = 0;
    public level[] levels;
    int l;

	public int scorepts = 0;
	int scoreTps = 0;
    public AudioManager am;

    [Header("time system :")]
    public bool activated = true;
    public float timeLeft = 60;
    bool gameRunning =true;

    [Header("lose system")]
    public ButtonActuator paus;
    public GameObject[] actu;

	GameObject[,] mains = new GameObject[6,6];
	int curLine = 5,curColumn = 0;
	int savedHor = 0, savedVer = 0;
	int savedObjHor = 0, savedObjVer = 0;

    bool quitEn = false;
    bool playing = true;
    // Start is called before the first frame update
    void Start()
    {	
    	am.Play("playMusic");
        if(LocalState.Type == 0){
            scorepts = LocalState.NormalScore;
        }
        if(Stats.Sound){
            am.Play("selected");
            Stats.Sound =false;
        }
        level = Stats.Level;
        activated = Stats.Timer;
        timeLeft = Stats.Time;
        timeLeft +=1;
    	LoadLevel();
    }

    // Update is called once per frame
    void Update()  
    {	
        if(!gameRunning){return;}
        if(activated){
            timeLeft -= Time.deltaTime;
            tot.SetActive(false);
        }else{
            time.GetComponent<Transform>().parent.gameObject.SetActive(false);
            tot.SetActive(true);
        }
    	scoreTps = 0;
    	score.text = scorepts.ToString();
        lvl.text = level.ToString();
        time.text = ((int)timeLeft).ToString();

        if(timeLeft<=0){
            gameRunning = false;
            Lose();
        }

        float curHor = Input.GetAxisRaw("moveHor");
        float curVer = Input.GetAxisRaw("moveVer");

        if(curHor != savedHor){
        	savedHor = (int)curHor;
        	MoveHor(savedHor);
        }

        if(curVer != savedVer){
        	savedVer = (int)curVer;
        	MoveVer(savedVer);
        }

        float curObjHor = Input.GetAxisRaw("objHor");
        float curObjVer = Input.GetAxisRaw("objVer");

        if(curObjHor != savedObjHor){
        	savedObjHor = (int)curObjHor;
        	if(savedObjHor != 0)
        	horLine.GetComponent<animSprite>().run();

        	switch(savedObjHor){
        		case -1:
        			MagnetLine(curLine);
        			break;

        		case 1:
					PullLine(curLine);
        			break;
        	}
        }

        if(curObjVer != savedObjVer){
        	savedObjVer = (int)curObjVer;
        	if(savedObjVer != 0)
        	verLine.GetComponent<animSprite>().run();

        	switch(savedObjVer){
        		case -1:
        			PullColumn(curColumn);
        			break;

        		case 1:
					MagnetColumn(curColumn);
        			break;
        	}
        }

        //test si ligne
        LineTest();

        //test si colonnes
 		ColumnTest();   

 		scorepts += scoreTps;
 		//test si vide
 		for(int i = 0 ; i < 6; i++){
 			for(int j = 0 ; j < 6; j++){
 				if(mains[i,j] != null){return;}
 			}
 		}
        level++;
 		LoadLevel();
    }

    public bool QuitEnabled(){
        return quitEn;
    }

    public bool IsRunning(){
        return gameRunning;
    }

    public bool isPlaying(){
    	return playing;
    }

    void Lose(){
    	playing = false;
        int curT = LocalState.Type -1;
        if(LocalState.Score == null){
            LocalState.Score = new int[3];
        }
        if(scorepts > LocalState.Score[curT]){
            //new high score
            LocalState.Score[curT] = scorepts;
        }
        paus.Open();
        for(int i = 0 ; i < actu.Length; i++){
            actu[i].SetActive(!actu[i].activeSelf);
        }
        //mettre quitEn en true 1 sec après
         Invoke("ActivateQuit", 1);
    }

    void ActivateQuit(){
        quitEn = true;
    }

    void LoadLevel(){
        l = levels.Length;
        if(curInd+1 < l && levels[curInd+1].minLevel <= level){
            while(curInd < l-1 && levels[curInd+1].minLevel <= level){
                curInd++;
            }
        }
        Generate(levels[curInd].nbColors,levels[curInd].nbLines);
    }

    void LineTest(){
    	for(int i = 0 ; i < 6; i ++){
        	if(mains[0,i] != null){
        		int chooseId = mains[0,i].GetComponent<movableObject>().id;
        		for(int j = 0 ; j < 6 ; j ++){
        			if(mains[j,i] == null){break;}
        			int cur = mains[j,i].GetComponent<movableObject>().id;
        			if(cur != chooseId){break;}
        			if(j == 5){
        				clearLine(i);
        			}
        		}
        	}
        }
    }

    void ColumnTest(){
    	for(int i = 0 ; i < 6; i ++){
        	if(mains[i,0] != null){
        		int chooseId = mains[i,0].GetComponent<movableObject>().id;
        		for(int j = 0 ; j < 6 ; j ++){
        			if(mains[i,j] == null){break;}
        			int cur = mains[i,j].GetComponent<movableObject>().id;
        			if(cur != chooseId){break;}
        			if(j == 5){
        				clearColumn(i);
        			}
        		}
        	}
        }
    }

    public void MoveHor(int v){
        if(v!=0){am.Play("line");}
    	curColumn += v;
        if(curColumn < 0){curColumn = 0;}
        if(curColumn > 5){curColumn = 5;}
    	verLine.GetComponent<selectLine>().setPosition(new Vector3(curColumn-2.5f,0,0));
    }

    public void MoveVer(int v){
        if(v!=0){am.Play("line");}
    	curLine += v;
        if(curLine < 0){curLine = 0;}
        if(curLine > 5){curLine = 5;}
    	horLine.GetComponent<selectLine>().setPosition(new Vector3(0,curLine-2.5f,0));
    }

    public void SetHor(int v){
        am.Play("line");
        curColumn = v;
        verLine.GetComponent<selectLine>().setPosition(new Vector3(curColumn-2.5f,0,0));
    }

    public void SetVer(int v){
        am.Play("line");
        curLine = v;
        horLine.GetComponent<selectLine>().setPosition(new Vector3(0,curLine-2.5f,0));
    }

    public void pLine(){
        horLine.GetComponent<animSprite>().run();
    	PullLine(curLine);
    }

    public void mLine(){
        horLine.GetComponent<animSprite>().run();
    	MagnetLine(curLine);
    }

    public void pColumn(){
        verLine.GetComponent<animSprite>().run();
    	PullColumn(curColumn);
    }

    public void mColumn(){
        verLine.GetComponent<animSprite>().run();
    	MagnetColumn(curColumn);
    }

    void AddPoint(){
    	if(scoreTps == 0){
    		scoreTps =1;
    	}else{
    		scoreTps *= 3;
    	}
    }

    void clearLine(int li){
        am.Play("lineclear");
    	AddPoint();
    	for(int i = 0 ; i < 6; i ++){;
    		mains[i,li].GetComponent<movableObject>().Destroy();
    		mains[i,li] = null;
        }
    }

    void clearColumn(int co){
        am.Play("lineclear");
    	AddPoint();
    	for(int i = 0 ; i < 6; i ++){
    		mains[co,i].GetComponent<movableObject>().Destroy();
    		mains[co,i] = null;
        }
    }

    void Generate(int nbColors,int[] lines){
    	int[,] cur = new int[6,6];

    	//etape 1 remplissage de base
    	for(int i = 0 ; i < 6; i++){
			for(int j = 0 ; j < 6; j++){
				cur[i,j] = 0;
			}
		}

		int gInd = 0;
		for(int i = 0 ; i < nbColors; i++){
			for(int j = 0 ; j < lines[i]; j++){
				for(int k = 0 ; k < 6; k++){
					cur[gInd,k] = i+1;
				}
				gInd ++;
			}
		}

		//randomisage
		for(int a = 0 ; a < 200; a ++){
			int or = (int)Random.Range(0,3.99f); //0 - hor att, 1 - hor push 2 - ver att , 3 - ver push
			int num = (int)Random.Range(0,5.99f);
			switch(or){
				case 0:
					for(int i = 0 ; i < 6; i++){
						for(int j = 1 ; j < 6; j++){
							if(cur[j-1,num] == 0){
								cur[j-1,num] = cur[j,num];
								cur[j,num] = 0;
							}
						}
					}
					break;

				case 1:
					for(int i = 0 ; i < 6; i++){
						for(int j = 4 ; j >= 0; j--){
							if(cur[j+1,num] == 0){
								cur[j+1,num] = cur[j,num];
								cur[j,num] = 0;
							}
						}
					}
					break;

				case 2:
					for(int i = 0 ; i < 6; i++){
						for(int j = 1 ; j < 6; j++){
							if(cur[num,j-1] == 0){
								cur[num,j-1] = cur[num,j];
								cur[num,j] = 0;
							}
						}
					}
					break;

				case 3:
					for(int i = 0 ; i < 6; i++){
						for(int j = 4 ; j >= 0; j--){
							if(cur[num,j+1] == 0){
								cur[num,j+1] = cur[num,j];
								cur[num,j] = 0;
							}
						}
					}
					break;
			}
		}

		//remplissage
		for(int i = 0 ; i < 6; i++){
			for(int j = 0 ; j < 6; j++){
				if(cur[i,j] >0)
				InsertBarrel(i,j,cur[i,j]-1);
			}
		}
    }

    void InsertBarrel(int x,int y,int id){
    	GameObject current = Instantiate(barrels[id],new Vector3(x-2.5f,y-2.5f,0),Quaternion.identity,parent.GetComponent<Transform>());
    	mains[x,y] = current;
    }

    void MagnetLine(int line){
        am.Play("barril");
    	for(int i = 0 ; i < 6; i++){
			for(int j = 1 ; j < 6; j++){
				if(mains[j-1,line] == null){
					if(mains[j,line] != null)
					mains[j,line].GetComponent<movableObject>().setPosition(new Vector3(-1,0,0));
					mains[j-1,line] = mains[j,line];
					mains[j,line] = null;
				}
			}
		}
    	
    }

    void PullLine(int line){
        am.Play("barril");
    	for(int i = 0 ; i < 6; i++){
			for(int j = 4 ; j >= 0; j--){
				if(mains[j+1,line] == null){
					if(mains[j,line] != null)
					mains[j,line].GetComponent<movableObject>().setPosition(new Vector3(1,0,0));

					mains[j+1,line] = mains[j,line];
					mains[j,line] = null;
				}
			}
		}
    }

    void PullColumn(int cols){
        am.Play("barril");
    	for(int i = 0 ; i < 6; i++){
			for(int j = 1 ; j < 6; j++){
				if(mains[cols,j-1] == null){
					if(mains[cols,j] != null)
					mains[cols,j].GetComponent<movableObject>().setPosition(new Vector3(0,-1,0));

					mains[cols,j-1] = mains[cols,j];
					mains[cols,j] = null;
				}
			}
		}
    }

    void MagnetColumn(int cols){
        am.Play("barril");
    	for(int i = 0 ; i < 6; i++){
			for(int j = 4 ; j >= 0; j--){
				if(mains[cols,j+1] == null){
					if(mains[cols,j] != null)
					mains[cols,j].GetComponent<movableObject>().setPosition(new Vector3(0,1,0));

					mains[cols,j+1] = mains[cols,j];
					mains[cols,j] = null;
				}
			}
		}
	}


    public void PlaysOnLoad(){
        Stats.Sound = true;
    }
}
