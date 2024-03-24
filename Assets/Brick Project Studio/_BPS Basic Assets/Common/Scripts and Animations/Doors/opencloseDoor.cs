using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;
		public LayerMask PlayerLayerMask;
		
		void Start()
		{
			open = false;
		}

		// void OnMouseOver()
		// {
		// 	{
		// 		if (Player)
		// 		{
		// 			float dist = Vector3.Distance(Player.position + new Vector3(0, 0, -1.8f), transform.position);
		// 			Debug.Log(dist);
		// 			if (dist < 15)
		// 			{
		// 				if (open == false)
		// 				{
		// 					if (Input.GetKeyDown(KeyCode.E))
		// 					{
		// 						StartCoroutine(opening());
		// 					}
		// 				}
		// 				else
		// 				{
		// 					if (open == true)
		// 					{
		// 						if (Input.GetKeyDown(KeyCode.E))
		// 						{
		// 							StartCoroutine(closing());
		// 						}
		// 					}
		//
		// 				}
		//
		// 			}
		// 		}
		//
		// 	}
		//
		// }

		private void OnCollisionEnter(Collision other)
		{
			if (LayerMarkChecker.LayerInLayerMask(other.gameObject.layer, PlayerLayerMask))
			{
				if (open == false)
				{
					StartCoroutine(opening());
				}
				else
				{
					if (open == true)
					{ 
						StartCoroutine(closing());
					}

				}
			}
		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}