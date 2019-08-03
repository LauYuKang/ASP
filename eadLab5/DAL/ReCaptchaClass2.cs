using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace eadLab5.DAL
{
    public class ReCaptchaClass2
    {
        public static string Validate(string EncodedResponseStaff)
        {
            var client = new System.Net.WebClient();

            string PrivateKey = "6Lfig7AUAAAAAGeJYCHIqGZ76PrarFf6K-Tadls9";

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponseStaff));

            var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass2>(GoogleReply);

            return captchaResponse.Success.ToLower();
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }
}