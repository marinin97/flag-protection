using System.Collections;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public void ActivateRotation(Transform objectToRotate)
    {
        StartCoroutine(RotateAndReturn(objectToRotate));
    }

    public IEnumerator RotateAndReturn(Transform objectToRotate)
    {
        float rotateSpeed = 10f;

        Quaternion endRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 
            Random.Range(0f, 360f), 0f);

        objectToRotate.rotation =
            Quaternion.Lerp(transform.rotation, endRotation, rotateSpeed);

        Quaternion initialRotation = Quaternion.Euler(0f, 0f, 0f);

        yield return new WaitForSeconds(0.5f);

        objectToRotate.rotation = initialRotation;
    }
}
