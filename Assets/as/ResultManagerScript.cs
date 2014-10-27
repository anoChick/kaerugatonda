using UnityEngine;
using System.Collections;

public class ResultManagerScript : MonoBehaviour {
  public GameObject label;
  public GUIText rank;
  public UnigeScorerScript uss;
  public int score ;
  public int state ;

	// Use this for initialization
  void Update(){
    if(uss.state=="ready"){
      uss.state="end";
      
      uss.Recordppppp(score);

    }
  }
	void Start () {
    state=0;
    score = 0;
    GameDataScript gds = GameObject.Find("GameData").GetComponent<GameDataScript>();
      score = (int)gds.maxHeight;
      label.guiText.text=score+" ｹﾛメートル";
    uss.OnReceive((JSONObject result) => {
      int r = (int)result.GetField("rank").n;
      if(r>=1){
        rank.text=""+r+"位";
      }
    });
	}

}
