using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using SpatalDBKit;

namespace SpatialDBKitTest
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		SpatialDBKitTest_TouchViewController viewController;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new SpatialDBKitTest_TouchViewController ();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();

			var SqliteVersion = SpatialDatabase.SqliteLibVersion;
			Console.WriteLine ("sqlite version: {0}", SqliteVersion);

			var spatialiteVersion = SpatialDatabase.SpatialiteLibVersion;
			Console.WriteLine ("spatialite version: {0}", spatialiteVersion);

			var db = new SpatialDatabase (NSBundle.MainBundle.PathForResource ("Assets/test-2.3", "sqlite"));
			db.Open ();
			var rs = db.ExecuteQuery ("select AsText(geometry) AS text FROM Regions WHERE PK_UID = 106");
			while (rs.Next)
			{
				var obj = rs.ResultDict;

				Console.WriteLine ("{0}", obj);
			}

			var rs3 = db.ExecuteQuery ("select geometry FROM Regions WHERE PK_UID = 106");
			ShapeKitGeometry geom = null;
			while (rs3.Next)
			{
				var obj = rs3.ResultDict;
				var key = new NSString ("geometry");
				if ((geom == null) && obj.ObjectForKey (key) != null) {
					geom = (ShapeKitGeometry)obj.ObjectForKey (key);
				}

				Console.WriteLine ("{0}", geom);
			}

			// test ShapeKit topology functions
			Console.WriteLine ("Route boundary: {0}", geom.Boundary ());
			Console.WriteLine ("Route cascaded union : {0}", ((ShapeKitMultiPolygon)geom).CascadedUnion ());

			// test VirtualNetwork module for Dijkstra-based routing
			//var db2 = new SpatialDatabase (NSBundle.MainBundle.PathForResource ("Assets/test-network-2.3", "sqlite"));
			//db2.Open ();
			//var rs2 = db2.ExecuteQuery (@"SELECT * AS WKT_geometry 
			//            FROM Roads_net 
			//            WHERE NodeFrom = 1 AND NodeTo = 512;");
			//while (rs2.Next)
			//{
			//	var obj = rs2.ResultDict;
			//
			//	Console.WriteLine ("{0}", obj);
			//}

			return true;
		}
	}
}

