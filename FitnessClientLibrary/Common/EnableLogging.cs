using log4net;

namespace FitnessClientLibrary.Common
{
    public abstract class EnableLogging
    {
        public static readonly ILog Log = LogManager.GetLogger("FitnessClientLibrary");
        //public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetMethodFromHandle().DeclaringType);
    }
}
