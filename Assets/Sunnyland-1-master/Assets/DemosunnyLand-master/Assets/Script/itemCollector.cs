using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    // Start is called before the first frame update
    private int carrot = 0;
    public AudioSource collect;
    public Text carrotText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Carrot"))
        {
            collect.Play();
            Destroy(collision.gameObject);
            carrot ++;
            carrotText.text = "Carrot" + carrot;
        }
    }
}
