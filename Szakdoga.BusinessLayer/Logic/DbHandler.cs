using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga.BusinessLayer.DAL;
using Szakdoga.BusinessLayer.Model;
using Szakdoga.BusinessLayer.Utils;

namespace Szakdoga.BusinessLayer.Logic
{
    public class DbHandler
    {
        public bool UpdateEnabled { get; set; }
        private SubjectTreeContext db;

        public DbHandler()
        {
            this.db = new SubjectTreeContext();
            this.UpdateEnabled = Constants.DefaultUpdateEnabled;
        }

        public void UploadMainSyllabus(MainSyllabus mainSyllabus)
        {
            var subjects = new List<Subject>();
            var subjectsInSylabus = new List<SubjectInSyllabus>();
            var preRequisites = new List<SubjectPreRequisites>();

            db.Add(mainSyllabus);
            mainSyllabus.Specializations.ToList().ForEach(spec =>
            {
                db.Add(spec);
            });
            mainSyllabus.Subjects.ToList().ForEach(subject =>
            {
                AddSubjects(subject);
            });
            mainSyllabus.Specializations.ToList().ForEach(spec =>
            {
                spec.Subjects.ToList().ForEach(subject =>
                {
                    AddSubjects(subject);
                });
            });
            subjects.ForEach(subject =>
            {
                var subjectEntity = db.Subject.Find(subject.ID);
                if (subjectEntity == null)
                    db.Add(subject);
                else if (UpdateEnabled)
                    db.Update(subjectEntity);
            });
            subjectsInSylabus.ForEach(subject =>
            {
                var subjectEntity = db.Su.Find(subject.ID);
                if (subjectEntity == null)
                    db.Add(subject);
                else if (UpdateEnabled)
                    db.Update(subjectEntity);
            });
            preRequisites.ForEach(subject =>
            {
                var subjectEntity = db.Subject.Find(subject.ID);
                if (subjectEntity == null)
                    db.Add(subject);
                else if (UpdateEnabled)
                    db.Update(subjectEntity);
            });

            void AddSubjects(SubjectInSyllabus subject)
            {
                subjects.Add(subject.Subject);
                subjectsInSylabus.Add(subject);
                subject.Subject.PreRequisite.ToList().ForEach(preRequisite => preRequisites.Add(preRequisite));
            }




        }


    }
}
