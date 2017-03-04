

using System.IO;
using System.Text;
using IssueTakerApp.Utilities.Constants;
using SimpleMVC.Interfaces;

namespace IssueTakerApp.Views.Issue
{
    public class New :IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();

            sb.Append(File.ReadAllText(Paths.Menulogged));
            sb.Append(File.ReadAllText(Paths.NewIssue));
            sb.Append(File.ReadAllText(Paths.Footer));

            return sb.ToString();
        }
    }
}
