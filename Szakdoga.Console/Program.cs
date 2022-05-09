using Microsoft.EntityFrameworkCore;
using Szakdoga.BusinessLayer.DAL;
using Szakdoga.BusinessLayer.Model;
using Szakdoga.BusinessLayer.Utils;



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using var db = new SubjectTreeContext();
var subject = new Subject() { ID = "tempID", Kredit = 2, SubjectLanguage = Constants.SubjectLanguage.Hungarian, SubjectName = "Temp", SubjectType = Constants.SubjectType.Required, PreRequisite=null };
db.Subject.Add(subject);
db.SaveChanges();
