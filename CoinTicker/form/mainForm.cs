using Newtonsoft.Json.Linq;
using System.Diagnostics;
using UpbitDealer.src;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace CoinTicker
{
    public partial class mainForm : Form
    {
        private bool STOP = false;
        private Thread tickerUpdater;
        private readonly object lock_tickerUpdater = new object();
        private long tickerUpdateInterval = 2000;
        private ApiData apiData = new ApiData();

        private List<string> totalNameList = new List<string>();
        private List<string> updateNameList = new List<string>();
        private Dictionary<string, Ticker> tickerData = new Dictionary<string, Ticker>();
        private List<TextBox> textName = new List<TextBox>();
        private List<TextBox> textValue = new List<TextBox>();

        private bool isClick = false;
        private Point mouseLoc;



        public mainForm()
        {
            InitializeComponent();
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            JArray jArray = apiData.getCoinList();
            if (jArray == null)
            {
                MessageBox.Show("Fail to receive coin list!");
                Close();
                return;
            }
            for (int i = 0; i < jArray.Count; i++)
            {
                string[] coinName = jArray[i]["market"].ToString().Split('-');
                if (coinName.Length > 1)
                    if (coinName[0] == "KRW" && !totalNameList.Contains(coinName[1]))
                    {
                        totalNameList.Add(coinName[1]);
                        leftMenuAddCombo.Items.Add(coinName[1]);
                        leftMenuChartCombo.Items.Add(coinName[1]);
                    }
            }
            totalNameList.Sort();

            // load saved list
            string settingDataPath = System.IO.Directory.GetCurrentDirectory() + "/setting.dat";
            if (!System.IO.File.Exists(settingDataPath)) System.IO.File.Create(settingDataPath);
            else
            {
                string[] reader = System.IO.File.ReadAllLines(settingDataPath);
                for (int i = 0; i < reader.Length; i++)
                    addCoin(reader[i]);
            }
            Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Size.Width - Size.Width,
                Screen.PrimaryScreen.WorkingArea.Size.Height - Size.Height);

            // start thread
            {
                tickerUpdater = new Thread(() => executeTickerUpdater());
                tickerUpdater.Start();
                updater.Start();
            }
        }
        private void mainForm_Shown(object sender, EventArgs e)
        {
            rearrangement();
        }
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;

            // wait for thread
            {
                STOP = true;
                updater.Stop();
                tickerUpdater.Join();
            }

            // save list
            string settingDataPath = System.IO.Directory.GetCurrentDirectory() + "/setting.dat";
            if (!System.IO.File.Exists(settingDataPath)) System.IO.File.Create(settingDataPath);
            System.IO.File.WriteAllText(settingDataPath, string.Join("\n", updateNameList) + '\n');
        }


        private void executeTickerUpdater()
        {
            while (!STOP)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                lock (lock_tickerUpdater)
                {
                    if (updateNameList.Count != 0)
                    {
                        JArray jArray = apiData.getTicker(updateNameList);
                        for (int i = 0; i < jArray.Count; i++)
                        {
                            string[] coinName = jArray[i]["market"].ToString().Split('-');
                            tickerData[coinName[1]].name = coinName[1];
                            tickerData[coinName[1]].open = jArray[i]["opening_price"].ToString();
                            tickerData[coinName[1]].close = jArray[i]["trade_price"].ToString();
                            tickerData[coinName[1]].max = jArray[i]["high_price"].ToString();
                            tickerData[coinName[1]].min = jArray[i]["low_price"].ToString();
                            tickerData[coinName[1]].volume = jArray[i]["trade_volume"].ToString();
                            tickerData[coinName[1]].prePrice = jArray[i]["prev_closing_price"].ToString();
                            tickerData[coinName[1]].accTotal = jArray[i]["acc_trade_price"].ToString();
                            tickerData[coinName[1]].accVolume = jArray[i]["acc_trade_volume"].ToString();
                            tickerData[coinName[1]].change = jArray[i]["signed_change_price"].ToString();
                            tickerData[coinName[1]].changeRate = jArray[i]["signed_change_rate"].ToString();
                        }
                    }
                }

                stopwatch.Stop();
                long sleepTime = tickerUpdateInterval - stopwatch.ElapsedMilliseconds;
                while (!STOP && sleepTime > 0)
                {
                    Thread.Sleep(100);
                    sleepTime -= 100;
                }
            }
        }
        private void updater_Tick(object sender, EventArgs e)
        {
            lock (lock_tickerUpdater)
                for (int i = 0; i < updateNameList.Count; i++)
                    textValue[i].Text = tickerData[updateNameList[i]].close;
        }


        private void rearrangement()
        {
            if (updateNameList.Count == 0)
            {
                Visible = false;
                ShowIcon = false;
            }
            else
            {
                Visible = true;
                ShowIcon = true;

                Size = new Size(192, updateNameList.Count * 26 + 18);
                Point nextLoc = Location;
                if (nextLoc.X + Size.Width > Screen.PrimaryScreen.WorkingArea.Size.Width)
                    nextLoc.X = Screen.PrimaryScreen.WorkingArea.Size.Width - Size.Width;
                else if (nextLoc.X < 0)
                    nextLoc.X = 0;
                if (nextLoc.Y + Size.Height > Screen.PrimaryScreen.WorkingArea.Size.Height)
                    nextLoc.Y = Screen.PrimaryScreen.WorkingArea.Size.Height - Size.Height;
                else if (nextLoc.Y < 0)
                    nextLoc.Y = 0;
                Location = nextLoc;

                groupBox1.Location = new Point(0, updateNameList.Count * 26 + 16);
                for (int i = 0; i < updateNameList.Count; i++)
                {
                    int y = i * 26 + 12;
                    textName[i].Location = new Point(12, y);
                    textValue[i].Location = new Point(78, y);
                }
            }
        }
        private void addCoin(string coinName)
        {
            if (!totalNameList.Contains(coinName)) return;
            if (updateNameList.Contains(coinName)) return;

            TextBox nameBox = new TextBox();
            TextBox valueBox = new TextBox();
            valueBox.BorderStyle = nameBox.BorderStyle = BorderStyle.None;
            valueBox.Text = "0"; nameBox.Text = coinName;
            valueBox.BackColor = nameBox.BackColor = Color.DimGray;
            valueBox.ForeColor = nameBox.ForeColor = Color.White;
            valueBox.Font = nameBox.Font = new Font("arial", 13);
            valueBox.TextAlign = nameBox.TextAlign = HorizontalAlignment.Center;
            valueBox.Cursor = nameBox.Cursor = Cursors.Arrow;
            valueBox.ReadOnly = nameBox.ReadOnly = true;
            valueBox.Size = new Size(100, 20); nameBox.Size = new Size(60, 20);
            valueBox.Enter += focusDisable; nameBox.Enter += focusDisable;
            valueBox.MouseDown += mainForm_MouseDown; nameBox.MouseDown += mainForm_MouseDown;
            valueBox.MouseMove += mainForm_MouseMove; nameBox.MouseMove += mainForm_MouseMove;
            valueBox.MouseUp += mainForm_MouseUp; nameBox.MouseUp += mainForm_MouseUp;
            Controls.Add(valueBox); Controls.Add(nameBox);

            lock (lock_tickerUpdater)
            {
                updateNameList.Add(coinName);
                tickerData.Add(coinName, new Ticker(coinName));
                textName.Add(nameBox);
                textValue.Add(valueBox);
            }
            rearrangement();
            leftMenuAddCombo.Items.Remove(coinName);
            leftMenuRemoveCombo.Items.Add(coinName);
        }
        private void removeCoin(string coinName)
        {
            if (!updateNameList.Contains(coinName)) return;

            int idx = updateNameList.IndexOf(coinName);
            Controls.Remove(textName[idx]);
            Controls.Remove(textValue[idx]);

            lock (lock_tickerUpdater)
            {
                updateNameList.Remove(coinName);
                tickerData.Remove(coinName);
                textName.RemoveAt(idx);
                textValue.RemoveAt(idx);
            }
            rearrangement();
            leftMenuAddCombo.Items.Add(coinName);
            leftMenuRemoveCombo.Items.Remove(coinName);
        }
        private void focusDisable(object sender, EventArgs e)
        {
            groupBox1.Focus();
        }


        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftMenu.Show(Cursor.Position);
                menuHider.Start();
            }
            else
                leftMenu.Hide();
        }
        private void menuHider_Tick(object sender, EventArgs e)
        {
            leftMenu.Hide();
            menuHider.Stop();
        }
        private void leftMenuAddCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            addCoin((string)leftMenuAddCombo.SelectedItem);
            leftMenu.Hide();
        }
        private void leftMenuRemoveCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeCoin((string)leftMenuRemoveCombo.SelectedItem);
            leftMenu.Hide();
        }
        private void leftMenuChartCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph graph = new graph((string)leftMenuChartCombo.SelectedItem);
            graph.Show();
            leftMenu.Hide();
        }
        private void leftMenuOpacityCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Opacity = double.Parse((string)leftMenuOpacityCombo.SelectedItem) / 100.0;
            leftMenu.Hide();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLoc = Cursor.Position;
                isClick = true;
            }
        }
        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClick)
            {
                Point mouseMoveLoc = Cursor.Position;
                Point nextLoc = Location;
                nextLoc.X -= mouseLoc.X - mouseMoveLoc.X;
                nextLoc.Y -= mouseLoc.Y - mouseMoveLoc.Y;
                if (nextLoc.X + Size.Width > Screen.PrimaryScreen.WorkingArea.Size.Width)
                    nextLoc.X = Screen.PrimaryScreen.WorkingArea.Size.Width - Size.Width;
                else if (nextLoc.X < 0)
                    nextLoc.X = 0;
                if (nextLoc.Y + Size.Height > Screen.PrimaryScreen.WorkingArea.Size.Height)
                    nextLoc.Y = Screen.PrimaryScreen.WorkingArea.Size.Height - Size.Height;
                else if (nextLoc.Y < 0)
                    nextLoc.Y = 0;
                Location = nextLoc;
                mouseLoc = mouseMoveLoc;
            }
        }
        private void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;
        }
    }
}