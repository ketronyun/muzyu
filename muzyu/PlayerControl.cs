using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzyu
{
    public partial class PlayerControl : UserControl
    {
        private bool isPlaying = false;
        private bool userIsDragging = false;
        public PlayerControl()
        {
            InitializeComponent();

            btnPlayPause.Click += BtnPlayPause_Click;
            btnNext.Click += BtnNext_Click;
            btnPrevious.Click += BtnPrevious_Click;
            trackBarVolume.Scroll += TrackBarVolume_Scroll;

            // Yeni eklendi: ilerleme çubuğu eventleri
            trackBarProgress.MouseDown += TrackBarProgress_MouseDown;
            trackBarProgress.MouseUp += TrackBarProgress_MouseUp;

            // Başlangıç değerleri
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 50;

            trackBarProgress.Minimum = 0;
            trackBarProgress.Maximum = 100;
            trackBarProgress.Value = 0;
            trackBarProgress.TickStyle = TickStyle.None;
        }
        public void SetSong(string title, string artist, Image albumCover)
        {
            lblTitle.Text = title;
            lblArtist.Text = artist;
            picAlbumCover.Image = albumCover;

            trackBarProgress.Value = 0;  // Yeni şarkıda ilerlemeyi sıfırla
        }

        // İlerleme çubuğu güncelleme için dışardan çağrılacak metod
        public void UpdateProgress(double positionSeconds, double totalSeconds)
        {
            if (userIsDragging) return; // Kullanıcı sürüklüyorsa güncelleme yapma

            if (totalSeconds <= 0) return;

            int progressValue = (int)((positionSeconds / totalSeconds) * trackBarProgress.Maximum);
            if (progressValue < trackBarProgress.Minimum)
                progressValue = trackBarProgress.Minimum;
            else if (progressValue > trackBarProgress.Maximum)
                progressValue = trackBarProgress.Maximum;

            trackBarProgress.Value = progressValue;
        }

        // Kullanıcı ilerleme çubuğunu tutmaya başladı
        private void TrackBarProgress_MouseDown(object sender, MouseEventArgs e)
        {
            userIsDragging = true;
        }

        // Kullanıcı ilerleme çubuğu hareketini bıraktı
        private void TrackBarProgress_MouseUp(object sender, MouseEventArgs e)
        {
            userIsDragging = false;

            // Burada ilerleme çubuğunun değerine göre şarkıyı ileri sar demek için event yayınla
            double percentage = (double)trackBarProgress.Value / trackBarProgress.Maximum;
            ProgressBarSeekRequested?.Invoke(this, percentage);
        }

        // Eventler
        public event EventHandler PlayClicked;
        public event EventHandler PauseClicked;
        public event EventHandler NextClicked;
        public event EventHandler PreviousClicked;
        public event EventHandler<int> VolumeChanged;

        // Yeni: şarkı ilerleme isteği için event, yüzde şeklinde
        public event EventHandler<double> ProgressBarSeekRequested;

        private void BtnPlayPause_Click(object sender, EventArgs e)
        {
            isPlaying = !isPlaying;
            btnPlayPause.Text = isPlaying ? "⏸️" : "▶️";

            if (isPlaying)
                PlayClicked?.Invoke(this, EventArgs.Empty);
            else
                PauseClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            PreviousClicked?.Invoke(this, EventArgs.Empty);
        }

        private void TrackBarVolume_Scroll(object sender, EventArgs e)
        {
            VolumeChanged?.Invoke(this, trackBarVolume.Value);
        }
        public int CurrentVolume
        {
            get => trackBarVolume.Value;
            set
            {
                if (value >= trackBarVolume.Minimum && value <= trackBarVolume.Maximum)
                {
                    trackBarVolume.Value = value;
                    VolumeChanged?.Invoke(this, value);
                }
            }
        }
        public void SetPlayState(bool isPlayingNow)
        {
            isPlaying = isPlayingNow;
            btnPlayPause.Text = isPlaying ? "⏸️" : "▶️";
        }


    }
}
