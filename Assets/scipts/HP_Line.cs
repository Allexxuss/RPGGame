using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Line : MonoBehaviour {

    public float HP = 100f;
    float startHP;
    public Image imgHP, imgSkill;


	void Start () {
        startHP = HP;


    }
	
	// Update is called once per frame
	void Update () {
        float scaleX = HP/startHP;
        float scalered = 0;
        imgHP.transform.localScale = new Vector3(scaleX, 1, 1);
        scalered += (1 - scaleX) * 2;
        imgHP.color = new Color(scalered, scaleX, 0, 1);		
	}
}
