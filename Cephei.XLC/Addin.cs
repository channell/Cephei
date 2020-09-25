using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDna.Integration;
using ExcelDna.Integration.Rtd;
using ExcelDna.Integration.CustomUI;
using Cephei.XL;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Cephei.XL
{
    public class Addin : ExcelDna.Integration.IExcelAddIn, Cephei.XL.IExcelInterace
    {
        public void AutoClose()
        {
        }

        public void AutoOpen()
        {
            Model .xlInterface = this;

        }

        public bool IsInFunctionWizard()
        {
            return ExcelDnaUtil.IsInFunctionWizard();
        }

        public object ModelRTD(string mnemonic, string hash)
        {
            return XlCall.RTD("Cephei.XL.ModelRTD", null, mnemonic, hash);
        }

        public object ValueRTD(string mnemonic, string layout)
        {
            return XlCall.RTD("Cephei.XL.ValueRTD", null, mnemonic, layout);
        }
    }

    public class ModelRTD : ExcelRtdServer
    {
        private Dictionary<ExcelRtdServer.Topic, string> _topics = new Dictionary<Topic, string>();
        private Dictionary<string, LinkedList<ExcelRtdServer.Topic>> _topicIndex = new Dictionary<string, LinkedList<Topic>>();


        protected override object ConnectData(Topic topic, IList<string> topicInfo, ref bool newValues)
        {
            var mnemonic = topicInfo[0];
            var hc = topicInfo[1];

            _topics[topic] = mnemonic;
            if (_topicIndex.ContainsKey(mnemonic))
                _topicIndex[mnemonic].AddLast(topic);
            else
            {
                var ll = new LinkedList<Topic>();
                _topicIndex[mnemonic] = ll;
                ll.AddLast(topic);
            }
            Model.add(mnemonic);
            return mnemonic;
        }

        protected override void DisconnectData(Topic topic)
        {
            var mnemonic = _topics[topic];
            var ll = _topicIndex[mnemonic];

            _topics.Remove(topic);
            ll.Remove(topic);
            if (ll.Count == 0)
                Model.remove(mnemonic);

        }
    }
    public class ValueRTD : ExcelRtdServer, Cephei.XL.IValueRTD
    {
        private Dictionary<ExcelRtdServer.Topic, KeyValuePair<string, string>> _topics = new Dictionary<Topic, KeyValuePair<string, string>>();
        private Dictionary<KeyValuePair<string, string>, LinkedList<ExcelRtdServer.Topic>> _topicIndex = new Dictionary<KeyValuePair<string, string>, LinkedList<Topic>>();
        private Dictionary<KeyValuePair<string, string>, IDisposable> _subscriptions = new Dictionary<KeyValuePair<string, string>, IDisposable>();

        public void UpdateRange(string value1, string value2, object[,] value3)
        {
            throw new NotImplementedException();
        }

        public void UpdateValue(string value1, string value2, object value3)
        {
            throw new NotImplementedException();
        }

        protected override object ConnectData(Topic topic, IList<string> topicInfo, ref bool newValues)
        {

            var mnemonic = topicInfo[0];
            var layout = topicInfo[1];

            var kv = new KeyValuePair<string, string>(mnemonic, layout);

            if (_topicIndex.ContainsKey(kv))
            {
                _topics[topic] = kv;
                _topicIndex[kv].AddLast(topic);
                return Model.cell(mnemonic).Box;
            }
            else
            {
                _topics[topic] = kv;
                var ll = new LinkedList<Topic>();
                _topicIndex[kv] = ll;
                ll.AddLast(topic);
                var listener = Model.subscribe(this, mnemonic, layout);
                if (listener != null)
                {
                    _subscriptions[kv] = listener;
                    return Model.cell(mnemonic).Box;
                }
                else
                    return "#NotValue";
            }
        }
        protected override void DisconnectData(Topic topic)
        {
            var kv = _topics[topic];
            var ll = _topicIndex[kv];

            _topics.Remove(topic);
            ll.Remove(topic);
            if (ll.Count == 0)
            {
                _topicIndex.Remove(kv);
                _subscriptions[kv].Dispose();
                _subscriptions.Remove(kv);
            }
        }
    }
}
