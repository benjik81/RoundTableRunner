using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendScoreScript : MonoBehaviour
{
    public dreamloLeaderBoard myBoard;

    public GameDataScript myData;

    public GameObject scoreLinePrefab;

    public Transform scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        //Add the myData of the current player in the Dreamlo
        myBoard.AddScore(myData.playerName, myData.score);

        //The Coroutine is there to run in parallel with my code without blocking my program.
        StartCoroutine(routine: GetScores());
    }

    //GetScores is there to retrieve the scores from the dreamlo table
    //We browse myBoard which is actually my scoreboard hosted online on Dreamlo.
    //If the array is empty, we do nothing, otherwise we call DisplayScore().
    private IEnumerator GetScores()
    {
        while (myBoard.ToStringArray() == null)
        {

            myBoard.GetScores();
            yield return new WaitForSeconds(1);
        }

        DisplayScore();
    }

    private void DisplayScore()
    {
        //It's a limiter to the number of scores that will be displayed  
        var numberOfScores = 0;

        //I go through all the lines of the Dreamlo scoreboard
        //I will create a "line" in the UI to display my ranking each time I run the loop
        //The scoreLine prefab is divided into two elements; the name displayed on the left and the score that I display on the right,
        //so I would assign to each of these elements the value concerning it (These are Strings).
        //When I have reached the desired number of lines (the number of scores displayed), the loop will be stopped.
        foreach (var line in myBoard.ToScoreArray())
        {
            numberOfScores++;
            GameObject myLine = Instantiate(scoreLinePrefab, scoreBoard);
            var displayScore = myLine.GetComponent<DisplayScoreScript>();
            displayScore.myName.text = line.playerName;
            displayScore.myScore.text = line.score.ToString();
            if (numberOfScores == 10)
                break;
        }
    }
}
