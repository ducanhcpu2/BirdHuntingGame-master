using BirdHuntingGame.Code;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace BirdHuntingGame.Forms
{
	public partial class ImgControlBackground : Form
	{
        #region Tạo ra màn hình chơi game trên form mới
        private static ImgControlBackground _Instance;

		public static ImgControlBackground Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new ImgControlBackground();
				}

				return (_Instance);
			}
		}

		private ImgControlBackground()
		{
            // Chỉnh thông số cho form
			InitializeComponent();
		}
		#endregion

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		private void GameOptionsForm_Load(object sender, EventArgs e)
		{
            // Chọn loại súng, chim mặc định
			ListGun.SelectedIndex = 0;
			ListBird.SelectedIndex = 1;
            new Thread(() => 
            {
                FileStream soundTrailer = new FileStream("Sounds/Trailer01.wav", FileMode.Open, FileAccess.Read);
                new SoundPlayer(soundTrailer).PlayLooping();
                Thread.Sleep(6700);
                this.BackgroundImage = global::BirdHuntingGame.Properties.Resources.BackGround08;
                Thread.Sleep(300);
                this.BackgroundImage = global::BirdHuntingGame.Properties.Resources.BackGround07;
                Thread.Sleep(500);
                this.BackgroundImage = global::BirdHuntingGame.Properties.Resources.BackGround06;
            }
            ).Start();
        }

		private void cmbGun_SelectedIndexChanged(object sender, EventArgs e)
		{
            // xử lý sự kiện chọn loại súng trên màn hình form
            #region Code xử lý loại súng
            switch (ListGun.SelectedItem.ToString())
            {
                case "Bronze V":
                    imageChooseGun.Image = Properties.Resources.Gun00;
                    break;
                case "Bronze IV":
                    imageChooseGun.Image = Properties.Resources.Gun01;
                    break;
                case "Bronze III":
                    imageChooseGun.Image = Properties.Resources.Gun02;
                    break;
                case "Bronze II":
                    imageChooseGun.Image = Properties.Resources.Gun03;
                    break;
                case "Bronze I":
                    imageChooseGun.Image = Properties.Resources.Gun04;
                    break;
                case "Silver V":
                    imageChooseGun.Image = Properties.Resources.Gun05;
                    break;
                case "Silver IV":
                    imageChooseGun.Image = Properties.Resources.Gun06;
                    break;
                case "Silver III":
                    imageChooseGun.Image = Properties.Resources.Gun07;
                    break;
                case "Silver II":
                    imageChooseGun.Image = Properties.Resources.Gun08;
                    break;
                default:
                    break;
            }
            #endregion
        }
        private void cmbBird_SelectedIndexChanged(object sender, EventArgs e)
		{
            // Xử lý sự kiện chọn loại chim trên màn hình form
            #region Code xử lý loại chim
            switch (ListBird.SelectedItem.ToString())
            {
                case "Bronze V":
                    imageChooseBird.Image = Properties.Resources.Bird00;
                    break;
                case "Bronze IV":
                    imageChooseBird.Image = Properties.Resources.Bird01;
                    break;
                case "Bronze III":
                    imageChooseBird.Image = Properties.Resources.Bird02;
                    break;
                case "Bronze II":
                    imageChooseBird.Image = Properties.Resources.Bird03;
                    break;
                case "Bronze I":
                    imageChooseBird.Image = Properties.Resources.Bird04;
                    break;
                case "Silver V":
                    imageChooseBird.Image = Properties.Resources.Dragon00;
                    break;
                default:
                    break;
            }
            #endregion
        }
        private void btnStartGame_Click(object sender, EventArgs e)
		{
            // Khi click vào nút start game
			Guns SelectedGun = Guns.Gun00;
			Birds SelectedBird = Birds.Bird01;
            #region Cài đặt súng vào game
            switch (ListGun.SelectedItem.ToString())
            {
                case "Bronze V":
                    SelectedGun = Guns.Gun00;
                    break;
                case "Bronze IV":
                    SelectedGun = Guns.Gun01;
                    break;
                case "Bronze III":
                    SelectedGun = Guns.Gun02;
                    break;
                case "Bronze II":
                    SelectedGun = Guns.Gun03;
                    break;
                case "Bronze I":
                    SelectedGun = Guns.Gun04;
                    break;
                case "Silver V":
                    SelectedGun = Guns.Gun05;
                    break;
                case "Silver IV":
                    SelectedGun = Guns.Gun06;
                    break;
                case "Silver III":
                    SelectedGun = Guns.Gun07;
                    break;
                case "Silver II":
                    SelectedGun = Guns.Gun08;
                    break;
                default:
                    break;
            }
            #endregion

            #region Cài đặt chim vào game
            switch (ListBird.SelectedItem.ToString())
            {
                case "Bronze V":
                    SelectedBird = Birds.Bird00;
                    break;
                case "Bronze IV":
                    SelectedBird = Birds.Bird01;
                    break;
                case "Bronze III":
                    SelectedBird = Birds.Bird02;
                    break;
                case "Bronze II":
                    SelectedBird = Birds.Bird03;
                    break;
                case "Bronze I":
                    SelectedBird = Birds.Bird04;
                    break;
                case "Silver V":
                    SelectedBird = Birds.Dragon00;
                    break;
                default:
                    break;
            }
            #endregion

            imgBackgroundOnGame playGameForm = new imgBackgroundOnGame(SelectedGun, SelectedBird);
			this.Hide();
			playGameForm.ShowDialog(); 
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
    }
}
