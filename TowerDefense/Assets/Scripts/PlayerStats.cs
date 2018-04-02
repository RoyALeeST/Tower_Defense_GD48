using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int money;
	public int startMoney = 400;
	public int startLives = 20;
	public static int lives;
	public static int rounds = 0;

	private void Start() {
		money = startMoney;
		lives=startLives;
		rounds = 0;
	}

}
