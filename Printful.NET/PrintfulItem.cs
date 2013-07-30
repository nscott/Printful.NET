using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Printful.NET
{
    /// <summary>
    /// Represents a Printful item.
    /// ProductId is NOT checked for validity.
    /// </summary>
    [DataContract]
    public class PrintfulItem
    {
        /// <summary>
        /// ProductId can be found at https://www.theprintful.com/api/products. It is NOT checked for validity here.
        /// </summary>
        [DataMember(Name = "product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Any SKU you want
        /// </summary>
        [DataMember(Name = "sku")]
        public int Sku { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The URL where the image resides
        /// </summary>
        [DataMember(Name = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The number of items to send
        /// </summary>
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        public PrintfulItem()
        {

        }
    }
}
