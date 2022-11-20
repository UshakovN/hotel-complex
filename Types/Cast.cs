using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public static class Cast
    {
        public static T CastObject<T>(object input)
        {
            return (T)input;
        }

        public static T ConvertObject<T>(object source)
        {
            return (T)Convert.ChangeType(source, typeof(T));
        }

        public static bool TryCastObject<T>(object source, out T output)
        {
            try
            {
                output = (T)source;
                return true;
            }
            catch
            {
                output = default;
                return false;
            }
        }

        public static bool TryConvertObject<T>(object source, out T output)
        {
            try
            {
                output = (T)Convert.ChangeType(source, typeof(T));
                return true;    
            }
            catch
            {
                output = default;
                return false;
            }
        }



    }
}