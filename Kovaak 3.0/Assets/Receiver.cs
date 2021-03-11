using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receiver : MonoBehaviour
{
    public Text totalHits;
    public int hits = 0;

    private void Start()
    {
        this.transform.position = new Vector3(-36.71f, 1.5f, 3);
    }

    public void Receive()
    {
        hits++;
        totalHits.text = hits.ToString();
        this.gameObject.GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
        this.transform.position = new Vector3(-36.71f, Random.Range(-1.5f, 4.5f), Random.Range(-1.1f, 6.9f));
        gameObject.SetActive(true);
    }
}
