

using System;
using System.Linq;
using IssueTakerApp.BindingModels;
using IssueTakerApp.Models;
using IssueTakerApp.Models.Enums;
using SimpleHttpServer.Models;

namespace IssueTakerApp.Service
{
    public class IssueService :Services
    {
        public IssueService() : base() { }

        public void AddNewIssue(NewIssueBM model,HttpSession session)
        {
            var user = Data.Data.Contex.Sessions.Find(session.Id).User;
            var issue = new Issue();
            issue.Name = model.Name;
            issue.Status = (Status) Enum.Parse(typeof(Status), model.Status);
            issue.Priority = (Priority) Enum.Parse(typeof(Priority), model.Priority);
            issue.CreationDate = DateTime.Now;
            issue.Author = user;

            Data.Data.Contex.Issues.Add(issue);

            Data.Data.Contex.SaveChanges();
        }

        public void EditIssue(EditIssueBM model)
        {
            var id = int.Parse(model.Id);
            var issue = Data.Data.Contex.Issues.Find(id);
            issue.Name = model.Name;
            issue.Status = (Status)Enum.Parse(typeof(Status), model.Status);
            issue.Priority = (Priority)Enum.Parse(typeof(Priority), model.Priority);

            Data.Data.Contex.SaveChanges();
        }

        public void DeleteIssue(int id)
        {
            var issue = Data.Data.Contex.Issues.Find(id);
            Data.Data.Contex.Issues.Remove(issue);
            Data.Data.Contex.SaveChanges();
        }
    }
}
