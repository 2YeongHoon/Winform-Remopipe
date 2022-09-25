using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace removipe.Common
{
    public class TraceManager
    {
        public TraceManager()
        {
            startupFolder = Application.StartupPath;
        }

        static bool useSaveLog = true;
        /// <summary>
        /// ログファイルを保存するかのフラグ
        /// </summary>
        public static bool UseSaveLog
        {
            get { return useSaveLog; }
            set { useSaveLog = value; }
        }

        static int traceMaxDay = 1;

        /// <summary>
        /// 保存する最大日
        /// </summary>
        public static int TraceMaxDay
        {
            get { return traceMaxDay; }
            set
            {
                traceMaxDay = value;
                if (traceMaxDay <= 0) traceMaxDay = 1;
            }
        }

        static string logFoler = "Trace";

        /// <summary>
        /// 保存するログフォルダ
        /// </summary>
        public static string LogFoler
        {
            get { return logFoler; }
            set { logFoler = value; }
        }



        static string startupFolder = Application.StartupPath;
        /// <summary>
        /// ex) c:\\startup  뒤쪽에 \\를 붙이지 말것
        /// default = Application.Startup
        /// </summary>
        public static string StartupFolder
        {
            get { return startupFolder; }
            set { startupFolder = value; }
        }


        /// <summary>
        /// ログを追加
        /// 内部できに日時を入れて保存
        /// </summary>
        /// <param name="log"></param>
        public static void AddLog(string log)
        {
            Console.WriteLine(log);
            if (!UseSaveLog) return;

            try
            {
                //読み込むファイルの名前
                string folder = Path.Combine(startupFolder, LogFoler);

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = folder + "\\" + "Trace_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                DateTime dtm = DateTime.Now;
                string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00} [{6:000}] ",
                    dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                log = formatDateTime + log;

                System.IO.StreamWriter sw = File.AppendText(fileName);
                sw.WriteLine(log);
                sw.Close();

                CheckRemoveFiles(folder);
            }
            catch (Exception ex)
            {
                AddLogEvent("ApplicationLogAddError", "Log Append error :" + log + ex.Message + ex.StackTrace, 9999);
            }

        }
        static void CheckRemoveFiles(string folder)
        {
            int maxHour = TraceMaxDay * 24; //

            string[] files = Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                DateTime tm = File.GetLastAccessTime(files[i]);
                TimeSpan span = DateTime.Now - tm;
                if (span.TotalHours >= maxHour)
                {
                    File.Delete(files[i]);
                }
            }
        }



        /// <summary>
        /// エベントログにログを書く
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="eventID"></param>
        public static void AddLogEvent(string source, string message, int eventID)
        {
            //ソース
            //string sourceName = Application.ProductName;//
            //ソースが存在していない時は、作成する
            //if (!System.Diagnostics.EventLog.SourceExists(source))
            //{
            //    //ログ名を空白にすると、"Application"となる
            //    System.Diagnostics.EventLog.CreateEventSource(source, "");
            //}

            //テスト用にイベントログエントリに付加するデータを適当に作る
            //byte[] myData = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //イベントログにエントリを書き込む
            //ここではエントリの種類をエラー、イベントIDを1、分類を1000とする
            // "イベントログに書き込む文字列",

            //System.Diagnostics.EventLog.WriteEntry(source, message, System.Diagnostics.EventLogEntryType.Error, eventID, 1000);//, 1, 1000, myData);

            //次のようにイベントソースとメッセージのみを指定して書き込むと、
            //Information("情報")エントリとして書き込まれる。
            //System.Diagnostics.EventLog.WriteEntry(
            //    "MySource", "イベントログに書き込む文字列");
        }

    }

}
