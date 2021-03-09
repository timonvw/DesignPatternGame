using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 startCameraPosition;
    private float shakeForce;
    public Camera mainCamera;
    public Transform player;

    // Start is called before the first frame update
    private void Start() {
        startCameraPosition = new Vector3(0,0,-10);
    }

    // Follow the player with the camera
    private void Update() {
         // transform.position = new Vector3(player.position.x, player.position.y, -10);
    }

    public void Shake(float force) {
        shakeForce = force;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);
    }

    // Shake the camera by moving the pos
    private void CameraShake() {
        if(shakeForce > 0) {
            float randomForce = Random.value * shakeForce * 2 - shakeForce;
            Vector3 pos = mainCamera.transform.position;
            pos.y += randomForce;
            mainCamera.transform.position = pos;
        }
    }

    // Stop camera shape and return to normal pos
    private void StopShaking() {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = startCameraPosition;
    }
}
