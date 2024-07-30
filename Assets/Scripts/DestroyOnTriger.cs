using UnityEngine;
using System.Collections;

public class DestroyOnTriger : MonoBehaviour
{
    public GameObject[] ThornsObject;

    private Animator[] _thornsObjectAnimator;

    private void Awake()
    {
        // Инициализация массива аниматоров
        _thornsObjectAnimator = new Animator[ThornsObject.Length];

        for (int i = 0; i < ThornsObject.Length; i++)
        {
            _thornsObjectAnimator[i] = ThornsObject[i].GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            // Активируем анимацию для всех объектов
            foreach (var animator in _thornsObjectAnimator)
            {
                animator.SetBool("target", true);
            }

            StartCoroutine(DeActivateAnimation());
        }
    }

    private IEnumerator DeActivateAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        // Деактивируем анимацию для всех объектов
        foreach (var animator in _thornsObjectAnimator)
        {
            animator.SetBool("target", false);
        }
    }
}
