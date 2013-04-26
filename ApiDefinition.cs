using System;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

namespace TestFlight
{
	[BaseType (typeof(NSObject))]
	public interface SDK
	{
		///	<summary>Add custom environment information</summary>
		/// <description>If you want to track custom information such as a user name from your application you can add 
		/// it here</description>
		/// <param name="information">A string containing the environment you are storing</param>
		/// <param name="key">The key to store the information with</param>
		[Internal]
		[Static, Export ("addCustomEnvironmentInformation:forKey:")]
		void AddCustomEnvironmentInformation (string information, string key);

		/// <summary>Starts a TestFlight session using the Application Token for this Application</summary>
		/// <description>Will be the application token for the current application. The token for this application can 
		///  be retrieved by going to https://testflightapp.com/dashboard/applications/ selecting this application from
		/// the list then selecting SDK.</description>
		/// <param name="applicationToken">Application token.</param>
		[Static, Export ("takeOff:")]
		void TakeOff (string applicationToken);

		/// <summary>Sets custom options</summary>
		/// <param name="options">NSDictionary containing the options you want to set. Available options are described 
		/// below at "TestFlight Option Keys"</param>
		[Internal]
		[Static, Export ("setOptions:")]
		void SetOptionsRaw (NSDictionary options);

		/// <summary>
		/// Track when a user has passed a checkpoint after the flight has taken off. Eg. passed level 1, posted high 
		/// score
		/// </summary>
		/// <param name="checkpointName">The name of the checkpoint, this should be a static string</param>
		[Static, Export ("passCheckpoint:")]
		void PassCheckpoint (string checkpointName);
		/// <summary>
		/// Opens a feedback window that is not attached to a checkpoint.
		/// </summary>
		[Static, Export ("openFeedbackView")]
		void OpenFeedbackView ();

		/// <summary>
		/// Submits custom feedback to the site. Sends the data in feedback to the site. This is to be used as the 
		/// method to submit feedback from custom feedback forms.
		/// </summary>
		/// <param name="feedback">Your users feedback, method does nothing if feedback is nil.</param>
		[Static, Export ("submitFeedback:")]
		void SubmitFeedback (string feedback);

		/// <summary>
		/// Sets the Device Identifier
		/// </summary>
		/// <description>
		/// !! DO NOT CALL IN SUBMITTED APP STORE APP.
		/// 
		/// !! MUST BE CALLED BEFORE +takeOff:
		/// 
		/// This method should only be used during testing so that you can identify a testers test data with them.
		/// If you do not provide the identifier you will still see all session data, with checkpoints
		/// and logs, but the data will be anonymized.
		/// 
		/// It is recommended that you only use this method during testing.
		///	Apple may reject your app if left in a submitted app.
		/// 
		/// Use:
		/// Only use this with the Apple device UDID. DO NOT use Open ID or your own identifier.
		/// TestFlight.SetDeviceIdentifier(UIDevice.CurrentDevice.UniqueIdentifier);</description>
		/// <param name="deviceIdentifier">The current devices device identifier.</param>
		[Static, Export ("setDeviceIdentifier:")]
		void SetDeviceIdentifier (string deviceIdentifier);
	}

	[Static]
	public interface OptionKeys {
		/// <summary>
		/// Defaults to @NO. Setting to @YES attaches the current backtrace, with symbols, to the feedback.
		/// </summary>
		[Field ("TFOptionAttachBacktraceToFeedback", "__Internal")]
		NSString AttachBacktraceToFeedback { get; }

		/// <summary>
		/// Defaults to @NO. Setting to @YES, disables the in app update screen shown in BETA apps when there is a new
		/// version available on TestFlight.
		/// </summary>
		[Field ("TFOptionDisableInAppUpdates", "__Internal")]
		NSString DisableInAppUpdates { get; }

		/// <summary>
		/// Defaults to @YES. Prints remote logs to Apple System Log.
		/// </summary>
		[Field ("TFOptionLogToConsole", "__Internal")]
		NSString LogToConsole { get; }

		/// <summary>
		/// Defaults to @YES. Sends remote logs to STDERR when debugger is attached.
		/// </summary>
		[Field ("TFOptionLogToSTDERR", "__Internal")]
		NSString LogToSTDERR { get; }

		/// <summary>
		/// If set to @YES: Reinstalls crash handlers, to be used if a third party library installs crash handlers 
		/// overtop of the TestFlight Crash Handlers.
		/// </summary>
		[Field ("TFOptionReinstallCrashHandlers", "__Internal")]
		NSString ReinstallCrashHandlers { get; }

		/// <summary>
		/// Defaults to @NO. Setting to @YES stops remote logs from being sent when sessions end. They would only be 
		/// sent in the event of a crash.
		/// </summary>
		[Field ("TFOptionSendLogOnlyOnCrash", "__Internal")]
		NSString SendLogOnlyOnCrash { get; }
	}
}

