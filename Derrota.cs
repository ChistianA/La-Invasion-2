using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{

	public void Salir()
	{
		Application.Quit();
	}

	public void JugarDeNuevo()
	{
		SceneManager.LoadScene("Level1");
	}




}
