using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {
  public float maxHeight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 Debug.Log(maxHeight);
	}
  void Awake(){
    DontDestroyOnLoad (this);//次のシーンを読み込むときに、自分自身を破壊しない。
  }
}
