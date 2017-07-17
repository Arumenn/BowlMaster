using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster {

    //like a normal score card
    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    //individual frame scores
    public static List<int> ScoreFrames (List<int> rolls) {
        List<int> frames = new List<int>();

        //Index i points to 2nd bowl of frame
        for (int i = 1; i < rolls.Count; i += 2) {
            if (frames.Count == 10) { break; }                  //prevents 11th frame

            if (rolls[i - 1] + rolls[i] < 10) {                 //normal OPEN frame
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count - i <= 1) {                         //insufficient look-ahead
                break;
            }

            if (rolls[i-1] == 10) {                             //STRIKE
                i--;                                            //strike frame has just 1 bowl so can't skip 2
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);   //strike bonus
            }else if (rolls[i - 1] + rolls[i] == 10) {          //SPARE
                frames.Add(10 + rolls[i+1]);                    //spare bonus 
            }
        }

        return frames;
    }    
}