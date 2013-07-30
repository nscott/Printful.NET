using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Printful.NET
{
    [DataContract]
    public class PrintfulApiResult
    {
        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "notes")]
        public string Notes { get; set; }

        [DataMember(Name = "handling")]
        public string Handling { get; set; }

        [DataMember(Name = "shipping")]
        public double Shipping { get; set; }

        [DataMember(Name = "tax")]
        public double Tax { get; set; }

        [DataMember(Name = "total")]
        public double Total { get; set; }

        [DataMember(Name = "created")]
        public long Created { get; set; }
        
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "recipients")]
        public PrintfulRecipient Recipient { get; set; }

        [DataMember(Name = "items")]
        public List<PrintfulItem> Items { get; set; }

        [DataMember(Name = "fulfilments")]
        public string Fulfilments { get; set; }

        public PrintfulApiResult() { }
    }
}
