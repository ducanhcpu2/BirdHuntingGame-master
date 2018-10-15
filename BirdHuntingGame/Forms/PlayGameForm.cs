using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BirdHuntingGame.Code;
using System.Media;
using System.IO;

namespace BirdHuntingGame.Forms
{
	public partial class imgBackgroundOnGame : Form
	{
		private GameStatus GameStatus;  // Trạng thái game
		private Guns SelectedGun;       // Súng bắn gà
		private Birds SelectedBird;     // Loại chim bay trong map

		private List<BirdTimer> FlyingBirds = new List<BirdTimer>();

		public imgBackgroundOnGame(Guns gun, Birds bird)
		{
            // Bắt đầu load form mở đầu
			InitializeComponent();

			this.GameStatus = GameStatus.Continue;
			this.SelectedGun = gun;
			this.SelectedBird = bird;

			SetupCrossHair();

			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		private void SetupCrossHair()
		{
            // Tuỳ chỉnh tâm súng
            #region Code chọn tâm súng và thay thế chuột bằng tâm
            switch (SelectedGun)
            {
                case Guns.Gun00:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope00.GetHicon());
                    break;
                case Guns.Gun01:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope00.GetHicon());
                    break;
                case Guns.Gun02:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope01.GetHicon());
                    break;
                case Guns.Gun03:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope01.GetHicon());
                    break;
                case Guns.Gun04:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope02.GetHicon());
                    break;
                case Guns.Gun05:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope02.GetHicon());
                    break;
                case Guns.Gun06:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope03.GetHicon());
                    break;
                case Guns.Gun07:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope03.GetHicon());
                    break;
                case Guns.Gun08:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope04.GetHicon());
                    break;
                case Guns.Gun09:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope04.GetHicon());
                    break;
                case Guns.Gun10:
                    this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Scope05.GetHicon());
                    break;
                default:
                    break;
            }
            #endregion
        }

        // Hàm ghi đè tham số mặc định
        #region Code ghi đề tham số mặc định
        protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}
        #endregion

        public void PlayGunSound()
		{
            // Random âm thanh bắn súng
            string nameSoundGun = "Sounds/gun" + Convert.ToString( new Random().Next(0,2) ) + ".wav";
            FileStream gunSoundFile = new FileStream(nameSoundGun, FileMode.Open, FileAccess.Read);
            new SoundPlayer(gunSoundFile).Play();
        }

		public void PlayBirdHitSound()
		{
            // Random âm thanh chim bị bắn trúng
            string nameSoundBird = "Sounds/chicken" + Convert.ToString(new Random().Next(0, 9)) + ".wav";
            FileStream gunSoundFile = new FileStream(nameSoundBird, FileMode.Open, FileAccess.Read);
			new SoundPlayer(gunSoundFile).Play();
		}

		public void PlayForestBirdsSound()
		{
            // Nhạc nền mở đầu lúc bắt đầu màn hình bắn gà
            FileStream forestBirdsSoundFile = new FileStream("Sounds/Start02.wav", FileMode.Open, FileAccess.Read);
            new SoundPlayer(forestBirdsSoundFile).Play();
        }

		private void PlayGameForm_Load(object sender, EventArgs e)
		{
            // Bắt đầu load màn hình bắn gà

            // Số lượng chim được sinh ra trong màn hình
            for (int i = 0; i < 3; i++)
            {
                AddNewBird("", "");
            }

            // Chạy nhạc nền bắn gà
			PlayForestBirdsSound();
		}
		
		public void AddNewBird(string Direction, string Bird)
		{
			BirdTimer BirdTimer = new BirdTimer();
			BirdTimer.BirdBox = NewBirdBox(Direction, Bird);
			
			BirdTimer.Interval = Extensions.GetRandomInterval();
			BirdTimer.Tick += new EventHandler(BirdTimer_Tick);

			this.Controls.Add(BirdTimer.BirdBox);

			FlyingBirds.Add(BirdTimer);

			BirdTimer.Start();
		}
		
		private void BirdTimer_Tick(object sender, EventArgs e)
		{
            /*
             * + xử lý toạ con chim bay
             * + trạng thái của chim
             * + thêm mới chim nếu con cũ chết
             * + điều kiện để chim chết
            */
			BirdTimer BirdTimer = (BirdTimer)sender;

			if (BirdTimer != null)
			{
				int XLocation = 0;
				int YLocation = 0;

				if (BirdTimer.BirdBox.Status == "Alive")
                    #region Code xử lý nếu chim vẫn sống
                {
                    if (BirdTimer.BirdBox.Location.X + BirdTimer.BirdBox.Size.Width < 0)
					{
                        // Nếu con chim bay ra phía ngoài màn hình -> xoá
						XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetRandomNumber();
						BirdTimer.BirdBox.Status = "Downed";
                        return;
					}
					else
					{
                        // Nếu không thì cho con chim bay về bên trái
						XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetRandomNumber();
					}

					if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height > this.Height - 50)
					{
                        // Nếu con chim bay lên cao quá so với màn hình -> xoá
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height - 50 < 0)
					{
                        // Nếu chim bay dưới màn hình -> xoá
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else
					{
                        // Nếu không thì con chim bay ngẫu nhiên lên trên, xuống dưới
						YLocation = BirdTimer.BirdBox.Location.Y + Extensions.GetLimitedRandomNumber(-10, 10);
					}
					
                    // Truyền toạ độ mới
					BirdTimer.BirdBox.Location = new Point(XLocation, YLocation);
				}
                    #endregion

                else if (BirdTimer.BirdBox.Status == "Dead")
                    #region Code xử lý nếu con chim bị bắn trúng (hoặc chết)
                {
                    if (BirdTimer.BirdBox.Location.X + BirdTimer.BirdBox.Size.Width < 0)
					{
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else
					{
						XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetLimitedRandomNumber(17, 23);
					}

					if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height > this.Height)
					{
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else
					{
						YLocation = BirdTimer.BirdBox.Location.Y + Extensions.GetLimitedRandomNumber(20, 25);
					}
					
					BirdTimer.BirdBox.Location = new Point(XLocation, YLocation);
				}
                    #endregion

                else if (BirdTimer.BirdBox.Status == "Downed")
				{
                    AddNewBird("", "");
                    RemoveBird(BirdTimer);
				}				
			}
		}

		public BirdBox NewBirdBox(string Direction, string Bird)
		{
            // Chỉnh kích thước cho con chim
			BirdBox birdBox = new BirdBox();
			var birdBoxSize = Extensions.GetLimitedRandomNumber(50, 120);
			birdBox.Size = new Size(birdBoxSize, birdBoxSize);
			birdBox.SizeMode = PictureBoxSizeMode.StretchImage;
			birdBox.Direction = Direction;

            // Chọn ảnh cho Box Bird
            switch (SelectedBird)
            {
                case Birds.Bird00:
                    birdBox.Image = Properties.Resources.Bird00;
                    break;
                case Birds.Bird01:
                    birdBox.Image = Properties.Resources.Bird01;
                    break;
                case Birds.Bird02:
                    birdBox.Image = Properties.Resources.Bird02;
                    break;
                case Birds.Bird03:
                    birdBox.Image = Properties.Resources.Bird03;
                    break;
                case Birds.Bird04:
                    birdBox.Image = Properties.Resources.Bird04;
                    break;
                case Birds.Dragon00:
                    birdBox.Image = Properties.Resources.Dragon00;
                    break;
                default:
                    break;
            }

            birdBox.BackColor = Color.Transparent;

			birdBox.Location = new Point(this.Width, Extensions.GetLimitedRandomNumber(200, this.Height - 200));

			birdBox.Click += new EventHandler(birdBox_Click);
			birdBox.DoubleClick += new EventHandler(birdBox_Click);

			return birdBox;
		}

		private void birdBox_Click(object sender, EventArgs e)
		{
            //Xử lý sự kiện khi click trúng vào chim
            #region Code chạy animation destroy khi chim bị bắn trúng
            if (GameStatus == GameStatus.Continue)
			{
				BirdBox birdbox = (BirdBox)sender;

				if (birdbox != null && birdbox.Status != "Dead")
				{
					PlayBirdHitSound();
					birdbox.Status = "Dead";
					birdbox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    switch (SelectedGun)
                    {
                        case Guns.Gun00:
                            birdbox.Image = Properties.Resources.Destroy00;
                            break;
                        case Guns.Gun01:
                            birdbox.Image = Properties.Resources.Destroy00;
                            break;
                        case Guns.Gun02:
                            birdbox.Image = Properties.Resources.Destroy01;
                            break;
                        case Guns.Gun03:
                            birdbox.Image = Properties.Resources.Destroy01;
                            break;
                        case Guns.Gun04:
                            birdbox.Image = Properties.Resources.Destroy02;
                            break;
                        case Guns.Gun05:
                            birdbox.Image = Properties.Resources.Destroy02;
                            break;
                        case Guns.Gun06:
                            birdbox.Image = Properties.Resources.Destroy03;
                            break;
                        case Guns.Gun07:
                            birdbox.Image = Properties.Resources.Destroy03;
                            break;
                        case Guns.Gun08:
                            birdbox.Image = Properties.Resources.Destroy04;
                            break;
                        case Guns.Gun09:
                            birdbox.Image = Properties.Resources.Destroy04;
                            break;
                        default:
                            break;
                    }
				}
				else
				{
					PlayGunSound();
				}
			}
            #endregion
        }

        private void PlayGameForm_Click(object sender, EventArgs e)
		{
            // Khi game vẫn đang tiếp tục, nếu click vào màn hình thì chạy tiếng súng
			if (GameStatus == GameStatus.Continue)
			{
				PlayGunSound();
			}
		}		

		private void RemoveBird(BirdTimer BirdTimer)
		{
			if (BirdTimer != null)
			{
				FlyingBirds.Remove(BirdTimer);

				BirdTimer.Stop();
				BirdTimer.BirdBox.Dispose();
				BirdTimer.Dispose();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
            // Khi bấm vào nút pause
			if(GameStatus == GameStatus.Continue)
			{
				GameStatus = GameStatus.Pause;

				foreach (var bird in FlyingBirds)
				{
					if(bird != null)
					{
						bird.Stop();
					}
				}
                btnPause.BackgroundImage = Properties.Resources.Control_Play;
                FileStream soundTrailer = new FileStream("Sounds/Trailer03.wav", FileMode.Open, FileAccess.Read);
                new SoundPlayer(soundTrailer).PlayLooping();
			}
			else
			{
				GameStatus = GameStatus.Continue;

				foreach (var bird in FlyingBirds)
				{
					if (bird != null)
					{
						bird.Start();
					}
				}

				btnPause.BackgroundImage = Properties.Resources.Control_Pause;
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			//GameOptionsForm.Instance.Close();
			this.Hide();

			ImgControlBackground.Instance.Show();

            FileStream soundTrailer = new FileStream("Sounds/Trailer04.wav", FileMode.Open, FileAccess.Read);
            new SoundPlayer(soundTrailer).PlayLooping();
        }
	}
}
