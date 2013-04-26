using System;
using MonoTouch.Foundation;

namespace TestFlight
{
	public partial class SDK {
		[Flags]
		public enum Options
		{
			AttachBacktraceToFeedback = 0x1,
			DisableInAppUpdates = 0x2,
			LogToConsole = 0x4,
			LogToSTDERR = 0x8,
			ReinstallCrashHandlers = 0x10,
			SendLogOnlyOnCrash = 0x20
		}

		/// <summary>Sets custom options</summary>
		/// <param name="options">Option mask containing the options you want to set. Available options are described 
		/// below at Options enum</param>
		public static void SetOptions (Options options) {
			var optionsDict = new NSMutableDictionary();
			NSString yes = new NSString("YES");
			NSString no = new NSString("NO");
			optionsDict.Add(((options & Options.AttachBacktraceToFeedback) != 0) ? yes : no, OptionKeys.AttachBacktraceToFeedback);
			optionsDict.Add(((options & Options.DisableInAppUpdates) != 0) ? yes : no, OptionKeys.DisableInAppUpdates);
			optionsDict.Add(((options & Options.LogToConsole) != 0) ? yes : no, OptionKeys.LogToConsole);
			optionsDict.Add(((options & Options.LogToSTDERR) != 0) ? yes : no, OptionKeys.LogToSTDERR);
			optionsDict.Add(((options & Options.ReinstallCrashHandlers) != 0) ? yes : no, OptionKeys.ReinstallCrashHandlers);
			optionsDict.Add(((options & Options.SendLogOnlyOnCrash) != 0) ? yes : no, OptionKeys.SendLogOnlyOnCrash);

			SDK.SetOptionsRaw(optionsDict);
		}
	}
}

