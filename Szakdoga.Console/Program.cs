using Microsoft.EntityFrameworkCore;
using Szakdoga.BusinessLayer.DAL;
using Szakdoga.BusinessLayer.Model;
using Szakdoga.BusinessLayer.Utils;



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using var db = new SubjectTreeContext();
var subject = new Subject() { ID = "tempID", Kredit = 2, SubjectLanguage = Constants.SubjectLanguage.Hungarian, SubjectName = "Temp", SubjectType = Constants.SubjectType.Required, };
var subject2 = new Subject() { ID = "tempID2", Kredit = 2, SubjectLanguage = Constants.SubjectLanguage.Hungarian, SubjectName = "Temp", SubjectType = Constants.SubjectType.Required, };
var subject22 = new Subject() { ID = "tempID22", Kredit = 2, SubjectLanguage = Constants.SubjectLanguage.Hungarian, SubjectName = "Temp", SubjectType = Constants.SubjectType.Required, };

var subject3 = new Subject() { ID = "tempID3", Kredit = 2, SubjectLanguage = Constants.SubjectLanguage.Hungarian, SubjectName = "Temp", SubjectType = Constants.SubjectType.Required, };





db.Database.EnsureCreated();

db.Subject.Add(subject);
db.Subject.Add(subject2);
db.Subject.Add(subject22);
db.PreRequisites.Add(new SubjectPreRequisites() { theSubject = subject22, PreRequisite = subject });
db.PreRequisites.Add(new SubjectPreRequisites() { theSubject = subject22, PreRequisite = subject2 });
db.PreRequisites.Add(new SubjectPreRequisites() { theSubject = subject3, PreRequisite = subject22 });

db.Subject.Add(subject3);


db.SaveChanges();

foreach (var item in db.Subject.First(Subject => Subject.ID == "tempID3").PreRequisite)
{
    Console.WriteLine(item.theSubject.ID);
}
foreach (var item in db.Subject.First(Subject => Subject.ID == "tempID22").PreRequisite)
{
    Console.WriteLine(item.PreRequisite.ID);

}