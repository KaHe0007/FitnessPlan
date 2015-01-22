using log4net;

namespace FitnessLibrary.Common
{
    public abstract class EnableLogging
    {
        public static readonly ILog Log = LogManager.GetLogger("Fitnessplan");
        //public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetMethodFromHandle().DeclaringType);
    }
}
