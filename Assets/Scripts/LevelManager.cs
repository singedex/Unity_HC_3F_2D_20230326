using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("���ŻP�g��Ȥ���")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("���ŤW��"), Range(0, 500)]
    public int LvMax = 100;

    private int lv = 1;
    private float exp;

    public float[] expNeeds = { 100, 200, 300 };

    [Header("�ɯŭ��O")]
    public GameObject goLevelUp;
    [Header("�ޯ����϶� 1~3")]
    public GameObject[] goChooseSkills;
    [Header("�����ޯ�")]
    public DataSkill[] dataSkills;

    public List<DataSkill> randomSkill = new List<DataSkill>();

    [ContextMenu("��s�g��ȻݨD��")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float[LvMax];

        for(int i = 0; i < LvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

        /// <summary>
        /// ��o�g���
        /// </summary>
        /// <param name="getExp">���o�g��ȯB�I��</param>
    public void GetExp(float getExp)
    {
        exp += getExp;
        // print($"<color=yellow>2; ��e�g���:{ exp }</color>");

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
		//�ɶ��Ȱ�
		Time.timeScale = 0;
		goLevelUp.SetActive(true);
		randomSkill = dataSkills.Where(x => lv < 5).ToList();
		randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

		for (int i = 0; i < 3; i++)
		{
			goChooseSkills[i].transform.Find("�ޯ�W��").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
			goChooseSkills[i].transform.Find("�ޯ�y�z").GetComponent<TextMeshProUGUI>().text = randomSkill[i].description;
			goChooseSkills[i].transform.Find("�ޯ൥��").GetComponent<TextMeshProUGUI>().text = "���� LV" + randomSkill[i].lv;
			goChooseSkills[i].transform.Find("�ޯ�Ϥ�").GetComponent<Image>().sprite = randomSkill[i].iconSkill;
		}
	}

	#region �ޯ�Ӷ�
	private void ClickSkillButton(int number)
	{
		print("���a���U���ޯ�O:" + randomSkill[number].nameSkill);

		randomSkill[number].lv++;
		if (randomSkill[number].nameSkill == "���ʳt��") UpdateMoveSpeed(number);
		if (randomSkill[number].nameSkill == "�Z������") UpdateWeaponAttack(number);
		if (randomSkill[number].nameSkill == "�Z�����j") UpdateWeaponInterval(number);
		if (randomSkill[number].nameSkill == "���a��q") UpdatePlyerHealth(number);
		if (randomSkill[number].nameSkill == "�g��Ƚd��") UpdateExpRange(number);

		Time.timeScale = 1;
		goLevelUp.SetActive(false);
	}

	[Header("����t��:�R��")]
	public ControlSystem controlSystem;
	[Header("�Z���t��:�R��")]
	public WeaponSystem weaponSystem;
	[Header("���a��q:���a�R��")]
	public DataHealth dataHealth;
	[Header("�g��Ӫ���:�i�ʸg���")]
	public CircleCollider2D expHadokan;
	[Header("�Z��:�j�۳�")]
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

