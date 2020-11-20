using System;
using System.Collections.Generic;

namespace Singleton.AmbientContext
{
    public class BuildingContext : IDisposable
    {
        // We need to add a list of stack of values (depending of the context)
        public int WallHeight { get; set; }

        private static Stack<BuildingContext> stack = new Stack<BuildingContext>();

        static BuildingContext()
        {
            stack.Push(new BuildingContext(0));
        }

        public BuildingContext(int wallHeight)
        {
            WallHeight = wallHeight;
            stack.Push(this);
        }

        public static BuildingContext Current => stack.Peek();

        public void Dispose()
        {
            if (stack.Count > 1)
            {
                stack.Pop();
            }
        }
    }
}