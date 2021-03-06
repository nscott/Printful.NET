﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Printful.NET
{
    [DataContract]
    public class PrintfulRequestResult
    {
        [IgnoreDataMember]
        public bool Success { get; set; }
        [IgnoreDataMember]
        public string RawBody { get; set; }

        [DataMember(Name = "status")]
        public bool Status { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "result")]
        public PrintfulApiResult Result { get; set; }

        public PrintfulRequestResult()
        {
            Success = false;
            RawBody = null;
        }

        public void DeserializeRawBody()
        {
            if (!String.IsNullOrEmpty(RawBody))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PrintfulRequestResult));
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(RawBody)))
                {
                    PrintfulRequestResult result = (PrintfulRequestResult)ser.ReadObject(ms);
                    this.Success = result.Status;
                    this.Status = result.Status;
                    this.Code = result.Code;
                    this.Result = result.Result;
                }
            }
        }
    }
}
