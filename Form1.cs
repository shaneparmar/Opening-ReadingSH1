using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;


namespace sh1demo
{
    public partial class Form1 : Form
    {
        private static Type StructType = typeof(TSHType1Record);
        private static int StructSize = Marshal.SizeOf(StructType);
        private string FilePath = @"Z:\DEVELOPMENT\Shane\SH1\20201229.SH1";
        private byte[] buffer = new byte[StructSize];

        public Form1()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        public struct TSHType1Record
        {
            //Header
            [FieldOffset(0)]
            public byte Exch;
            [FieldOffset(1)]
            public int ExchCode;
            [FieldOffset(5)]
            public int RecTime;
            [FieldOffset(9)]
            public byte RecType;

            #region CTCL_IML ---to---> IQS

            //a Added on 30.01.17 For Scan Stocks
            [FieldOffset(10)]
            public Single ActionRate;
            [FieldOffset(14)]
            public byte ActionIdentifier;

            //A
            [FieldOffset(10)]
            public Single Rate;
            [FieldOffset(14)]
            public int Qty;
            [FieldOffset(18)]
            public int CumQty;
            [FieldOffset(22)]
            public Single AvgTradePrize;
            [FieldOffset(26)]
            public int OpenInt;

            //B,C,D,E,F
            [FieldOffset(10)]
            public Single BidRate;
            [FieldOffset(14)]
            public int BidQty;
            [FieldOffset(18)]
            public ushort BidOrder;
            [FieldOffset(20)]
            public Single OfferRate;
            [FieldOffset(24)]
            public int OfferQty;
            [FieldOffset(28)]
            public ushort OfferOrder;

            //G
            [FieldOffset(10)]
            public Single Open;
            [FieldOffset(14)]
            public Single High;
            [FieldOffset(18)]
            public Single Low;
            [FieldOffset(22)]
            public Single PrevDayClose;

            //g
            [FieldOffset(10)]
            public Single YearlyHigh;
            [FieldOffset(14)]
            public Single YearlyLow;
            [FieldOffset(18)]
            public byte TickSize; //13.10.15
            [FieldOffset(19)]
            public byte AllowedIntraday; //14.01.2016

            //f
            [FieldOffset(10)]
            public byte AllowMTF;

            //H
            [FieldOffset(10)]
            public Single IndexValue;
            [FieldOffset(14)]
            public int ExchQty;
            [FieldOffset(18)]
            public Single ExchValue;

            //I,i
            [FieldOffset(10)]
            public ushort Adv;
            [FieldOffset(12)]
            public ushort Dec;
            [FieldOffset(14)]
            public ushort Same;
            [FieldOffset(16)]
            public int AdvVal;
            [FieldOffset(20)]
            public int DecVal;
            [FieldOffset(24)]
            public ushort SameVal;
            [FieldOffset(26)]
            public ushort NewHigh;
            [FieldOffset(28)]
            public ushort NewLow;

            #region JKL
            //J
            //[FieldOffset(10)]
            //public byte NewMsgLength;
            //[FieldOffset(11)]
            //public fixed char NewMsg[19];

            ////K
            //[FieldOffset(10)]
            //public byte ContMsgLength;
            //[FieldOffset(11)]
            //public fixed char ContMsg[19];

            ////L
            //[FieldOffset(10)]
            //public byte EOMsgLength;
            //[FieldOffset(11)]
            //public fixed char EOMsg[19];
            #endregion

            //m
            [FieldOffset(10)]
            public int OpenInterest;
            [FieldOffset(14)]
            public int OpenInterestHigh;
            [FieldOffset(18)]
            public int OpenInterestLow;

            //W
            [FieldOffset(10)]
            public Single UpperCktLimit;
            [FieldOffset(14)]
            public Single LowerCktLimit;
            [FieldOffset(18)]
            public int FreezQty;

            //w
            [FieldOffset(10)]
            public Single UpperTERLimit; //05.12.15 Sanchit TRADE EXECUTION RANGE. New Rec Type - 'w'.
            [FieldOffset(14)]
            public Single LowerTERLimit;

            //X
            [FieldOffset(10)]
            public uint TotalBuyQty;
            [FieldOffset(14)]
            public uint TotalSellQty;
            [FieldOffset(18)]
            public int OpenInterestX;
            [FieldOffset(22)]
            public int OpenInterestHighX;
            [FieldOffset(26)]
            public int OpenInterestLowX;

            //Y
            [FieldOffset(10)]
            public byte Exchstatus;

            //Z
            [FieldOffset(10)]
            public int PrevDayTime;
            [FieldOffset(14)]
            public Single PrevDayPrice;
            [FieldOffset(18)]
            public int PrevDayQty;

            #endregion

            #region IQS ---to---> Pointer
            ////M
            //[FieldOffset(10)]
            //public byte ScripNamelength;

            //n
            [FieldOffset(10)]
            public int Expiry;
            [FieldOffset(14)]
            public Single StrikePrice;
            [FieldOffset(18)]
            public byte CPType;
            [FieldOffset(19)]
            public int ULToken;
            [FieldOffset(23)]
            public byte OFISType;
            [FieldOffset(24)]
            public ushort MinimumLotQty;
            [FieldOffset(26)]
            public byte CALevel;

            //S
            [FieldOffset(10)]
            public ushort SummaryRecCnt;
            [FieldOffset(12)]
            public byte ExchType;
            [FieldOffset(13)]
            public byte Dummy19Length;

            //s
            [FieldOffset(10)]
            public ushort HistoryRecCntB;
            [FieldOffset(12)]
            public byte HistoryType;
            [FieldOffset(13)]
            public byte Dummy8ALength;

            //t
            [FieldOffset(10)]
            public Single RateA;
            [FieldOffset(14)]
            public int QtyA;
            [FieldOffset(18)]
            public Single RateB;
            [FieldOffset(22)]
            public int QtyB;
            [FieldOffset(26)]
            public int TimeB;

            //u
            [FieldOffset(10)]
            public ushort HistoryOverB;

            //y
            [FieldOffset(10)]
            public byte ExchMS;
            [FieldOffset(11)]
            public byte ExchTypeMS;
            [FieldOffset(12)]
            public byte ReportType;

            //T
            [FieldOffset(10)]
            public int ScripCnt;

            //U
            [FieldOffset(10)]
            public byte ScripNamelength2;
            [FieldOffset(12)]
            public unsafe fixed byte ScripName2[15];

            ////M
            // [FieldOffset(10)]
            //public byte ScripNamelength;
            // [FieldOffset(11)]                    
            // public string ScripName;           

            #endregion
        }

