SpatialDBKitSharp
=================

This project is Xamarin.iOS port of [SpatialDBKit](https://github.com/andreacremaschi/SpatialDBKit).  
This repository is public but maintainer is very newbie of Xamarin binding, so just experimental.  
Cause of short knowledge about Marshal Class, there are many interfaces exposured as IntPtr.  
Patches, pull requests, tests are very welcome.  

## SpatialDBKit is ##

An Objective-C lightweight spatial RDBMS (based on SQLite/SpatiaLite).
The project manages a whole stack of technologies that allow combined together to perform spatial SQL queries (i.e. queries based on distance, intersection between geometries etc.) to obtain easy-to-use Cocoa objects.

## Notice ##

static library file SpatialDBKit/SpatialDBKit/libSpatialiteFMDB.a is too big to commit in github, so it was compressed as SpatialDBKit/SpatialDBKit/libSpatialiteFMDB.a.zip.  
You must unzip it before trying to use this repository.

## Features ##

With SpatialDBKit you will be able to:

* Open a spatialite database:

```cs
    // Open a spatialite database
    var db = new SpatialDatabase (NSBundle.MainBundle.PathForResource ("test", "sqlite"));
    db.Open ();
```

* fetch geometries in form of Shapekit objects:

```cs    
    var rs = db.ExecuteQuery ("select Name, geometry FROM Regions");
    while (rs.Next) {
        Console.WriteLine ("{0}", rs.ResultDict);
    }
```    
    
* or in textual form:

```cs  
    var rs = db.ExecuteQuery ("select Name, AsText(geometry) as geom_text FROM Regions");
```

* calculating distance from a point if you need to:

```cs   
    var rs = db.ExecuteQuery ("select distance(geometry, MakePoint(45.694216,9.676909,4326)) AS text FROM Regions");
```

* or filtering points by distance:

```cs   
    var rs = db.ExecuteQuery ("SELECT astext(geometry) as geometry, distance(geometry, MakePoint(45.694216,9.676909,4326)) as geometry, Name FROM Towns where distance(geometry, MakePoint(45.694216,9.676909,4326)) < 5000");
```

This is just the point of the iceberg.. check [spatialite SQL functions reference list](http://www.gaia-gis.it/gaia-sins/spatialite-sql-4.1.0.html) to be sure you don't miss anything of this awesome library!

## How to use it ##

Since importing C libraries is a sort of nightmare, SpatialDBKit has been thought to be used with [CocoaPods](http://cocoapods.org) that should address all the boring stuff for you.

```
platform :ios, '5.0'
pod 'SpatialDBKit'
```

Of course now you should ```#import <SpatialDBKit/SpatialDatabase.h>```

While fully working, the project is in alpha stage. <em>Please be sure to check that none of the dependency include other versions of sqlite</em> (i.e. -lsqlite3 in 'Other linker flags') or nothing will work!
This issue will be fixed soon.

## Documentation ##

Since SpatialDBKit actually sits on a stack of technology, you should refer to the submodules documentation. The most relevant are:

- [spatialite](https://www.gaia-gis.it/fossil/libspatialite/index)
- [ShapeKit](https://github.com/andreacremaschi/ShapeKit) 
- [FMDB](https://github.com/ccgus/fmdb)


## License ##

 * [PROJ.4](http://trac.osgeo.org/proj/) is under the MIT license.

 * [GEOS](http://trac.osgeo.org/geos/) is available under the terms of  [GNU Lesser General Public License (LGPL)](http://www.gnu.org/licenses/old-licenses/lgpl-2.1.html), and is a project of  [OSGeo](http://www.osgeo.org).
 * [ShapeKit](https://github.com/andreacremaschi/ShapeKit), being a GEOS wrapper, is under the terms of GNU Lesser General Public License.

 * [spatialite](https://www.gaia-gis.it/fossil/libspatialite/index) is developed and maintained by Alessandro Furieri  and are licensed under the [MPL tri-license](http://www.mozilla.org/MPL/boilerplate-1.1/mpl-tri-license-html) terms.
 * SpatialDBKit itself is licensed under the same MPL tri-license terms.

 * [SQLite](http://www.sqlite.org/copyright.html) has been dedicated to the public domain by the authors (thanks!).
 * Its Objective-C wrapper, [FMDB](https://github.com/ccgus/fmdb) by Gus Mueller, is under the MIT License.

**License note: Be aware that LGPL v2.1 (GEOS license) and Apple Store compatibility is at least controversial** ([Ragi Burhum's blog post](http://blog.burhum.com/post/38236943467/your-lgpl-license-is-completely-destroying-ios-adoption) explains why - I join his appeal to open up the license, anyway).
