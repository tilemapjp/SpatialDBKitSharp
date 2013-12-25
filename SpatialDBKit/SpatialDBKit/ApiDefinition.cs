using System;

using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using MonoTouch.ObjCRuntime;

namespace SpatalDBKit {

	[BaseType (typeof (NSObject))]
	public partial interface FMResultSet {

		[Export ("query", ArgumentSemantic.Retain)]
		string Query { get; set; }

		[Export ("columnNameToIndexMap")]
		NSMutableDictionary ColumnNameToIndexMap { get; }

		[Export ("statement", ArgumentSemantic.Retain)]
		FMStatement Statement { get; set; }

		[Static, Export ("resultSetWithStatement:usingParentDatabase:")]
		NSObject ResultSetWithStatement (FMStatement statement, FMDatabase aDB);

		[Export ("close")]
		void Close ();

		[Export ("parentDB")]
		FMDatabase ParentDB { set; }

		[Export ("next")]
		bool Next { get; }

		[Export ("hasAnotherRow")]
		bool HasAnotherRow { get; }

		[Export ("columnCount")]
		int ColumnCount { get; }

		[Export ("columnIndexForName:")]
		int ColumnIndexForName (string columnName);

		[Export ("columnNameForIndex:")]
		string ColumnNameForIndex (int columnIdx);

		[Export ("intForColumn:")]
		int IntForColumn (string columnName);

		[Export ("intForColumnIndex:")]
		int IntForColumnIndex (int columnIdx);

		[Export ("longForColumn:")]
		int LongForColumn (string columnName);

		[Export ("longForColumnIndex:")]
		int LongForColumnIndex (int columnIdx);

		[Export ("longLongIntForColumn:")]
		long LongLongIntForColumn (string columnName);

		[Export ("longLongIntForColumnIndex:")]
		long LongLongIntForColumnIndex (int columnIdx);

		[Export ("unsignedLongLongIntForColumn:")]
		ulong UnsignedLongLongIntForColumn (string columnName);

		[Export ("unsignedLongLongIntForColumnIndex:")]
		ulong UnsignedLongLongIntForColumnIndex (int columnIdx);

		[Export ("boolForColumn:")]
		bool BoolForColumn (string columnName);

		[Export ("boolForColumnIndex:")]
		bool BoolForColumnIndex (int columnIdx);

		[Export ("doubleForColumn:")]
		double DoubleForColumn (string columnName);

		[Export ("doubleForColumnIndex:")]
		double DoubleForColumnIndex (int columnIdx);

		[Export ("stringForColumn:")]
		string StringForColumn (string columnName);

		[Export ("stringForColumnIndex:")]
		string StringForColumnIndex (int columnIdx);

		[Export ("dateForColumn:")]
		NSDate DateForColumn (string columnName);

		[Export ("dateForColumnIndex:")]
		NSDate DateForColumnIndex (int columnIdx);

		[Export ("dataForColumn:")]
		NSData DataForColumn (string columnName);

		[Export ("dataForColumnIndex:")]
		NSData DataForColumnIndex (int columnIdx);

		[Export ("UTF8StringForColumnIndex:")]
		//(const unsigned char *)
		IntPtr UTF8StringForColumnIndex (int columnIdx);

		[Export ("UTF8StringForColumnName:")]
		//(const unsigned char *)
		IntPtr UTF8StringForColumnName (string columnName);

		[Export ("objectForColumnName:")]
		NSObject ObjectForColumnName (string columnName);

		[Export ("objectForColumnIndex:")]
		NSObject ObjectForColumnIndex (int columnIdx);

		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string columnName);

		[Export ("objectAtIndexedSubscript:")]
		NSObject ObjectAtIndexedSubscript (int columnIdx);

		[Export ("dataNoCopyForColumn:")]
		NSData DataNoCopyForColumn (string columnName);

		[Export ("dataNoCopyForColumnIndex:")]
		NSData DataNoCopyForColumnIndex (int columnIdx);

		[Export ("columnIndexIsNull:")]
		bool ColumnIndexIsNull (int columnIdx);

		[Export ("columnIsNull:")]
		bool ColumnIsNull (string columnName);

		[Export ("resultDictionary")]
		NSDictionary ResultDictionary { get; }

		[Export ("resultDict")]
		NSDictionary ResultDict { get; }

