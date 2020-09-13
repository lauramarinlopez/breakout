using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

    public bool gun = false;
    public int enemiesdied=0;
    bool flag = true;

    [SerializeField]
    GameObject playerGun;

    [SerializeField]
    GameObject complPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(enemiesdied);
		if(enemiesdied >= 8 && flag)
        {
            flag = false;
            complPanel.SetActive(true);
        }
	}

    public void exchangeWeaons()
    {
        if(gun == false)
        {
            gun = true;
            playerGun.SetActive(true);
        }
        else if(gun == true)
        {
            gun = false;
            playerGun.SetActive(false);
        }
    }

}
