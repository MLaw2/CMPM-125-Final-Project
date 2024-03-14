using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaulting : MonoBehaviour
{
    // Start is called before the first frame update
    private int vaultLayer;
    public Camera cam;
    private float playerHeight = 2f;
    private float playerRadius = 0.5f;
    void Start()
    {
        vaultLayer = LayerMask.NameToLayer("VaultLayer");
        vaultLayer = ~vaultLayer;
    }

    // Update is called once per frame
    void Update()
    {
        Vault();
    }
    private void Vault()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var firstHit, 1f, vaultLayer))
            {
                print("vaultable in front");

                // Calculate vault point
                Vector3 vaultPoint = firstHit.point + (Vector3.up * playerHeight);

                // Perform a raycast to find a landing position
                if (Physics.Raycast(vaultPoint + (cam.transform.forward * playerRadius), Vector3.down, out var secondHit, playerHeight))
                {
                    print("found place to land");

                    // Calculate the end position of the vault animation
                    Vector3 endPosition = secondHit.point + (Vector3.up * 0.5f * playerHeight);

                    // Start the vault animation
                    StartCoroutine(LerpVault(endPosition, 0.5f));
                }
            }
        }
    }
    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}