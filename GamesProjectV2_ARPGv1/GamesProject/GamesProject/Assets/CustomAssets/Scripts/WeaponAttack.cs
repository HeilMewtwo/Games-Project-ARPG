using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponAttack : MonoBehaviour
{
    public Slider StaminaBar;
    public bool CanAttack = true;
    public bool IsAttacking;
    public GameObject Player;
    public float Damage = 10;

    private bool _restPeriod;
    private Animator _weaponAnimatitor;
    private AnimationClip _weaponAnimation;

    // Use this for initialization
    void Start()
    {
        StaminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();
        
        _weaponAnimatitor = gameObject.GetComponent<Animator>();
        _weaponAnimation = _weaponAnimatitor.runtimeAnimatorController.animationClips[0];

        if (gameObject.transform.parent == null)
        {
            enabled = false;
        }
    }

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetMouseButtonDown(0) && CanAttack)
        {
            StartCoroutine(LaunchAttack());
            Player.GetComponent<Stamina>().StopCoroutine("Regeneration");
        }

        if (StaminaBar.value <= 10)
        {
            CanAttack = false;
            _restPeriod = true;
        }

        if (StaminaBar.value >= 55 && _restPeriod)
        {
            CanAttack = true;
            _restPeriod = false;
        }
    }

    IEnumerator LaunchAttack()
    {
        CanAttack = false;
        IsAttacking = true;
        StaminaBar.value -= 20f;
        _weaponAnimatitor.enabled = true;
        yield return new WaitForSeconds(_weaponAnimation.length);
        IsAttacking = false;
        _weaponAnimatitor.enabled = false;
        CanAttack = true;
    }

    void OnCollisionEnter (Collision other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);

        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            other.gameObject.GetComponent<EnemyHealth>().healthBar.value -= Damage;
        }
    }
}