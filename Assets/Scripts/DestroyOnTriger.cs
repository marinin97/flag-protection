using UnityEngine;
using System.Collections;

public class DestroyOnTriger : MonoBehaviour
{
    public GameObject[] KillObjects;
    public GameObject[] RotateObjects;

    private Animator[] _thornsObjectAnimator;

    private void Awake()
    {       
       _thornsObjectAnimator = new Animator[KillObjects.Length];

        for (int i = 0; i < KillObjects.Length; i++)
        {
            _thornsObjectAnimator[i] = KillObjects[i].GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            foreach (var animator in _thornsObjectAnimator)
            {
                animator.SetBool("target", true);
            }

            StartCoroutine(DeActivateAnimation());

            foreach (var obj in RotateObjects)
            {
                var rotateObj = obj.GetComponent<RotateObjects>();
                if (rotateObj != null)
                {
                    rotateObj.ActivateRotation(obj.transform);
                }
            }
        }
    }

    private IEnumerator DeActivateAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (var animator in _thornsObjectAnimator)
        {
            animator.SetBool("target", false);
        }
    }
}
