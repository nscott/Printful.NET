using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Printful.NET
{
    /// <summary>
    /// Full information about the recipient of this order
    /// NO VALIDATION IS DONE.
    /// </summary>
    [DataContract]
    public class PrintfulRecipient
    {
        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        [DataMember(Name = "address1")]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "address2")]
        public string AddressLine2 { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// State should just be the short version, e.g. New Jersey is NJ
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Country should be the short version, e.g. United States is US
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// I'm unsure as to what format the phone # should be in
        /// </summary>
        [DataMember(Name = "phone")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }

        public PrintfulRecipient()
        {
        }

        public PrintfulRecipient(string fullName, string addressLine1, string addressLine2, string city, string zip, string state, string country)
        {
            FullName = fullName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Zip = zip;
            State = state;
            Country = country;
        }
    }
}
