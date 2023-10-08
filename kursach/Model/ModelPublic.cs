using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.Model
{
    public class ModelPublic
    {
        static int _count;
        private static KurkurContext context;
        public static KurkurContext GetContext()
        {
            if (context == null)
            {
                context = new KurkurContext();
            }
            return context;
        }
    }
}
