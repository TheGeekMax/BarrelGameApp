using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{	
	public Text num;
	int cur = 0;

	void Start(){
		num.text = cur.ToString();
	}

	public void Plus(){
		cur ++;
		if(cur > LocalState.NormalLevel){cur = LocalState.NormalLevel;}
		num.text = cur.ToString();
	}

	public void Minus(){
		cur --;
		if(cur < 0){cur = 0;}
		num.text = cur.ToString();
	}

	public void Set(int newLevel){
		cur = newLevel;
		num.text = cur.ToString();
	}

	public int Get(){
		return cur;
	}
}
