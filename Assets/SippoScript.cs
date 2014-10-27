
using UnityEngine;
using System.Collections;

public class SippoScript : MonoBehaviour {

public Vector2 a;
public Vector2 g;
public Vector2 v;
public Camera cam;
public System.Boolean stop;
public float maxHeight;
public float height;
public float groundY;
public string state;
public GameObject maxHeightLabel;
public GameObject heightLabel;
public GameObject timeLimitLabel;
public AudioSource pyon;
public Sprite shoe1;
public Sprite shoe2;
public Sprite shoe3;
public GameObject shoe;
public int shoeTime;
public AudioSource join;
public AudioSource don;
public AudioSource fail;
public GameObject gameData;
public int timeLimit;
void  Start (){
  timeLimit=3600;
  //timeLimit=400;
  shoeTime=0;
  height=0;
  maxHeight=0;
  state="free";
  stop = false;
  g = new Vector2(0, -0.004f);

  a = new Vector2(0, 0);

  v =new  Vector2(0, 0);

}
void  SuperShoe (){
  shoe.GetComponent<SpriteRenderer>().sprite=shoe2;
  shoeTime=1;
  join.Play();
}
void  Update (){
  if(timeLimit>0){
    timeLimit--;
  }else{

    gameData.GetComponent<GameDataScript>().maxHeight=maxHeight;
    Application.LoadLevel ("Result");
  }
  //transform.rotation.z=0;
  transform.rotation = new Quaternion(0f,0f,0f,1f);

  transform.Rotate(new Vector3(0f,0f,-transform.rotation.z));
  if (Input.GetKeyDown(KeyCode.Space)){
    SuperShoe();
  }
  if(shoeTime!=0){
    shoeTime++;
    if(shoeTime>50){
      shoe.GetComponent<SpriteRenderer>().sprite=shoe3;
    }
    if(shoeTime>100){
      shoe.GetComponent<SpriteRenderer>().sprite=shoe1;
      shoeTime=0;
    }
  }


  heightLabel.guiText.text="高度:"+height+"ｹﾛメートル";
  maxHeightLabel.guiText.text="最高高度:"+maxHeight+"ｹﾛメートル";
  timeLimitLabel.guiText.text="残り時間:"+((timeLimit/60)+1)+"ｹﾛ秒";
  if (stop) {
    return;
  }
  v += g;
  Vector3 p = transform.position;
  p = new Vector3(p.x,p.y+v.y,p.z);
  transform.position = p;
  height=((int)(transform.position.y+2.261f)*10)/10.0f;
  if(maxHeight<height){
    maxHeight=height;
  }
}

void  OnCollisionEnter2D (){

  OnGround();
  Bound();

}

void  OnGround (){
  Contract();

  if (Mathf.Pow(v.y, 2) < 0.0005f) {
    Stop();
  }

}
void  Contract (){
 GameObject body= transform.FindChild("Body").gameObject;

}
void  Expand (){

}

void  Bound (){
  if(shoeTime==0){
  pyon.Play();
  v.y = -v.y * 1.0368f;
  //v.y = -v.y*1.5f;
  }else if(shoeTime>50){
    shoeTime=0;
    shoe.GetComponent<SpriteRenderer>().sprite=shoe1;
    fail.Play();
    v.y = -v.y * 0.50f;
  }else{
    shoe.GetComponent<SpriteRenderer>().sprite=shoe1;
    don.Play();
    v.y = -v.y * (1.0f+((float)(shoeTime)/100.0f));
    Debug.Log((1.0f+((float)(shoeTime)/100.0f)));
    shoeTime=0;
  }
}

void  Stop (){
  stop = true;
}
}