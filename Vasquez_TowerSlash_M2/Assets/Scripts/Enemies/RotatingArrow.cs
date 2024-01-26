using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public enum thisEnemyType{
    red,
    green, 
    yellow
}


public class RotatingArrow : MonoBehaviour
{
    public bool isRotating = true;
    int degrees;
    float timeElapsed;
    float spriteChangeInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ArrowRotation());
    }

    // Update is called once per frame
    void Update()
    {
        //if (thisEnemyType == enemyType.yellow)
        //{
        //    timeElapsed += Time.deltaTime;
        //    if (timeElapsed >= spriteChangeInterval)
        //    {
        //        int randomizedRange = Random.Range(0, 4);
        //        this.gameObject.GetComponent<SpriteRenderer>().sprite = reverseSprite[randomizedRange];
        //        timeElapsed = 0f;
        //    }
        //}
    }

    IEnumerator ArrowRotation()
    {
        if (isRotating == true)
        {
            degrees = 90;
            transform.eulerAngles = Vector3.forward * degrees;
            yield return new WaitForSeconds(1f);

            degrees = 180;
            transform.eulerAngles = Vector3.forward * degrees;
            yield return new WaitForSeconds(1f);

            degrees = 270;
            transform.eulerAngles = Vector3.forward * degrees;
            yield return new WaitForSeconds(1f);

            degrees = 360;
            transform.eulerAngles = Vector3.forward * degrees;
            yield return new WaitForSeconds(1f);

            degrees = 0;

            StartCoroutine(ArrowRotation());

        }
    }
}
