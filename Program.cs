using System;
using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

form.BackColor = Color.Red;
form.TransparencyKey = Color.Red;

Random rand = Random.Shared;

var pn = new Panel();
pn.Width = 300;
pn.Height = 200;
pn.BackColor = Color.Orange;

PictureBox pb = new PictureBox()
{
    ImageLocation = "sleepcat.png",
    Location = new Point(0, 0),
    Dock = DockStyle.Fill,
    SizeMode = PictureBoxSizeMode.StretchImage
};

pn.Controls.Add(pb);
form.Controls.Add(pn);

var speedx = 5;
var speedy = 5;
int x = 0, y = 0;

var timer = new Timer();
timer.Interval = 5;
timer.Tick += delegate
{
    pn.Location = new Point(x, y);
    x += speedx;
    y += speedy;

    if(x > form.Width - 300 || x < 0)
    {
        speedx *= -1;
        pn.BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
    }
    
    if(y > form.Height - 200 || y < 0)
    {
        speedy *= -1;
        pn.BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
    }
};

form.Load += delegate
{
    timer.Start();
};

form.KeyPreview = true;
form.KeyDown += (o, e) => 
{
    if(e.KeyCode == Keys.Escape)
        Application.Exit();
};

Application.Run(form);