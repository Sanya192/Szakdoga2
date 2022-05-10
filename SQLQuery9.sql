create table Student
(
    ID   int not null
        constraint Student_pk
            primary key,
    Name varchar(300)
)
go

create unique index Student_ID_uindex
    on Student (ID)
go

INSERT INTO SzakdogaExcelFirst.dbo.Student ( Name) VALUES (N'Sanyi');
