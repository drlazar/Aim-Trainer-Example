using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Text totalShots;
    public Text accuracy;
    public GameObject target;
    int shots = 0;
    float percentage = 0f;
    bool checkRaycast;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        totalShots.text = shots.ToString();
        Receiver receive = target.GetComponent<Receiver>();
        percentage = ((float)receive.hits / (float)shots) * 100;
        accuracy.text = "Accuracy: " + percentage.ToString() + "%";

        if (Input.GetMouseButtonDown(0))
        {
            shots++;
            RaycastHit hit;
            checkRaycast = Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out hit);
            if (checkRaycast)
            {
                hit.transform.SendMessage("Receive", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                this.GetComponent<AudioSource>().Play();
            }
        }
    }
}
