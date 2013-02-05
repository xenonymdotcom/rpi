using System;
using System.Threading;

namespace MonoFeatureTest
{
    class ThreadCaller
    {
        static void Main()
        {
            ThreadCaller myCaller = new ThreadCaller();
            myCaller.CheckIterator();
            Console.WriteLine( "Main exiting" );
        }

        void CheckIterator()
        {
            Console.WriteLine( "Check Iterator" );
            foreach ( int number in SomeNumbers() )
            {
                Console.Write( " " + number.ToString() );
            }
            Console.WriteLine();
        }

        public static System.Collections.IEnumerable SomeNumbers()
        {
            yield return 3;
            yield return 5;
            yield return 8;
        }

        public ThreadCaller()
        {
            Thread myThread = new Thread( delegate( object myValue )
            {
                Thread.Sleep( 1000 );
                Console.WriteLine( String.Format( "The parameter have" +
                                                " a {0} in it's value",
                                                myValue ) );
                int res = getCalcFunction()( 2, 4 );
                Console.WriteLine( "The sum is {0}", res );
                Console.Write( "Press Key to contine :: " );
                Console.ReadKey();
                Console.WriteLine( "Thread exiting" );
            } );

            // Passing the start-argument to the thread (10 in this case)
            myThread.Start( 101 );
        }

        public Func<int, int, int> getCalcFunction()
        {
            return ( a, b ) => simpleSum( a, b );
        }

        public int simpleSum( int a, int b )
        {
            Console.WriteLine( "Main::simpleSum({0},{1})", a, b );
            return a + b;
        }
    }
}