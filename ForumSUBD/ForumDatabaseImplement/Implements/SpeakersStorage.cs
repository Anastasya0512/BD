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
    public class SpeakersStorage : ISpeakersStorage
    {
        public List<SpeakersViewModel> GetFullList()
        {
            using (var context = new ForumContext())
            {
                return context.Speakers.Select(rec => new SpeakersViewModel
                {
                    Speakerid = rec.Speakerid,
                    Namespeaker = rec.Namespeaker,
                    Nickname = rec.Nickname,
                    Email = rec.Email
                })
                .ToList();
            }
        }

        public List<SpeakersViewModel> GetFilteredList(SpeakersBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumContext())
            {
                return context.Speakers.Select(rec => new SpeakersViewModel
                {
                    Speakerid = rec.Speakerid,
                    Namespeaker = rec.Namespeaker,
                    Nickname = rec.Nickname,
                    Email = rec.Email
                })
                .ToList();
            }
        }

        public SpeakersViewModel GetElement(SpeakersBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumContext())
            {
                var authors = context.Speakers.FirstOrDefault(rec => rec.Speakerid == model.Speakerid);
                return authors != null ?
                new SpeakersViewModel
                {
                    Speakerid = authors.Speakerid,
                    Namespeaker = authors.Namespeaker,
                    Nickname = authors.Nickname,
                    Email = authors.Email
                } :
                null;
            }
        }

        public void Insert(SpeakersBindingModel model)
        {
            using (var context = new ForumContext())
            {
                context.Speakers.Add(CreateModel(model, new Speakers()));
                context.SaveChanges();
            }
        }

        public void Update(SpeakersBindingModel model)
        {
            using (var context = new ForumContext())
            {
                var element = context.Speakers.FirstOrDefault(rec => rec.Speakerid == model.Speakerid);
                if (element == null)
                {
                    throw new Exception("Докладчик не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(SpeakersBindingModel model)
        {
            using (var context = new ForumContext())
            {
                Speakers element = context.Speakers.FirstOrDefault(rec => rec.Speakerid == model.Speakerid);
                if (element != null)
                {
                    context.Speakers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Докладчик не найден");
                }
            }
        }

        private Speakers CreateModel(SpeakersBindingModel model, Speakers authors)
        {
            authors.Namespeaker = model.Namespeaker;
            authors.Nickname = model.Nickname;
            authors.Email = model.Email;
            return authors;
        }
    }
}
