

using System.IO;
using System.Text;
using IssueTakerApp.Utilities.Constants;
using IssueTakerApp.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace IssueTakerApp.Views.Issue
{
    public class Edit :IRenderable<EditIssueVM>
    {
        public string Render()
        {
            var issue = Data.Data.Contex.Issues.Find(Model.Id);
            var sb = new StringBuilder();

            sb.Append(File.ReadAllText(Paths.Menulogged));
            var editTemplate =File.ReadAllText(Paths.EditIssue);
            sb.Append(string.Format(editTemplate, issue.Name,issue.Id));
            sb.Append(File.ReadAllText(Paths.Footer));

            return sb.ToString();
        }

        public EditIssueVM Model { get; set; }
    }
}