        private TSHType1Record ReadStruct(FileStream fs)
        {
            fs.Read(buffer, 0, StructSize);
            var gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var addrPinObj = gcHandle.AddrOfPinnedObject();
            gcHandle.Free();
            return (TSHType1Record)Marshal.PtrToStructure(addrPinObj, StructType);
        }



        private Dictionary<char, int> GetHeaderCount()
        {
            var dict = new Dictionary<char, int>();
            var totalRecordsRead = 0;
            var sh1RecordArray = new TSHType1Record[5000];

            using (var fs = File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var totalRecordsAvailable = fs.Length / StructSize;

                if (totalRecordsAvailable == 0) return dict;

                while (totalRecordsRead < totalRecordsAvailable)
                {
                    char recType;
                    var pos = 0;
                    var cnt = (int)Math.Min(sh1RecordArray.Length, totalRecordsAvailable - totalRecordsRead);
                    var recordsToRead = StructSize * cnt;
                    var readBuffer = new byte[sh1RecordArray.Length * StructSize];

                    fs.Read(readBuffer, 0, recordsToRead);
                    IntPtr buffer = Marshal.AllocCoTaskMem(recordsToRead);
                    Marshal.Copy(readBuffer, 0, buffer, recordsToRead);

                    for (int i = 0; i < cnt; i++)
                    {
                        sh1RecordArray[i] = (TSHType1Record)Marshal.PtrToStructure(new IntPtr(buffer.ToInt32() + pos), StructType);
                        pos += StructSize;

                        recType = (char)sh1RecordArray[i].RecType;

                        if (dict.ContainsKey(recType)) dict[recType] = dict[recType] + 1;
                        else dict.Add(recType, 0);
                    }

                    Marshal.FreeCoTaskMem(buffer);
                    totalRecordsRead += cnt;
                }
            }

            return dict;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            GetHeaderCount();
        }
        //private void button1_Click()
        //{
        //    var stWatch = System.Diagnostics.Stopwatch.StartNew();
        //    var controlsList = new List<Control>();
        //    var hsChar = new HashSet<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'g', 'H', 'I', 'i', 'J', 'K', 'L', 'm', 'W', 'w', 'X', 'Y', 'Z', 'z', 'c', 'y', 'd', 'e', 'f', 'j', 'k', 'l', 'n', 'p', 'S', 's', 't', 'u', 'y', 'P', 'a', 'x', 'N', 'v' };

        //    if (GetHeaderCount().Count == 0)
        //    {
        //        MessageBox.Show("No records found...");
        //        return;
        //    }

        //    var newDict = GetHeaderCount().Where(w => w.Value != 0 && hsChar.Contains(w.Key)).ToDictionary(x => x.Key, x => x.Value).OrderBy(o => o.Key);

        //    foreach (var item in newDict)
        //        controlsList.AddRange(new Control[] { new Label { Text = item.Key.ToString() }, new Label { Text = item.Value.ToString(), Anchor = AnchorStyles.Top | AnchorStyles.Right } });

        //    stWatch.Stop();
        //    var time = stWatch.Elapsed;

        //    controlsList.AddRange(new Control[] { new Label { Text = "Time Elasped" }, new Label { Text = time.TotalSeconds.ToString(), Anchor = AnchorStyles.Top | AnchorStyles.Right } });
        //    dataGridView1.Controls.AddRange(controlsList.ToArray());

        //    WindowState = FormWindowState.Maximized;
        //}

    }
}