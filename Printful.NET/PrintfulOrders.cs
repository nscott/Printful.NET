using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Printful.NET
{
    /// <summary>
    /// All the CRUD you need for your orders
    /// </summary>
    public class PrintfulOrders : PrintfulRequester
    {
        public PrintfulOrders(Printful printful) : base(printful)
        {
        }

        /// <summary>
        /// Serialize and send the order to Printful
        /// </summary>
        /// <param name="order"></param>
        /// <returns>true on success, false on failure</returns>
        public bool CreateOrder(PrintfulOrder order)
        {
            PrintfulRequestResult result = null;
            try
            {
                string jsonToSend = order.ToJson();
                string url = Printful.ApiUrl + "orders";

                result = SendRequest(url, jsonToSend, "POST");
                result.DeserializeRawBody();
            }
            catch (Exception e)
            {
                _printful.LastErrorMessage = e.Message;
            }

            if (result != null)
            {
                return result.Success;
            }
            return false;
        }

        /// <summary>
        /// Update the order based on orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="updatedOrder"></param>
        /// <returns></returns>
        public bool UpdateOrder(int orderId, PrintfulOrder updatedOrder)
        {
            PrintfulRequestResult result = null;
            try
            {
                if (updatedOrder == null)
                {
                    throw new PrintfulException("No order supplied for the updated order!");
                }
                string url = Printful.ApiUrl + "orders/" + orderId;
                result = SendRequest(url, updatedOrder.ToJson(), "PUT");
                result.DeserializeRawBody();
            }
            catch (Exception e)
            {
                _printful.LastErrorMessage = e.Message;
                if (_printful.LetExceptionsBubble)
                {
                    throw;
                }
            }

            if (result != null)
            {
                return result.Success;
            }
            return false;
        }

        /// <summary>
        /// Delete the order based on order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool DeleteOrder(int orderId)
        {
            string url = Printful.ApiUrl + "orders/" + orderId;
            PrintfulRequestResult result = SendRequest(url, null, "DELETE");
            if (result != null)
            {
                return result.Success;
            }
            return false;
        }

        /// <summary>
        /// Grab the current order status based on order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string OrderStatus(int orderId)
        {
            string url = Printful.ApiUrl + "orders/" + orderId;
            PrintfulRequestResult result = SendRequest(url, null, "GET");
            result.DeserializeRawBody();
            if (result != null && result.Success)
            {
                return result.RawBody;
            }
            return null;
        }  
    }
}
