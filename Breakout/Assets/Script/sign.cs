using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour
{

    public GameObject dialogb;
    public Text dialogt;
    public string dialog;
    public bool dialogAct;
    public bool playerinrange;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ControlFreak2.CF2Input.GetKeyDown(KeyCode.Space) && playerinrange )
        {
            if(dialogb.activeInHierarchy)
            {
                dialogb.SetActive(false);
            }
            else
            {
                dialogb.SetActive(true);
                dialogt.text = dialog;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerinrange = false;
            dialogb.SetActive(false);
        }
    }
}
