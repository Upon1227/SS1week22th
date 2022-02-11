using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealManager : MonoBehaviour
{
    Text mytext;
    public float[] num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        mytext.text = num[Random.Range(1, 10)].ToString();  
    }


    public float span = 3f;

    void Start()
    {
        StartCoroutine("Logging");
        mytext = GetComponent<Text>();
    }

    IEnumerator Logging()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            mytext.text = num[Random.Range(1, 10)].ToString();
        }
    }
}
