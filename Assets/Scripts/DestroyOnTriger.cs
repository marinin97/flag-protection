using UnityEngine;
using System.Collections;

public class DestroyOnTriger : MonoBehaviour
{
    public GameObject ThornsObject;

    private Animator _thornsObjectAnimator;

    private void Awake()
    {
        _thornsObjectAnimator = ThornsObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            _thornsObjectAnimator.SetBool("target", true);
            StartCoroutine(DeActivateAnimation());
        }
    }
    private IEnumerator DeActivateAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        _thornsObjectAnimator.SetBool("target", false);
    }
}
