using Azure.Core;
using MissedWork.Models;
using MWTEmailSender;
using System;
using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        using(var context = new ApplicationDbContext())
        {
            DateTime deadlineDate = DateTime.Now;
            DateTime overdueDate = DateTime.Now.AddDays(-1).Date;
            var DayOfWeek = deadlineDate.DayOfWeek;
            List<Entries> entries = new List<Entries>();
            bool blnTriggerSubmit = true;
            if (deadlineDate.TimeOfDay.Hours == TimeSpan.FromHours(12).Hours) //12pm
                blnTriggerSubmit = false;
            if (DayOfWeek == DayOfWeek.Monday)
            {
                entries = context.Entries.Where(x => x.EntryDate >= overdueDate.AddDays(-2) && x.EntryDate <= DateTime.Now.AddDays(-1).Date && x.ForGM == "Y").ToList();
            }
            else
            {
                entries = context.Entries.Where(x => x.EntryDate == overdueDate && x.ForGM == "Y").ToList();
            }
            if (entries == null)
            {
                Environment.Exit(0);
            }

            foreach (var entry in entries)
            {
                if (blnTriggerSubmit)
                {
                    var entryResult = context.Entries.SingleOrDefault(x => x.Id == entry.Id);
                    entryResult.GMCommentary = "No Response";
                    entryResult.GMMitigationPlan = "No Response";
                    entryResult.ForGM = "N";
                    context.SaveChangesAsync();
                }
                else
                {
                    using (var tmodscontext = new TmodsDbContext())
                    {
                        var gm = tmodscontext.TMODS.Where(x => x.EmpId == entry.GM_Id).FirstOrDefault();
                        var companyDetails = context.Company.Where(x => x.CompanyName == entry.Company).FirstOrDefault();
                        using (SmtpClient smtp = new SmtpClient("mail.telus.com", 25))
                        {
                            MailMessage mail = new MailMessage();
                            mail.From = new MailAddress("donotreply@telus.com");
                            mail.To.Add(gm.Email); //LIVE
                            //mail.To.Add("angelo.macapinlac@telus.com");
                            if (companyDetails.Email != null)
                                mail.CC.Add(companyDetails.Email);
                            //mail.CC.Add("angelo.macapinlac@telus.com");
                            mail.CC.Add("SEGUN.ADEOYE@TELUS.COM");
                            mail.CC.Add("TOM.STEFAN@TELUS.COM");
                            mail.Subject = "REMINDER: Action Required Missed Work | " + entry.District + "(" + entry.Call_Id + ")";
                            mail.IsBodyHtml = true;
                            mail.Body = "TO: " + entry.GM + "(" + gm.Email + ")" + "<br /><br />Hello, <br /><br />This is to remind you that there has been a missed job in your area that you have not yet submitted and will be noted as 'No Response' soon.";
                            smtp.Send(mail);
                        }
                    }
                }
            }
        }
    }
}