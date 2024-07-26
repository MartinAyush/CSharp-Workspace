using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class GarbageCollection
    {
        /*
         *  Garbage collection (GC) is a process by which the C# runtime automatically 
         *  frees up memory that is no longer being used by your application. 
         * 
         *  Algorithm used in Garbage Collection :- Mark - Compact Algorithm.
         *  Mark-compact garbage collection is a type of garbage collection algorithm that combines the 
         *  mark-and-sweep algorithm with a compaction step. 
         *  
         *  The mark-and-sweep algorithm works by first marking all of the objects in the heap that are still being used. 
         *  Once all of the live objects have been marked, the GC then sweeps through the heap and frees up the memory 
         *  that is used by the dead objects. 
         *  
         *  The compaction step in mark-compact garbage collection moves all of the live objects together in the heap, 
         *  which helps to reduce fragmentation in the heap.
         *  
         *  In short, mark-compact garbage collection is a more efficient algorithm than mark-and-sweep garbage collection,
         *  especially for large heaps, but it can also be more disruptive to the application, 
         *  as it requires the heap to be compacted.
         */
    }
}
