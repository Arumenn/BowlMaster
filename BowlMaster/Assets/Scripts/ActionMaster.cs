using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

    public enum Action { Tidy, Reset, EndTurn, EndGame, Undefined };

    public static Action NextAction(List<int> rolls) {
        Action nextAction = Action.Undefined;

        for (int i = 0; i < rolls.Count; i++) { // Step through rolls

            if (i == 20) {
                nextAction = Action.EndGame;
            } else if (i >= 18 && rolls[i] == 10) { // Handle last-frame special cases
                nextAction = Action.Reset;
            } else if (i == 19) {
                if (rolls[18] == 10 && rolls[19] == 0) {
                    nextAction = Action.Tidy;
                } else if (rolls[18] + rolls[19] == 10) {
                    nextAction = Action.Reset;
                } else if (rolls[18] + rolls[19] >= 10) {  // Roll 21 awarded
                    nextAction = Action.Tidy;
                } else {
                    nextAction = Action.EndGame;
                }
            } else if (i % 2 == 0) { // First bowl of frame
                if (rolls[i] == 10) {
                    rolls.Insert(i, 0); // Insert virtual 0 after strike
                    nextAction = Action.EndTurn;
                } else {
                    nextAction = Action.Tidy;
                }
            } else { // Second bowl of frame
                nextAction = Action.EndTurn;
            }
        }

        return nextAction;
    }

    /*private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> pinFalls) {
        ActionMaster actionMaster = new ActionMaster();
        Action currentAction = new Action();

        foreach (int i in pinFalls) {
            currentAction = actionMaster.Bowl(i);
        }

        return currentAction;
    }

    private Action Bowl(int pins) {
        //Scoring and tracking action to take after pins have settled
        if ((pins < 0) || (pins > 10)) {
            throw new UnityException("Invalid pins");
        }

        bowls[bowl-1] = pins; //scores

        if (bowl == 21) {
            return Action.EndGame;
        }

        if (bowl >= 19 && pins == 10) {
            bowl++;
            return Action.Reset;
        } else if (bowl == 20) {
            bowl++;
            if (bowls[19-1] == 10 && bowls[20-1] == 0) {
                return Action.Tidy;
            }else if (bowls[19-1] + bowls[20-1] == 10) {
                return Action.Reset;
            }else if (Bowl21Awarded()) {
                return Action.Tidy;
            }else {
                return Action.EndGame;
            }
            
        }

        if (bowl % 2 != 0) {
            if (pins == 10) {
                bowl += 2;
                return Action.EndTurn;
            } else {
                bowl++;
                return Action.Tidy;
            }
        }else {
            bowl++;
            return Action.EndTurn;
        }
    }

    private bool Bowl21Awarded() {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }*/
}
