using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class end_to_menu : MonoBehaviour
{
	
	public int finalScoreValue;
	public int rank;
	public bool is_high_score;
	
	public bool end;
	public int frames;
	
    // Start is called before the first frame update
    void Start()
    {
		end = false;
		frames = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
		if(end){
			frames +=1;
		}
		
		if(frames == 60){
			SceneManager.LoadScene(1);
		}
    }
	
	void OnCollisionEnter(Collision collision){
		
		if((collision.transform.name == "Player")||(collision.transform.name == "HeadCollider")||
        (collision.transform.name == "HandColliderLeft(Clone)")||(collision.transform.name == "HandColliderRight(Clone)")){
			finalScoreValue = PlayerPrefs.GetInt("active_score");
			if(finalScoreValue > PlayerPrefs.GetInt("Score5")){
				is_high_score = true;
				Update_high_scores();
			}
			else{
				is_high_score = false;
			}
			end = true;
		}
		
	}
	
	public void Update_high_scores(){
		if(this.finalScoreValue > PlayerPrefs.GetInt("Score1")){
			rank = 1;
		}
		else if(this.finalScoreValue > PlayerPrefs.GetInt("Score2")){
			rank = 2;
		}
		else if(this.finalScoreValue > PlayerPrefs.GetInt("Score3")){
			rank = 3;
		}
		else if(this.finalScoreValue > PlayerPrefs.GetInt("Score4")){
			rank = 4;
		}
		else{
			rank  = 5;
		}
		
		int temp = finalScoreValue;
		int temp2 = finalScoreValue;
		string ntemp = PlayerPrefs.GetString("entry");
		string ntemp2 = PlayerPrefs.GetString("entry");
		switch(rank){
			case 1:
				temp = PlayerPrefs.GetInt("Score1");
				PlayerPrefs.SetInt("Score1", finalScoreValue);
				ntemp = PlayerPrefs.GetString("Name1");
				PlayerPrefs.SetString("Name1", PlayerPrefs.GetString("entry"));
				goto case 2;
			case 2:
				temp2 = PlayerPrefs.GetInt("Score2");
				PlayerPrefs.SetInt("Score2", temp);
				ntemp2 = PlayerPrefs.GetString("Name2");
				PlayerPrefs.SetString("Name2", ntemp);
				goto case 3;
			case 3:
				temp = PlayerPrefs.GetInt("Score3");
				PlayerPrefs.SetInt("Score3", temp2);
				ntemp = PlayerPrefs.GetString("Name3");
				PlayerPrefs.SetString("Name3", ntemp2);
				goto case 4;
			case 4:
				temp2 = PlayerPrefs.GetInt("Score4");
				PlayerPrefs.SetInt("Score4", temp);
				ntemp2 = PlayerPrefs.GetString("Name4");
				PlayerPrefs.SetString("Name4", ntemp);
				goto case 5;
			case 5:
				PlayerPrefs.SetInt("Score5", temp2);
				PlayerPrefs.SetString("Name5", ntemp2);
				break;
			default:
				Debug.Log("Tryed to change score board but could not find place");
				break;
		}
		Debug.Log(PlayerPrefs.GetInt("Score1"));
	}
}
