﻿using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;

namespace InMindLab5.Application.Mappers;

public static class EntrollMapper
{
    public static EnrollDto ToDto(this Enroll enroll)
    {
        return new EnrollDto
        {
            Id = enroll.EnrollId,
            CourseId = enroll.CourseId,
            StudentId = enroll.StudentId,
            EnrollementDate = enroll.Date,
        };
    }

    public static List<EnrollDto> ToDtoList(this List<Enroll> enrolls)
    {
        return enrolls.Select( e => e.ToDto()).ToList();
    }
}