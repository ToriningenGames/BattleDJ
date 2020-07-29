using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScorpCamp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int PLAYERHEIGHT = 400;
        //<Image x:Name="goni" HorizontalAlignment="Left" Height="463" VerticalAlignment="Top" Width="228" Source="standard.png" Margin="991,85,0,0" RenderTransformOrigin="3.292,0.792" Grid.Column="1"/>
        public class Combatant
        {
            public Image pic;
            public string Name;
        }

        Combatant player = new Combatant();
        Combatant enemy = new Combatant();

        public MainWindow()
        {
            InitializeComponent();
            player = setCriss();
            player.pic = flipImage(player.pic);
            enemy = setRatMaster();

            var img = player.pic;
            Grid.SetColumn(img, 0);
            Grid.SetRow(img, 0);
            GameArea.Children.Add(img);

            img = enemy.pic;
            Grid.SetColumn(img, 1);
            Grid.SetRow(img, 0);
            GameArea.Children.Add(img);
        }

        public Image flipImage(Image arg)
        {
            arg.FlowDirection = FlowDirection.RightToLeft;
            return arg;
        }

        public Combatant setCriss()
        {
            Combatant rtrn = new Combatant();

            Image img = new Image();
            img.Name = "criss";
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.Height = PLAYERHEIGHT;
            //goni.Width = 350;
            Uri src = new Uri("crisswithagun.png", UriKind.Relative);
            img.Source = new BitmapImage(src);
            img.Margin = new Thickness(0, 40, 50, 0);

            rtrn.Name = "Criss";
            rtrn.pic = img;

            return rtrn;
        }

        public Combatant setRatMaster()
        {
            Combatant rtrn = new Combatant();

            Image img = new Image();
            img.Name = "goni";
            img.HorizontalAlignment = HorizontalAlignment.Right;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.Height = PLAYERHEIGHT;
            //goni.Width = 350;
            Uri src = new Uri("standard.png", UriKind.Relative);
            img.Source = new BitmapImage(src);
            img.Margin = new Thickness(0, 40, 50, 0);

            //goni.RenderTransformOrigin = new Point(3.292, 0.792);

            rtrn.pic = img;
            rtrn.Name = "The Rat Master";

            return rtrn;
        }
    }
}
