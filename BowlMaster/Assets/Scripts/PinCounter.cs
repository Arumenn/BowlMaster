using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;

    private GameManager gameManager;

    // Use this for initialization
    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay) {
            standingDisplay.color = Color.red;
            UpdateStandingCountAndSettle();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Ball") {
            ballOutOfPlay = true;
        }
    }

    int CountStanding() {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                standing++;
            }
        }

        return standing;
    }

    void UpdateStandingCountAndSettle() {
        //Update the lastStandingCount
        //Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; //3 seconds to wait for settle
        if (Time.time - lastChangeTime > settleTime) {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled() {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    public void Reset() {
        lastSettledCount = 10;
    }
}
