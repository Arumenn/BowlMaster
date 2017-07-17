using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {
        foreach(Text t in rollTexts) {
            t.text = "";
        }
        foreach(Text t in frameTexts) {
            t.text = "";
        }
	}

    public void FillRolls(List<int> rolls) {
        string scoresString = FormatRolls(rolls);
        for (int i = 0; i < scoresString.Length; i++) {
            rollTexts[i].text = scoresString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames) {
        for (int i = 0; i < frames.Count; i++) {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls) {
        string output = "";
        int box;

        for (int i = 0; i < rolls.Count; i++) {
            box = output.Length + 1;
            if (rolls[i] == 0) {                                            
                output += "-";                                              //Always enter 0 as -
            } else if (((box % 2 == 0) || (box == 21)) && (rolls[i - 1] + rolls[i] == 10)) {    
                output += "/";                                              //SPARE
            } else if (box >= 19 && rolls[i] == 10) {
                output += "X";                                              //STRIKE in frame 10 (so no space)
            }else if (rolls[i] == 10) {
                output += "X ";                                             //STRIKE in 1-9 (with space)
            } else {
                output += rolls[i].ToString();                              //normal 1-9
            }
        }

        return output;
    }
}
