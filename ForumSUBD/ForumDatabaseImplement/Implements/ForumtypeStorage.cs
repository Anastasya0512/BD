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
    public class ForumtypeStorage : IForumtypeStorage
    {
        public List<ForumtypeViewModel> GetFullList()
        {
            using (var context = new ForumContext())
            {
                return context.Forumtype.Select(rec => new ForumtypeViewModel
                {
                    Forumtypeid = rec.Forumtypeid,
                    Nametype = rec.Nametype
                })
                .ToList();
            }
        }

        public List<ForumtypeViewModel> GetFilteredList(ForumtypeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumContext())
            {
                return context.Forumtype.Select(rec => new ForumtypeViewModel
                {
                    Forumtypeid = rec.Forumtypeid,
                    Nametype = rec.Nametype
                })
                .ToList();
            }
        }

        public ForumtypeViewModel GetElement(ForumtypeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumContext())
            {
                var status = context.Forumtype.FirstOrDefault(rec => rec.Forumtypeid == model.Forumtypeid);
                return status != null ?
                new ForumtypeViewModel
                {
                    Forumtypeid = status.Forumtypeid,
                    Nametype = status.Nametype
                } :
                null;
            }
        }

        public void Insert(ForumtypeBindingModel model)
        {
            using (var context = new ForumContext())
            {
                context.Forumtype.Add(CreateModel(model, new Forumtype()));
                context.SaveChanges();
            }
        }

        public void Update(ForumtypeBindingModel model)
        {
            using (var context = new ForumContext())
            {
                var element = context.Forumtype.FirstOrDefault(rec => rec.Forumtypeid == model.Forumtypeid);
                if (element == null)
                {
                    throw new Exception("Тип не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ForumtypeBindingModel model)
        {
            using (var context = new ForumContext())
            {
                Forumtype element = context.Forumtype.FirstOrDefault(rec => rec.Forumtypeid == model.Forumtypeid);
                if (element != null)
                {
                    context.Forumtype.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Тип не найден");
                }
            }
        }

        private Forumtype CreateModel(ForumtypeBindingModel model, Forumtype status)
        {

            status.Nametype = model.Nametype;
            return status;
        }
    }
}
