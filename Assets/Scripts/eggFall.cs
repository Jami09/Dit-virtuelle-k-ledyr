using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggFall : MonoBehaviour {

    public GameObject upperEgg;
    public Transform[] target;
    public Transform ground;
    public float speed;
    public float speedRotate;

    private int current;
	
	// Update is called once per frame
	void Update () {
        if (upperEgg.activeSelf)
        {
            Debug.Log("open egg");
            if (transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else current = (current + 1) % target.Length;

            upperEgg.transform.Rotate(Vector3.up * Time.deltaTime * speedRotate);
            upperEgg.transform.Rotate(Vector3.right * Time.deltaTime * speedRotate);
        }
	}
}
