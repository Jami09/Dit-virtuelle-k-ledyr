using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{

    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay = 0.0008f;
    public float shake_intensity = .13f;
    public GameObject egg;
    public GameObject upperHalfEgg;
    public GameObject lowerHalfEgg;
    public float speed;
    public GameObject particles;

    private float temp_shake_intensity = 0;

    private void Start()
    {
        lowerHalfEgg.SetActive(false);
        upperHalfEgg.SetActive(false);
        egg.SetActive(true);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(180, 140, 180, 120), "Open Egg"))
        {
            Shake();
            StartCoroutine(crackEgg());
        }
    }

    void Update()
    {
        if (temp_shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
                temp_shake_intensity -= shake_decay;
        }

    }

    void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = shake_intensity;
    }

    IEnumerator crackEgg()
    {
        yield return new WaitForSeconds(1);
        particles.SetActive(true);
        yield return new WaitForSeconds(1);
        
        Debug.Log("cracked");
        lowerHalfEgg.SetActive(true);
        upperHalfEgg.SetActive(true);
        egg.SetActive(false);
    }
}
