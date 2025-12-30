using UnityEngine;

namespace UnityEngineMod
{
	public sealed class Application
	{
		private static bool s_debugLogInApplicationQuit = true;
		
		public static string version
		{
			get
			{
				return "";
			}
		}
		
		public static void Quit(int arg0)
		{
			// WRAPPER CALL - UnityEngine.Application.Quit(int arg0)
			Application.Quit(arg0);
			
			if (s_debugLogInApplicationQuit)
			{
				Debug.Log("[Application] Quitted with exit-code " + arg0);
			}
		}
		
		public static void Quit()
		{
			Quit(1);
		}
		
		
		///////////////////////////////////////////////////////
		
	}
}