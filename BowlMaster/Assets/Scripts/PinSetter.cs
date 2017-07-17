using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;

    private PinCounter pinCounter;
    private Animator animator;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    public void RaisePins() {
        foreach(Pin pin in FindObjectsOfType<Pin>()) {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins() {
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }

    public void RenewPins() {
        Debug.Log("Renewing pins");
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 40f, 0);
        pinSet = newPins;
    }

    public void PerformAction(ActionMaster.Action action) {
        switch (action) {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.Reset:
                animator.SetTrigger("resetTrigger");
                pinCounter.Reset();
                break;
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                pinCounter.Reset();
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Don't know how to end yet");
        }
    }
}
