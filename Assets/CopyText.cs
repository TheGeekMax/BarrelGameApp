using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyText : MonoBehaviour
{	
	public Text from;
	public Text to;

    // Update is called once per frame
    void Update()
    {
        to.text = from.text;
    }
}
