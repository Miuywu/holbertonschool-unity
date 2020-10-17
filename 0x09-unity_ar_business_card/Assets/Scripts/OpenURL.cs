using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public string url;
    public AudioSource buttonClick;
    public void Open()
    {
        buttonClick.Play();
        Application.OpenURL(url);
    }
    
    /*public void ButtonClick()
	{
		buttonClick.Play();
	}*/
}
