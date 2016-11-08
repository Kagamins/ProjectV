#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
	[System.Serializable]
	public class ISQuest : ISObject,IISQuest {
		[SerializeField] string _questDialog;



		public ISQuest()
		{
			_questDialog = "blank";

		}

		public ISQuest(ISQuest q)
		{
			Clone (q);
		}

		public void Clone(ISQuest q)
		{
			base.Clone (q);
			_questDialog = q._questDialog;
		
		}

		public string  QuestDialog
		{
			get{return _questDialog; }	
		}





	
		//this code will go to a new script
		#if UNITY_EDITOR
		public override void OnGUI()
		{

			base.OnGUI ();
			_questDialog = EditorGUILayout.TextField ("Quest Dialog", _questDialog);
		}
	
		#endif
	}

}