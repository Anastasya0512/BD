using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.Interfaces;
using ForumBusinessLogic.ViewModels;
using ForumDatabaseImplement.Models;
namespace ForumDatabaseImplement.Implements
{
    public class ForumStorage : IForumStorage
    {
         public List<ForumViewModel> GetFullList()
         {

             using (var context = new ForumContext())
             {
                 return context.Forum.Include(rec => rec.User).Include(rec => rec.Forumtype).Select(rec => new ForumViewModel
                 {
                     Forumid = rec.Forumid,
                     Themeforum = rec.Themeforum,
                     Startdate = rec.Startdate,
                     Userid = rec.Userid,
                     User = rec.User.Username,
                     Forumtypeid = rec.Forumtypeid,
                     Forumtype = rec.Forumtype.Nametype
                 })
                 .ToList();
             }
         }

         public List<ForumViewModel> GetFilteredList(ForumBindingModel model)
         {
             if (model == null)
             {
                 return null;
             }
             using (var context = new ForumContext())
             {
                 return context.Forum.Include(rec => rec.User).Include(rec => rec.Forumtype).Select(rec => new ForumViewModel
                 {
                     Forumid = rec.Forumid,
                     Themeforum = rec.Themeforum,
                     Startdate = rec.Startdate,
                     Userid = rec.Userid,
                     User = rec.User.Username,
                     Forumtypeid = rec.Forumtypeid,
                     Forumtype = rec.Forumtype.Nametype
                 })
                 .ToList();
             }
         }

         public ForumViewModel GetElement(ForumBindingModel model)
         {
             if (model == null)
             {
                 return null;
             }
             using (var context = new ForumContext())
             {

                 var forum = context.Forum.Include(rec => rec.User).Include(rec => rec.Forumtype).FirstOrDefault(rec => rec.Forumid == model.Forumid);
                 return forum != null ?
                 new ForumViewModel
                 {
                     Forumid = forum.Forumid,
                     Themeforum = forum.Themeforum,
                     Startdate = forum.Startdate,
                     Userid = forum.Userid,
                     User = forum.User.Username,
                     Forumtypeid = forum.Forumtypeid,
                     Forumtype = forum.Forumtype.Nametype
                 } :
                 null;
             }
         }

         public void Insert(ForumBindingModel model)
         {
             using (var context = new ForumContext())
             {
                 context.Forum.Add(CreateModel(model, new Forum()));
                 context.SaveChanges();
             }
         }

         public void Update(ForumBindingModel model)
         {
             using (var context = new ForumContext())
             {
                 var element = context.Forum.Include(rec => rec.User).Include(rec => rec.Forumtype).FirstOrDefault(rec => rec.Forumid == model.Forumid);
                 if (element == null)
                 {
                     throw new Exception("Форум не найден");
                 }
                 CreateModel(model, element);
                 context.SaveChanges();
             }
         }

         public void Delete(ForumBindingModel model)
         {
             using (var context = new ForumContext())
             {
                 Forum element = context.Forum.Include(rec => rec.User).Include(rec => rec.Forumtype).FirstOrDefault(rec => rec.Forumid == model.Forumid);
                 if (element != null)
                 {
                     context.Forum.Remove(element);
                     context.SaveChanges();
                 }
                 else
                 {
                     throw new Exception("Форум не найден");
                 }
             }
         }

         private Forum CreateModel(ForumBindingModel model, Forum forum)
         {
             forum.Themeforum = model.Themeforum;
             forum.Startdate = model.Startdate;
             forum.Userid = model.Userid;
             forum.Forumtypeid = model.Forumtypeid;
             return forum;
         }
     }
 }
      