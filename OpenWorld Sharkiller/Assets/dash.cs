using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Configuration du Dash")]
    [SerializeField] private float dashForce = 25f;       // Force de l'impulsion
    [SerializeField] private float dashDuration = 0.2f;    // Durée pendant laquelle la vitesse est maintenue
    [SerializeField] private float dashCooldown = 1f;      // Temps d'attente entre deux dashs
    [SerializeField] private KeyCode dashKey = KeyCode.LeftShift;

    private Rigidbody rb;
    private bool isDashing = false;
    private bool canDash = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Détection de la touche de Dash
        if (Input.GetKeyDown(dashKey) && canDash && !isDashing)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        canDash = false;
        isDashing = true;

        // Récupère les entrées de déplacement (Z, Q, S, D ou Fleches)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Calcule la direction globale
        Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;

        // Si le joueur ne touche à aucune touche de direction, on dash vers l'avant du personnage
        if (direction == Vector3.zero)
        {
            direction = transform.forward;
        }

        // Sauvegarde la vitesse actuelle pour la restaurer après le dash (optionnel)
        Vector3 previousVelocity = rb.linearVelocity;

        // Applique l'impulsion du Dash
        rb.linearVelocity = direction * dashForce;

        // Attend la fin du dash
        yield return new WaitForSeconds(dashDuration);

        // Remet la vitesse d'origine (ou zéro pour arrêter net)
        rb.linearVelocity = Vector3.zero;
        isDashing = false;

        // Attend le temps de recharge (Cooldown)
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}