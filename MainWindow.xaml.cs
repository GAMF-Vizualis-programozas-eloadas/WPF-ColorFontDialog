using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace CF_Dialog_Example
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void miExit_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}

		private void miBColor_Click(object sender, RoutedEventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (tkTest.Background is SolidColorBrush br)
			{
				cd.Color = System.Drawing.Color.FromArgb(br.Color.A, br.Color.R, br.Color.G, br.Color.B);
			}
			if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				var cl = cd.Color;
				tkTest.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(cl.A, cl.R, cl.G, cl.B));
			}
		}
		private void miFont_Click(object sender, RoutedEventArgs e)
		{
			FontDialog fd = new FontDialog();
			System.Drawing.FontStyle CurrentFontStyle=0;
			if (tkTest.TextDecorations!=null)
				foreach(var td in tkTest.TextDecorations)
					switch (td.Location)
					{
						case TextDecorationLocation.Underline:
							CurrentFontStyle |= System.Drawing.FontStyle.Underline;
							break;
						case TextDecorationLocation.Strikethrough:
							CurrentFontStyle |= System.Drawing.FontStyle.Strikeout;
							break;
					}
			if(tkTest.FontWeight == FontWeights.Bold) CurrentFontStyle |= System.Drawing.FontStyle.Bold;
			if (tkTest.FontStyle == FontStyles.Italic) CurrentFontStyle |= System.Drawing.FontStyle.Italic;
			fd.Font = new System.Drawing.Font(tkTest.FontFamily.ToString(), 
				(float)tkTest.FontSize, CurrentFontStyle);
			if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tkTest.FontFamily = new FontFamily(fd.Font.FontFamily.Name);
				tkTest.FontSize = fd.Font.Size;
				tkTest.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Normal;
				tkTest.FontStyle= fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
				tkTest.TextDecorations = new TextDecorationCollection();
				if (fd.Font.Underline) tkTest.TextDecorations.Add(TextDecorations.Underline);
				if(fd.Font.Strikeout) tkTest.TextDecorations.Add(TextDecorations.Strikethrough);
			
			}
		}
	}
}
