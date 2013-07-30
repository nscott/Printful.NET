using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;

namespace Printful.NET
{
    /// <summary>
    /// A full PrintfulOrder.
    /// </summary>
    [DataContract]
    public class PrintfulOrder
    {
        [DataMember(Name = "notes")]
        public string Notes { get; set; }

        [DataMember(Name = "handling")]
        public string Handling { get; set; }

        [DataMember(Name = "recipient")]
        public PrintfulRecipient Recipient { get; set; }

        [DataMember(Name = "items")]
        public List<PrintfulItem> Items { get; set; }

        /// <summary>
        /// The order number is _required_. Please add an order number to track this order, as well as to update or delete the order in the future.
        /// </summary>
        [DataMember(Name = "number")]
        public int OrderNumber { get; set; }

        /// <summary>
        /// An order number is always required for an order to work
        /// </summary>
        /// <param name="orderNumber"></param>
        public PrintfulOrder(int orderNumber)
        {
            Items = new List<PrintfulItem>();
            Notes = "";
            Handling = PrintfulShippingHandling.STANDARD;
            Recipient = new PrintfulRecipient();
            OrderNumber = orderNumber;
        }

        public PrintfulOrder(int orderNumber, string notes, string handling, PrintfulRecipient recipient, List<PrintfulItem> items)
        {
            OrderNumber = orderNumber;
            Notes = notes;
            Handling = handling;
            Recipient = recipient;
            Items = items;
        }

        public string ToJson()
        {
            string jsonToSend = "";

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PrintfulOrder));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                jsonToSend = Encoding.Default.GetString(ms.ToArray());
                ms.Close();
            }
            return jsonToSend;
        }
    }
}
