using System.Net.NetworkInformation;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        QuanLyBanCo banCo;
        SocketManager socket;
        #endregion
        public Form1()
        {

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            banCo = new QuanLyBanCo(BanCo, tbTenNguoiChoi, pctrMark);
            banCo.EndedGame += BanCo_EndedGame;
            banCo.PlayerMarked += BanCo_PlayerMarked;
            DemNguoc.Step = Cons.STEP_DEMNGUOC;
            DemNguoc.Maximum = Cons.TIME_DEMNGUOC;
            DemNguoc.Value = 0;

            tmDemNguoc.Interval = Cons.INTERVAL_DEMNGUOC;
            banCo.VeBanco();
            socket = new SocketManager();
            NewGame();
        }
        #region Methods
        void EndGame()
        {
            tmDemNguoc.Stop();
            BanCo.Enabled = false;
            MessageBox.Show("Kết thúc");
        }
        void NewGame()
        {
            DemNguoc.Value = 0;
            tmDemNguoc.Stop();
            banCo.VeBanco();

        }
        void Thoat()
        {
            Application.Exit();
        }
        void TroLai()
        {

        }
        private void BanCo_PlayerMarked(object? sender, ButtonClickEvent e)
        {
            tmDemNguoc.Start();
            DemNguoc.Value = 0;
            BanCo.Enabled=false;
            socket.Send(new SocketData((int)SocketCommand.SEND_POINT,"",e.ClickedPoint));
            Listen();
        }

        private void BanCo_EndedGame(object? sender, EventArgs e)
        {
            EndGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));

        }

        private void tmDemNguoc_Tick_1(object sender, EventArgs e)
        {
            DemNguoc.PerformStep();
            if (DemNguoc.Value >= DemNguoc.Maximum)
            {
                EndGame();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));

            }

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();

            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            BanCo.Enabled = true;


        }



        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thoat();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                try
                {

                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }
            }
        }

        private void BTNLan_Click(object sender, EventArgs e)
        {
            socket.IP = tbIP.Text;
            if (!socket.ConnectServer())
            {
                socket.IsServer = true;
                BanCo.Enabled = true;
                socket.CreateServer();

            }
            else
            {
                socket.IsServer=false;
                BanCo.Enabled=false;
                Listen();

            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(tbIP.Text))
            {
                tbIP.Text=socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
        void Listen()
        {
            
                Thread listenThread = new Thread(() =>
                {
                    try
                    {
                        SocketData data = (SocketData)socket.Receive();

                        ProcessData(data);
                    }
                    catch { }
               });
                listenThread.IsBackground = true;
            listenThread.Start();
        }
        private void ProcessData(SocketData data)
        {

            switch(data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    break;
                case(int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        BanCo.Enabled = false;
                    }));
                    break ;
                case (int)SocketCommand.QUIT:
                    tmDemNguoc.Stop();
                    MessageBox.Show("đối thủ đã sợ và thoát");
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                        {
                        DemNguoc.Value = 0;
                        BanCo.Enabled = true;
                        tmDemNguoc.Start();
                        banCo.OtherPlayerMark(data.Point);
                    }));
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Hết giờ");
                    break;
                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Đã phân định thắng thua");
                    break;
                default:
                    break;
            }
           // Listen();
        }
            #endregion
        }

    }
