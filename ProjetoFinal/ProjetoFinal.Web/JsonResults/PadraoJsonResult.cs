using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Ephesto.Web.JsonResults
{
    public class PadraoJsonResult : JsonResult
    {
        const string RequestRefused = "Para retornar uma requisição GET, mude o JsonRequestBehavior para AllowGet.";

        public HttpStatusCode Status { get; set; }
        
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(RequestRefused);

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            SerializeData(response);

        }

        protected virtual void SerializeData(HttpResponseBase response)
        {
            var originalData = Data;

            Data = new
            {
                Success = true,
                Content = originalData,
                ErrorMessages = String.Empty,
                RequestTime = DateTime.Now,
            };

            response.StatusCode = (int)HttpStatusCode.OK;


            response.Write(JsonConvert.SerializeObject(Data));
        }
    }
}