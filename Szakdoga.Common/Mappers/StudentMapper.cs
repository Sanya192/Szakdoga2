using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga.Common.Dto;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.Common.Mappers
{
    public class StudentMapper : IMapper<Student, StudentDto>
    {
        public StudentDto? MapToDto(Student? model)
        {
            if (model == null)
                return null;
            StudentDto output = new()
            {
                Id = model.Id,
                Name = model.Name,
                FinishedCourses = model.StudentFinisheds
                    .Select(x => new { key = x.SubjectId, grade = x.Grade })
                    .ToDictionary(x => x.key, x => x.grade),
                Syllabi = model.Syllabi.Select(x => x.Id).ToList(),
            };
            return output;
        }

        public Student? MapToModel(StudentDto? dto)
        {
            if (dto == null)
                return null;
            Student student = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                StudentFinisheds = dto.FinishedCourses.Select(x => new StudentFinished()
                {
                    Grade = x.Value,
                    StudentId = dto.Id,
                    SubjectId = x.Key
                }).ToList(),
                Syllabi = dto.Syllabi.Select(x => new Syllabus() { Id = x }).ToList(),
            };
            return student;
        }

   
    }
}
