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
    public class ReportsStorage : IReportsStorage
    {
        public List<ReportsViewModel> GetFullList()
        {
            using (var context = new ForumContext())
            {
                return context.Reports.Include(rec => rec.Speaker).Select(rec => new ReportsViewModel
                {
                    Reportid = rec.Reportid,
                    Themereport = rec.Themereport,
                    Speakerid = rec.Speakerid
                })
                .ToList();
            }
        }

        public List<ReportsViewModel> GetFilteredList(ReportsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumContext())
            {
                return context.Reports.Include(rec => rec.Speaker).Select(rec => new ReportsViewModel
                {
                    Reportid = rec.Reportid,
                    Themereport = rec.Themereport,
                    Speakerid = rec.Speakerid
                })
                .ToList();
            }
        }

        public ReportsViewModel GetElement(ReportsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumContext())
            {
                var reports = context.Reports.Include(rec => rec.Speaker).FirstOrDefault(rec => rec.Reportid == model.Reportid);
                return reports != null ?
                new ReportsViewModel
                {
                    Reportid = reports.Reportid,
                    Themereport = reports.Themereport,
                    Speakerid = reports.Speakerid
                } :
                null;
            }
        }

        public void Insert(ReportsBindingModel model)
        {
            using (var context = new ForumContext())
            {
                context.Reports.Add(CreateModel(model, new Reports()));
                context.SaveChanges();
            }
        }

        public void Update(ReportsBindingModel model)
        {
            using (var context = new ForumContext())
            {
                var element = context.Reports.Include(rec => rec.Speaker).FirstOrDefault(rec => rec.Reportid == model.Reportid);
                if (element == null)
                {
                    throw new Exception("Книга не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ReportsBindingModel model)
        {
            using (var context = new ForumContext())
            {
                Reports element = context.Reports.Include(rec => rec.Speaker).FirstOrDefault(rec => rec.Reportid == model.Reportid);
                if (element != null)
                {
                    context.Reports.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Книга не найдена");
                }
            }
        }

        private Reports CreateModel(ReportsBindingModel model, Reports reports)
        {
            reports.Themereport = model.Themereport;
            reports.Speakerid = model.Speakerid;
            return reports;
        }
    }
}
    
