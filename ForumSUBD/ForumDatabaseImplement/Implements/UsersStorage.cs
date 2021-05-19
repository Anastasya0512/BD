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
    public class UsersStorage : IUsersStorage
    {
        public List<UsersViewModel> GetFullList()
         {
             using (var context = new ForumContext())
             {
                 return context.Users.Include(x => x.Forum).Select(CreateModel)
                 .ToList();
             }
         }
         public List<UsersViewModel> GetFilteredList(UsersBindingModel model)
         {
             if (model == null)
             {
                 return null;
             }
             using (var context = new ForumContext())
             {
                 return context.Users.Include(x => x.Forum)
                 .Where(rec => rec.Email == model.Email)
                 .Select(CreateModel)
                 .ToList();
             }
         }
         public UsersViewModel GetElement(UsersBindingModel model)
         {
             if (model == null)
             {
                 return null;
             }
             using (var context = new ForumContext())
             {
                 var user = context.Users.Include(x => x.Forum)
                 .FirstOrDefault(rec => rec.Userid == model.Userid || rec.Email == model.Email);
                 return user != null ? CreateModel(user) :
                 null;
             }
         }
         public void Insert(UsersBindingModel model)
         {
             using (var context = new ForumContext())
             {
                 context.Users.Add(CreateModel(model, new Users()));
                 context.SaveChanges();
             }
         }

         public void Update(UsersBindingModel model)
         {
             using (var context = new ForumContext())
             {
                 var element = context.Users.FirstOrDefault(rec => rec.Userid == model.Userid);
                 if (element == null)
                 {
                     throw new Exception("Пользователь не найден");
                 }
                 CreateModel(model, element);
                 context.SaveChanges();
             }
         }

         public void Delete(UsersBindingModel model)
         {
             using (var context = new ForumContext())
             {
                 Users element = context.Users.FirstOrDefault(rec => rec.Userid == model.Userid);
                 if (element != null)
                 {
                     context.Users.Remove(element);
                     context.SaveChanges();
                 }
                 else
                 {
                     throw new Exception("Пользователь не найден");
                 }
             }
         }

         private Users CreateModel(UsersBindingModel model, Users user)
         {
             user.Username = model.Username;
             user.Email = model.Email;
             user.Password = model.Password;
             return user;
         }

         private UsersViewModel CreateModel(Users user)
         {
             UsersViewModel model = new UsersViewModel
             {
                 Userid = user.Userid,
                 Username = user.Username,
                 Forum = user.Forum.ToDictionary(x => x.Forumid, x => x.Themeforum),
                 Email = user.Email,
                 Password = user.Password,
             };
             return model;
         }
     }
    }

