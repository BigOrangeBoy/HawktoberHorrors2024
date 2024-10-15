using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class Weapon: MonoBehaviour {
    [Header("Raycast")]
    [SerializeField] LayerMask hittableLayer;
    [SerializeField] float weaponRange;

    [SerializeField] float fireRate;
    private bool canShoot = true;
    private int count = 0;

    Animator gunAnimator;

    Camera mainCam;

    void Start() {
        gunAnimator = GetComponent<Animator>();
    }

    void Awake() {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main; 
    }

    private void Update() {   
        if (Input.GetMouseButton(0) && canShoot) {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        canShoot = false;
        HandleRaycast();
        gunAnimator.SetTrigger("Shoot");

        yield return new WaitForSeconds(0.1f);  // Small delay to ensure the transition starts
        AnimatorStateInfo animationState = gunAnimator.GetCurrentAnimatorStateInfo(0);
        // Wait until the animation is done playing
        while (animationState.normalizedTime < 1.0f)
        {
            // Update the state info in each loop iteration
            animationState = gunAnimator.GetCurrentAnimatorStateInfo(0);

            // Wait for the next frame before checking again
            yield return null;
        }
        // yield return new WaitForSeconds(gunAnimator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log("Animation finished" + gunAnimator.GetCurrentAnimatorStateInfo(0).length);
        canShoot = true;
    }

    void HandleRaycast() {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit hit, weaponRange, hittableLayer)) {
            Debug.Log($"Hit a wall ({count})");
            count++;
        }
        else {
            Debug.Log($"Not hit wall ({count})");
            count++;
        }
    }


    


}