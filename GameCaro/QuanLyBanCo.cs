using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
   
    internal class QuanLyBanCo
    {
        #region Properties
        private Panel BanCo;

        private List<TenNguoiChoi> TenNguoiChoi;
        internal List<TenNguoiChoi> TenNguoiChoi1 { get => TenNguoiChoi; set => TenNguoiChoi = value; }

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        private TextBox PlayerName;
        public TextBox PlayerName1 { get => PlayerName; set => PlayerName = value; }

        private PictureBox playerMark;
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }

        private List<List<Button>> matrix;
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private event EventHandler <ButtonClickEvent>playerMarked;
        public event EventHandler<ButtonClickEvent>  PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }

        }
        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        
        #endregion

        #region Initialize
        public QuanLyBanCo(Panel BanCo, TextBox playerName1, PictureBox playerMark)
        {
            this.matrix = new List<List<Button>>();
            this.BanCo = BanCo;
            this.PlayerName = playerName1;
            this.playerMark = playerMark;
            this.TenNguoiChoi = new List<TenNguoiChoi>()
            {
                new TenNguoiChoi("DauGauA",Image.FromFile(Application.StartupPath+"\\Resources\\redX.png")),
                new TenNguoiChoi("DauGauB",Image.FromFile(Application.StartupPath+"\\Resources\\blueO.png"))
            };
            
            PlayerName1 = playerName1;
            this.playerMark = playerMark;
            PlayerMark = playerMark;
        }
        //

        //

        #endregion

        #region Methods
        public void VeBanco()
{
    BanCo.Enabled = true;
    BanCo.Controls.Clear();

    CurrentPlayer = 0;
    DoiNguoiChoi();
    
    matrix = new List<List<Button>>();

    Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
    for (int i = 0; i < Cons.BANCO_HEIGHT; i++)
    {
        matrix.Add(new List<Button>());

        for (int j = 0; j < Cons.BANCO_WIDTH; j++)
        {
            Button btn = new Button()
            {
                Width = Cons.CHESS_WIDTH,
                Height = Cons.CHESS_HEIGHT,
                Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = null, // Clear any previous images
                Tag = i.ToString()
            };
            btn.Click += Btn_Click;
            BanCo.Controls.Add(btn);
            matrix[i].Add(btn);
            oldButton = btn;
        }
        oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
        oldButton.Width = 0;
        oldButton.Height = 0;
    }
}


        private void Btn_Click(object? sender, EventArgs e)
        {
                Button? btn = sender as Button;
            if (btn != null)
            {
                if (btn.BackgroundImage != null)
                    return;
                Mark(btn);
                
                DoiNguoiChoi();
                if (playerMarked != null)
                    playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));
                if (isEndGame(btn))
                {
                    EndGame();
                }
                
                
            }
           
        }
        public void OtherPlayerMark(Point point)
        {
            Button? btn = matrix[point.Y][point.X];
            if (btn != null)
            {
                if (btn.BackgroundImage != null)
                    return;
                BanCo.Enabled = true;
                Mark(btn);
                DoiNguoiChoi();
                if (isEndGame(btn))
                {
                    EndGame();
                }


            }
        }
        private void EndGame()
        {
            if(endedGame!=null)
                endedGame(this,new EventArgs());
        }

        private bool isEndGame(Button btn)
        {
            return isEndGameNgang(btn) || isEndGameDoc(btn)||isEndGameCheoChinh(btn)||isEndGameCheoPhu(btn);
        }
        private Point GetChessPoint(Button btn)
        {
            int doc= Convert.ToInt32(btn.Tag);
            int ngang = matrix[doc].IndexOf(btn);
            Point point = new Point(ngang, doc);

            return point;
        }

        private bool isEndGameNgang(Button btn)
        {
            Point point = GetChessPoint(btn);
            int DemTrai = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    DemTrai++;
                }
                else
                    break;
            }

            int DemPhai = 0;
            for (int i = point.X + 1; i < Cons.BANCO_WIDTH; i++)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    DemPhai++;
                }
                else
                    break;
            }

            return DemTrai + DemPhai >= 5; // Kiểm tra đủ 5 quân để chiến thắng
        }

        private bool isEndGameDoc(Button btn)
        {
            Point point = GetChessPoint(btn);
            int DemTren = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    DemTren++;
                }
                else
                    break;
            }

            int DemDuoi = 0;
            for (int i = point.Y + 1; i < Cons.BANCO_HEIGHT; i++)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    DemDuoi++;
                }
                else
                    break;
            }

            return DemTren + DemDuoi >= 5; // Kiểm tra đủ 5 quân để chiến thắng
        }
        private bool isEndGameCheoChinh(Button btn)
        {
            Point point = GetChessPoint(btn);
            int DemTren = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if(point.X-i<0||point.Y-i<0)
                    break;
                if (matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                {
                    DemTren++;
                }
                else
                    break;
            }

            int DemDuoi = 0;
            for (int i = 1; i < Cons.BANCO_WIDTH-point.X; i++)
            {
                if (point.X + i > Cons.BANCO_WIDTH || point.X + i >= Cons.BANCO_HEIGHT)
                    break;
                if (matrix[point.Y+i][point.X+i].BackgroundImage == btn.BackgroundImage)
                {
                    DemDuoi++;
                }
                else
                    break;
            }

            return DemTren + DemDuoi >= 5; // Kiểm tra đủ 5 quân để chiến thắng
        }
        private bool isEndGameCheoPhu(Button btn)
        {
            Point point = GetChessPoint(btn);
            int DemTren = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= Cons.BANCO_HEIGHT) break;
                if (matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    DemTren++;
                }
                else
                    break;
            }

            int DemDuoi = 0;
            for (int i = 1; i < Cons.BANCO_WIDTH - point.X; i++)
            {
                if (point.X + i >= Cons.BANCO_WIDTH || point.Y - i < 0) break;
                if (matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    DemDuoi++;
                }
                else
                    break;
            }

            return DemTren + DemDuoi >= 5;
        }
        private void Mark(Button btn)
        {
            btn.BackgroundImage = TenNguoiChoi[currentPlayer].Mark;
            currentPlayer = currentPlayer == 1 ? 0 : 1;
        }
        private void DoiNguoiChoi()
        {
            PlayerName.Text = TenNguoiChoi[currentPlayer].Name;
            playerMark.Image = TenNguoiChoi[currentPlayer].Mark;
        }
        #endregion

    }
    public class ButtonClickEvent:EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint { get => clickedPoint; set => clickedPoint = value; }
        public ButtonClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }
}
