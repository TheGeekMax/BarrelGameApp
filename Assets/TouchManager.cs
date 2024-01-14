using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{	

	public int touchtype;
	[Header("ajouts")]
	public master ms;
	public Camera cam;

	public ButtonActuator paus;
	public GameObject buttonUi;

	int begX, begY, endX, endY;
    Vector3 end;
    bool buttonActivated = false;

	Vector3 savedBegin;

    void Start(){
    	touchtype = Stats.Touchtype;
    }

    void Update()
    {	
    	if(paus.IsActivated()){return;}
    	if(!ms.IsRunning()){return;}

    	buttonActivated = false;

    	switch(touchtype){
    		case 0:
	    		//souris
	    		if(Input.GetMouseButtonDown(0)){
		            savedBegin = cam.ScreenToWorldPoint(Input.mousePosition);
		        }

		        if(Input.GetMouseButtonUp(0) && savedBegin.y < 4){
		        	

        			begX = (int)Mathf.Floor(savedBegin.x+3);
		            begY = (int)Mathf.Floor(savedBegin.y+3);
		    		end = cam.ScreenToWorldPoint(Input.mousePosition);
		            endX = (int)Mathf.Floor(end.x+3);
		            endY = (int)Mathf.Floor(end.y+3);

		            if(begX >= 0 && begX < 6 && begY >= 0 && begY < 6 && begX == endX && begY == endY){
		            	SetCursor();
		            }else{
		            	MoveBarrils();
		            }
				}
		        break;
		    case 1:
		    	//touch clasique
		    	if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
		        	Touch touch = Input.GetTouch(0);
		        	savedBegin = cam.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,0));
		        }

		        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && savedBegin.y < 4){
		        	Touch touch = Input.GetTouch(0);
	            	begX = (int)Mathf.Floor(savedBegin.x+3);
		            begY = (int)Mathf.Floor(savedBegin.y+3);
		    		end = cam.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,0));
		            endX = (int)Mathf.Floor(end.x+3);
		            endY = (int)Mathf.Floor(end.y+3);

		            if(begX >= 0 && begX < 6 && begY >= 0 && begY < 6 && begX == endX && begY == endY){
		            	SetCursor();
		            }else{
		            	MoveBarrils();
		            }
		        }
		        break;
		    case 2:
		    	//bouton a l'ecran
		    	buttonActivated = true;
		    	break;
    	}
    	buttonUi.SetActive(buttonActivated);
    }

    void SetCursor(){
    	ms.SetHor(begX);
        ms.SetVer(begY);
    }

    void MoveBarrils(){
    	float lX = end.x - savedBegin.x;
    	float lY = end.y - savedBegin.y;

    	if(lX >= 0 && lY >= 0){
    		if(lX < lY){
    			ms.mColumn();
    		}else{
    			ms.pLine();
    		}
    	}else if(lX < 0 && lY >= 0){
    		if(lX*-1 < lY){
    			ms.mColumn();
    		}else{
    			ms.mLine();
    		}
    	}else if(lX >= 0 && lY < 0){
    		if(lX < lY*-1){
    			ms.pColumn();
    		}else{
    			ms.pLine();
    		}
    	}else if(lX < 0 && lY < 0){
    		if(lX*-1 < lY*-1){
    			ms.pColumn();
    		}else{
    			ms.mLine();
    		}
    	}
    }
}
