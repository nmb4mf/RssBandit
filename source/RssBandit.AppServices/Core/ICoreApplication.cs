#region CVS Version Header
/*
 * $Id$
 * Last modified by $Author$
 * Last modified at $Date$
 * $Revision$
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using NewsComponents; 

namespace RssBandit.AppServices
{
	/// <summary>
	/// ICoreApplication contains the core service functions 
	/// of RSS Bandit.
	/// </summary>
	public interface ICoreApplication
	{
		#region General

		/// <summary>
		/// Raised after preferences settings was changed
		/// </summary>
		event EventHandler PreferencesChanged;
		
		///// <summary>
		///// Raised after the feedlist/subscriptions were loaded
		///// </summary>
		//event EventHandler FeedlistLoaded;

		///// <summary>
		///// Raised after a feed was deleted
		///// </summary>
		//event FeedDeletedHandler FeedDeleted;

		/// <summary>
		/// Returns the current global (specified via options)
		/// Feed Refresh Rate in minutes.
		/// </summary>
		int CurrentGlobalRefreshRate { get; }

		/// <summary>
		/// Gets the feed sources.
		/// </summary>
		/// <value>
		/// The feed sources.
		/// </value>
		IFeedSources FeedSources {get; }

		/// <summary>
		/// Gets the current application web proxy
		/// </summary>
		IWebProxy Proxy { get; }

		/// <summary>
		/// Gets the News Item Formatter Stylesheet list.
		/// </summary>
		/// <returns>list of strings.</returns>
		IList GetItemFormatterStylesheets();

		/// <summary>
		/// Gets the defined web search engines. 
		/// Items are of type ISearchEngine.
		/// </summary>
		IList WebSearchEngines { get ; }

		#endregion

		#region Dialogs
		/// <summary>
		/// Display the options dialog and select the desired detail section
		/// </summary>
		/// <param name="selectedSection">OptionDialogSection</param>
		/// <param name="optionsChangedHandler">A Change EventHandler</param>
		void ShowOptions(OptionDialogSection selectedSection, IWin32Window owner, EventHandler optionsChangedHandler);

		/// <summary>
		/// Shows the podcast options dialog.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="optionsChangedHandler">The options changed handler.</param>
		void ShowPodcastOptionsDialog(IWin32Window owner, EventHandler optionsChangedHandler);
		#endregion

		#region Enclosure/Podcast related 
		/// <summary>
		/// Gets the current Enclosure folder
		/// </summary>
		string EnclosureFolder { get; }

		/// <summary>
		/// Gets the current Podcast folder
		/// </summary>
		string PodcastFolder { get; }

		/// <summary>
		/// Gets a semi-colon delimited list of file extensions of enclosures that 
		/// should be treated as podcasts
		/// </summary>
		string PodcastFileExtensions { get; }

		/// <summary>
		/// Gets whether enclosures should be created in a subfolder named after the feed. 
		/// </summary>
		bool DownloadCreateFolderPerFeed  {get;}
		
		/// <summary>
		/// Gets whether alert Windows should be displayed for enclosures or not. 
		/// </summary>
		bool EnableEnclosureAlerts {get;}
		
		/// <summary>
		/// Gets whether enclosures should be downloaded automatically or not.
		/// </summary>
		bool DownloadEnclosures {get;}

		/// <summary>
		/// Indicates the maximum amount of space that enclosures and podcasts can use on disk.
		/// </summary>
		int EnclosureCacheSize { get;}

		/// <summary>
		/// Indicates the number of enclosures which should be downloaded automatically from a newly subscribed feed.
		/// </summary>
		int NumEnclosuresToDownloadOnNewFeed { get; }

		#endregion 

		#region Url/Link navigation
		
		/// <summary>
		/// Navigates to an Url.
		/// </summary>
		/// <param name="url">Url to navigate to</param>
		/// <param name="tabCaption">The suggested tab caption (maybe replaced by the url's html page title)</param>
		/// <param name="forceNewTabOrWindow">Force to open a new Tab/Window</param>
		/// <param name="setFocus">Force to set the focus to the new Tab/Window</param>
		void NavigateToUrl(string url, string tabCaption, bool forceNewTabOrWindow, bool setFocus);

		/// <summary>
		/// Navigates to an provided Url on the user preferred Web Browser.
		/// So it may be the external OS Web Browser, or the internal one.
		/// </summary>
		/// <param name="url">Url to navigate to</param>
		/// <param name="tabCaption">The suggested tab caption (maybe replaced by the url's html page title)</param>
		/// <param name="forceNewTabOrWindow">Force to open a new Browser Window (Tab)</param>
		/// <param name="setFocus">Force to set the focus to the new Window (Tab)</param>
		void NavigateToUrlAsUserPreferred(string url, string tabCaption, bool forceNewTabOrWindow, bool setFocus);

		/// <summary>
		/// Navigates to an provided Url with help of the OS system preferred Web Browser.
		/// If it fails to navigate with that browser, it falls back to internal tabbed browsing.
		/// </summary>
		/// <param name="url">Url to navigate to</param>
		void NavigateToUrlInExternalBrowser(string url);

		#endregion

		#region Category management
		/// <summary>
		/// Gets the default category.
		/// </summary>
		string DefaultCategory { get; }
		/// <summary>
		/// Gets the list of categories including the default category.
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetCategories();
		/// <summary>
		/// Use this method to add a new category.
		/// </summary>
		/// <param name="category"></param>
		void AddCategory(string category);
		#endregion

		#region Feeds management
		/// <summary>
		/// Call to subscribe to a new feed. This will initiate to
		/// display the Add Subscription Wizard with the parameters
		/// pre-set you provide.
		/// </summary>
		/// <param name="url">New feed Url</param>
		/// <returns></returns>
		bool SubscribeToFeed(string url);
		
		/// <summary>
		/// Call to subscribe to a new feed. This will initiate to
		/// display the Add Subscription Wizard with the parameters
		/// pre-set you provide.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="category">The category.</param>
		/// <returns></returns>
		bool SubscribeToFeed(string url, string category);
		/// <summary>
		/// Call to subscribe to a new feed. This will initiate to
		/// display the Add Subscription Wizard with the parameters
		/// pre-set you provide.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="category">The category.</param>
		/// <param name="title">The title.</param>
		/// <returns></returns>
		bool SubscribeToFeed(string url, string category, string title);

        /// <summary>
        /// Checks to see if the feed already exists
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        bool ContainsFeed(string url);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="category"></param>
        /// <param name="title"></param>
        /// <param name="link"></param>
        bool TryGetFeedDetails(string url, out string category, out string title, out string link);
		#endregion

		#region Channel processing
		/// <summary>
		/// Register a IChannelProcessor services, that works
		/// in the receiving news channel chain: the moment we requested new feeds
		/// or update feeds from the original sources. 
		/// </summary>
		/// <param name="channelProcessor">IChannelProcessor</param>
		void RegisterReceivingNewsChannelProcessor(IChannelProcessor channelProcessor);
		/// <summary>
		/// Unregister a previously registered IChannelProcessor services 
		/// and removes it from the receiving news channel processing chain.
		/// </summary>
		/// <param name="channelProcessor">IChannelProcessor</param>
		void UnregisterReceivingNewsChannelProcessor(IChannelProcessor channelProcessor);
		/// <summary>
		/// Register a IChannelProcessor services, that works
		/// in the displaying news channel chain: the moment before we render feeds
		/// or newsitems in the detail display pane. 
		/// </summary>
		/// <param name="channelProcessor">IChannelProcessor</param>
		void RegisterDisplayingNewsChannelProcessor (IChannelProcessor channelProcessor);

		/// <summary>
		/// Unregister a previously registered IChannelProcessor services 
		/// and removes it from the receiving news channel processing chain.
		/// </summary>
		/// <param name="channelProcessor">IChannelProcessor</param>
		void UnregisterDisplayingNewsChannelProcessor (IChannelProcessor channelProcessor);
		#endregion
	}
}
