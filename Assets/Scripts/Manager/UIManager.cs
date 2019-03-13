using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
	private Text resultText;
	
	public void OnAwake ()
	{
		resultText = transform.FindChild("ResultText").GetComponent<Text>();
	}
	
	public void OnUpdate ()
	{
		
	}

	public void ResultSet()
	{
		//resultTextへ書く言葉（星座名とタイム、引数も使うかも）
	}
}
