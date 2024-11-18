using System.Diagnostics;

namespace Dawn
{
    public class Debug
    {
        public static void Log(params object[] args)
        {
            StackFrame frame = new StackFrame(1, true);
            string str = "Demo:";
            if (frame != null)
            {
                str += Path.GetFileName(frame.GetFileName()) + ":" + frame.GetFileLineNumber() + " => ";
            }
            foreach (var v in args)
            {
                str += v.ToString() + " ";
            }
            Console.WriteLine(str);
        }

        public static void Error(params object[] args)
        {
            Log("[Error]", args);
        }
    }
}

