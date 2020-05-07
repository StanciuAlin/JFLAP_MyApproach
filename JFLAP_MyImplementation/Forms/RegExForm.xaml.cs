using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace JFLAP_MyApproach.Forms
{
    /// <summary>
    /// Interaction logic for RegExForm.xaml
    /// </summary>
    public partial class RegExForm : Window
    {
        private Regex rx;
        private bool isActiveCbxCaseSensitive = false;
        public RegExForm()
        {
            InitializeComponent();

            tbxRegEx.ToolTip = "Please insert the regular expression";
            tbxText.ToolTip = "Please insert the text to check the match with regex";
            tbxMatches.ToolTip = "Match informations";

            cbxCaseSensitive.Content = "Case sensitive OFF";
            cbxCaseSensitive.ToolTip = "Match the text case sensitive";
        }

        #region Events
        private void Window_Closed_RegEx(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }


        private void cbxCaseSensitive_Checked(object sender, RoutedEventArgs e)
        {
            isActiveCbxCaseSensitive = true;
            cbxCaseSensitive.Content = "Case sensitive ON";
        }


        private void cbxCaseSensitive_Unchecked(object sender, RoutedEventArgs e)
        {
            isActiveCbxCaseSensitive = false;
            cbxCaseSensitive.Content = "Case sensitive OFF";
        }
        #endregion

        private void tbxText_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Define a regular expression for repeated words.
            if (!isActiveCbxCaseSensitive)
            {
                rx = new Regex(tbxRegEx.Text,
              RegexOptions.Compiled | RegexOptions.IgnoreCase);
            }
            else
            {
                rx = new Regex(tbxRegEx.Text,
              RegexOptions.Compiled);
            }

            // Define a test string.
            string text = tbxText.Text;
            // Find matches.
            MatchCollection matches = rx.Matches(text);

            if(matches.Count > 0)
            {
                tbxMatches.Foreground = new SolidColorBrush(Colors.Green);
                // Report the number of matches found.
                string infoText = "";
                if (matches.Count > 1)
                {
                    infoText = Convert.ToString(matches.Count + " matches \n");
                }
                else
                {
                    infoText = Convert.ToString(matches.Count + " match \n");
                }
                // Report on each match.
                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;

                    //Console.WriteLine("'{0}' repeated at positions {1} and {2}",
                    //                  groups["word"].Value,
                    //                  groups[0].Index,
                    //                  groups[1].Index);
                    infoText = infoText + groups["word"].Value + " Reported starting at position " + 
                        groups[0].Index + "\n";
                }
                tbxMatches.Text = infoText;
            }
            else
            {
                tbxMatches.Foreground = new SolidColorBrush(Colors.Red);
                // Report the number of matches found.
                tbxMatches.Text = Convert.ToString("No match");
            }
        }

    }
}
