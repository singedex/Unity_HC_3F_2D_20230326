using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("等級與經驗值介面")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("等級上限"), Range(0, 500)]
    public int LvMax = 100;

    private int lv = 1;
    private float exp;

    public float[] expNeeds = { 100, 200, 300 };

    [Header("升級面板")]
    public GameObject goLevelUp;
    [Header("技能選取區塊 1~3")]
    public GameObject[] goChooseSkills;
    [Header("全部技能")]
    public DataSkill[] dataSkills;

    public List<DataSkill> randomSkill = new List<DataSkill>();

    [ContextMenu("更新經驗值需求表")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float[LvMax];

        for(int i = 0; i < LvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

        /// <summary>
        /// 獲得經驗值
        /// </summary>
        /// <param name="getExp">取得經驗值浮點數</param>
    public void GetExp(float getExp)
    {
        exp += getExp;
        // print($"<color=yellow>2; 當前經驗值:{ exp }</color>");

        if (exp >= expNeeds[lv - 1] && lv < LvMax)
        {
            exp -= expNeeds[lv - 1];
            lv++;
            textLv.text = $"Lv{lv}";
            LevelUp();
        }

        textExp.text = $"{exp} /{expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];
    }

		private void LevelUp()
	{
		//時間暫停
		Time.timeScale = 0;
		goLevelUp.SetActive(true);
		randomSkill = dataSkills.Where(x => lv < 5).ToList();
		randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

		for (int i = 0; i < 3; i++)
		{
			goChooseSkills[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
			goChooseSkills[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].description;
			goChooseSkills[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "等級 LV" + randomSkill[i].lv;
			goChooseSkills[i].transform.Find("技能圖片").GetComponent<Image>().sprite = randomSkill[i].iconSkill;
		}
	}

	#region 技能細項
	private void ClickSkillButton(int number)
	{
		print("玩家按下的技能是:" + randomSkill[number].nameSkill);

		randomSkill[number].lv++;
		if (randomSkill[number].nameSkill == "移動速度") UpdateMoveSpeed(number);
		if (randomSkill[number].nameSkill == "武器攻擊") UpdateWeaponAttack(number);
		if (randomSkill[number].nameSkill == "武器間隔") UpdateWeaponInterval(number);
		if (randomSkill[number].nameSkill == "玩家血量") UpdatePlyerHealth(number);
		if (randomSkill[number].nameSkill == "經驗值範圍") UpdateExpRange(number);

		Time.timeScale = 1;
		goLevelUp.SetActive(false);
	}

	[Header("控制系統:犀牛")]
	public ControlSystem controlSystem;
	[Header("武器系統:犀牛")]
	public WeaponSystem weaponSystem;
	[Header("玩家血量:玩家犀牛")]
	public DataHealth dataHealth;
	[Header("經驗植物件:波動經驗值")]
	public CircleCollider2D expHadokan;
	[Header("武器:迴旋鳥")]
	public Weapon weaponBird;

	private void Awake()
	{
		controlSystem.moveSpeed = dataSkills[3].skillValues[0];
		weaponBird.attack = dataSkills[0].skillValues[0];
		weaponSystem.interval = dataSkills[1].skillValues[0];
		dataHealth.hp = dataSkills[2].skillValues[0];
		expHadokan.radius = dataSkills[4].skillValues[0];
	}

	public void UpdateMoveSpeed(int number)
	{
		int lv = randomSkill[number].lv;
		controlSystem.moveSpeed = randomSkill[number].skillValues[lv - 1];
	}

	public void UpdateWeaponAttack(int number)
	{
		int lv = randomSkill[number].lv;
		weaponBird.attack = randomSkill[number].skillValues[lv - 1];
	}

	public void UpdateWeaponInterval(int number)
	{
		int lv = randomSkill[number].lv;
		weaponSystem.interval = randomSkill[number].skillValues[lv - 1];
	}

	public void UpdatePlyerHealth(int number)
	{
		int lv = randomSkill[number].lv;
		dataHealth.hp = randomSkill[number].skillValues[lv - 1];
	}

	public void UpdateExpRange(int number)
	{
		int lv = randomSkill[number].lv;
		expHadokan.radius = randomSkill[number].skillValues[lv - 1];
	}
}  
#endregion

