using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthBar;
    public GameObject DeathEffect;
    public GameObject AttachedEnemy;

    private bool _launchDeath = true;
    private Color _enemyColor;
    private Material _enemyMaterial;
    private bool _restoreColor;

    // Use this for initialization
    void Start()
    {
        healthBar.value = 100;
        _enemyMaterial = AttachedEnemy.GetComponent<MeshRenderer>().material;
        _enemyColor = _enemyMaterial.color;
    }

    // Update is called once per frame
    void Update ()
    {
        if (healthBar.value <= 0)
        {
            StartCoroutine(Death());
        }

        CheckForColorRestore();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            if (other.gameObject.transform.parent.GetComponent<WeaponAttack>().IsAttacking == true)
            {
                healthBar.value -= other.transform.parent.GetComponent<WeaponAttack>().Damage;
                _enemyMaterial.color = new Color(255, 0, 0, 1);
                _restoreColor = true;
            }
        }
    }

    void CheckForColorRestore()
    {
        if (_restoreColor)
        {
            _enemyMaterial.color = Color.Lerp(_enemyMaterial.color, _enemyColor, 3f * Time.deltaTime);

            if (_enemyMaterial.color == _enemyColor)
            {
                _restoreColor = false;
            }
        }
    }

    public IEnumerator Death()
    {
        if (_launchDeath)
        {
            _launchDeath = false;
            GameObject deathEffect = Instantiate(DeathEffect, AttachedEnemy.transform.position, AttachedEnemy.transform.rotation) as GameObject;
            yield return new WaitForSeconds(1);
            Destroy(AttachedEnemy);
        }
    }
}
