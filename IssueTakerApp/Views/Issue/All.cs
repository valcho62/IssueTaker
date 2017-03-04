

using System.IO;
using System.Linq;
using System.Text;
using IssueTakerApp.Utilities.Constants;
using SimpleMVC.Interfaces;

namespace IssueTakerApp.Views.Issue
{
    public class All :IRenderable
    {
        public string Render()
        {
            var allIssues = Data.Data.Contex.Issues.ToList();
            var issueCode = new StringBuilder();
            var issueTemplate = File.ReadAllText(Paths.IssueBody);
            foreach (var issue in allIssues)
            {
                
                issueCode.Append(string.Format(issueTemplate, issue.Id, issue.Name
                    , issue.Status, issue.Priority, issue.CreationDate.Date
                    , issue.Author.Username));
            }

            var sb = new StringBuilder();

            sb.Append(File.ReadAllText(Paths.Menulogged));
            var allIssueCode =File.ReadAllText(Paths.Issues);
            sb.Append(string.Format(allIssueCode, issueCode));
            sb.Append(File.ReadAllText(Paths.Footer));

            return sb.ToString();
        }
    }
}
