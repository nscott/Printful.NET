using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Printful.NET
{
    /// <summary>
    /// Shipping & handling options.
    /// </summary>
    [DataContract(Name = "handling")]
    public class PrintfulShippingHandling
    {
        //static class
        private PrintfulShippingHandling(){}

        [DataMember(Name = "STANDARD")]
        public static string STANDARD = "STANDARD";

        [DataMember(Name = "PRIORITY")]
        public static string PRIORITY = "PRIORITY";
    }
}
