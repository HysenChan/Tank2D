using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //玩家属性值
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead;
    public bool isDefeat;

    public GameObject born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public GameObject isDefeatUI;

    //单例
    private static PlayerManager instance;

    public static PlayerManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnToMain", 3);
            return;
        }
        if (isDead)
        {
            Recover();
        }
        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text = lifeValue.ToString();
    }

    private void Recover()
    {
        if (lifeValue<=0)
        {
            //游戏失败，返回主界面
            isDefeat = true;
            Invoke("ReturnToMain", 3);
        }
        else
        {
            lifeValue--;
            GameObject gO = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            gO.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }

    private void ReturnToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
