using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// from http://msdn.microsoft.com/en-us/library/bb546159.aspx
class DirLinq
{
    // This query will produce the full path for all .txt files 
    // under the specified folder including subfolders. 
    // It orders the list according to the file name. 
    static void Main()
    {
        string startFolder = @".";

        // Take a snapshot of the file system.
        DirectoryInfo dir = new DirectoryInfo( startFolder );

        // This method assumes that the application has discovery permissions 
        // for all folders under the specified path.
        IEnumerable<FileInfo> fileList = dir.GetFiles( "*.*", SearchOption.AllDirectories );

        //Create the query
        IEnumerable<FileInfo> fileQuery =
            from file in fileList
            where file.Extension == ".txt"
            orderby file.Name
            select file;

        //Execute the query. This might write out a lot of files! 
        foreach ( FileInfo fi in fileQuery )
        {
            Console.WriteLine( fi.FullName );
        }

        // Create and execute a new query by using the previous  
        // query as a starting point. fileQuery is not  
        // executed again until the call to Last() 
        var newestFile =
            (from file in fileQuery
             orderby file.CreationTime
             select new { file.FullName, file.CreationTime })
            .Last();

        Console.WriteLine( "\r\nThe newest .txt file is {0}. Creation time: {1}",
            newestFile.FullName, newestFile.CreationTime );

        // Keep the console window open in debug mode.
        Console.WriteLine( "Press any key to exit" );
        Console.ReadKey();
    }
}