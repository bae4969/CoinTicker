using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace UpbitDealer.src
{
    public class Ticker
    {
        public string name;
        public string open = "";
        public string close = "";
        public string max = "";
        public string min = "";
        public string volume = "";
        public string prePrice = "";
        public string accTotal = "";
        public string accVolume = "";
        public string change = "";
        public string changeRate = "";

        public Ticker(string name)
        {
            this.name = name;
        }
    }

    static class ac
    {
        public static string BASE_URL = "https://api.upbit.com/v1/";

        public static string CANDLE_MIN1 = "minutes/1";
        public static string CANDLE_MIN3 = "minutes/3";
        public static string CANDLE_MIN5 = "minutes/5";
        public static string CANDLE_MIN10 = "minutes/10";
        public static string CANDLE_MIN15 = "minutes/15";
        public static string CANDLE_MIN30 = "minutes/30";
        public static string CANDLE_HOUR1 = "minutes/60";
        public static string CANDLE_HOUR4 = "minutes/240";
        public static string CANDLE_DAY = "days";
        public static string CANDLE_WEEK = "weeks";
        public static string CANDLE_MONTH = "months";
    }

    class ApiData
    {
        public JArray getCoinList(bool detail = false)
        {
            string url = ac.BASE_URL + "market/all";
            string dataParams;
            if (detail)
                dataParams = "isDetails=true";
            else
                dataParams = "isDetails=false";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + dataParams);
            request.Method = "GET";

            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                return JArray.Parse(reader.ReadToEnd());
            }
            catch
            {
                return null;
            }
        }

        public JArray getCandle(string coinName, string candleType, int num = 0)
        {
            string url = ac.BASE_URL + "candles/" + candleType;
            string dataParams = "market=KRW-" + coinName;
            if (num > 0) dataParams += "&count=" + num;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + dataParams);
            request.Method = "GET";

            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                return JArray.Parse(reader.ReadToEnd());
            }
            catch
            {
                return null;
            }
        }

        public JArray getTrans(string coinName, int num = 0)
        {
            string url = ac.BASE_URL + "trades/ticks";
            string dataParams = "market=KRW-" + coinName;
            if (num > 0) dataParams += ("&count=" + num);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + dataParams);
            request.Method = "GET";

            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                return JArray.Parse(reader.ReadToEnd());
            }
            catch
            {
                return null;
            }
        }

        public JArray getTicker(List<string> coinName)
        {
            string url = ac.BASE_URL + "ticker";
            string dataParams = "markets=KRW-" + coinName[0];
            for (int i = 1; i < coinName.Count; i++)
                dataParams += ",KRW-" + coinName[i];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + dataParams);
            request.Method = "GET";

            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                return JArray.Parse(reader.ReadToEnd());
            }
            catch (WebException wx)
            {
                return new JArray();
            }
        }

        public JArray getOrderBook(List<string> coinName)
        {
            string url = ac.BASE_URL + "orderbook";
            string dataParams = "markets=KRW-" + coinName[0];
            for (int i = 1; i < coinName.Count; i++)
                dataParams += ",KRW-" + coinName[i];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + dataParams);
            request.Method = "GET";

            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                return JArray.Parse(reader.ReadToEnd());
            }
            catch
            {
                return null;
            }
        }
    }
}
