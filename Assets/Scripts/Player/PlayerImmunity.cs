using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImmunity : MonoBehaviour
{
    public float immunityDuration = 2f; // Dura��o da imunidade em segundos
    public LayerMask enemyLayer;
    public LayerMask bulletLayer;

    private Collider2D playerCollider;
    private bool isImmune = false;

    private void Start()
    {
        //bulletLayer = LayerMask.GetMask(LayerMask.LayerToName(3));
        //enemyLayer = LayerMask.GetMask(LayerMask.LayerToName(6));
        playerCollider = GetComponent<Collider2D>();
        StartCoroutine(ActivateImmunity());
    }

    private IEnumerator ActivateImmunity()
    {
        isImmune = true;

        // Desativar colis�o com inimigos e balas de inimigos
        Physics2D.IgnoreLayerCollision(gameObject.layer, enemyLayer, true);
        //Physics2D.IgnoreLayerCollision(gameObject.layer, bulletLayer, true);

        yield return new WaitForSeconds(immunityDuration);

        // Reativar colis�o com inimigos e balas de inimigos
        Physics2D.IgnoreLayerCollision(gameObject.layer, enemyLayer, false);
        //Physics2D.IgnoreLayerCollision(gameObject.layer, bulletLayer, false);

        isImmune = false;
    }

    public bool IsImmune()
    {
        return isImmune;
    }
}
