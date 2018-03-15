using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DSA.Extensions.Base;

namespace DSA.Extensions.GamePlay
{
	[System.Serializable]
	public class GameManager : ManagerBase
	{
		public override ExtensionEnum Extension { get { return ExtensionEnum.GamePlay; } }

		public enum GameState { PlayMode, UIMode };
		[SerializeField] private GameState currentState;
		public GameState CurrentState { get { return currentState; } }

		public delegate void OnStartGamePlayEvent();
		public event OnStartGamePlayEvent OnStartGamePlay;

		public delegate void OnUIEscapeEvent();
		public event OnUIEscapeEvent OnUIEscape;

		//called from UI Button in Editor, work around for Unity being unable to access all Scenes in project

		public override void Initialize()
		{
			base.Initialize();
		}

		protected override void StartProcess()
		{
			base.StartProcess();
			currentState = GameState.UIMode;
		}

		public override void EndProcess()
		{
			base.EndProcess();
			currentState = GameState.PlayMode;
			//StartCoroutine(MaintainInteractHUD());
		}

		public void UIEscape()
		{
			OnUIEscape();
		}

		/*public IEnumerator MaintainInteractHUD()
		{
			GameObject currentObj = GamePlayGlobals.ViewedObject;
			ToggleInteractHud(currentObj);
			while (GamePlayGlobals.ViewedObject == currentObj)
			{
				yield return null;
			}
			StartCoroutine(MaintainInteractHUD());
		}*/
	}
}