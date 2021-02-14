// *** Script para cambiar de texto con botones en caso de tener varios eventos por hora. *** //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class managerData : MonoBehaviour
{
	public Button buttonLeft; 
	public Button buttonRight;
	
	public GameObject container;

	private Transform child;
	private int totalChildren;
	private int index;

	void Start()
	{

		Button buttonR = buttonRight.GetComponent<Button>();
		Button buttonL = buttonLeft.GetComponent<Button>();

		buttonR.onClick.AddListener(TaskOnClickRightArrow);
		buttonL.onClick.AddListener(TaskOnClickLeftArrow);


		totalChildren = container.transform.childCount;

		Debug.Log(totalChildren);

		container.transform.GetChild(0).gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1;

		if (totalChildren > 1)
        {
			buttonRight.gameObject.SetActive(true);
		}
		
	}



	void TaskOnClickRightArrow()
	{

		GetActiveIndex();

		if (index == totalChildren - 2)
		{
			container.GetComponentInChildren<Transform>().GetChild(index).GetComponentInChildren<CanvasGroup>().alpha = 0;
			container.GetComponentInChildren<Transform>().GetChild(index + 1).GetComponentInChildren<CanvasGroup>().alpha = 1;


			buttonRight.gameObject.SetActive(false);
			buttonLeft.gameObject.SetActive(true);
		}

		if (index < totalChildren - 2)
		{
			container.GetComponentInChildren<Transform>().GetChild(index).GetComponentInChildren<CanvasGroup>().alpha = 0;
			container.GetComponentInChildren<Transform>().GetChild(index + 1).GetComponentInChildren<CanvasGroup>().alpha = 1;

			buttonLeft.gameObject.SetActive(true);
			buttonRight.gameObject.SetActive(true);

		}
	}

	void TaskOnClickLeftArrow()
	{
		GetActiveIndex();

		if (index == 1)
		{
			container.GetComponentInChildren<Transform>().GetChild(index).GetComponentInChildren<CanvasGroup>().alpha = 0;
			container.GetComponentInChildren<Transform>().GetChild(index - 1).GetComponentInChildren<CanvasGroup>().alpha = 1;

			buttonLeft.gameObject.SetActive(false);
		}

		if (index > 1)
		{
			container.GetComponentInChildren<Transform>().GetChild(index).GetComponentInChildren<CanvasGroup>().alpha = 0;
			container.GetComponentInChildren<Transform>().GetChild(index - 1).GetComponentInChildren<CanvasGroup>().alpha = 1;

			buttonLeft.gameObject.SetActive(true);
			buttonRight.gameObject.SetActive(true);
		}
	}

	void GetActiveIndex()
    {
		totalChildren = container.transform.childCount;

		for (int i = 0; i < totalChildren; i++)
		{
			if(container.transform.GetChild(i).gameObject.GetComponentInChildren<CanvasGroup>().alpha == 1)
            {
				index = i;
            }
		}
	}
	


}