		[Export ("kvcMagic:")]
		void KvcMagic (NSObject _object);
	}

	[BaseType (typeof (NSObject))]
	public partial interface FMDatabasePool {

		[Export ("path", ArgumentSemantic.Retain)]
		string Path { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		NSObject Delegate { get; set; }

		[Export ("maximumNumberOfDatabasesToCreate")]
		uint MaximumNumberOfDatabasesToCreate { get; set; }

		[Static, Export ("databasePoolWithPath:")]
		NSObject DatabasePoolWithPath (string aPath);

		[Export ("initWithPath:")]
		IntPtr Constructor (string aPath);

		[Export ("countOfCheckedInDatabases")]
		uint CountOfCheckedInDatabases { get; }

		[Export ("countOfCheckedOutDatabases")]
		uint CountOfCheckedOutDatabases { get; }

		[Export ("countOfOpenDatabases")]
		uint CountOfOpenDatabases { get; }

		[Export ("releaseAllDatabases")]
		void ReleaseAllDatabases ();

		[Export ("inDatabase:")]
		void InDatabase (Action<FMDatabase> block);

		[Export ("inTransaction:")]
		void InTransaction (Action<FMDatabase, bool> block);

		[Export ("inDeferredTransaction:")]
		void InDeferredTransaction (Action<FMDatabase, bool> block);

		[Export ("inSavePoint:")]
		NSError InSavePoint (Action<FMDatabase, bool> block);
	}

	[Category, BaseType (typeof (NSObject))]
	public partial interface FMDatabasePoolDelegate_NSObject {

		[Export ("databasePool:shouldAddDatabaseToPool:")]
		bool DatabasePool (FMDatabasePool pool, FMDatabase database);
	}

	[BaseType (typeof (NSObject))]
	public partial interface FMDatabase {

		[Export ("traceExecution")]
		bool TraceExecution { get; set; }

		[Export ("checkedOut")]
		bool CheckedOut { get; set; }

		[Export ("busyRetryTimeout")]
		int BusyRetryTimeout { get; set; }

		[Export ("crashOnErrors")]
		bool CrashOnErrors { get; set; }

		[Export ("logsErrors")]
		bool LogsErrors { get; set; }

		[Export ("cachedStatements", ArgumentSemantic.Retain)]
		NSMutableDictionary CachedStatements { get; set; }

		[Static, Export ("databaseWithPath:")]
		NSObject DatabaseWithPath (string inPath);

		[Export ("initWithPath:")]
		IntPtr Constructor (string inPath);

		[Export ("open")]
		bool Open ();

		[Export ("openWithFlags:")]
		bool OpenWithFlags (int flags);

		[Export ("close")]
		bool Close ();

		[Export ("goodConnection")]
		bool GoodConnection { get; }

		[Export ("clearCachedStatements")]
		void ClearCachedStatements ();

		[Export ("closeOpenResultSets")]
		void CloseOpenResultSets ();

		[Export ("hasOpenResultSets")]
		bool HasOpenResultSets { get; }

		[Export ("setKey:")]
		bool SetKey (string key);

		[Export ("rekey:")]
		bool Rekey (string key);

		[Export ("setKeyWithData:")]
		bool SetKeyWithData (NSData keyData);

		[Export ("rekeyWithData:")]
		bool RekeyWithData (NSData keyData);

		[Export ("databasePath")]
		string DatabasePath { get; }

		[Export ("lastErrorMessage")]
		string LastErrorMessage { get; }

		[Export ("lastErrorCode")]
		int LastErrorCode { get; }

		[Export ("hadError")]
		bool HadError { get; }

		[Export ("lastError")]
		NSError LastError { get; }

		[Export ("lastInsertRowId")]
		//sqlite_int64
		long LastInsertRowId { get; }

		[Export ("sqliteHandle")]
		//(sqlite3*)
		IntPtr SqliteHandle { get; }

		[Export ("update:withErrorAndBindings:")]
		bool Update (string sql, out NSError outErr);

		[Export ("executeUpdate:")]
		bool ExecuteUpdate (string sql);

		[Export ("executeUpdateWithFormat:")]
		bool ExecuteUpdateWithFormat (string format);

		[Export ("executeUpdate:withArgumentsInArray:")]
		bool ExecuteUpdate (string sql, NSObject [] arguments);

		[Export ("executeUpdate:withParameterDictionary:")]
		bool ExecuteUpdate (string sql, NSDictionary arguments);

		[Export ("executeQuery:")]
		FMResultSet ExecuteQuery (string sql);

		[Export ("executeQueryWithFormat:")]
		FMResultSet ExecuteQueryWithFormat (string format);

		[Export ("executeQuery:withArgumentsInArray:")]
		FMResultSet ExecuteQuery (string sql, NSObject[] arguments);

		[Export ("executeQuery:withParameterDictionary:")]
		FMResultSet ExecuteQuery (string sql, NSDictionary arguments);

		[Export ("rollback")]
		bool Rollback ();

		[Export ("commit")]
		bool Commit ();

		[Export ("beginTransaction")]
		bool BeginTransaction ();

		[Export ("beginDeferredTransaction")]
		bool BeginDeferredTransaction ();

		[Export ("inTransaction")]
		bool InTransaction { get; }

		[Export ("shouldCacheStatements")]
		bool ShouldCacheStatements { get; set; }

		[Export ("startSavePointWithName:error:")]
		bool StartSavePointWithName (string name, out NSError outErr);

		[Export ("releaseSavePointWithName:error:")]
		bool ReleaseSavePointWithName (string name, out NSError outErr);

		[Export ("rollbackToSavePointWithName:error:")]
		bool RollbackToSavePointWithName (string name, out NSError outErr);

		[Export ("inSavePoint:")]
		NSError InSavePoint (Action<bool> block);

		[Static, Export ("isSQLiteThreadSafe")]
		bool IsSQLiteThreadSafe { get; }

		[Static, Export ("sqliteLibVersion")]
		string SqliteLibVersion { get; }

		[Export ("changes")]
		int Changes { get; }

		//[Export ("makeFunctionNamed:maximumArguments:withBlock:")]
		//void MakeFunctionNamed (string name, int count, Delegate block);

		[Static, Export ("storeableDateFormat:")]
		NSDateFormatter StoreableDateFormat (string format);

		[Export ("hasDateFormatter")]
		bool HasDateFormatter { get; }

		[Export ("setDateFormat:")]
		void SetDateFormat (NSDateFormatter format);

		[Export ("dateFromString:")]
		NSDate DateFromString (string s);

		[Export ("stringFromDate:")]
		string StringFromDate (NSDate date);
	}

	[BaseType (typeof (NSObject))]
	public partial interface FMStatement {

		[Export ("useCount")]
		int UseCount { get; set; }

		[Export ("query", ArgumentSemantic.Retain)]
		string Query { get; set; }

		[Export ("statement", ArgumentSemantic.Assign)]
		//(sqlite3_stmt *)
		IntPtr Statement { get; set; }

		[Export ("close")]
		void Close ();

		[Export ("reset")]
		void Reset ();
	}

	[BaseType (typeof (FMDatabase))]
	public partial interface SpatialDatabase {

		[Static, Export ("spatialiteLibVersion")]
		string SpatialiteLibVersion { get; }

		[Export ("initWithPath:")]
		IntPtr Constructor (string aPath);
	}

	[BaseType (typeof (NSObject))]
	public partial interface ShapeKitFactory {

		[Static, Export ("defaultFactory")]
		ShapeKitFactory DefaultFactory { get; }

//		[Export ("geometryWithGEOSGeometry:")]
//		ShapeKitGeometry GeometryWithGEOSGeometry ([unmapped: pointer: Pointer] geometry);

		[Export ("geometryWithWKB:")]
		ShapeKitGeometry GeometryWithWKB (NSData wkbData);

		[Export ("geometryWithWKT:")]
		ShapeKitGeometry GeometryWithWKT (string _string);
	}

	[BaseType (typeof (NSObject))]
	public partial interface ShapeKitGeometry {

//		[Export ("initWithWKB:size:")]
//		IntPtr Constructor ([unmapped: pointer: Pointer] wkb, size_t wkb_size);

		[Export ("initWithWKT:")]
		IntPtr Constructor (string wkt);

//		[Export ("initWithGeosGeometry:")]
//		IntPtr Constructor ([unmapped: pointer: Pointer] geom);

		[Export ("wktGeom", ArgumentSemantic.Copy)]
		string WktGeom { get; }

		[Export ("geomType", ArgumentSemantic.Copy)]
		string GeomType { get; }

		[Export ("projDefinition", ArgumentSemantic.Copy)]
		string ProjDefinition { get; }

		[Export ("handle")]
		//(void *)
		IntPtr ShapeKitHandle { get; }

		[Export ("numberOfCoords")]
		uint NumberOfCoords { get; }

		[Export ("coordinateAtIndex:")]
		CLLocationCoordinate2D CoordinateAtIndex (int index);

		[Export ("reprojectTo:")]
		void ReprojectTo (string newProjectionDefinition);
	}

	[BaseType (typeof (ShapeKitGeometry))]
	public partial interface ShapeKitPoint {

		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		[Export ("initWithCoordinate:")]
		IntPtr Constructor (CLLocationCoordinate2D coordinate);
	}

	[BaseType (typeof (ShapeKitGeometry))]
	public partial interface ShapeKitPolyline {

		[Export ("initWithCoordinates:count:")]
		//(CLLocationCoordinate2D[])
		IntPtr Constructor (NSValue[] coordinates, uint count);
	}

	[BaseType (typeof (ShapeKitGeometry))]
	public partial interface ShapeKitPolygon {

		[Export ("initWithCoordinates:count:")]
		//(CLLocationCoordinate2D[])
		IntPtr Constructor (NSValue[] coordinates, uint count);

		[Export ("interiors")]
		NSObject [] Interiors { get; }
	}

	[BaseType (typeof (ShapeKitGeometry))]
	public partial interface ShapeKitGeometryCollection {

		[Export ("numberOfGeometries")]
		uint NumberOfGeometries ();

		[Export ("geometryAtIndex:")]
		ShapeKitGeometry GeometryAtIndex (int index);
	}

	[BaseType (typeof (ShapeKitGeometryCollection))]
	public partial interface ShapeKitMultiPolyline {

		[Export ("numberOfPolylines")]
		uint NumberOfPolylines ();

		[Export ("polylineAtIndex:")]
		ShapeKitPolyline PolylineAtIndex (int index);
	}

	[BaseType (typeof (ShapeKitGeometryCollection))]
	public partial interface ShapeKitMultiPoint {

		[Export ("numberOfPoints")]
		uint NumberOfPoints ();

		[Export ("pointAtIndex:")]
		ShapeKitPoint PointAtIndex (int index);
	}

	[BaseType (typeof (ShapeKitGeometryCollection))]
	public partial interface ShapeKitMultiPolygon {

		[Export ("numberOfPolygons")]
		uint NumberOfPolygons ();

		[Export ("polygonAtIndex:")]
		ShapeKitPolygon PolygonAtIndex (int index);
	}

	[Category, BaseType (typeof (ShapeKitGeometry))]
	public partial interface Predicates_ShapeKitGeometry {

		[Export ("isDisjointFromGeometry:")]
		bool IsDisjointFromGeometry (ShapeKitGeometry compareGeometry);

		[Export ("touchesGeometry:")]
		bool TouchesGeometry (ShapeKitGeometry compareGeometry);

		[Export ("intersectsGeometry:")]
		bool IntersectsGeometry (ShapeKitGeometry compareGeometry);

		[Export ("crossesGeometry:")]
		bool CrossesGeometry (ShapeKitGeometry compareGeometry);

		[Export ("isWithinGeometry:")]
		bool IsWithinGeometry (ShapeKitGeometry compareGeometry);

		[Export ("containsGeometry:")]
		bool ContainsGeometry (ShapeKitGeometry compareGeometry);

		[Export ("overlapsGeometry:")]
		bool OverlapsGeometry (ShapeKitGeometry compareGeometry);

		[Export ("isEqualToGeometry:")]
		bool IsEqualToGeometry (ShapeKitGeometry compareGeometry);

		[Export ("isRelatedToGeometry:withRelatePattern:")]
		bool IsRelatedToGeometry (ShapeKitGeometry compareGeometry, string pattern);
	}

	[Category, BaseType (typeof (ShapeKitGeometry))]
	public partial interface Topology_ShapeKitGeometry {

		[Export ("bufferWithWidth:")]
		ShapeKitPolygon BufferWithWidth (double width);

		[Export ("boundary")]
		ShapeKitGeometry Boundary ();

		[Export ("centroid")]
		ShapeKitPoint Centroid ();

		[Export ("convexHull")]
		ShapeKitPolygon ConvexHull ();

		[Export ("envelope")]
		ShapeKitPolygon Envelope ();

		[Export ("pointOnSurface")]
		ShapeKitPoint PointOnSurface ();

		[Export ("relationshipWithGeometry:")]
		string RelationshipWithGeometry (ShapeKitGeometry geometry);

		[Export ("intersectionWithGeometry:")]
		ShapeKitGeometry IntersectionWithGeometry (ShapeKitGeometry geometry);

		[Export ("differenceWithGeometry:")]
		ShapeKitGeometry DifferenceWithGeometry (ShapeKitGeometry geometry);

		[Export ("unionWithGeometry:")]
		ShapeKitGeometry UnionWithGeometry (ShapeKitGeometry geometry);
	}

	[Category, BaseType (typeof (ShapeKitMultiPolygon))]
	public partial interface Topology_ShapeKitMultiPolygon {

		[Export ("cascadedUnion")]
		ShapeKitGeometry CascadedUnion ();
	}

	[Category, BaseType (typeof (ShapeKitPolyline))]
	public partial interface Linearref_ShapeKitPolyline {

		[Export ("distanceFromOriginToProjectionOfPoint:")]
		double DistanceFromOriginToProjectionOfPoint (ShapeKitPoint point);

		[Export ("normalizedDistanceFromOriginToProjectionOfPoint:")]
		double NormalizedDistanceFromOriginToProjectionOfPoint (ShapeKitPoint point);

		[Export ("middlePoint")]
		ShapeKitPoint MiddlePoint ();

		[Export ("interpolatePointAtDistance:")]
		ShapeKitPoint InterpolatePointAtDistance (double distance);

		[Export ("interpolatePointAtNormalizedDistance:")]
		ShapeKitPoint InterpolatePointAtNormalizedDistance (double fraction);
	}
}
